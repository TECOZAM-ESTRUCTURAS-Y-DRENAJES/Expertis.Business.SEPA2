
#Region " Constantes Generales "

Public Module Longitud
    Public IBAN As Integer = 34
    Public SWIFT As Integer = 11
    Public IBAN_ESPANIA As Integer = 24
End Module

Public Module CodigoCuadernoSEPA
    Public CSB34_14 As String = "34145"
    Public CSB19_14_BASICO As String = "19143"
    Public CSB19_14_REDUCIDO As String = "19154"
    Public CSB19_44 As String = "19445"
End Module

Public Module FormatosFechas
    Public AAAAMMDD As String = "yyyyMMdd"
    Public HHmmssfffff As String = "HHmmssfffff"
End Module

Public Enum enumTipoCampo
    Alfanumerico = 0
    Numerico = 1
    Fecha = 2
End Enum

Public Enum enumFormatoFicheroSEPA
    Plano = 0
    XML = 1
End Enum

Public Enum enumTipoFicheroXMLSEPA
    CORE = 0
    COR1 = 1
    B2B = 2
    TransferenciasSEPA = 3
    TransferenciasOtras = 4
    TransferenciasCheque = 5
End Enum

#End Region

Public Class RegistroTotales
    Public TotalImportes As Double
    Public NumRegistros As Integer
    Public TotalRegistros As Integer

    Public Sub New()
        TotalImportes = 0
        NumRegistros = 0
        TotalRegistros = 0
    End Sub
End Class


#Region " Definición de Tipos de Datos para los Registros de Totales Ficheros 19.14 y 19.44 "

Public Class RegTotalesGeneral
    Inherits RegistroTotales

End Class

Public Class RegTotalesAcreedores
    Inherits RegistroTotales

End Class

Public Class RegTotalesIndividuales
    Inherits RegistroTotales

End Class

#End Region


<Serializable()> _
  Public Class DataGenerarFichero
    Public IDProcess As Guid
    Public IDBancoPropio As String
    Public FechaEmision As Date
    Public FechaCargo As Date       '//19.14 y 19.44
    Public FormatoFichero As enumFormatoFicheroSEPA
    Public IDRemesa As Integer
    Public SufijoRemesa As String

    'Public TipoFichero As enumTipoFicheroTrans
    'Public Fichero As String

    Public LiquidacionGastosObras As Boolean

    'IBIS. SERGIO - 20/02/19
    Public strTipoFichero As String
    'David Velasco 16/06/2022
    Public dt As DataTable
End Class

Public Class ProcessInfoFichero
    Public IDProcess As Guid
    Public FechaEmision As Date
    Public OrigenDatos As DataTable
    Public LiquidacionGastosObras As Boolean

    Public TipoFichero As enumTipoFicheroXMLSEPA
    Public FechaCargo As Date

    Public OrigenDatosTrans As DatosTransferencias

    'IBIS. SERGIO - 20/02/19
    Public strTipoFichero As String
End Class

Public Class DatosTransferencias
    Public TransSEPA As DataTable
    Public TransOtras As DataTable
    Public TransCheque As DataTable
End Class


#Region " Tipos de datos de trabajo "

Public Class DataAddRegistroFichero
    Public Fichero As New List(Of String)
    Public Registro As String
    Public services As New ServiceProvider
    Public Fecha As Date

    'Public Sub New(ByVal Fichero As List(Of String))
    '    Me.Fichero = Fichero
    'End Sub

    Public Sub AddRegistro(ByVal Registro As String)
        'Dim datSimEsp As New FicherosTransferencias.DataSimbolosEspeciales(Registro)
        'Registro = ProcessServer.ExecuteTask(Of FicherosTransferencias.DataSimbolosEspeciales, String)(AddressOf FicherosTransferencias.TratarSimbolosEspeciales, datSimEsp, services)
        Me.Fichero.Add(Registro)
    End Sub
End Class

Public Class ListaCamposRegistro
    Public Lista As New List(Of DataCampoRegistro)

    Public RowDatosOrdenante As DataRow
    Public Row As DataRow

    Public Sub Add(ByVal data As DataCampoRegistro)
        Dim LongitudElemAnt As Integer
        Dim PosElemAnt As Integer

        If Me.Lista.Count > 0 Then
            Dim datElemAnt As DataCampoRegistro = Me.Lista.Last
            If Not datElemAnt Is Nothing Then
                LongitudElemAnt = datElemAnt.Longitud
                PosElemAnt = datElemAnt.Posicion
            End If
        End If


        data.Posicion = PosElemAnt + LongitudElemAnt

        Me.Lista.Add(data)
    End Sub
End Class

Public Class DataCampoRegistro
    'Public NumeroCampo As Integer
    Public DescCampo As String      '//Solamente es descriptivo para el programador
    Public NombreCampo As String
    Public Obligatorio As Boolean
    Public Tipo As enumTipoCampo
    Public Longitud As Integer
    Public Posicion As Integer
    Public DefaultValue As Object
    Public FormatoFecha As String
    Public RegistroOrdenante As Boolean

    Public Sub New(ByVal DescCampo As String, ByVal NombreCampo As String, ByVal Obligatorio As Boolean, ByVal Tipo As enumTipoCampo, ByVal Longitud As Integer, Optional ByVal DefaultValue As Object = Nothing, Optional ByVal FormatoFecha As String = "", Optional ByVal RegistroOrdenante As Boolean = False)
        'Me.NumeroCampo = NumeroCampo
        Me.DescCampo = DescCampo
        Me.NombreCampo = NombreCampo
        Me.Obligatorio = Obligatorio
        Me.Tipo = Tipo
        Me.Longitud = Longitud
        If Not DefaultValue Is Nothing Then Me.DefaultValue = DefaultValue
        If Length(FormatoFecha) > 0 Then Me.FormatoFecha = FormatoFecha
        Me.RegistroOrdenante = RegistroOrdenante
    End Sub
End Class

#End Region

<Serializable()> _
  Public Class DataSimbolosEspeciales
    Public Texto As String
    Public ExcluirN As Boolean '//Excluir Ñ
    Public FormatoXML As Boolean
    Public Formato003 As Boolean

    Public Sub New(ByVal Texto As String, Optional ByVal ExcluirN As Boolean = True, Optional ByVal FormatoXML As Boolean = False, Optional ByVal Formato003 As Boolean = False)
        Me.Texto = Texto
        Me.ExcluirN = ExcluirN
        Me.FormatoXML = FormatoXML
        Me.Formato003 = Formato003
    End Sub
End Class

<Serializable()> _
 Public Class DatosBancoPropioFicheros
    Public IDBancoPropio As String

    Public CodigoIBAN As String
    Public SWIFT As String
    Public SufijoRemesas As String
    ' ''Public Direccion As String
    ' ''Public CodClie As String
    ' ''Public PrefijoIBAN As String
    ' ''Public Sufijo As String
    Public Entidad As String
    Public Sucursal As String
    ' ''Public DC As String
    ' ''Public NCuenta As String

    Public Sub New(ByVal IDBancoPropio As String, ByVal CodigoIBAN As String, ByVal SWIFT As String)
        Me.IDBancoPropio = IDBancoPropio

        If CodigoIBAN Is Nothing Then CodigoIBAN = String.Empty
        If SWIFT Is Nothing Then SWIFT = String.Empty

        If CodigoIBAN.Length > Longitud.IBAN Then
            Me.CodigoIBAN = Left(CodigoIBAN, Longitud.IBAN)
        Else
            Me.CodigoIBAN = CodigoIBAN & Space(Longitud.IBAN - CodigoIBAN.Length)
        End If

        If SWIFT.Length > Longitud.SWIFT Then
            Me.SWIFT = Left(SWIFT, Longitud.SWIFT)
        Else
            Me.SWIFT = SWIFT & Space(Longitud.SWIFT - SWIFT.Length)
        End If
    End Sub

    Public Sub New()
        Me.CodigoIBAN = Space(Longitud.IBAN)
        Me.SWIFT = Space(Longitud.SWIFT)
    End Sub
End Class


<Serializable()> _
Public Class DatosOrdenante
    Public NIF As String
    Public Nombre As String
    Public Direccion As String
    Public Pais As String
    Public ISOPais As String
    Public CodigoPostal As String
    Public Poblacion As String
    Public Provincia As String


    Public IDAcreedor As String
    Public Sub New()

    End Sub

End Class


Public Class FicherosGeneral

    Public Shared CodigoISO_Espania As String = "ES"

    <Task()> Public Shared Function TratarSimbolosEspeciales(ByVal data As DataSimbolosEspeciales, ByVal services As ServiceProvider) As String

        data.Texto = Strings.Replace(data.Texto, "ç", "c", , , CompareMethod.Binary)
        data.Texto = Strings.Replace(data.Texto, "Ç", "C", , , CompareMethod.Binary)
        data.Texto = Strings.Replace(data.Texto, vbCrLf, " ", , , CompareMethod.Binary)
        '1º Grupo de Simbolos Especiales
        For i As Integer = 33 To 38
            If data.FormatoXML AndAlso data.Formato003 AndAlso (i = 36 OrElse i = 37 OrElse i = 38) Then
                'data.Texto = Strings.Replace(data.Texto, Chr(i), "&#" & i & ";", , , CompareMethod.Binary)
                If i = 38 Then
                    data.Texto = Strings.Replace(data.Texto, Chr(i), Space(1), , , CompareMethod.Binary)
                End If
            Else
                data.Texto = Strings.Replace(data.Texto, Chr(i), "", , , CompareMethod.Binary)
            End If
        Next

        If data.FormatoXML Then
            '// El caracter apóstrofe, no está permitido en el formato XML
            data.Texto = Strings.Replace(data.Texto, Chr(39), "", , , CompareMethod.Binary)
        End If

        For i As Integer = 42 To 42
            If data.FormatoXML AndAlso data.Formato003 Then
                'data.Texto = Strings.Replace(data.Texto, Chr(i), "&#" & i & ";", , , CompareMethod.Binary)
            Else
                data.Texto = Strings.Replace(data.Texto, Chr(i), "", , , CompareMethod.Binary)
            End If
        Next

        '2º Grupo de Simbolos Especiales
        For i As Integer = 59 To 64
            If i <> 63 Then 'I=63 --> ?
                data.Texto = Strings.Replace(data.Texto, Chr(i), "", , , CompareMethod.Binary)
            End If
        Next
        '3º Grupo de Simbolos Especiales
        For i As Integer = 91 To 96
            data.Texto = Strings.Replace(data.Texto, Chr(i), "", , , CompareMethod.Binary)
        Next
        '4º Grupo de Simbolos Especiales
        For i As Integer = 123 To 126
            data.Texto = Strings.Replace(data.Texto, Chr(i), "", , , CompareMethod.Binary)
        Next

        'Simbolo de la Ñ (164-165)
        ' If data.ExcluirN Then
        data.Texto = Strings.Replace(data.Texto, "ñ", "n", , , CompareMethod.Binary)
        data.Texto = Strings.Replace(data.Texto, "Ñ", "N", , , CompareMethod.Binary)
        ' End If

        'Caracteres con Acentos en mayusculas
        data.Texto = Strings.Replace(data.Texto, "Á", "A", , , CompareMethod.Binary) : data.Texto = Strings.Replace(data.Texto, "á", "a", , , CompareMethod.Binary)
        data.Texto = Strings.Replace(data.Texto, "É", "E", , , CompareMethod.Binary) : data.Texto = Strings.Replace(data.Texto, "é", "e", , , CompareMethod.Binary)
        data.Texto = Strings.Replace(data.Texto, "Í", "I", , , CompareMethod.Binary) : data.Texto = Strings.Replace(data.Texto, "í", "i", , , CompareMethod.Binary)
        data.Texto = Strings.Replace(data.Texto, "Ó", "O", , , CompareMethod.Binary) : data.Texto = Strings.Replace(data.Texto, "ó", "o", , , CompareMethod.Binary)
        data.Texto = Strings.Replace(data.Texto, "Ú", "U", , , CompareMethod.Binary) : data.Texto = Strings.Replace(data.Texto, "ú", "u", , , CompareMethod.Binary)

        'Últimos símbolos sueltos de la tabla Ascii
        For i As Integer = 127 To 255
            If data.FormatoXML AndAlso data.Formato003 AndAlso (i = 196 OrElse i = 214 OrElse i = 220 OrElse i = 223) Then
                '//Caracteres alemanes
                'data.Texto = Strings.Replace(data.Texto, Chr(i), "&#" & i & ";", , , CompareMethod.Binary)
            Else
                data.Texto = Strings.Replace(data.Texto, Chr(i), "", , , CompareMethod.Binary)
            End If
        Next

        Return data.Texto
    End Function

    <Task()> Public Shared Function GenerarRegistro(ByVal lstRegistro As ListaCamposRegistro, ByVal services As ServiceProvider) As String
        Dim str As String = String.Empty

        If Not lstRegistro Is Nothing Then
            For Each elem As DataCampoRegistro In lstRegistro.Lista
                Dim Valor As Object = String.Empty
                If Length(elem.DefaultValue) > 0 Then
                    If elem.Tipo = enumTipoCampo.Fecha Then
                        Valor = CStr(elem.DefaultValue & String.Empty)
                    Else
                        If TypeOf elem.DefaultValue Is Double OrElse TypeOf elem.DefaultValue Is Decimal Then
                            Valor = Left(CStr(Nz(elem.DefaultValue, 0) * 100), elem.Longitud)
                            Valor = CDec(Valor)
                        Else
                            Valor = Left(CStr(elem.DefaultValue & String.Empty), elem.Longitud)
                        End If
                    End If
                ElseIf Length(elem.NombreCampo) > 0 Then
                    Dim VariosCampos() As String = Split(elem.NombreCampo, "+")
                    If Not lstRegistro.Row Is Nothing Then
                        For Each NombreCampo As String In VariosCampos
                            If lstRegistro.Row.Table.Columns.Contains(NombreCampo) Then
                                If elem.Tipo = enumTipoCampo.Fecha Then
                                    Valor &= CStr(lstRegistro.Row(NombreCampo) & String.Empty)
                                Else
                                    If TypeOf lstRegistro.Row(NombreCampo) Is Double OrElse TypeOf lstRegistro.Row(NombreCampo) Is Decimal Then
                                        Valor &= Left(CStr(Nz(lstRegistro.Row(NombreCampo), 0) * 100), elem.Longitud)
                                        Valor = CDec(Valor)
                                    Else
                                        Valor &= Left(CStr(lstRegistro.Row(NombreCampo) & String.Empty), elem.Longitud)
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If


                Select Case elem.Tipo
                    Case enumTipoCampo.Alfanumerico
                        Dim datSimEsp As New DataSimbolosEspeciales(Valor)
                        Valor = ProcessServer.ExecuteTask(Of DataSimbolosEspeciales, String)(AddressOf TratarSimbolosEspeciales, datSimEsp, services)
                        Dim Longitud As Integer
                        If elem.Longitud - Length(Valor) < 0 Then
                            Longitud = 0
                        Else
                            Longitud = elem.Longitud - Length(Valor)
                        End If
                        str &= Left(Valor, elem.Longitud) & Space(Longitud)
                    Case enumTipoCampo.Numerico
                        If TypeOf Valor Is Decimal Then Valor = CStr(CInt(Valor))
                        str &= New String("0", elem.Longitud - Length(Valor)) & Valor ' Replace(Space(elem.Longitud - Length(Valor)), Space(1), "0") & Valor
                    Case enumTipoCampo.Fecha
                        str &= Strings.Format(CDate(Nz(Valor, Today)), elem.FormatoFecha)
                End Select
            Next
        End If
        Return str
    End Function

    <Task()> Public Shared Function GetDatosBancoPropio(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider) As DatosBancoPropioFicheros
        'Dim data As DataGenerarFichero = services.GetService(Of DataGenerarFichero)()
        If Length(data.IDBancoPropio) > 0 Then

            'Dim BancosPropios As EntityInfoCache(Of BancoPropioInfo) = services.GetService(Of EntityInfoCache(Of BancoPropioInfo))()
            'Dim BPInfo As BancoPropioInfo = BancosPropios.GetEntity(IDBancoPropio)
            Dim dtBancoPropio As DataTable = New BancoPropio().SelOnPrimaryKey(data.IDBancoPropio)
            If dtBancoPropio.Rows.Count > 0 Then
                Dim datBanco As New DatosBancoPropioFicheros(data.IDBancoPropio, dtBancoPropio.Rows(0)("CodigoIBAN") & String.Empty, Nz(dtBancoPropio.Rows(0)("SWIFT") & String.Empty, "NOTPROVIDED"))
                If Length(data.SufijoRemesa) > 0 Then
                    datBanco.SufijoRemesas = New String("0", 3 - Length(data.SufijoRemesa)) & data.SufijoRemesa & String.Empty
                Else
                    datBanco.SufijoRemesas = New String("0", 3 - Length(dtBancoPropio.Rows(0)("SufijoRemesas"))) & dtBancoPropio.Rows(0)("SufijoRemesas") & String.Empty
                End If
                datBanco.Entidad = dtBancoPropio.Rows(0)("IDBanco") & String.Empty
                datBanco.Sucursal = dtBancoPropio.Rows(0)("Sucursal") & String.Empty
                Return datBanco
            Else
                ApplicationService.GenerateError("El Banco Propio {0} no existe en el sistema.", Quoted(data.IDBancoPropio))
            End If
        End If
    End Function

    <Task()> Public Shared Function GetDatosOrdenante(ByVal data As String, ByVal services As ServiceProvider) As DatosOrdenante

        Dim datOrdte As New DatosOrdenante
        Dim dtDatosEmpresa As DataTable = AdminData.Filter("vSEPA_DatosEmpresaPais")
        If dtDatosEmpresa.Rows.Count > 0 Then
            datOrdte.NIF = dtDatosEmpresa.Rows(0)("Cif") & String.Empty
            datOrdte.NIF = datOrdte.NIF.Replace("-", String.Empty)
            datOrdte.Nombre = dtDatosEmpresa.Rows(0)("DescEmpresa") & String.Empty
            datOrdte.Direccion = dtDatosEmpresa.Rows(0)("Direccion") & String.Empty
            datOrdte.CodigoPostal = dtDatosEmpresa.Rows(0)("CodPostal") & String.Empty
            datOrdte.Poblacion = dtDatosEmpresa.Rows(0)("Poblacion") & String.Empty
            datOrdte.Provincia = dtDatosEmpresa.Rows(0)("Provincia") & String.Empty
            datOrdte.Pais = dtDatosEmpresa.Rows(0)("DescPais") & String.Empty
            datOrdte.ISOPais = UCase(dtDatosEmpresa.Rows(0)("CodigoISO") & String.Empty)

            SepaServices.RegisterUse(datOrdte.NIF, datOrdte.Nombre)
        End If

        Return datOrdte
    End Function


#Region "  Algoritmo de Generación del Identificador Acreedor "

    <Task()> Public Shared Function GetIdentificacionAcreedor(ByVal data As Object, ByVal services As ServiceProvider) As String
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim datBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()

        '//'ES' + D.C + Sufijo + CIF
        Dim ID As String = String.Empty
        ID = datOrdenante.ISOPais
        ID &= ProcessServer.ExecuteTask(Of Object, String)(AddressOf GetDigitoControlIdentificacionAcreedor, Nothing, services)
        ID &= datBanco.SufijoRemesas & datOrdenante.NIF

        datOrdenante.IDAcreedor = ID
        Return ID
    End Function

    <Task()> Public Shared Function GetDigitoControlIdentificacionAcreedor(ByVal data As Object, ByVal services As ServiceProvider) As String
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()

        '//ISO 7604. Modelo 97-10
        Dim datBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()
        Dim strCodigo As String = datOrdenante.NIF + UCase(datOrdenante.ISOPais) + "00"
        strCodigo = ProcessServer.ExecuteTask(Of String, String)(AddressOf GetCaracteresEnNumero, strCodigo, services)
        Dim Resto As Integer = CDec(strCodigo) Mod 97
        Resto = 98 - Resto
        Dim DC As String = Format(Resto, "0#")
        Return DC
    End Function

    <Task()> Public Shared Function GetCaracteresEnNumero(ByVal data As String, ByVal services As ServiceProvider) As String
        Dim Num As String = String.Empty
        For Each c As Char In data
            Select Case UCase(c)
                Case "A"
                    Num &= "10"
                Case "B"
                    Num &= "11"
                Case "C"
                    Num &= "12"
                Case "D"
                    Num &= "13"
                Case "E"
                    Num &= "14"
                Case "F"
                    Num &= "15"
                Case "G"
                    Num &= "16"
                Case "H"
                    Num &= "17"
                Case "I"
                    Num &= "18"
                Case "J"
                    Num &= "19"
                Case "K"
                    Num &= "20"
                Case "L"
                    Num &= "21"
                Case "M"
                    Num &= "22"
                Case "N"
                    Num &= "23"
                Case "O"
                    Num &= "24"
                Case "P"
                    Num &= "25"
                Case "Q"
                    Num &= "26"
                Case "R"
                    Num &= "27"
                Case "S"
                    Num &= "28"
                Case "T"
                    Num &= "29"
                Case "U"
                    Num &= "30"
                Case "V"
                    Num &= "31"
                Case "W"
                    Num &= "32"
                Case "X"
                    Num &= "33"
                Case "Y"
                    Num &= "34"
                Case "Z"
                    Num &= "35"
                Case Else
                    Num &= c
            End Select
        Next
        Return Num
    End Function

#End Region


    <Task()> Public Shared Function GetFacturasCobroAgrupado(ByVal IDCobro As Integer, ByVal services As ServiceProvider) As List(Of Object)
        Dim lstFras As New List(Of Object)
        Dim dtCobro As DataTable = New BE.DataEngine().Filter("tbCobro", New NumberFilterItem("IDCobroAgrupado", IDCobro), "NFactura")
        If dtCobro.Rows.Count <> 0 Then
            lstFras = (From c In dtCobro Where Not c.IsNull("NFactura") Select c("NFactura") Distinct).ToList
        End If

        Return lstFras
    End Function

    <Task()> Public Shared Function GetFacturasPagoAgrupado(ByVal IDPago As Integer, ByVal services As ServiceProvider) As List(Of Object)
        Dim lstFras As New List(Of Object)
        Dim dtPago As DataTable = New BE.DataEngine().Filter("vSEPA_SuFacturaGenerarFicheros", New NumberFilterItem("IDPagoAgrupado", IDPago), "SuFactura")
        If dtPago.Rows.Count <> 0 Then
            lstFras = (From c In dtPago Where Not c.IsNull("SuFactura") Select c("SuFactura") Distinct).ToList
        End If

        Return lstFras
    End Function


#Region " Validación y Generación del Código IBAN (SEPA) "

    <Task()> Public Shared Sub ValidarCodigoIBAN(ByVal data As DataRow, ByVal services As ServiceProvider)
        If data.Table.Columns.Contains("CodigoIBAN") Then
            If data.RowState = DataRowState.Added OrElse (data.RowState = DataRowState.Modified AndAlso Length(data("CodigoIBAN")) > 0 AndAlso data("CodigoIBAN") & String.Empty <> data("CodigoIBAN", DataRowVersion.Original) & String.Empty) Then
                ProcessServer.ExecuteTask(Of String, Boolean)(AddressOf ValidarIBAN, data("CodigoIBAN") & String.Empty, services)
            End If
        End If
    End Sub

    <Task()> Public Shared Function ValidarIBAN(ByVal CodigoIBAN As String, ByVal services As ServiceProvider) As Boolean
        ValidarIBAN = False
        If Length(CodigoIBAN) > 0 Then
            CodigoIBAN = UCase(CodigoIBAN)
            If Length(CodigoIBAN) >= 5 AndAlso Length(CodigoIBAN) <= 34 Then

                Dim ISOPais As String = Strings.Left(CodigoIBAN, 2)
                If IsNumeric(ISOPais) Then
                    ApplicationService.GenerateError("Los 2 primeros caracteres, deben corresponder al Código ISO del País. Revise sus datos.")
                End If

                If ISOPais = CodigoISO_Espania AndAlso Length(CodigoIBAN) < Longitud.IBAN_ESPANIA Then
                    ApplicationService.GenerateError("La longitud del Código IBAN introducido no es correcta. Revise sus datos.")
                End If

                Dim DC As String = Strings.Mid(CodigoIBAN, 3, 2)
                If Not IsNumeric(DC) Then
                    ApplicationService.GenerateError("El dígito de control debe ser un valor numérico. Revise sus datos.")
                End If

                Dim NumeroCuenta As String = Strings.Mid(CodigoIBAN, 5, Length(CodigoIBAN))
                'Dim CodVerificar As String = NumeroCuenta + ProcessServer.ExecuteTask(Of String, String)(AddressOf GetCaracteresEnNumero, ISOPais, services) + DC
                'Dim Resto As Integer = CDec(CodVerificar) Mod 97

                Dim CodVerificar As String
                Dim Resto As Integer
                If ISOPais = CodigoISO_Espania Then
                    CodVerificar = NumeroCuenta + ProcessServer.ExecuteTask(Of String, String)(AddressOf GetCaracteresEnNumero, ISOPais, services) + DC
                    Resto = CDec(CodVerificar) Mod 97
                Else
                    'CodVerificar = GetCaracteresEnNumero(NumeroCuenta) + GetCaracteresEnNumero(ISOPais) + DC
                    'Resto = CalcularModulo(CodVerificar, 97)
                    Resto = 1
                End If

                If Resto = 1 Then
                    ValidarIBAN = True
                Else
                    ApplicationService.GenerateError("El Código IBAN introducido no es correcto. Revise sus datos.")
                End If
            Else
                ApplicationService.GenerateError("La longitud del Código IBAN introducido no es correcta. Revise sus datos.")
            End If
        End If
    End Function

    <Serializable()> _
    Public Class DataGenerarIBAN
        Public IDBanco As String
        Public Sucursal As String
        Public DigitoControl As String
        Public NCuenta As String
        Public CodigoISO As String

        Public Sub New(ByVal IDBanco As String, ByVal Sucursal As String, ByVal DigitoControl As String, ByVal NCuenta As String, ByVal CodigoISO As String)
            Me.IDBanco = IDBanco & String.Empty
            Me.Sucursal = Sucursal & String.Empty
            Me.DigitoControl = DigitoControl & String.Empty
            Me.NCuenta = NCuenta
            Me.CodigoISO = CodigoISO
        End Sub
    End Class

    <Task()> Public Shared Function GenerarIBANEspania(ByVal data As DataGenerarIBAN, ByVal services As ServiceProvider) As String
        'If Length(data.NCuenta) = 0 OrElse Length(data.CodigoISO) = 0 Then Exit Function
        ''If Length(data.IDBanco) <> 4 OrElse Length(data.Sucursal) <> 4 OrElse Length(data.DigitoControl) <> 2 OrElse Length(data.NCuenta) <> 10 OrElse Length(data.CodigoISO) <> 2 Then Exit Function

        'Dim CuentaSinLetras As String = ProcessServer.ExecuteTask(Of String, String)(AddressOf GetCaracteresEnNumero, data.NCuenta, services)
        'Dim strCodigo As String = data.IDBanco + data.Sucursal + data.DigitoControl + CuentaSinLetras + ProcessServer.ExecuteTask(Of String, String)(AddressOf GetCaracteresEnNumero, data.CodigoISO, services) + "00"
        'Dim CodigoNum As New XNumber.StdBigNumber(strCodigo)
        'Dim AppMod97 As New XNumber.StdBigNumber("97")
        ''CodigoNum.IMod 
        'Dim RestoBN As XNumber.StdBigNumber = CodigoNum.IMod(AppMod97)
        'Dim Resto As Integer = CInt(RestoBN.ToString)
        'Resto = 98 - Resto
        'Dim DC As String = Format(Resto, "0#")
        'Dim CodIBAN As String = (data.CodigoISO + DC + data.IDBanco + data.Sucursal + data.DigitoControl + data.NCuenta)

        'If Not ProcessServer.ExecuteTask(Of String, Boolean)(AddressOf ValidarIBAN, CodIBAN, services) Then
        '    CodIBAN = String.Empty
        'End If
        'Return CodIBAN

        Dim cnLONG_CUENTA As Integer = 20
        If Length(data.NCuenta) = 0 OrElse Length(data.CodigoISO) = 0 Then Exit Function
        If Length(data.CodigoISO) <> 2 OrElse _
           (Length(data.CodigoISO) = 2 AndAlso data.CodigoISO = CodigoISO_Espania AndAlso (Length(data.IDBanco) <> 4 OrElse Length(data.Sucursal) <> 4 OrElse Length(data.DigitoControl) <> 2 OrElse Length(data.NCuenta) <> 10)) Then Exit Function

        Dim strCodigo As String
        Dim DC As String
        If (data.CodigoISO = CodigoISO_Espania) OrElse ((Length(data.IDBanco) <> 0 AndAlso Length(data.Sucursal) <> 0 AndAlso Length(data.DigitoControl) <> 0 AndAlso Length(data.NCuenta) <> 0)) Then
            strCodigo = data.IDBanco + data.Sucursal + data.DigitoControl + data.NCuenta + ProcessServer.ExecuteTask(Of String, String)(AddressOf GetCaracteresEnNumero, data.CodigoISO, services) + "00"
            Dim Resto As Integer
            If Length(strCodigo) > cnLONG_CUENTA Then  '//Si tenemos desglosado pero hemos incrementado la longitud de los campos para poder introducir toda la cuenta.
                Resto = CInt(CalcularModulo(strCodigo, 97))
            Else
                Resto = CDec(strCodigo) Mod 97
            End If
            Resto = 98 - Resto
            DC = Format(Resto, "0#")
            Return (data.CodigoISO + DC + data.IDBanco + data.Sucursal + data.DigitoControl + data.NCuenta)
        Else
            '//Para paises que no sean españa metemos la cuenta completa en NCuenta, o que no tengan todos los campos rellenos
            strCodigo = ProcessServer.ExecuteTask(Of String, String)(AddressOf GetCaracteresEnNumero, data.NCuenta, services)
            strCodigo += ProcessServer.ExecuteTask(Of String, String)(AddressOf GetCaracteresEnNumero, data.CodigoISO, services) + "00"

            Dim Resto As Integer = CInt(CalcularModulo(strCodigo, 97))
            Resto = 98 - Resto
            DC = Format(Resto, "0#")
            Return (data.CodigoISO + DC + data.NCuenta)
        End If

    End Function


    Private Shared Function CalcularModulo(ByVal Numero As String, ByVal Modulo As Integer) As String
        Dim Dividendo As Long
        Dim Resto As Integer
        Dim i As Integer = 1

        Do While i <= Len(Numero)
            Dividendo = Resto & Strings.Mid(Numero, i, 1)
            Resto = Dividendo Mod Modulo
            i += 1
        Loop
        CalcularModulo = Resto
    End Function


#End Region

#Region " Actualizaciones Directas desde pantallas masivas, para evitar las validaciones de las entidades, por datos mal introducidos en cuentas bancarias "

    <Task()> Public Shared Sub ClienteBancoUpdate(ByVal data As DataTable, ByVal services As ServiceProvider)
        data.TableName = "ClienteBanco"
        BusinessHelper.UpdateTable(data)
    End Sub

    <Task()> Public Shared Sub ProveedorBancoUpdate(ByVal data As DataTable, ByVal services As ServiceProvider)
        data.TableName = "ProveedorBanco"
        BusinessHelper.UpdateTable(data)
    End Sub

    <Task()> Public Shared Sub BancoPropioUpdate(ByVal data As DataTable, ByVal services As ServiceProvider)
        data.TableName = "BancoPropio"
        BusinessHelper.UpdateTable(data)
    End Sub

    <Task()> Public Shared Sub PersonalUpdate(ByVal data As DataTable, ByVal services As ServiceProvider)
        data.TableName = "Operario"
        BusinessHelper.UpdateTable(data)
    End Sub


#End Region

#Region "Formatos XML"

    <Serializable()> _
   Public Class DataFormatoNumerico
        Public Numero As Double
        Public Formato As String

        Public Sub New(ByVal Numero As Double, ByVal Formato As String)
            Me.Numero = Numero
            Me.Formato = Formato
        End Sub
    End Class


    <Task()> Public Shared Function FormatoNumericoTexto(ByVal data As DataFormatoNumerico, ByVal services As ServiceProvider) As String
        Dim CultureExpertis As System.Globalization.CultureInfo
        CultureExpertis = System.Threading.Thread.CurrentThread.CurrentCulture.Clone

        Dim forceDotCulture As System.Globalization.CultureInfo
        forceDotCulture = CultureExpertis.Clone()
        forceDotCulture.NumberFormat.NumberDecimalSeparator = "."
        forceDotCulture.NumberFormat.NumberGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture = forceDotCulture

        Dim strNumero As String = String.Empty
        strNumero = Format(data.Numero, data.Formato)

        '//Despues de aplicar el formato lo cambiamos
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureExpertis
        Return strNumero
    End Function

    <Task()> Public Shared Function AplicarFormatoCampoXML(ByVal elem As DataCampoRegistro, ByVal services As ServiceProvider) As String
        Dim RegFormato As FormatoXML = services.GetService(Of FormatoXML)()
        Dim str As String = String.Empty
        Select Case elem.Tipo
            Case enumTipoCampo.Alfanumerico
                Dim datSimEsp As New DataSimbolosEspeciales(elem.DefaultValue, , True, (RegFormato.Formato & String.Empty = "003"))
                elem.DefaultValue = ProcessServer.ExecuteTask(Of DataSimbolosEspeciales, String)(AddressOf TratarSimbolosEspeciales, datSimEsp, services)
                Dim Longitud As Integer
                If elem.Longitud - Length(elem.DefaultValue) < 0 Then
                    Longitud = 0
                Else
                    Longitud = elem.Longitud - Length(elem.DefaultValue)
                End If
                str = Trim(Left(elem.DefaultValue, elem.Longitud) & Space(Longitud))
            Case enumTipoCampo.Numerico
                Dim FormatoNumerico As String = "###0.00"
                Dim dat As New DataFormatoNumerico(CDbl(elem.DefaultValue), FormatoNumerico)
                str = Trim(ProcessServer.ExecuteTask(Of DataFormatoNumerico, String)(AddressOf FicherosGeneral.FormatoNumericoTexto, dat, services))
            Case enumTipoCampo.Fecha
                str = Trim(Strings.Format(CDate(Nz(elem.DefaultValue, Today)), elem.FormatoFecha))
        End Select
        Return str
    End Function

#End Region

End Class

Public Class FormatoXML
    Public Formato As String
End Class