
#Region " Constantes Modelo CSB19_14 "

Public Module CodigoRegistroCSB19_14
    Public REG_CABECERA_GENERAL As String = "01"
    Public REG_TOTALES_GENERAL As String = "99"

    Public REG_CABECERA_ACREEDOR_FECHA As String = "02"
    Public REG_INDIVIDUAL As String = "03"
    Public REG_TOTALES_ACREEDOR_FECHA As String = "04"
    Public REG_TOTALES_ACREEDOR As String = "05"
End Module

Public Module NumeroDatoCSB19_14
    Public CABECERA As String = "001"

    Public CABECERA_ACREEDOR_FECHA As String = "002"
    Public INDIVIDUAL_TIPO1 As String = "003"
    Public INDIVIDUAL_TIPO2 As String = "004"
    Public INDIVIDUAL_TIPO3 As String = "005"
    Public INDIVIDUAL_TIPO4 As String = "006"

End Module

Public Module TipoAdeudoCSB19_14
    Public ADEUDO_RECURRENTE_PRIMERO As String = "FRST"
    Public ADEUDO_RECURRENTE_ULTIMO As String = "FNAL"
    Public ADEUDO_RECURRENTE_INTERMEDIO As String = "RCUR"
    Public ADEUDO_UNICO As String = "OOFF"
End Module

Public Module PrefijoFichAdeudoCSB19_14
    Public FICHERO_PRESEN_ADEUDOS As String = "PRE"
End Module

#End Region


Public Class FicheroCSB19_14_CORE

    <Task()> Public Shared Function GenerarFichero(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider) As List(Of String)
        services.RegisterService(data, GetType(DataGenerarFichero))
        ProcessServer.ExecuteTask(Of DataGenerarFichero)(AddressOf PrepararInfoGeneralFicheroCORE, data, services)

        Dim datFichero As New DataAddRegistroFichero
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB19_14_RegistroCabeceraGeneral, datFichero, services)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB19_14_RegistrosAcreedores, datFichero, services)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB19_14_RegistroTotalesGeneral, datFichero, services)

        Return datFichero.Fichero
    End Function

#Region " Identificación del Fichero "

    <Task()> Public Shared Function GetIdentificacionFichero(ByVal data As Object, ByVal services As ServiceProvider) As String
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Return PrefijoFichAdeudoCSB19_14.FICHERO_PRESEN_ADEUDOS & Format(Today, FormatosFechas.AAAAMMDD) & Format(Date.Now, FormatosFechas.HHmmssfffff) & datOrdenante.NIF
    End Function

#End Region



#Region " Cabecera y Totales "

    <Task()> Public Shared Sub FichCSB19_14_RegistroCabeceraGeneral(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim datBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()

        '//NOTA: Se incluirán en la línea en el orden en que aparezcan en esta lista.
        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB19_14.REG_CABECERA_GENERAL))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB19_14_BASICO))
        lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB19_14.CABECERA))

        Dim IDAcreedor As String = ProcessServer.ExecuteTask(Of Object, String)(AddressOf FicherosGeneral.GetIdentificacionAcreedor, Nothing, services)
        datOrdenante.IDAcreedor = IDAcreedor
        lstRegistro.Add(New DataCampoRegistro("Identificación del Presentador", String.Empty, True, enumTipoCampo.Alfanumerico, 35, IDAcreedor))
        lstRegistro.Add(New DataCampoRegistro("Nombre del Presentador", String.Empty, True, enumTipoCampo.Alfanumerico, 70, datOrdenante.Nombre))
        lstRegistro.Add(New DataCampoRegistro("Fecha de Creación del Fichero", String.Empty, True, enumTipoCampo.Fecha, 8, Today, FormatosFechas.AAAAMMDD))
        Dim IDFichero As String = ProcessServer.ExecuteTask(Of Object, String)(AddressOf GetIdentificacionFichero, Nothing, services)
        lstRegistro.Add(New DataCampoRegistro("Identificación del Fichero", String.Empty, True, enumTipoCampo.Alfanumerico, 35, IDFichero))
        lstRegistro.Add(New DataCampoRegistro("Entidad Receptora", String.Empty, True, enumTipoCampo.Numerico, 4, datBanco.Entidad))
        lstRegistro.Add(New DataCampoRegistro("Oficina Receptora", String.Empty, True, enumTipoCampo.Numerico, 4, datBanco.Sucursal))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, True, enumTipoCampo.Alfanumerico, 434))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

    <Task()> Public Shared Sub FichCSB19_14_RegistroTotalesGeneral(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim TotGeneral As RegTotalesGeneral = services.GetService(Of RegTotalesGeneral)()

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB19_14.REG_TOTALES_GENERAL))
        lstRegistro.Add(New DataCampoRegistro("Total de Importes General", String.Empty, True, enumTipoCampo.Numerico, 17, TotGeneral.TotalImportes))
        lstRegistro.Add(New DataCampoRegistro("Número de Registros", String.Empty, True, enumTipoCampo.Numerico, 8, TotGeneral.NumRegistros))
        lstRegistro.Add(New DataCampoRegistro("Total de Registros", String.Empty, True, enumTipoCampo.Numerico, 10, TotGeneral.TotalRegistros + 2)) '// 2 regs más: cabecera + totales
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 563))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

#End Region

#Region " Registros de Acreedores - Cabeceras, Totales e Individuales "

    <Task()> Public Shared Sub FichCSB19_14_RegistrosAcreedores(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)

        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim FechasCobro As List(Of Object) = (From c In ProcInfo.OrigenDatos _
                                                 Where Not c.IsNull("FechaVencimiento") Select c("FechaVencimiento") Distinct).ToList()

        For Each FechaCobro As Date In FechasCobro
            'data.Fecha = ProcInfo.FechaCargo
            data.Fecha = FechaCobro
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB19_14_RegistrosCabeceraAcreedorFecha, data, services)
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB19_14_RegistrosIndividuales, data, services)
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB19_14_RegistrosTotalAcreedorFecha, data, services)
        Next

        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB19_14_RegistrosTotalAcreedor, data, services)
    End Sub

    <Task()> Public Shared Sub FichCSB19_14_RegistrosCabeceraAcreedorFecha(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim datBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB19_14.REG_CABECERA_ACREEDOR_FECHA))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB19_14_BASICO))
        lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB19_14.CABECERA_ACREEDOR_FECHA))

        Dim IDAcreedor As String
        If Length(datOrdenante.IDAcreedor) > 0 Then
            IDAcreedor = datOrdenante.IDAcreedor
        Else
            IDAcreedor = ProcessServer.ExecuteTask(Of Object, String)(AddressOf FicherosGeneral.GetIdentificacionAcreedor, Nothing, services)
        End If
        lstRegistro.Add(New DataCampoRegistro("Identificación del Acreedor (AT-02)", String.Empty, True, enumTipoCampo.Alfanumerico, 35, IDAcreedor))

        lstRegistro.Add(New DataCampoRegistro("Fecha de cobro (AT-11)", String.Empty, True, enumTipoCampo.Fecha, 8, Nz(data.Fecha, cnMinDate), FormatosFechas.AAAAMMDD))
        lstRegistro.Add(New DataCampoRegistro("Nombre del Acreedor (AT-03)", String.Empty, True, enumTipoCampo.Alfanumerico, 70, datOrdenante.Nombre))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Acreedor (D1) (AT-05)", String.Empty, False, enumTipoCampo.Alfanumerico, 50, datOrdenante.Direccion))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Acreedor (D2) (AT-05) Cod.Postal - Poblacion", String.Empty, False, enumTipoCampo.Alfanumerico, 50, datOrdenante.CodigoPostal + datOrdenante.Poblacion))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Acreedor (D3) (AT-05) Provincia", String.Empty, False, enumTipoCampo.Alfanumerico, 40, datOrdenante.Provincia))
        lstRegistro.Add(New DataCampoRegistro("País del Acreedor (AT-05)", String.Empty, False, enumTipoCampo.Alfanumerico, 2, datOrdenante.ISOPais))
        lstRegistro.Add(New DataCampoRegistro("Cuenta del Acreedor (AT-04)", String.Empty, True, enumTipoCampo.Alfanumerico, 34, datBanco.CodigoIBAN))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, True, enumTipoCampo.Alfanumerico, 301))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

    <Task()> Public Shared Sub FichCSB19_14_RegistrosIndividuales(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub


        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB19_14.REG_INDIVIDUAL))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB19_14_BASICO))
        lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB19_14.INDIVIDUAL_TIPO1))
        lstRegistro.Add(New DataCampoRegistro("Referencia del adeudo (AT-10)", "IDCobro", True, enumTipoCampo.Alfanumerico, 35))
        lstRegistro.Add(New DataCampoRegistro("Referencia única del Mandato (AT-01)", "NMandato", True, enumTipoCampo.Alfanumerico, 35))
        '//Cuidado con el TipoPago, hay que darle formato, no es el valor del campo tal cual.
        lstRegistro.Add(New DataCampoRegistro("Tipo de adeudo (AT-21)", "TipoAdeudo", True, enumTipoCampo.Alfanumerico, 4))
        lstRegistro.Add(New DataCampoRegistro("Categoría de Propósito", String.Empty, False, enumTipoCampo.Alfanumerico, 4))
        lstRegistro.Add(New DataCampoRegistro("Importe del adeudo (AT-06)", "ImpTotalVencimientoA", True, enumTipoCampo.Numerico, 11))
        lstRegistro.Add(New DataCampoRegistro("Fecha de firma del Mandato (AT-25)", "FechaMandato", True, enumTipoCampo.Fecha, 8, , FormatosFechas.AAAAMMDD))
        lstRegistro.Add(New DataCampoRegistro("Entidad del Deudor (AT-13)", "Swift", True, enumTipoCampo.Alfanumerico, 11))
        lstRegistro.Add(New DataCampoRegistro("Nombre del Deudor (AT-14)", "RazonSocial", True, enumTipoCampo.Alfanumerico, 70))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Deudor (D1) (AT-09)", "DomicilioDeudor", False, enumTipoCampo.Alfanumerico, 50))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Deudor (D2) (AT-09) Cod.Postal - Poblacion", "CodigoPostal+Poblacion", False, enumTipoCampo.Alfanumerico, 50))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Deudor (D3) (AT-09) Provincia", "Provincia", False, enumTipoCampo.Alfanumerico, 40))
        lstRegistro.Add(New DataCampoRegistro("País del Deudor (AT-09)", "ISOPais", False, enumTipoCampo.Alfanumerico, 2))
        lstRegistro.Add(New DataCampoRegistro("Tipo Identificación del Deudor", String.Empty, False, enumTipoCampo.Alfanumerico, 1))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Deudor (Código) - (AT-27)", String.Empty, False, enumTipoCampo.Alfanumerico, 36))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Deudor Emisor Código (Otro) - (AT-27)", String.Empty, False, enumTipoCampo.Alfanumerico, 35))
        lstRegistro.Add(New DataCampoRegistro("Identificador de la Cuenta del Deudor", String.Empty, True, enumTipoCampo.Alfanumerico, 1, IdentificacionCuenta.IBAN))
        lstRegistro.Add(New DataCampoRegistro("Cuenta del Deudor (AT-07)", "CodigoIBAN", True, enumTipoCampo.Alfanumerico, 34))
        lstRegistro.Add(New DataCampoRegistro("Propósito del Adeudo (AT-58)", String.Empty, False, enumTipoCampo.Alfanumerico, 4))
        lstRegistro.Add(New DataCampoRegistro("Concepto (AT-22)", "Concepto", False, enumTipoCampo.Alfanumerico, 140))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, True, enumTipoCampo.Alfanumerico, 19))


        Dim TotIndividuales As RegTotalesIndividuales = services.GetService(Of RegTotalesIndividuales)()

        If Not ProcInfo.OrigenDatos.Columns.Contains("Concepto") Then
            ProcInfo.OrigenDatos.Columns.Add("Concepto", GetType(String))
            ProcInfo.OrigenDatos.Columns("Concepto").ReadOnly = False
        End If


        If Not ProcInfo.OrigenDatos.Columns.Contains("TipoAdeudo") Then
            ProcInfo.OrigenDatos.Columns.Add("TipoAdeudo", GetType(String))
            ProcInfo.OrigenDatos.Columns("TipoAdeudo").ReadOnly = False
        End If


        'Dim CobrosEnFecha As List(Of DataRow) = (From c In ProcInfo.OrigenDatos _
        '                                        Where Not c.IsNull("FechaVencimiento") AndAlso c("FechaVencimiento") = data.Fecha).ToList()

        For Each dr As DataRow In ProcInfo.OrigenDatos.Select("FechaVencimiento = '" & data.Fecha & "'")
            dr("TipoAdeudo") = ProcessServer.ExecuteTask(Of DataRow, String)(AddressOf GetTipoAdeudo, dr, services)
            dr("Concepto") = ProcessServer.ExecuteTask(Of DataRow, String)(AddressOf GetConceptoCobros, dr, services)

            lstRegistro.Row = dr

            TotIndividuales.TotalImportes += Nz(dr("ImpVencimientoA"), 0) + Nz(dr("ARepercutirA"), 0)
            TotIndividuales.NumRegistros += 1
            TotIndividuales.TotalRegistros += 1
            Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
            If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
        Next
    End Sub

    <Task()> Public Shared Sub FichCSB19_14_RegistrosTotalAcreedorFecha(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        ' Dim TotAcreedores As RegTotalesAcreedores = services.GetService(Of RegTotalesAcreedores)()
        Dim TotIndividuales As RegTotalesIndividuales = services.GetService(Of RegTotalesIndividuales)()
        Dim TotGeneral As RegistroTotales = services.GetService(Of RegistroTotales)()

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB19_14.REG_TOTALES_ACREEDOR_FECHA))
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()

        Dim IDAcreedor As String
        If Length(datOrdenante.IDAcreedor) > 0 Then
            IDAcreedor = datOrdenante.IDAcreedor
        Else
            IDAcreedor = ProcessServer.ExecuteTask(Of Object, String)(AddressOf FicherosGeneral.GetIdentificacionAcreedor, Nothing, services)
        End If
        lstRegistro.Add(New DataCampoRegistro("Identificación del Acreedor (AT-02)", String.Empty, True, enumTipoCampo.Alfanumerico, 35, IDAcreedor))
        lstRegistro.Add(New DataCampoRegistro("Fecha de Cobro (AT-11)", String.Empty, True, enumTipoCampo.Fecha, 8, Nz(data.Fecha, cnMinDate), FormatosFechas.AAAAMMDD))
        lstRegistro.Add(New DataCampoRegistro("Total de Importes", String.Empty, True, enumTipoCampo.Numerico, 17, TotIndividuales.TotalImportes))
        lstRegistro.Add(New DataCampoRegistro("Número de Adeudos", String.Empty, True, enumTipoCampo.Numerico, 8, TotIndividuales.NumRegistros))
        lstRegistro.Add(New DataCampoRegistro("Total de Registros", String.Empty, True, enumTipoCampo.Numerico, 10, TotIndividuales.TotalRegistros + 2)) '// 2 regs más: cabecera + totales
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 520))

        Dim TotAcreedores As RegTotalesAcreedores = services.GetService(Of RegTotalesAcreedores)()
        TotAcreedores.TotalImportes += TotIndividuales.TotalImportes
        TotAcreedores.NumRegistros += TotIndividuales.NumRegistros
        TotAcreedores.TotalRegistros += TotIndividuales.TotalRegistros + 2

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)

        TotIndividuales.TotalImportes = 0
        TotIndividuales.NumRegistros = 0
        TotIndividuales.TotalRegistros = 0

    End Sub

    <Task()> Public Shared Sub FichCSB19_14_RegistrosTotalAcreedor(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim TotAcreedores As RegTotalesAcreedores = services.GetService(Of RegTotalesAcreedores)()
        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB19_14.REG_TOTALES_ACREEDOR))
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()

        Dim IDAcreedor As String
        If Length(datOrdenante.IDAcreedor) > 0 Then
            IDAcreedor = datOrdenante.IDAcreedor
        Else
            IDAcreedor = ProcessServer.ExecuteTask(Of Object, String)(AddressOf FicherosGeneral.GetIdentificacionAcreedor, Nothing, services)
        End If
        lstRegistro.Add(New DataCampoRegistro("Identificación del Acreedor (AT-02)", String.Empty, True, enumTipoCampo.Alfanumerico, 35, IDAcreedor))
        lstRegistro.Add(New DataCampoRegistro("Total de Importes", String.Empty, True, enumTipoCampo.Numerico, 17, TotAcreedores.TotalImportes))
        lstRegistro.Add(New DataCampoRegistro("Número de Adeudos", String.Empty, True, enumTipoCampo.Numerico, 8, TotAcreedores.NumRegistros))
        lstRegistro.Add(New DataCampoRegistro("Total de Registros", String.Empty, True, enumTipoCampo.Numerico, 10, TotAcreedores.TotalRegistros + 1)) '// 2 regs más: cabecera + totales
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 528))

        Dim TotGeneral As RegTotalesGeneral = services.GetService(Of RegTotalesGeneral)()
        TotGeneral.TotalImportes = TotAcreedores.TotalImportes
        TotGeneral.NumRegistros = TotAcreedores.NumRegistros
        TotGeneral.TotalRegistros = TotAcreedores.TotalRegistros + 1

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)

        TotAcreedores.TotalImportes = 0
        TotAcreedores.NumRegistros = 0
        TotAcreedores.TotalRegistros = 0
    End Sub

#End Region

#Region " Métodos Auxiliares para obtener información del sistema "

    <Task()> Public Shared Sub PrepararInfoGeneralFicheroCORE(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider)
        Dim datosBanco As DatosBancoPropioFicheros = ProcessServer.ExecuteTask(Of Object, DatosBancoPropioFicheros)(AddressOf FicherosGeneral.GetDatosBancoPropio, data, services)
        services.RegisterService(datosBanco, GetType(DatosBancoPropioFicheros))

        Dim datosOrdenante As DatosOrdenante = ProcessServer.ExecuteTask(Of Object, DatosOrdenante)(AddressOf FicherosGeneral.GetDatosOrdenante, Nothing, services)
        services.RegisterService(datosOrdenante, GetType(DatosOrdenante))

        Dim ProcInfo As New ProcessInfoFichero
        ProcInfo.IDProcess = data.IDProcess
        ProcInfo.FechaEmision = data.FechaEmision
        ProcInfo.FechaCargo = data.FechaCargo
        services.RegisterService(ProcInfo, GetType(ProcessInfoFichero))

        If Nz(data.IDRemesa) = 0 Then
            ApplicationService.GenerateError("Debe indicar el Nº de Remesa para generar el Fichero.")
        End If

        Dim f As New Filter
        f.Add(New NumberFilterItem("IDRemesa", data.IDRemesa))
        Dim DtCobrosTotal As DataTable = New BE.DataEngine().Filter("frmCobros", f)
        Dim dtCobros As DataTable = New BE.DataEngine().Filter("vSEPA_RemesaDefinitivaGenFichero_19_14", f)
        If Not dtCobros Is Nothing AndAlso dtCobros.Rows.Count > 0 Then
            Dim CobrosSinMandato As List(Of DataRow) = (From c In DtCobrosTotal Where c.IsNull("IDMandato")).ToList()
            If Not CobrosSinMandato Is Nothing AndAlso CobrosSinMandato.Count > 0 Then
                ApplicationService.GenerateError("Existen Cobros en los que no tiene asociado mandato.")
            End If
            Dim CobrosDifTipoMandato As List(Of Object) = (From c In DtCobrosTotal Select c("IDTipoMandato") Distinct).ToList
            If Not CobrosDifTipoMandato Is Nothing AndAlso CobrosDifTipoMandato.Count > 1 Then
                ApplicationService.GenerateError("Existen Cobros con diferentes tipos de mandato.")
            End If
            Dim CobrosSinIDCuenta As List(Of DataRow) = (From c In dtCobros Where c.IsNull("CodigoIBAN")).ToList()
            If Not CobrosSinIDCuenta Is Nothing AndAlso CobrosSinIDCuenta.Count > 0 Then
                ApplicationService.GenerateError("Existen Cobros en los que la Cuenta Bancaria no está identificada. Revise sus datos.")
            End If
            ProcInfo.OrigenDatos = dtCobros.Copy
        Else : ApplicationService.GenerateError("No existen cobros del tipo Mandato CORE.")
        End If
    End Sub


    <Task()> Public Shared Function GetTipoAdeudo(ByVal drCobro As DataRow, ByVal services As ServiceProvider) As String
        Dim TipoAdeudo As String = String.Empty
        Select Case drCobro("TipoPago")
            Case BusinessEnum.MandatoTipoPago.Unico
                TipoAdeudo = TipoAdeudoCSB19_14.ADEUDO_UNICO
            Case BusinessEnum.MandatoTipoPago.Recurrente
                Dim dtCobrosMandato As DataTable = New BE.DataEngine().Filter("vSEPA_frmCobros", New NumberFilterItem("IDMandato", drCobro("IDMandato")), , "FechaVencimiento")
                If dtCobrosMandato.Rows.Count > 0 Then
                    If dtCobrosMandato.Rows(0)("IDCobro") = drCobro("IDCobro") Then
                        TipoAdeudo = TipoAdeudoCSB19_14.ADEUDO_RECURRENTE_PRIMERO
                        'ElseIf dtCobrosMandato.Rows(dtCobrosMandato.Rows.Count - 1)("IDCobro") = drCobro("IDCobro") Then
                        '    TipoAdeudo = TipoAdeudoCSB19_14.ADEUDO_RECURRENTE_ULTIMO
                    Else
                        TipoAdeudo = TipoAdeudoCSB19_14.ADEUDO_RECURRENTE_INTERMEDIO
                    End If
                End If
        End Select
        Return TipoAdeudo
    End Function

    <Task()> Public Shared Function GetConceptoCobros(ByVal drCobro As DataRow, ByVal services As ServiceProvider) As String
        Dim dtParametro As DataTable = New BE.DataEngine().Filter("tbParametro", New StringFilterItem("IDParametro", "FRACOBROAG"))
        Dim NCobroAgrupado As String = String.Empty
        If dtParametro.Rows.Count > 0 Then
            NCobroAgrupado = dtParametro.Rows(0)("Valor") & String.Empty
        End If
        Dim strConcepto As String = String.Empty
        If drCobro("NFactura") & String.Empty = NCobroAgrupado Then
            Dim lstFras As List(Of Object) = ProcessServer.ExecuteTask(Of Integer, List(Of Object))(AddressOf FicherosGeneral.GetFacturasCobroAgrupado, drCobro("IDCobro"), services)
            If lstFras.Count > 0 Then strConcepto = "Factura Numero " & Join(lstFras.ToArray, ",")
        Else : strConcepto = "Factura Numero " & drCobro("NFactura")
        End If

        Return strConcepto
    End Function

  

#End Region

End Class

