
#Region " Constantes Modelo PAIN_008_001_02 "

Public Module FORMATOS_PAIN_008_001_02
    Public ISODateLong As String = "yyyy-MM-ddThh:mm:ss"
    Public ISODateShort As String = "yyyy-MM-dd"
    Public Numerico As String = "#,##0.00"
End Module

Public Module ETIQUETAS_PAIN_008_001_02
    Public RAIZ As String = "CstmrDrctDbtInitn"

    Public CAB_NODO As String = "GrpHdr"
    Public CAB_ID_MESSAGE As String = "MsgId"
    Public CAB_FECHA_HORA_CREACION As String = "CreDtTm"
    Public CAB_NUM_OPERACIONES As String = "NbOfTxs"
    Public CAB_CONTROL_SUMA As String = "CtrlSum"
    Public CAB_PARTE_INICIADORA As String = "InitgPty"
    Public CAB_NOMBRE As String = "Nm"
    Public CAB_IDENTIFICACION As String = "Id"
    Public CAB_PERSONA_JURIDICA As String = "OrgId"
    Public CAB_BIC As String = "BICOrBEI"
    Public CAB_Otra As String = "Othr"
    Public CAB_ID_ACREEDOR As String = "Id"

    Public INF_PAGO_NODO As String = "PmtInf"
    Public INF_PAGO_ID As String = "PmtInfId"
    Public INF_PAGO_METODO As String = "PmtMtd"
    Public INF_PAGO_NUM_OPERACIONES As String = "NbOfTxs"
    Public INF_PAGO_CONTROL_SUMA As String = "CtrlSum"
    Public INF_PAGO_INFO_TIPO_PAGO As String = "PmtTpInf"
    Public INF_PAGO_NIVEL_SERVICIO As String = "SvcLvl"
    Public INF_PAGO_NIVEL_SERVICIO_COD As String = "Cd"

    Public INF_PAGO_INSTRUMENTO_LOCAL As String = "LclInstrm"
    Public INF_PAGO_CODIGO As String = "Cd"
    Public INF_PAGO_TIPO_SECUENCIA As String = "SeqTp"
    Public INF_PAGO_FECHA_COBRO As String = "ReqdColltnDt"
    Public INF_PAGO_ACREEDOR As String = "Cdtr"
    Public INF_PAGO_ACREEDOR_NOMBRE As String = "Nm"
    Public INF_PAGO_DIRECCION_POSTAL As String = "PstlAdr"
    Public INF_PAGO_PAIS As String = "Ctry"
    Public INF_PAGO_DIRECCION_LIBRE As String = "AdrLine"
    Public INF_PAGO_CTA_ACREEDOR As String = "CdtrAcct"
    Public INF_PAGO_CTA_ID As String = "Id"
    Public INF_PAGO_CTA_IBAN As String = "IBAN"
    Public INF_PAGO_CTA_MONEDA As String = "Ccy"
    Public INF_PAGO_ENTIDAD_ACREEDOR As String = "CdtrAgt"
    Public INF_PAGO_ENTIDAD_ACREEDOR_ID As String = "FinInstnId"
    Public INF_PAGO_ENTIDAD_ACREEDOR_BIC As String = "BIC"
    Public INF_PAGO_ENTIDAD_ACREEDOR_OTRA As String = "Othr"
    Public INF_PAGO_ENTIDAD_ACREEDOR_OTRA_ID As String = "Id"

    Public INF_PAGO_ESQ_ACRREDOR As String = "CdtrSchmeId"
    Public INF_PAGO_ESQ_ACRREDOR_ID As String = "Id"
    Public INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA As String = "PrvtId"
    Public INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA_OTR As String = "Othr"
    Public INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA_OTR_ID As String = "Id"
    Public INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA_OTR_NAME As String = "SchmeNm"
    Public INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA_OTR_PROPERTY As String = "Prtry"

    Public ADEUDO_INDV_NODO As String = "DrctDbtTxInf"
    Public ADEUDO_INDV_ID As String = "PmtId"
    Public ADEUDO_INDV_ID_EXT_A_EXT As String = "EndToEndId"
    Public ADEUDO_INDV_IMPORTE As String = "InstdAmt"
    Public ADEUDO_INDV_MONEDA As String = "Ccy"
    Public ADEUDO_INDV_OP_ADEUDO_NODO As String = "DrctDbtTx"
    Public ADEUDO_INDV_OP_ADEUDO_INFO_MDTO As String = "MndtRltdInf"
    Public ADEUDO_INDV_OP_ADEUDO_ID_MDTO As String = "MndtId"
    Public ADEUDO_INDV_OP_ADEUDO_FECHA_MDTO As String = "DtOfSgntr"
    Public ADEUDO_INDV_ENTIDAD_DEUDOR_NODO As String = "DbtrAgt"
    Public ADEUDO_INDV_ENTIDAD_ID As String = "FinInstnId"
    Public ADEUDO_INDV_ENTIDAD_BIC As String = "BIC"
    Public ADEUDO_INDV_ENTIDAD_OTRA As String = "Othr"
    Public ADEUDO_INDV_ENTIDAD_OTRA_ID As String = "Id"

    Public ADEUDO_INDV_DEUDOR_NODO As String = "Dbtr"
    Public ADEUDO_INDV_DEUDOR_NOMBRE As String = "Nm"
    Public ADEUDO_INDV_DEUDOR_DIRECCION_POSTAL As String = "PstlAdr"
    Public ADEUDO_INDV_DEUDOR_PAIS As String = "Ctry"
    Public ADEUDO_INDV_DEUDOR_DIRECCION_LIBRE As String = "AdrLine"
    Public ADEUDO_INDV_DEUDOR_ID As String = "Id"
    Public ADEUDO_INDV_DEUDOR_PERSONA_JURIDICA As String = "OrgId"
    Public ADEUDO_INDV_DEUDOR_BIC As String = "BICOrBEI"
    Public ADEUDO_INDV_DEUDOR_Otra As String = "Othr"
    Public ADEUDO_INDV_DEUDOR_ID_DEUDOR As String = "Id"
    Public ADEUDO_INDV_CTA_DEUDOR_NODO As String = "DbtrAcct"
    Public ADEUDO_INDV_CTA_DEUDOR_ID As String = "Id"
    Public ADEUDO_INDV_CTA_DEUDOR_IBAN As String = "IBAN"
    Public ADEUDO_INDV_CONCEPTO As String = "RmtInf"
    Public ADEUDO_INDV_CONCEPTO_NO_ESTRUC As String = "Ustrd"

End Module

Public Module CODIGOS_PAIN_008_001_02
    Public MONEDA_EURO As String = "EUR"
    Public OPERACION As String = "SEPA"
    Public METODO_PAGO As String = "DD"
    Public FICHERO_CORE As String = "CORE"
    Public FICHERO_COR1 As String = "COR1"
    Public FICHERO_B2B As String = "B2B"

End Module


'Public Module CodigoRegistroCSB19_14
'    Public REG_CABECERA_GENERAL As String = "01"
'    Public REG_TOTALES_GENERAL As String = "99"

'    Public REG_CABECERA_ACREEDOR_FECHA As String = "02"
'    Public REG_INDIVIDUAL As String = "03"
'    Public REG_TOTALES_ACREEDOR_FECHA As String = "04"
'    Public REG_TOTALES_ACREEDOR As String = "05"
'End Module

'Public Module NumeroDatoCSB19_14
'    Public CABECERA As String = "001"

'    Public CABECERA_ACREEDOR_FECHA As String = "002"
'    Public INDIVIDUAL_TIPO1 As String = "003"
'    Public INDIVIDUAL_TIPO2 As String = "004"
'    Public INDIVIDUAL_TIPO3 As String = "005"
'    Public INDIVIDUAL_TIPO4 As String = "006"

'End Module

'Public Module TipoAdeudoCSB19_14
'    Public ADEUDO_RECURRENTE_PRIMERO As String = "FRST"
'    Public ADEUDO_RECURRENTE_ULTIMO As String = "FNAL"
'    Public ADEUDO_RECURRENTE_INTERMEDIO As String = "RCUR"
'    Public ADEUDO_UNICO As String = "OOFF"
'End Module

'Public Module PrefijoFichAdeudoCSB19_14
'    Public FICHERO_PRESEN_ADEUDOS As String = "PRE"
'End Module

#End Region

Public Class Fichero_PAIN_008_001_02

    <Task()> Public Shared Function GenerarFicheroCORE(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider) As Byte()
        ProcessServer.ExecuteTask(Of DataGenerarFichero)(AddressOf FicheroCSB19_14_CORE.PrepararInfoGeneralFicheroCORE, data, services)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        ProcInfo.TipoFichero = enumTipoFicheroXMLSEPA.CORE
        Return ProcessServer.ExecuteTask(Of DataGenerarFichero, Byte())(AddressOf GenerarFichero, data, services)
    End Function

    <Task()> Public Shared Function GenerarFicheroCOR1(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider) As Byte()
        ProcessServer.ExecuteTask(Of DataGenerarFichero)(AddressOf FicheroCSB19_14_CORE.PrepararInfoGeneralFicheroCORE, data, services)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        ProcInfo.TipoFichero = enumTipoFicheroXMLSEPA.COR1
        Return ProcessServer.ExecuteTask(Of DataGenerarFichero, Byte())(AddressOf GenerarFichero, data, services)
    End Function

    <Task()> Public Shared Function GenerarFicheroB2B(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider) As Byte()
        ProcessServer.ExecuteTask(Of DataGenerarFichero)(AddressOf FicheroCSB19_44_B2B.PrepararInfoGeneralFicheroB2B, data, services)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        ProcInfo.TipoFichero = enumTipoFicheroXMLSEPA.B2B
        Return ProcessServer.ExecuteTask(Of DataGenerarFichero, Byte())(AddressOf GenerarFichero, data, services)
    End Function

    <Task()> Public Shared Function GenerarFichero(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider) As Byte()
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then
            ApplicationService.GenerateError("No hay datos para generar el Fichero XML")
        End If

        If Not ProcInfo.OrigenDatos.Columns.Contains("Concepto") Then
            ProcInfo.OrigenDatos.Columns.Add("Concepto", GetType(String))
            ProcInfo.OrigenDatos.Columns("Concepto").ReadOnly = False
        End If


        If Not ProcInfo.OrigenDatos.Columns.Contains("TipoAdeudo") Then
            ProcInfo.OrigenDatos.Columns.Add("TipoAdeudo", GetType(String))
            ProcInfo.OrigenDatos.Columns("TipoAdeudo").ReadOnly = False
        End If

        For Each dr As DataRow In ProcInfo.OrigenDatos.Rows
            dr("TipoAdeudo") = ProcessServer.ExecuteTask(Of DataRow, String)(AddressOf FicheroCSB19_14_CORE.GetTipoAdeudo, dr, services)
            dr("Concepto") = ProcessServer.ExecuteTask(Of DataRow, String)(AddressOf FicheroCSB19_14_CORE.GetConceptoCobros, dr, services)
        Next

        Dim xmlDoc As New Xml.XmlDocument
        ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf ValidacionesBasicas, xmlDoc, services)

        Dim xmlNodoDecla As Xml.XmlDeclaration = xmlDoc.CreateNode(Xml.XmlNodeType.XmlDeclaration, "1.0", Nothing, Nothing)
        xmlNodoDecla.Encoding = "UTF-8"
        xmlDoc.AppendChild(xmlNodoDecla)

        Dim document As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, "Document", String.Empty)
        xmlDoc.AppendChild(document)
        xmlDoc.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
        xmlDoc.DocumentElement.SetAttribute("xmlns", "urn:iso:std:iso:20022:tech:xsd:pain.008.001.02")

        ''Nodo raiz
        Dim raiz As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.RAIZ, String.Empty)
        document.AppendChild(raiz)

        ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf CrearNodoCabecera, xmlDoc, services)
        ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf CrearNodoInformacionPago, xmlDoc, services)

        Dim enc As System.Text.Encoding = System.Text.Encoding.UTF8
        Return enc.GetBytes(xmlDoc.InnerXml)
    End Function

    <Task()> Public Shared Sub ValidacionesBasicas(ByVal xmlDoc As Xml.XmlDocument, ByVal services As ServiceProvider)
        Dim datosBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()

        If Length(Trim(datosBanco.CodigoIBAN)) = 0 Then
            ApplicationService.GenerateError("Debe indicar el Código IBAN del Banco Propio de la Remesa. No se generá el fichero.")
        End If

        If Length(Trim(datosBanco.SWIFT)) = 0 Then
            ApplicationService.GenerateError("Debe indicar el Código SWIFT/BIC del Banco Propio de la Remesa. No se generá el fichero.")
        End If

        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim CobrosSinIBAN As List(Of DataRow) = (From c In CType(ProcInfo.OrigenDatos, DataTable) _
                                                    Where c.IsNull("CodigoIBAN")).ToList()

        If CobrosSinIBAN.Count > 0 Then
            ApplicationService.GenerateError("Existen registros sin Código IBAN. No se generá el fichero.")
        End If


        Dim CobrosSinSWIFT As List(Of DataRow) = (From c In CType(ProcInfo.OrigenDatos, DataTable) _
                                                       Where c.IsNull("SWIFT")).ToList()

        If CobrosSinSWIFT.Count > 0 Then
            ApplicationService.GenerateError("Existen registros sin Código SWIFT/BIC. No se generá el fichero.")
        End If

        'Por cada cobro mirar si para el IDMandato que viene en el cobro es el IDClienteBanco que viene en el cobro
        For Each DrCobro As DataRow In ProcInfo.OrigenDatos.Select
            Dim DtMandato As DataTable = New Mandato().SelOnPrimaryKey(DrCobro("IDMandato"))
            If Not DtMandato Is Nothing AndAlso DtMandato.Rows.Count > 0 Then
                If DtMandato.Rows(0)("IDClienteBanco") <> DrCobro("IDClienteBanco") Then
                    ApplicationService.GenerateError("El mandato no tiene Cliente Banco correcto.")
                End If
                'Comprobamos de paso que el CodigoIban esté correcto
                ProcessServer.ExecuteTask(Of String, Boolean)(AddressOf FicherosGeneral.ValidarIBAN, DrCobro("CodigoIBAN"), services)
            End If
        Next
    End Sub

    <Task()> Public Shared Sub CrearNodoCabecera(ByVal xmlDoc As Xml.XmlDocument, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()

        Dim lstRaiz As Xml.XmlNodeList = xmlDoc.GetElementsByTagName(ETIQUETAS_PAIN_008_001_02.RAIZ)
        Dim raiz As Xml.XmlNode = lstRaiz.ItemOf(0)

        Dim Cabecera As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_NODO, String.Empty)
        raiz.AppendChild(Cabecera)

        Dim IDFichero As String = ProcessServer.ExecuteTask(Of Object, String)(AddressOf FicheroCSB19_14_CORE.GetIdentificacionFichero, Nothing, services)
        Dim DtRemesa As DataTable = New Remesa().SelOnPrimaryKey(ProcInfo.OrigenDatos.Rows(0)("IDRemesa"))
        If Not DtRemesa Is Nothing AndAlso DtRemesa.Rows.Count > 0 Then
            If DtRemesa.Rows(0)("IDTipoNegociacion") = enumTipoRemesa.RemesaAlDescuento Then
                IDFichero = "FSDD" & IDFichero
            End If
        End If
        Dim IDMensaje As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_ID_MESSAGE, String.Empty)
        Dim ValorCampo As New DataCampoRegistro("Identificación del Mensaje", Nothing, True, enumTipoCampo.Alfanumerico, 35, IDFichero, Nothing, Nothing)
        IDMensaje.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        Cabecera.AppendChild(IDMensaje)

        Dim FechaCreacion As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_FECHA_HORA_CREACION, String.Empty)
        FechaCreacion.InnerText = Format(Today.Now, FORMATOS_PAIN_008_001_02.ISODateLong)
        Cabecera.AppendChild(FechaCreacion)

        Dim NumeroOperaciones As Integer = Nz(ProcInfo.OrigenDatos.Compute("COUNT(IDCobro)", Nothing), 0)
        Dim TotalSuma As Double = ProcInfo.OrigenDatos.Compute("SUM(ImpVencimientoA)", Nothing)
        TotalSuma += ProcInfo.OrigenDatos.Compute("SUM(ARepercutirA)", Nothing)

        Dim NumOperaciones As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_NUM_OPERACIONES, String.Empty)
        ValorCampo = New DataCampoRegistro("Número Operaciones", Nothing, True, enumTipoCampo.Alfanumerico, 15, NumeroOperaciones, Nothing, Nothing) '//Alfanumérico para que no ponga los decimales
        NumOperaciones.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        Cabecera.AppendChild(NumOperaciones)

        Dim TotalImportes As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_CONTROL_SUMA, String.Empty)
        ValorCampo = New DataCampoRegistro("Control de Suma", Nothing, False, enumTipoCampo.Numerico, 18, TotalSuma, Nothing, Nothing)
        TotalImportes.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        Cabecera.AppendChild(TotalImportes)

        Dim PresentadorInfo As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_PARTE_INICIADORA, String.Empty)
        Cabecera.AppendChild(PresentadorInfo)

        Dim PresentadorNombre As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_NOMBRE, String.Empty)
        ValorCampo = New DataCampoRegistro("Nombre Presentador", Nothing, True, enumTipoCampo.Alfanumerico, 70, datOrdenante.Nombre, Nothing, Nothing)
        PresentadorNombre.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        PresentadorInfo.AppendChild(PresentadorNombre)

        Dim PresentadorID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_IDENTIFICACION, String.Empty)
        PresentadorInfo.AppendChild(PresentadorID)

        Dim PerJuridica As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_PERSONA_JURIDICA, String.Empty)
        PresentadorID.AppendChild(PerJuridica)

        'Dim BIC As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_BIC, String.Empty)
        'BIC.Value = BIC
        'PerJuridica.AppendChild(BIC)

        Dim OtraID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_Otra, String.Empty)
        PerJuridica.AppendChild(OtraID)

        Dim IDAcreedor As String = ProcessServer.ExecuteTask(Of Object, String)(AddressOf FicherosGeneral.GetIdentificacionAcreedor, Nothing, services)
        datOrdenante.IDAcreedor = IDAcreedor
        Dim IDAcreeedor As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.CAB_IDENTIFICACION, String.Empty)
        ValorCampo = New DataCampoRegistro("Identificador del Presentador", Nothing, False, enumTipoCampo.Alfanumerico, 35, datOrdenante.IDAcreedor, Nothing, Nothing)
        IDAcreeedor.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        OtraID.AppendChild(IDAcreeedor)
    End Sub

    <Task()> Public Shared Sub CrearNodoInformacionPago(ByVal xmlDoc As Xml.XmlDocument, ByVal services As ServiceProvider)
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim datBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()

        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub


        Dim lstRaiz As Xml.XmlNodeList = xmlDoc.GetElementsByTagName(ETIQUETAS_PAIN_008_001_02.RAIZ)
        Dim raiz As Xml.XmlNode = lstRaiz.ItemOf(0)


        Dim Orden As String = "TipoAdeudo,FechaVencimiento"
        Dim dvAgrupacion As New DataView(ProcInfo.OrigenDatos, Nothing, Orden, DataViewRowState.CurrentRows)
        If dvAgrupacion.Count > 0 Then
            ' Dim FechaCargo As Date = ProcInfo.FechaCargo
            'Dim CodigoIBAN As String
            Dim FechaVencimiento As Date
            Dim TipoAdeudo As String = vbNullString
            Dim f As New Filter
            Dim cont As Integer = 0
            For Each drv As DataRowView In dvAgrupacion

                If drv.Row("TipoAdeudo") <> TipoAdeudo OrElse drv.Row("FechaVencimiento") <> FechaVencimiento Then

                    ' CodigoIBAN = drv.Row("CodigoIBAN")
                    TipoAdeudo = drv.Row("TipoAdeudo")
                    FechaVencimiento = drv.Row("FechaVencimiento")

                    Dim NumeroOperaciones As Integer = 0
                    Dim TotalSuma As Double = 0

                    f.Clear()
                    f.Add(New StringFilterItem("TipoAdeudo", TipoAdeudo))
                    f.Add(New DateFilterItem("FechaVencimiento", FechaVencimiento))

                    ' f.Add(New StringFilterItem("CodigoIBAN", CodigoIBAN))

                    Dim Where As String = f.Compose(New AdoFilterComposer)
                    NumeroOperaciones = ProcInfo.OrigenDatos.Compute("COUNT(IDCobro)", Where)
                    TotalSuma = ProcInfo.OrigenDatos.Compute("SUM(ImpVencimientoA)", Where)
                    TotalSuma += ProcInfo.OrigenDatos.Compute("SUM(ARepercutirA)", Where)

                    cont += 1

                    Dim NodoPagos As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_NODO, String.Empty)
                    raiz.AppendChild(NodoPagos)

                    '//--------------------------------------------------- Nodo Pagos: Información General ---------------------------------------------
                    Dim Identificacion As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ID, String.Empty)
                    'Identificacion.InnerText = 
                    Dim ValorCampo As New DataCampoRegistro("Identificador del Pago", Nothing, True, enumTipoCampo.Alfanumerico, 35, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ID & cont, Nothing, Nothing)
                    Identificacion.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    NodoPagos.AppendChild(Identificacion)

                    Dim Metodo As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_METODO, String.Empty)
                    ValorCampo = New DataCampoRegistro("Método de Pago", Nothing, True, enumTipoCampo.Alfanumerico, 2, CODIGOS_PAIN_008_001_02.METODO_PAGO, Nothing, Nothing)
                    Metodo.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    NodoPagos.AppendChild(Metodo)

                    Dim NumOps As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_NUM_OPERACIONES, String.Empty)
                    ValorCampo = New DataCampoRegistro("Número de Operaciones", Nothing, False, enumTipoCampo.Alfanumerico, 15, NumeroOperaciones, Nothing, Nothing) '//Alfanumérico para que no ponga los decimales
                    NumOps.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    NodoPagos.AppendChild(NumOps)

                    Dim CtrlSuma As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_CONTROL_SUMA, String.Empty)
                    ValorCampo = New DataCampoRegistro("Control de Suma", Nothing, False, enumTipoCampo.Numerico, 18, TotalSuma, Nothing, Nothing)
                    CtrlSuma.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    NodoPagos.AppendChild(CtrlSuma)


                    Dim InfoTipoPago As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_INFO_TIPO_PAGO, String.Empty)
                    NodoPagos.AppendChild(InfoTipoPago)

                    Dim NivelSrv As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_NIVEL_SERVICIO, String.Empty)
                    InfoTipoPago.AppendChild(NivelSrv)

                    Dim NivelSrvCod As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_NIVEL_SERVICIO_COD, String.Empty)
                    NivelSrvCod.InnerText = CODIGOS_PAIN_008_001_02.OPERACION '//SEPA
                    NivelSrv.AppendChild(NivelSrvCod)

                    Dim LclInst As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_INSTRUMENTO_LOCAL, String.Empty)
                    InfoTipoPago.AppendChild(LclInst)

                    Dim LclInstCod As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_CODIGO, String.Empty)
                    '//Formato Fichero CORE o COR1 o B2B
                    Select Case ProcInfo.TipoFichero
                        Case enumTipoFicheroXMLSEPA.CORE
                            LclInstCod.InnerText = CODIGOS_PAIN_008_001_02.FICHERO_CORE
                        Case enumTipoFicheroXMLSEPA.COR1
                            LclInstCod.InnerText = CODIGOS_PAIN_008_001_02.FICHERO_COR1
                        Case enumTipoFicheroXMLSEPA.B2B
                            LclInstCod.InnerText = CODIGOS_PAIN_008_001_02.FICHERO_B2B
                    End Select
                    LclInst.AppendChild(LclInstCod)

                    If Length(TipoAdeudo) > 0 Then
                        Dim TipoSecuencia As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_TIPO_SECUENCIA, String.Empty)
                        ValorCampo = New DataCampoRegistro("Tipo de Secuencia", Nothing, False, enumTipoCampo.Alfanumerico, 4, TipoAdeudo, Nothing, Nothing)
                        TipoSecuencia.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                        InfoTipoPago.AppendChild(TipoSecuencia)
                    End If


                    '// -------------- Nodo Pagos: Datos Comunes de los Cobros (FechaCobro, Info Acreedor (cuentas, entidad,....)) ----------------------
                    Dim xmlFechaCobro As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_FECHA_COBRO, String.Empty)
                    ValorCampo = New DataCampoRegistro("Fecha Cobro", Nothing, False, enumTipoCampo.Fecha, 10, FechaVencimiento, FORMATOS_PAIN_008_001_02.ISODateShort, Nothing)
                    xmlFechaCobro.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    NodoPagos.AppendChild(xmlFechaCobro)


                    '//--------- Info Acreedor
                    Dim AcreedorInfo As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ACREEDOR, String.Empty)
                    NodoPagos.AppendChild(AcreedorInfo)

                    Dim AcreedorNombre As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ACREEDOR_NOMBRE, String.Empty)
                    ValorCampo = New DataCampoRegistro("Nombre Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 70, datOrdenante.Nombre, Nothing, Nothing)
                    AcreedorNombre.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    AcreedorInfo.AppendChild(AcreedorNombre)

                    Dim AcreedorDirPostal As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_DIRECCION_POSTAL, String.Empty)

                    Dim AcreedorPais As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_PAIS, String.Empty)
                    ValorCampo = New DataCampoRegistro("Código ISO Pais", Nothing, True, enumTipoCampo.Alfanumerico, 2, datOrdenante.ISOPais, Nothing, Nothing)
                    AcreedorPais.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    AcreedorDirPostal.AppendChild(AcreedorPais)

                    Dim AcreedorDirTexto As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_DIRECCION_LIBRE, String.Empty)
                    ValorCampo = New DataCampoRegistro("Dirección Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 70, datOrdenante.Direccion, Nothing, Nothing)
                    AcreedorDirTexto.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    AcreedorDirPostal.AppendChild(AcreedorDirTexto)

                    AcreedorInfo.AppendChild(AcreedorDirPostal)


                    '//--------- Cuenta Acreedor
                    Dim AcreedorInfoCta As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_CTA_ACREEDOR, String.Empty)
                    NodoPagos.AppendChild(AcreedorInfoCta)

                    Dim AcreedorInfoCtaID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_CTA_ID, String.Empty)
                    AcreedorInfoCta.AppendChild(AcreedorInfoCtaID)

                    Dim AcreedorInfoCtaIBAN As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_CTA_IBAN, String.Empty)
                    ValorCampo = New DataCampoRegistro("Código IBAN Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 34, datBanco.CodigoIBAN, Nothing, Nothing)
                    AcreedorInfoCtaIBAN.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    AcreedorInfoCtaID.AppendChild(AcreedorInfoCtaIBAN)

                    'Dim AcreedorInfoCtaMon As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_CTA_MONEDA, String.Empty)
                    'AcreedorInfoCtaMon.InnerText = ""
                    'AcreedorInfoCta.AppendChild(AcreedorInfoCtaMon)


                    '//--------- Entidad Acreedor  (NODO 2.21)
                    Dim AcreedorInfoEntidad As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ENTIDAD_ACREEDOR, String.Empty)
                    NodoPagos.AppendChild(AcreedorInfoEntidad)

                    Dim AcreedorInfoEntidadID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ENTIDAD_ACREEDOR_ID, String.Empty)
                    AcreedorInfoEntidad.AppendChild(AcreedorInfoEntidadID)

                    Dim AcreedorInfoCtaBIC As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ENTIDAD_ACREEDOR_BIC, String.Empty)
                    ValorCampo = New DataCampoRegistro("Código SWIFT Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 11, datBanco.SWIFT, Nothing, Nothing)
                    AcreedorInfoCtaBIC.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    AcreedorInfoEntidadID.AppendChild(AcreedorInfoCtaBIC)

                    'Dim AcreedorInfoCtaOtra As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ENTIDAD_ACREEDOR_OTRA, String.Empty)
                    'AcreedorInfoEntidadID.AppendChild(AcreedorInfoCtaOtra)

                    'Dim AcreedorInfoCtaOtraID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ENTIDAD_ACREEDOR_OTRA_ID, String.Empty)
                    'ValorCampo = New DataCampoRegistro("Código Otra ID Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 35, datBanco.CodigoIBAN, Nothing, Nothing)
                    'AcreedorInfoCtaOtraID.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    'AcreedorInfoCtaOtra.AppendChild(AcreedorInfoCtaOtraID)

                    '// ----------------------------------- ESQUEMA IDENTIFICADOR ACREEDOR ------------------------------------------------------------------

                    Dim AcreedorInfoSchema As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ESQ_ACRREDOR, String.Empty)
                    NodoPagos.AppendChild(AcreedorInfoSchema)

                    Dim AcreedorInfoId As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ESQ_ACRREDOR_ID, String.Empty)
                    AcreedorInfoSchema.AppendChild(AcreedorInfoId)

                    Dim AcreedorInfoPrvtId As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA, String.Empty)
                    AcreedorInfoId.AppendChild(AcreedorInfoPrvtId)

                    Dim AcreedorInfoPrvtIdOtr As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA_OTR, String.Empty)
                    AcreedorInfoPrvtId.AppendChild(AcreedorInfoPrvtIdOtr)

                    Dim AcreedorInfoPrvtIdOtrId As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA_OTR_ID, String.Empty)
                    Dim IDAcreedor As String = ProcessServer.ExecuteTask(Of Object, String)(AddressOf FicherosGeneral.GetIdentificacionAcreedor, Nothing, services)
                    datOrdenante.IDAcreedor = IDAcreedor
                    ValorCampo = New DataCampoRegistro("Identificador del Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 35, datOrdenante.IDAcreedor, Nothing, Nothing)
                    AcreedorInfoPrvtIdOtrId.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    AcreedorInfoPrvtIdOtr.AppendChild(AcreedorInfoPrvtIdOtrId)

                    Dim AcreedorInfoPrvtName As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA_OTR_NAME, String.Empty)
                    AcreedorInfoPrvtIdOtr.AppendChild(AcreedorInfoPrvtName)

                    Dim AcreedorInfoPrvtPrtry As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.INF_PAGO_ESQ_ACRREDOR_ID_PRIVADA_OTR_PROPERTY, String.Empty)
                    AcreedorInfoPrvtPrtry.InnerText = CODIGOS_PAIN_008_001_02.OPERACION '//SEPA
                    AcreedorInfoPrvtName.AppendChild(AcreedorInfoPrvtPrtry)

                    Dim datAdeudos As New DataCrearNodosAdeudosDirectos(xmlDoc, drv.Row, NodoPagos)
                    ProcessServer.ExecuteTask(Of DataCrearNodosAdeudosDirectos)(AddressOf CrearNodosAdeudosDirectos, datAdeudos, services)
                End If
            Next
        End If
    End Sub

    Public Class DataCrearNodosAdeudosDirectos
        Public xmlDoc As Xml.XmlDocument
        Public Row As DataRow
        Public NodoPadre As Xml.XmlNode

        Public Sub New(ByVal xmlDoc As Xml.XmlDocument, ByVal Row As DataRow, ByVal NodoPadre As Xml.XmlNode)
            Me.xmlDoc = xmlDoc
            Me.Row = Row
            Me.NodoPadre = NodoPadre
        End Sub
    End Class

    <Task()> Public Shared Sub CrearNodosAdeudosDirectos(ByVal data As DataCrearNodosAdeudosDirectos, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim NodoPagos As Xml.XmlNode = data.NodoPadre

        Dim f As New Filter
        f.Add(New StringFilterItem("TipoAdeudo", data.Row("TipoAdeudo")))
        f.Add(New DateFilterItem("FechaVencimiento", data.Row("FechaVencimiento")))

        Dim Where As String = f.Compose(New AdoFilterComposer)
        Dim dv As New DataView(ProcInfo.OrigenDatos, Where, "FechaVencimiento, ImpTotalVencimientoA", DataViewRowState.CurrentRows)
        For Each drv As DataRowView In dv

            Dim NodoAdeudo As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_NODO, String.Empty)
            NodoPagos.AppendChild(NodoAdeudo)


            '// ------------------------  Identificación del Pago  ----------------------------------------------
            Dim NodoInfoPago As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_ID, String.Empty)
            NodoAdeudo.AppendChild(NodoInfoPago)

            Dim NodoIDPago As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_ID_EXT_A_EXT, String.Empty)
            Dim ValorCampo As New DataCampoRegistro("Identificación del Pago", Nothing, False, enumTipoCampo.Alfanumerico, 35, drv.Row("IDCobro"), Nothing, Nothing)
            NodoIDPago.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
            NodoInfoPago.AppendChild(NodoIDPago)

            '// ------------------------------  Importe  ----------------------------------------------
            Dim Importe As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_IMPORTE, String.Empty)
            Dim atr As Xml.XmlAttribute = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Attribute, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_MONEDA, Nothing)
            atr.Value = CODIGOS_PAIN_008_001_02.MONEDA_EURO
            Importe.Attributes.Append(atr)

            Dim ImporteAdeudo As Double = Nz(drv.Row("ImpTotalVencimientoA"), 0)
            ValorCampo = New DataCampoRegistro("Importe Adeudo", Nothing, False, enumTipoCampo.Numerico, 12, ImporteAdeudo, Nothing, Nothing)
            Importe.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
            NodoAdeudo.AppendChild(Importe)

            '// ------------------------------  Operación de Adeudo Directo  ------------------------------------
            Dim NodoAdeudoDir As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_OP_ADEUDO_NODO, String.Empty)
            NodoAdeudo.AppendChild(NodoAdeudoDir)

            Dim MndtoInfo As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_OP_ADEUDO_INFO_MDTO, String.Empty)
            NodoAdeudoDir.AppendChild(MndtoInfo)

            Dim MndtoInfoID As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_OP_ADEUDO_ID_MDTO, String.Empty)
            ValorCampo = New DataCampoRegistro("Nº Mandato", Nothing, False, enumTipoCampo.Alfanumerico, 35, drv.Row("NMandato") & String.Empty, Nothing, Nothing)
            MndtoInfoID.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
            MndtoInfo.AppendChild(MndtoInfoID)

            Dim MndtoInfoFecha As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_OP_ADEUDO_FECHA_MDTO, String.Empty)
            ValorCampo = New DataCampoRegistro("Fecha Mandato", Nothing, False, enumTipoCampo.Fecha, 10, drv.Row("FechaMandato") & String.Empty, FORMATOS_PAIN_008_001_02.ISODateShort, Nothing)
            MndtoInfoFecha.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
            MndtoInfo.AppendChild(MndtoInfoFecha)

            '// ------------------------------  Entidad del Deudor (NODO 2.70) ------------------------------------
            Dim NodoEntidad As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_ENTIDAD_DEUDOR_NODO, String.Empty)
            NodoAdeudo.AppendChild(NodoEntidad)

            Dim NodoEntidadID As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_ENTIDAD_ID, String.Empty)
            NodoEntidad.AppendChild(NodoEntidadID)

            Dim NodoEntidadBIC As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_ENTIDAD_BIC, String.Empty)
            ValorCampo = New DataCampoRegistro("Código SWIFT/BIC Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 11, drv.Row("Swift"), Nothing, Nothing)
            NodoEntidadBIC.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
            NodoEntidadID.AppendChild(NodoEntidadBIC)


            'Dim NodoEntidadOtra As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_ENTIDAD_OTRA, String.Empty)
            'NodoEntidadID.AppendChild(NodoEntidadOtra)

            'Dim NodoEntidadOtraID As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_ENTIDAD_OTRA_ID, String.Empty)
            'ValorCampo = New DataCampoRegistro("Otra Identificación Entidad ID", Nothing, True, enumTipoCampo.Alfanumerico, 35, drv.Row("CodigoIBAN"), Nothing, Nothing)
            'NodoEntidadOtraID.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
            'NodoEntidadOtra.AppendChild(NodoEntidadOtraID)

            '// ------------------------------  Deudor  ------------------------------------

            Dim NodoDeudor As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_NODO, String.Empty)
            NodoAdeudo.AppendChild(NodoDeudor)

            If Length(drv.Row("RazonSocial")) > 0 Then
                Dim NodoDeudorNombre As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_NOMBRE, String.Empty)
                ValorCampo = New DataCampoRegistro("Nombre Deudor", Nothing, False, enumTipoCampo.Alfanumerico, 70, drv.Row("RazonSocial") & String.Empty, Nothing, Nothing)
                NodoDeudorNombre.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoDeudor.AppendChild(NodoDeudorNombre)
            End If

            Dim NodoDirPostal As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_DIRECCION_POSTAL, String.Empty)
            NodoDeudor.AppendChild(NodoDirPostal)

            If Length(drv.Row("ISOPais")) > 0 Then
                Dim NodoPais As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_PAIS, String.Empty)
                ValorCampo = New DataCampoRegistro("Pais Deudor", Nothing, False, enumTipoCampo.Alfanumerico, 2, drv.Row("ISOPais") & String.Empty, Nothing, Nothing)
                NodoPais.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoDirPostal.AppendChild(NodoPais)
            End If

            If Length(drv.Row("DomicilioDeudor")) > 0 Then
                Dim NodoDirTexto As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_DIRECCION_LIBRE, String.Empty)
                ValorCampo = New DataCampoRegistro("Dirección Deudor", Nothing, False, enumTipoCampo.Alfanumerico, 70, drv.Row("DomicilioDeudor") & String.Empty, Nothing, Nothing)
                NodoDirTexto.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoDirPostal.AppendChild(NodoDirTexto)
            End If


            'Dim NodoDeudorID As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_ID, String.Empty)
            'NodoDeudor.AppendChild(NodoDeudorID)

            'Dim NodoDeudorPersJuridica As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_PERSONA_JURIDICA, String.Empty)
            'NodoDeudorID.AppendChild(NodoDeudorPersJuridica)

            'Dim NodoDeudorBIC As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_BIC, String.Empty)
            'NodoDeudorPersJuridica.AppendChild(NodoDeudorBIC)

            'Dim NodoDeudorOtra As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_Otra, String.Empty)
            'NodoDeudorPersJuridica.AppendChild(NodoDeudorOtra)

            'Dim NodoDeudorOtraID As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_DEUDOR_ID_DEUDOR, String.Empty)
            'NodoDeudorOtra.AppendChild(NodoDeudorOtraID)


            '// ------------------------------  Cuenta del Deudor  ------------------------------------

            Dim NodoCtaDeudor As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_CTA_DEUDOR_NODO, String.Empty)
            NodoAdeudo.AppendChild(NodoCtaDeudor)

            Dim NodoCtaDeudorID As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_CTA_DEUDOR_ID, String.Empty)
            NodoCtaDeudor.AppendChild(NodoCtaDeudorID)


            Dim NodoCtaDeudorIBAN As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_CTA_DEUDOR_IBAN, String.Empty)
            ValorCampo = New DataCampoRegistro("Código IBAN Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 34, drv.Row("CodigoIBAN"), Nothing, Nothing)
            NodoCtaDeudorIBAN.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
            NodoCtaDeudorID.AppendChild(NodoCtaDeudorIBAN)

            '// ------------------------------  Concepto ------------------------------------
            If Length(drv.Row("Concepto")) > 0 Then
                Dim NodoConcepto As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_CONCEPTO, String.Empty)
                NodoAdeudo.AppendChild(NodoConcepto)

                Dim NodoTextoConcepto As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_008_001_02.ADEUDO_INDV_CONCEPTO_NO_ESTRUC, String.Empty)
                ValorCampo = New DataCampoRegistro("Concepto", Nothing, False, enumTipoCampo.Alfanumerico, 140, drv.Row("Concepto") & String.Empty, Nothing, Nothing)
                NodoTextoConcepto.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoConcepto.AppendChild(NodoTextoConcepto)
            End If
        Next

    End Sub

End Class