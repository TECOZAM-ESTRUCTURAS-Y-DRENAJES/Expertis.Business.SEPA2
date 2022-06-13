#Region " Constantes Modelo PAIN_001_001_03 "

Public Module FORMATOS_PAIN_001_001_03
    Public ISODateLong As String = "yyyy-MM-ddThh:mm:ss"
    Public ISODateShort As String = "yyyy-MM-dd"
    Public Numerico As String = "#,##0.00"
End Module

Public Module ETIQUETAS_PAIN_001_001_03
    Public RAIZ As String = "CstmrCdtTrfInitn"

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

    'SERGIO.IBIS -21/02/2019
    Public INF_PAGO_CONCEPTO_TRANSF As String = "CtgyPurp"

    Public INF_PAGO_INSTRUMENTO_LOCAL As String = "LclInstrm"
    Public INF_PAGO_CODIGO As String = "Cd"
    'Public INF_PAGO_TIPO_SECUENCIA As String = "SeqTp"
    Public INF_PAGO_FECHA_PAGO As String = "ReqdExctnDt"
    Public INF_PAGO_DEUDOR As String = "Dbtr"
    Public INF_PAGO_DEUDOR_NOMBRE As String = "Nm"
    Public INF_PAGO_DIRECCION_POSTAL As String = "PstlAdr"
    Public INF_PAGO_PAIS As String = "Ctry"
    Public INF_PAGO_DIRECCION_LIBRE As String = "AdrLine"

    Public INF_PAGO_CTA_DEUDOR As String = "DbtrAcct"
    Public INF_PAGO_CTA_ID As String = "Id"
    Public INF_PAGO_CTA_IBAN As String = "IBAN"
    Public INF_PAGO_CTA_MONEDA As String = "Ccy"
    Public INF_PAGO_ENTIDAD_DEUDOR As String = "DbtrAgt"
    Public INF_PAGO_ENTIDAD_DEUDOR_ID As String = "FinInstnId"
    Public INF_PAGO_ENTIDAD_DEUDOR_BIC As String = "BIC"
    Public INF_PAGO_ENTIDAD_DEUDOR_OTRA As String = "Othr"
    Public INF_PAGO_ENTIDAD_DEUDOR_OTRA_ID As String = "Id"

    Public TRANSF_INDV_NODO As String = "CdtTrfTxInf"
    Public TRANSF_INDV_ID As String = "PmtId"
    Public TRANSF_INDV_INSTR_ID As String = "InstrId"
    Public TRANSF_INDV_ID_EXT_A_EXT As String = "EndToEndId"
    Public TRANSF_INDV_IMPORTE As String = "Amt"
    Public TRANSF_INDV_IMPORTE_ORDENADO As String = "InstdAmt"
    Public TRANSF_INDV_MONEDA As String = "Ccy"

    Public TRANSF_INDV_ENTIDAD_ACREEDOR_NODO As String = "CdtrAgt"
    Public TRANSF_INDV_ENTIDAD_ID As String = "FinInstnId"
    Public TRANSF_INDV_ENTIDAD_BIC As String = "BIC"
    'Public TRANSF_INDV_ENTIDAD_OTRA As String = "Othr"
    'Public TRANSF_INDV_ENTIDAD_OTRA_ID As String = "Id"

    Public TRANSF_INDV_ACREEDOR_NODO As String = "Cdtr"
    Public TRANSF_INDV_ACREEDOR_NOMBRE As String = "Nm"
    Public TRANSF_INDV_ACREEDOR_DIRECCION_POSTAL As String = "PstlAdr"
    Public TRANSF_INDV_ACREEDOR_PAIS As String = "Ctry"
    Public TRANSF_INDV_ACREEDOR_DIRECCION_LIBRE As String = "AdrLine"
    Public TRANSF_INDV_ACREEDOR_ID As String = "Id"
    Public TRANSF_INDV_ACREEDOR_PERSONA_JURIDICA As String = "OrgId"
    Public TRANSF_INDV_ACREEDOR_BIC As String = "BICOrBEI"
    Public TRANSF_INDV_ACREEDOR_Otra As String = "Othr"
    Public TRANSF_INDV_ACREEDOR_ID_ACREEDOR As String = "Id"
    Public TRANSF_INDV_CTA_ACREEDOR_NODO As String = "CdtrAcct"
    Public TRANSF_INDV_CTA_ACREEDOR_ID As String = "Id"
    Public TRANSF_INDV_CTA_ACREEDOR_IBAN As String = "IBAN"
    Public TRANSF_INDV_CONCEPTO As String = "RmtInf"
    Public TRANSF_INDV_CONCEPTO_NO_ESTRUC As String = "Ustrd"

End Module


Public Module CODIGOS_PAIN_001_001_03
    Public MONEDA_EURO As String = "EUR"
    Public OPERACION As String = "SEPA"
    Public METODO_PAGO_TRF As String = "TRF"
    Public METODO_PAGO_CHK As String = "CHK"
    Public NOT_PROVIDED As String = "NOTPROVIDED"
End Module

#End Region

Public Class Fichero_PAIN_001_001_03

    <Task()> Public Shared Function GenerarFichero(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider) As Byte()
        ProcessServer.ExecuteTask(Of DataGenerarFichero)(AddressOf FicheroCSB34_14.PrepararInfoGeneralFichero, data, services)

        Dim xmlDoc As New Xml.XmlDocument
        ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf ValidacionesBasicas, xmlDoc, services)

        Dim xmlNodoDecla As Xml.XmlDeclaration = xmlDoc.CreateNode(Xml.XmlNodeType.XmlDeclaration, "1.0", Nothing, Nothing)
        xmlNodoDecla.Encoding = "UTF-8"
        xmlDoc.AppendChild(xmlNodoDecla)

        Dim document As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, "Document", String.Empty)
        xmlDoc.AppendChild(document)
        xmlDoc.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
        xmlDoc.DocumentElement.SetAttribute("xmlns", "urn:iso:std:iso:20022:tech:xsd:pain.001.001.03")

        'Nodo raiz
        Dim raiz As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.RAIZ, String.Empty)
        document.AppendChild(raiz)

        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        ProcInfo.OrigenDatosTrans = New DatosTransferencias
        ProcInfo.OrigenDatosTrans.TransSEPA = ProcessServer.ExecuteTask(Of Object, DataTable)(AddressOf GetTransferenciasSEPA, Nothing, services)
        ProcInfo.OrigenDatosTrans.TransOtras = ProcessServer.ExecuteTask(Of Object, DataTable)(AddressOf GetTransferenciasOtras, Nothing, services)
        ProcInfo.OrigenDatosTrans.TransCheque = ProcessServer.ExecuteTask(Of Object, DataTable)(AddressOf GetTransferenciasCheques, Nothing, services)

        ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf CrearNodoCabecera, xmlDoc, services)
        ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf CrearNodoInformacionPagoSEPA, xmlDoc, services)
        ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf CrearNodoInformacionPagoOtras, xmlDoc, services)
        ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf CrearNodoInformacionPagoCheques, xmlDoc, services)

        Dim enc As System.Text.Encoding = System.Text.Encoding.UTF8
        Return enc.GetBytes(xmlDoc.InnerXml)
    End Function

    <Task()> Public Shared Function GetTransferenciasSEPA(ByVal data As Object, ByVal services As ServiceProvider) As DataTable
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()

        'Dim fTransferenciasSEPA As New Filter
        'fTransferenciasSEPA.Add(New GuidFilterItem("IDProcess", ProcInfo.IDProcess))
        'fTransferenciasSEPA.Add(New BooleanFilterItem("ChequeTalon", False))
        'fTransferenciasSEPA.Add(New BooleanFilterItem("SEPA", True))

        'Dim ViewName As String = "vSEPA_frmPagosGenerarFichero_34_14"
        'If ProcInfo.LiquidacionGastosObras Then
        '    ViewName = "vSEPA_LiquidacionGastos"
        'End If

        'Return New BE.DataEngine().Filter(ViewName, fTransferenciasSEPA)

        Dim fTransferenciasSEPA As New Filter
        fTransferenciasSEPA.Add(New GuidFilterItem("IDProcess", ProcInfo.IDProcess))
        Dim ViewName As String = "vSEPA_frmPagosGenerarFichero_34_14"
        If ProcInfo.strTipoFichero = "" Then
            fTransferenciasSEPA.Add(New BooleanFilterItem("ChequeTalon", False))
            fTransferenciasSEPA.Add(New BooleanFilterItem("SEPA", True))

            If ProcInfo.LiquidacionGastosObras Then
                ViewName = "vSEPA_LiquidacionGastos"
            End If
        Else
            If ProcInfo.strTipoFichero = "Operario" Then
                ViewName = "vSEPAPagosOperarioXML"
            End If
            'If data.strTipoFichero = "Anticipo" Then
            'ViewName = "vSEPAPagosOperarioAnticipoXML"
            'End If
            'If data.strTipoFichero = "SSocial" Then
            '    ViewName = "vSEPAPagosOperarioSSocialXML"
            'End If
            'If data.strTipoFichero = "Derechos" Then
            '    ViewName = "vSEPAPagosOperarioDerechosXML"
            'End If
            If ProcInfo.strTipoFichero = "PagaExtra" Then
                ViewName = "vSEPAPagosOperarioPagaExtraXML"
            End If
            If ProcInfo.strTipoFichero = "Atraso" Then
                ViewName = "vSEPAPagosOperarioAtrasosXML"
            End If
            If ProcInfo.strTipoFichero = "Pisos" Then
                ViewName = "vSEPAPagosPisosXML"
            End If
        End If

        Return New BE.DataEngine().Filter(ViewName, fTransferenciasSEPA)

    End Function

    <Task()> Public Shared Function GetTransferenciasOtras(ByVal data As Object, ByVal services As ServiceProvider) As DataTable
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()

        Dim fTransferenciasOtras As New Filter
        fTransferenciasOtras.Add(New GuidFilterItem("IDProcess", ProcInfo.IDProcess))
        fTransferenciasOtras.Add(New BooleanFilterItem("ChequeTalon", False))
        fTransferenciasOtras.Add(New BooleanFilterItem("Trasferencia", True))
        fTransferenciasOtras.Add(New BooleanFilterItem("SEPA", False))

        Dim ViewName As String = "vSEPA_frmPagosGenerarFichero_34_14"
        If ProcInfo.LiquidacionGastosObras Then
            ViewName = "vSEPA_LiquidacionGastos"
        End If
        Return New BE.DataEngine().Filter(ViewName, fTransferenciasOtras)
    End Function

    <Task()> Public Shared Function GetTransferenciasCheques(ByVal data As Object, ByVal services As ServiceProvider) As DataTable
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()

        Dim fTransferenciasCheques As New Filter
        fTransferenciasCheques.Add(New GuidFilterItem("IDProcess", ProcInfo.IDProcess))
        fTransferenciasCheques.Add(New BooleanFilterItem("ChequeTalon", True))
        fTransferenciasCheques.Add(New BooleanFilterItem("Trasferencia", True))

        Dim ViewName As String = "vSEPA_frmPagosGenerarFichero_34_14"
        If ProcInfo.LiquidacionGastosObras Then
            ViewName = "vSEPA_LiquidacionGastos"
        End If
        Return New BE.DataEngine().Filter(ViewName, fTransferenciasCheques)
    End Function

    <Task()> Public Shared Sub ValidacionesBasicas(ByVal xmlDoc As Xml.XmlDocument, ByVal services As ServiceProvider)
        Dim datosBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()

        If Length(Trim(datosBanco.CodigoIBAN)) = 0 Then
            ApplicationService.GenerateError("Debe indicar el Código IBAN del Banco Propio. No se generá el fichero.")
        End If

        If Length(Trim(datosBanco.SWIFT)) = 0 Then
            ApplicationService.GenerateError("Debe indicar el Código SWIFT/BIC del Banco Propio. No se generá el fichero.")
        End If

    End Sub

    <Task()> Public Shared Sub CrearNodoCabecera(ByVal xmlDoc As Xml.XmlDocument, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        'If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim datBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()


        Dim lstRaiz As Xml.XmlNodeList = xmlDoc.GetElementsByTagName(ETIQUETAS_PAIN_001_001_03.RAIZ)
        Dim raiz As Xml.XmlNode = lstRaiz.ItemOf(0)

        Dim Cabecera As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_NODO, String.Empty)
        raiz.AppendChild(Cabecera)

        Dim IDFichero As String = ProcessServer.ExecuteTask(Of Object, String)(AddressOf GetIdentificacionFichero, Nothing, services)
        Dim IDMensaje As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_ID_MESSAGE, String.Empty)
        Dim ValorCampo As New DataCampoRegistro("Identificación del Mensaje", Nothing, True, enumTipoCampo.Alfanumerico, 35, IDFichero, Nothing, Nothing)
        IDMensaje.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        Cabecera.AppendChild(IDMensaje)

        Dim FechaCreacion As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_FECHA_HORA_CREACION, String.Empty)
        FechaCreacion.InnerText = Format(Today.Now, FORMATOS_PAIN_001_001_03.ISODateLong)
        Cabecera.AppendChild(FechaCreacion)

        Dim NumeroOperaciones As Integer
        Dim TotalSuma As Double
        If Not ProcInfo.OrigenDatosTrans Is Nothing Then
            If Not ProcInfo.OrigenDatosTrans.TransSEPA Is Nothing Then
                NumeroOperaciones = Nz(ProcInfo.OrigenDatosTrans.TransSEPA.Compute("COUNT(IDPago)", Nothing), 0)
                TotalSuma = CDbl(Nz(ProcInfo.OrigenDatosTrans.TransSEPA.Compute("SUM(ImpVencimientoA)", Nothing), 0))
            End If

            If Not ProcInfo.OrigenDatosTrans.TransOtras Is Nothing Then
                NumeroOperaciones += Nz(ProcInfo.OrigenDatosTrans.TransOtras.Compute("COUNT(IDPago)", Nothing), 0)
                TotalSuma += CDbl(Nz(ProcInfo.OrigenDatosTrans.TransOtras.Compute("SUM(ImpVencimientoA)", Nothing), 0))
            End If

            If Not ProcInfo.OrigenDatosTrans.TransCheque Is Nothing Then
                NumeroOperaciones += Nz(ProcInfo.OrigenDatosTrans.TransCheque.Compute("COUNT(IDPago)", Nothing), 0)
                TotalSuma += CDbl(Nz(ProcInfo.OrigenDatosTrans.TransCheque.Compute("SUM(ImpVencimientoA)", Nothing), 0))
            End If
        End If

        Dim NumOperaciones As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_NUM_OPERACIONES, String.Empty)
        ValorCampo = New DataCampoRegistro("Número Operaciones", Nothing, True, enumTipoCampo.Alfanumerico, 15, NumeroOperaciones, Nothing, Nothing) '//Alfanumérico para que no ponga los decimales
        NumOperaciones.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        Cabecera.AppendChild(NumOperaciones)

        Dim TotalImportes As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_CONTROL_SUMA, String.Empty)
        ValorCampo = New DataCampoRegistro("Control de Suma", Nothing, False, enumTipoCampo.Numerico, 18, TotalSuma, Nothing, Nothing)
        TotalImportes.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        Cabecera.AppendChild(TotalImportes)


        Dim PresentadorInfo As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_PARTE_INICIADORA, String.Empty)
        Cabecera.AppendChild(PresentadorInfo)

        Dim PresentadorNombre As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_NOMBRE, String.Empty)
        ValorCampo = New DataCampoRegistro("Nombre Presentador", Nothing, True, enumTipoCampo.Alfanumerico, 70, datOrdenante.Nombre, Nothing, Nothing)
        PresentadorNombre.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        PresentadorInfo.AppendChild(PresentadorNombre)

        Dim PresentadorID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_IDENTIFICACION, String.Empty)
        PresentadorInfo.AppendChild(PresentadorID)

        Dim PerJuridica As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_PERSONA_JURIDICA, String.Empty)
        PresentadorID.AppendChild(PerJuridica)

        'Dim BIC As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_BIC, String.Empty)
        'BIC.Value = BIC
        'PerJuridica.AppendChild(BIC)

        Dim OtraID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_Otra, String.Empty)
        PerJuridica.AppendChild(OtraID)

        Dim IDAcreedor As String = ProcessServer.ExecuteTask(Of Object, String)(AddressOf FicherosGeneral.GetIdentificacionAcreedor, Nothing, services)
        datOrdenante.IDAcreedor = IDAcreedor
        Dim IDAcreeedor As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_IDENTIFICACION, String.Empty)
        ValorCampo = New DataCampoRegistro("Identificador del Presentador", Nothing, False, enumTipoCampo.Alfanumerico, 12, datOrdenante.NIF + datBanco.SufijoRemesas, Nothing, Nothing)
        IDAcreeedor.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
        OtraID.AppendChild(IDAcreeedor)
    End Sub

   
    <Task()> Public Shared Sub ValidacionesCuentasBancarias(ByVal data As Object, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        Dim PagosSinIDCuenta As List(Of DataRow) = (From c In CType(ProcInfo.OrigenDatos, DataTable) _
                                                     Where c.IsNull("CodigoIBAN")).ToList()

        If Not PagosSinIDCuenta Is Nothing AndAlso PagosSinIDCuenta.Count > 0 Then
            ApplicationService.GenerateError("Existen Pagos en los que la Cuenta Bancaria no está identificada. Revise sus datos.")
        End If

        Dim PagosSinSWIFT As List(Of DataRow) = (From c In CType(ProcInfo.OrigenDatos, DataTable) _
                                           Where c.IsNull("SWIFT")).ToList()

        If PagosSinSWIFT.Count > 0 Then
            ApplicationService.GenerateError("Existen registros sin Código SWIFT/BIC. Revise sus datos.")
        End If
    End Sub

    <Task()> Public Shared Sub CrearNodoInformacionPagoSEPA(ByVal xmlDoc As Xml.XmlDocument, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        ProcInfo.TipoFichero = enumTipoFicheroXMLSEPA.TransferenciasSEPA


        Dim dtPagos As DataTable = ProcInfo.OrigenDatosTrans.TransSEPA
        If Not dtPagos Is Nothing Then
            Dim PagosTrasferencia As List(Of DataRow) = (From c In dtPagos _
                                                        Where c.IsNull("Trasferencia") Or c("Trasferencia") = False).ToList()

            If Not PagosTrasferencia Is Nothing AndAlso PagosTrasferencia.Count > 0 Then
                ApplicationService.GenerateError("Existen Pagos cuya Forma de Pago no tiene activa la marca de Trasferencia. Revise sus datos.")
            End If
            Dim PagosChequeTalon As List(Of DataRow) = (From c In dtPagos _
                                                    Where c.IsNull("ChequeTalon") Or c("ChequeTalon") = True).ToList()

            If Not PagosChequeTalon Is Nothing AndAlso PagosChequeTalon.Count > 0 Then
                ApplicationService.GenerateError("Existen Pagos cuya Forma de Pago tiene activa la marca de ChequeTalon. Revise sus datos.")
            End If
            ProcInfo.OrigenDatos = dtPagos.Copy

            ProcessServer.ExecuteTask(Of Object)(AddressOf ValidacionesCuentasBancarias, Nothing, services)
        End If
        If Not ProcInfo.OrigenDatos Is Nothing AndAlso ProcInfo.OrigenDatos.Rows.Count > 0 Then
            ProcessServer.ExecuteTask(Of Object)(AddressOf AsignarConceptoPagos, Nothing, services)

            ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf CrearNodoInformacionPago, xmlDoc, services)

        End If
    End Sub

    <Task()> Public Shared Sub CrearNodoInformacionPagoOtras(ByVal xmlDoc As Xml.XmlDocument, ByVal services As ServiceProvider)

        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        ProcInfo.TipoFichero = enumTipoFicheroXMLSEPA.TransferenciasOtras
        If Not ProcInfo.OrigenDatos Is Nothing Then ProcInfo.OrigenDatos.Rows.Clear()
      
        Dim dtPagos As DataTable = ProcInfo.OrigenDatosTrans.TransOtras
        If Not dtPagos Is Nothing Then
            ProcInfo.OrigenDatos = dtPagos.Copy

            ProcessServer.ExecuteTask(Of Object)(AddressOf ValidacionesCuentasBancarias, Nothing, services)
        End If
        If Not ProcInfo.OrigenDatos Is Nothing AndAlso ProcInfo.OrigenDatos.Rows.Count > 0 Then
            ProcessServer.ExecuteTask(Of Object)(AddressOf AsignarConceptoPagos, Nothing, services)
            ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf CrearNodoInformacionPago, xmlDoc, services)
        End If

    End Sub

    <Task()> Public Shared Sub AsignarConceptoPagos(ByVal data As Object, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If Not ProcInfo.LiquidacionGastosObras Then
            If Not ProcInfo.OrigenDatos.Columns.Contains("Concepto") Then
                ProcInfo.OrigenDatos.Columns.Add("Concepto", GetType(String))
                ProcInfo.OrigenDatos.Columns("Concepto").ReadOnly = False
            End If
            Dim Concepto As List(Of DataRow) = (From c In ProcInfo.OrigenDatos _
                                                 Where c.IsNull("Concepto")).ToList()
            For Each dr As DataRow In Concepto
                dr("Concepto") = ProcessServer.ExecuteTask(Of DataRow, String)(AddressOf FicheroCSB34_14.GetConceptoPagos, dr, services)
            Next
        End If
    End Sub
    <Task()> Public Shared Sub CrearNodoInformacionPagoCheques(ByVal xmlDoc As Xml.XmlDocument, ByVal services As ServiceProvider)

        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        ProcInfo.TipoFichero = enumTipoFicheroXMLSEPA.TransferenciasCheque
        If Not ProcInfo.OrigenDatos Is Nothing Then ProcInfo.OrigenDatos.Rows.Clear()
      
        Dim dtPagos As DataTable = ProcInfo.OrigenDatosTrans.TransCheque
        If Not dtPagos Is Nothing Then
            ProcInfo.OrigenDatos = dtPagos.Copy

            ProcessServer.ExecuteTask(Of Object)(AddressOf ValidacionesCheques, Nothing, services)
        End If
        If Not ProcInfo.OrigenDatos Is Nothing AndAlso ProcInfo.OrigenDatos.Rows.Count > 0 Then
            ProcessServer.ExecuteTask(Of Object)(AddressOf AsignarConceptoPagos, Nothing, services)

            ProcessServer.ExecuteTask(Of Xml.XmlDocument)(AddressOf CrearNodoInformacionPago, xmlDoc, services)
        End If
    End Sub
    <Task()> Public Shared Sub ValidacionesCheques(ByVal data As Object, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        Dim PagosSinNombreBfo As List(Of DataRow) = (From c In CType(ProcInfo.OrigenDatos, DataTable) _
                                                              Where c.IsNull("DescBeneficiario")).ToList()

        If Not PagosSinNombreBfo Is Nothing AndAlso PagosSinNombreBfo.Count > 0 Then
            ApplicationService.GenerateError("Existen Pagos en los que no se ha especificado el nombre del beneficiario. Revise sus datos.")
        End If
    End Sub

    <Task()> Public Shared Function GetLongitudNombre(ByVal data As Object, ByVal services As ServiceProvider) As Integer
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        Dim LongNombre As Integer = 70
        Select Case ProcInfo.TipoFichero
            Case enumTipoFicheroXMLSEPA.TransferenciasCheque, enumTipoFicheroXMLSEPA.TransferenciasOtras
                LongNombre = 35
        End Select
        Return LongNombre
    End Function

    <Task()> Public Shared Function GetLongitudDireccion(ByVal data As Object, ByVal services As ServiceProvider) As Integer
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        Dim LongNombre As Integer = 70
        Select Case ProcInfo.TipoFichero
            Case enumTipoFicheroXMLSEPA.TransferenciasCheque, enumTipoFicheroXMLSEPA.TransferenciasOtras
                LongNombre = 50
        End Select
        Return LongNombre
    End Function


    <Task()> Public Shared Sub CrearNodoInformacionPago(ByVal xmlDoc As Xml.XmlDocument, ByVal services As ServiceProvider)

        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim datBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()

        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim lstRaiz As Xml.XmlNodeList = xmlDoc.GetElementsByTagName(ETIQUETAS_PAIN_001_001_03.RAIZ)
        Dim raiz As Xml.XmlNode = lstRaiz.ItemOf(0)


        Dim blnPorFechaVencimiento As Boolean = False
        Dim FechasVencimientos As List(Of Object)
        If Nz(ProcInfo.FechaEmision, cnMinDate) = cnMinDate Then
            FechasVencimientos = (From c In ProcInfo.OrigenDatos Order By c("FechaVencimiento") Select c("FechaVencimiento") Distinct).ToList
            blnPorFechaVencimiento = True
        Else
            FechasVencimientos = New List(Of Object)
            FechasVencimientos.Add(ProcInfo.FechaEmision)
        End If

        Dim cont As Integer = 0
        If Not FechasVencimientos Is Nothing AndAlso FechasVencimientos.Count > 0 Then
            For Each FechaCargo As Date In FechasVencimientos

                Dim NodoPagos As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_NODO, String.Empty)
                raiz.AppendChild(NodoPagos)


                '//--------------------------------------------------- Nodo Pagos: Información General ---------------------------------------------
                Dim ID As Integer
                Select Case ProcInfo.TipoFichero
                    Case enumTipoFicheroXMLSEPA.TransferenciasSEPA
                        ID = 1
                    Case enumTipoFicheroXMLSEPA.TransferenciasOtras
                        ID = 2
                    Case enumTipoFicheroXMLSEPA.TransferenciasCheque
                        ID = 3
                End Select
                cont += 1

                Dim Identificacion As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_ID, String.Empty)
                Dim ValorCampo As New DataCampoRegistro("Identificador del Pago", Nothing, True, enumTipoCampo.Alfanumerico, 35, ETIQUETAS_PAIN_001_001_03.INF_PAGO_ID & ID & cont, Nothing, Nothing)
                Identificacion.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoPagos.AppendChild(Identificacion)

                Dim Metodo As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_METODO, String.Empty)
                Select Case ProcInfo.TipoFichero
                    Case enumTipoFicheroXMLSEPA.TransferenciasCheque
                        ValorCampo = New DataCampoRegistro("Método de Pago", Nothing, True, enumTipoCampo.Alfanumerico, 3, CODIGOS_PAIN_001_001_03.METODO_PAGO_CHK, Nothing, Nothing)
                    Case Else
                        ValorCampo = New DataCampoRegistro("Método de Pago", Nothing, True, enumTipoCampo.Alfanumerico, 3, CODIGOS_PAIN_001_001_03.METODO_PAGO_TRF, Nothing, Nothing)
                End Select

                Metodo.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoPagos.AppendChild(Metodo)

                Dim NumeroOperaciones As Integer = 0
                Dim TotalSuma As Double = 0

                If blnPorFechaVencimiento Then
                    Dim fFechaVto As New Filter
                    fFechaVto.Add(New DateFilterItem("FechaVencimiento", FechaCargo))
                    Dim whereFechaCargo As String = fFechaVto.Compose(New AdoFilterComposer)
                    NumeroOperaciones = ProcInfo.OrigenDatos.Compute("COUNT(IDPago)", whereFechaCargo)
                    TotalSuma = ProcInfo.OrigenDatos.Compute("SUM(ImpVencimientoA)", whereFechaCargo)
                Else
                    NumeroOperaciones = ProcInfo.OrigenDatos.Compute("COUNT(IDPago)", Nothing)
                    TotalSuma = ProcInfo.OrigenDatos.Compute("SUM(ImpVencimientoA)", Nothing)
                End If

                'TotalSuma += ProcInfo.OrigenDatos.Compute("SUM(ARepercutirA)", Where)

                Dim NumOps As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_NUM_OPERACIONES, String.Empty)
                ValorCampo = New DataCampoRegistro("Número de Operaciones", Nothing, False, enumTipoCampo.Alfanumerico, 15, NumeroOperaciones, Nothing, Nothing)
                NumOps.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoPagos.AppendChild(NumOps)

                Dim CtrlSuma As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_CONTROL_SUMA, String.Empty)
                ValorCampo = New DataCampoRegistro("Control de Suma", Nothing, False, enumTipoCampo.Numerico, 18, TotalSuma, Nothing, Nothing)
                CtrlSuma.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoPagos.AppendChild(CtrlSuma)

                Select Case ProcInfo.TipoFichero
                    Case enumTipoFicheroXMLSEPA.TransferenciasSEPA

                        Dim InfoTipoPago As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_INFO_TIPO_PAGO, String.Empty)
                        NodoPagos.AppendChild(InfoTipoPago)

                        Dim NivelSrv As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_NIVEL_SERVICIO, String.Empty)
                        InfoTipoPago.AppendChild(NivelSrv)

                        Dim NivelSrvCod As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_NIVEL_SERVICIO_COD, String.Empty)
                        NivelSrvCod.InnerText = CODIGOS_PAIN_001_001_03.OPERACION '//SEPA
                        NivelSrv.AppendChild(NivelSrvCod)

                        'SERGIO.IBIS - 21/02/2019
                        If ProcInfo.strTipoFichero <> "" And ProcInfo.strTipoFichero <> "Pisos" Then
                            Dim NivelSrv2 As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_CONCEPTO_TRANSF, String.Empty)
                            InfoTipoPago.AppendChild(NivelSrv2)

                            Dim NivelSrvCod2 As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_NIVEL_SERVICIO_COD, String.Empty)
                            NivelSrvCod2.InnerText = "SALA"
                            NivelSrv2.AppendChild(NivelSrvCod2)
                        End If
                        'FIN
                End Select

                '// -------------- Nodo Pagos: Datos Comunes de los Pagos (FechaPago, Info Deudor (cuentas, entidad,....)) ----------------------
                Dim xmlFechaCobro As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_FECHA_PAGO, String.Empty)
                ValorCampo = New DataCampoRegistro("Fecha de Ejecución Solicitada", Nothing, False, enumTipoCampo.Fecha, 10, FechaCargo, FORMATOS_PAIN_001_001_03.ISODateShort, Nothing)
                xmlFechaCobro.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoPagos.AppendChild(xmlFechaCobro)


                '//--------- Info Deudor
                Dim DeudorInfo As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_DEUDOR, String.Empty)
                NodoPagos.AppendChild(DeudorInfo)

                Dim DeudorNombre As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_DEUDOR_NOMBRE, String.Empty)
                Dim LongNombre As Integer = ProcessServer.ExecuteTask(Of Object, Integer)(AddressOf GetLongitudNombre, Nothing, services)
                ValorCampo = New DataCampoRegistro("Nombre Deudor", Nothing, True, enumTipoCampo.Alfanumerico, LongNombre, datOrdenante.Nombre, Nothing, Nothing)
                DeudorNombre.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                DeudorInfo.AppendChild(DeudorNombre)

                Dim DeudorDirPostal As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_DIRECCION_POSTAL, String.Empty)

                Dim DeudorPais As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_PAIS, String.Empty)
                ValorCampo = New DataCampoRegistro("Código ISO Pais", Nothing, True, enumTipoCampo.Alfanumerico, 2, datOrdenante.ISOPais, Nothing, Nothing)
                DeudorPais.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                DeudorDirPostal.AppendChild(DeudorPais)

                Dim DeudorDirTexto As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_DIRECCION_LIBRE, String.Empty)
                Dim LongDir As Integer = ProcessServer.ExecuteTask(Of Object, Integer)(AddressOf GetLongitudDireccion, Nothing, services)
                ValorCampo = New DataCampoRegistro("Dirección Deudor", Nothing, True, enumTipoCampo.Alfanumerico, LongDir, datOrdenante.Direccion, Nothing, Nothing)
                DeudorDirTexto.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                DeudorDirPostal.AppendChild(DeudorDirTexto)

                Select Case ProcInfo.TipoFichero
                    Case enumTipoFicheroXMLSEPA.TransferenciasOtras, enumTipoFicheroXMLSEPA.TransferenciasCheque
                        If Length(datOrdenante.Direccion) > LongDir Then
                            Dim DireccionCompl As String = Strings.Mid(datOrdenante.Direccion, LongDir + 1, LongDir)
                            If Length(DireccionCompl) > 0 Then
                                Dim DeudorDirTextoCompl As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_DIRECCION_LIBRE, String.Empty)
                                ValorCampo = New DataCampoRegistro("Dirección Deudor", Nothing, True, enumTipoCampo.Alfanumerico, LongDir, DireccionCompl, Nothing, Nothing)
                                DeudorDirTextoCompl.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                                DeudorDirPostal.AppendChild(DeudorDirTextoCompl)
                            End If
                        End If
                End Select

                DeudorInfo.AppendChild(DeudorDirPostal)


                Dim PresentadorID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_IDENTIFICACION, String.Empty)
                DeudorInfo.AppendChild(PresentadorID)

                Dim PerJuridica As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_PERSONA_JURIDICA, String.Empty)
                PresentadorID.AppendChild(PerJuridica)

                'Dim BIC As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_BIC, String.Empty)
                'BIC.Value = BIC
                'PerJuridica.AppendChild(BIC)

                Dim OtraID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_Otra, String.Empty)
                PerJuridica.AppendChild(OtraID)

                Dim IDAcreedor As String = ProcessServer.ExecuteTask(Of Object, String)(AddressOf FicherosGeneral.GetIdentificacionAcreedor, Nothing, services)
                datOrdenante.IDAcreedor = IDAcreedor
                Dim IDAcreeedor As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.CAB_IDENTIFICACION, String.Empty)
                ValorCampo = New DataCampoRegistro("Identificador del Presentador", Nothing, False, enumTipoCampo.Alfanumerico, 12, datOrdenante.NIF + datBanco.SufijoRemesas, Nothing, Nothing)
                IDAcreeedor.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                OtraID.AppendChild(IDAcreeedor)


                '//--------- Cuenta Deudor

                Dim DeudorInfoCta As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_CTA_DEUDOR, String.Empty)
                NodoPagos.AppendChild(DeudorInfoCta)

                Dim DeudorInfoCtaID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_CTA_ID, String.Empty)
                DeudorInfoCta.AppendChild(DeudorInfoCtaID)

                Dim DeudorInfoCtaIBAN As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_CTA_IBAN, String.Empty)
                ValorCampo = New DataCampoRegistro("Código IBAN Deudor", Nothing, True, enumTipoCampo.Alfanumerico, 34, datBanco.CodigoIBAN, Nothing, Nothing)
                DeudorInfoCtaIBAN.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                DeudorInfoCtaID.AppendChild(DeudorInfoCtaIBAN)

                'Dim DeudorInfoCtaMon As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_CTA_MONEDA, String.Empty)
                'DeudorInfoCtaMon.InnerText = ""
                'DeudorInfoCta.AppendChild(DeudorInfoCtaMon)


                '//--------- Entidad Deudor  (NODO 2.21)
                Dim DeudorInfoEntidad As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_ENTIDAD_DEUDOR, String.Empty)
                NodoPagos.AppendChild(DeudorInfoEntidad)

                Dim DeudorInfoEntidadID As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_ENTIDAD_DEUDOR_ID, String.Empty)
                DeudorInfoEntidad.AppendChild(DeudorInfoEntidadID)

                Dim DeudorInfoCtaBIC As Xml.XmlNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.INF_PAGO_ENTIDAD_DEUDOR_BIC, String.Empty)
                ValorCampo = New DataCampoRegistro("Código SWIFT Deudor", Nothing, True, enumTipoCampo.Alfanumerico, 11, datBanco.SWIFT, Nothing, Nothing)
                DeudorInfoCtaBIC.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                DeudorInfoEntidadID.AppendChild(DeudorInfoCtaBIC)


                Dim datTransf As New DataCrearNodosTransferenciasIndividuales(xmlDoc, Nothing, NodoPagos, blnPorFechaVencimiento, FechaCargo)
                ProcessServer.ExecuteTask(Of DataCrearNodosTransferenciasIndividuales)(AddressOf CrearNodosTransferenciasIndividuales, datTransf, services)
            Next
        End If
    End Sub

    Public Class DataCrearNodosTransferenciasIndividuales
        Public xmlDoc As Xml.XmlDocument
        Public Row As DataRow
        Public NodoPadre As Xml.XmlNode
        Public PorFechaVencimiento As Boolean
        Public FechaCargo As Date

        Public Sub New(ByVal xmlDoc As Xml.XmlDocument, ByVal Row As DataRow, ByVal NodoPadre As Xml.XmlNode, ByVal PorFechaVencimiento As Boolean, ByVal FechaCargo As Date)
            Me.xmlDoc = xmlDoc
            Me.Row = Row
            Me.NodoPadre = NodoPadre
            Me.PorFechaVencimiento = PorFechaVencimiento
            Me.FechaCargo = FechaCargo
        End Sub
    End Class

    <Task()> Public Shared Sub CrearNodosTransferenciasIndividuales(ByVal data As DataCrearNodosTransferenciasIndividuales, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim NodoPagos As Xml.XmlNode = data.NodoPadre

        Dim lstPagos As List(Of DataRow)
        If data.PorFechaVencimiento Then
            lstPagos = (From c In CType(ProcInfo.OrigenDatos, DataTable) Where c("FechaVencimiento") = data.FechaCargo Order By c("FechaVencimiento"), c("ImpVencimientoA") Select c).ToList
        Else
            lstPagos = (From c In CType(ProcInfo.OrigenDatos, DataTable) Order By c("FechaVencimiento"), c("ImpVencimientoA") Select c).ToList
        End If
        For Each dr As DataRow In lstPagos
            Dim NodoTransf As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_NODO, String.Empty)
            NodoPagos.AppendChild(NodoTransf)


            '// ------------------------  Identificación del Pago  ----------------------------------------------
            Dim NodoInfoPago As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ID, String.Empty)
            NodoTransf.AppendChild(NodoInfoPago)


            Dim IDPago As String
            Select Case ProcInfo.TipoFichero
                Case enumTipoFicheroXMLSEPA.TransferenciasCheque
                    Dim NodoInstrPago As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_INSTR_ID, String.Empty)
                    IDPago = dr("IDPago") & String.Empty
                    Dim ValorCampoID As New DataCampoRegistro("Identificación de la Instrucción", Nothing, False, enumTipoCampo.Alfanumerico, 35, IDPago, Nothing, Nothing)
                    NodoInstrPago.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampoID, services)
                    NodoInfoPago.AppendChild(NodoInstrPago)
            End Select


            Dim NodoIDPago As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ID_EXT_A_EXT, String.Empty)
            IDPago = String.Empty
            Select Case ProcInfo.TipoFichero
                Case enumTipoFicheroXMLSEPA.TransferenciasSEPA
                    IDPago = dr("IDPago") & String.Empty
                Case enumTipoFicheroXMLSEPA.TransferenciasOtras
                    IDPago = dr("IDPago") & String.Empty
                Case enumTipoFicheroXMLSEPA.TransferenciasCheque
                    IDPago = CODIGOS_PAIN_001_001_03.NOT_PROVIDED
            End Select

            Dim ValorCampo As New DataCampoRegistro("Identificación de Extremo a Extremo", Nothing, False, enumTipoCampo.Alfanumerico, 35, IDPago, Nothing, Nothing)
            NodoIDPago.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
            NodoInfoPago.AppendChild(NodoIDPago)

            '// ------------------------------  Importe  ----------------------------------------------
            Dim NodoImporte As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_IMPORTE, String.Empty)
            NodoTransf.AppendChild(NodoImporte)

            Dim Importe As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_IMPORTE_ORDENADO, String.Empty)
            Dim atr As Xml.XmlAttribute = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Attribute, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_MONEDA, Nothing)
            atr.Value = CODIGOS_PAIN_001_001_03.MONEDA_EURO
            Importe.Attributes.Append(atr)

            Dim ImportePago As Double = Nz(dr("ImpVencimientoA"), 0)
            ValorCampo = New DataCampoRegistro("Importe Pago", Nothing, False, enumTipoCampo.Numerico, 18, ImportePago, Nothing, Nothing)
            Importe.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
            NodoImporte.AppendChild(Importe)

            Select Case ProcInfo.TipoFichero
                Case enumTipoFicheroXMLSEPA.TransferenciasSEPA, enumTipoFicheroXMLSEPA.TransferenciasOtras
                    '// ------------------------------  Entidad del Acreedor (NODO 2.77) ------------------------------------
                    Dim NodoEntidad As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ENTIDAD_ACREEDOR_NODO, String.Empty)
                    NodoTransf.AppendChild(NodoEntidad)

                    Dim NodoEntidadID As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ENTIDAD_ID, String.Empty)
                    NodoEntidad.AppendChild(NodoEntidadID)

                    Dim NodoEntidadBIC As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ENTIDAD_BIC, String.Empty)
                    ValorCampo = New DataCampoRegistro("Código SWIFT/BIC Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 11, dr("Swift"), Nothing, Nothing)
                    NodoEntidadBIC.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    NodoEntidadID.AppendChild(NodoEntidadBIC)
            End Select

            '// ------------------------------  Acreedor  ------------------------------------

            Dim NodoAcreedor As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ACREEDOR_NODO, String.Empty)
            NodoTransf.AppendChild(NodoAcreedor)

            If Length(dr("DescBeneficiario")) > 0 Then
                Dim NodoAcreedorNombre As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ACREEDOR_NOMBRE, String.Empty)
                Dim LongNombre As Integer = ProcessServer.ExecuteTask(Of Object, Integer)(AddressOf GetLongitudNombre, Nothing, services)
                ValorCampo = New DataCampoRegistro("Nombre Acreedor", Nothing, False, enumTipoCampo.Alfanumerico, LongNombre, dr("DescBeneficiario") & String.Empty, Nothing, Nothing)
                NodoAcreedorNombre.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoAcreedor.AppendChild(NodoAcreedorNombre)
            End If

            Dim NodoDirPostal As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ACREEDOR_DIRECCION_POSTAL, String.Empty)
            NodoAcreedor.AppendChild(NodoDirPostal)

            If Length(dr("ISOPais")) > 0 Then
                Dim NodoPais As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ACREEDOR_PAIS, String.Empty)
                ValorCampo = New DataCampoRegistro("Pais Acreedor", Nothing, False, enumTipoCampo.Alfanumerico, 2, UCase(dr("ISOPais") & String.Empty), Nothing, Nothing)
                NodoPais.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoDirPostal.AppendChild(NodoPais)
            End If

            If Length(dr("DireccionPago")) > 0 Then
                Dim NodoDirTexto As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ACREEDOR_DIRECCION_LIBRE, String.Empty)
                Dim LongDir As Integer = ProcessServer.ExecuteTask(Of Object, Integer)(AddressOf GetLongitudDireccion, Nothing, services)
                ValorCampo = New DataCampoRegistro("Dirección Acreedor", Nothing, False, enumTipoCampo.Alfanumerico, LongDir, dr("DireccionPago") & String.Empty, Nothing, Nothing)
                NodoDirTexto.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoDirPostal.AppendChild(NodoDirTexto)


                Select Case ProcInfo.TipoFichero
                    Case enumTipoFicheroXMLSEPA.TransferenciasOtras, enumTipoFicheroXMLSEPA.TransferenciasCheque
                        If Length(dr("DireccionPago") & String.Empty) > LongDir Then
                            Dim DireccionCompl As String = Strings.Mid(dr("DireccionPago") & String.Empty, LongDir + 1, LongDir)
                            If Length(DireccionCompl) > 0 Then
                                Dim NodoDirTextoCompl As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_ACREEDOR_DIRECCION_LIBRE, String.Empty)
                                ValorCampo = New DataCampoRegistro("Dirección Acreedor", Nothing, False, enumTipoCampo.Alfanumerico, LongDir, DireccionCompl, Nothing, Nothing)
                                NodoDirTextoCompl.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                                NodoDirPostal.AppendChild(NodoDirTextoCompl)
                            End If
                        End If
                End Select
            End If

            Select Case ProcInfo.TipoFichero
                Case enumTipoFicheroXMLSEPA.TransferenciasSEPA, enumTipoFicheroXMLSEPA.TransferenciasOtras

                    '// ------------------------------  Cuenta del Acreedor  ------------------------------------

                    Dim NodoCtaAcreedor As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_CTA_ACREEDOR_NODO, String.Empty)
                    NodoTransf.AppendChild(NodoCtaAcreedor)

                    Dim NodoCtaAcreedorID As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_CTA_ACREEDOR_ID, String.Empty)
                    NodoCtaAcreedor.AppendChild(NodoCtaAcreedorID)


                    Dim NodoCtaAcreedorIBAN As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_CTA_ACREEDOR_IBAN, String.Empty)
                    ValorCampo = New DataCampoRegistro("Código IBAN Acreedor", Nothing, True, enumTipoCampo.Alfanumerico, 34, dr("CodigoIBAN"), Nothing, Nothing)
                    NodoCtaAcreedorIBAN.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                    NodoCtaAcreedorID.AppendChild(NodoCtaAcreedorIBAN)

            End Select

            '// ------------------------------  Concepto ------------------------------------
            If Length(dr("Concepto")) > 0 Then
                Dim NodoConcepto As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_CONCEPTO, String.Empty)
                NodoTransf.AppendChild(NodoConcepto)

                Dim NodoTextoConcepto As Xml.XmlNode = data.xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, ETIQUETAS_PAIN_001_001_03.TRANSF_INDV_CONCEPTO_NO_ESTRUC, String.Empty)
                ValorCampo = New DataCampoRegistro("Concepto", Nothing, False, enumTipoCampo.Alfanumerico, 140, dr("Concepto") & String.Empty, Nothing, Nothing)
                NodoTextoConcepto.InnerText = ProcessServer.ExecuteTask(Of DataCampoRegistro, String)(AddressOf FicherosGeneral.AplicarFormatoCampoXML, ValorCampo, services)
                NodoConcepto.AppendChild(NodoTextoConcepto)
            End If

        Next

    End Sub


#Region " Identificación del Fichero "

    <Task()> Public Shared Function GetIdentificacionFichero(ByVal data As Object, ByVal services As ServiceProvider) As String
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Return Format(Today, FormatosFechas.AAAAMMDD) & Format(Date.Now, FormatosFechas.HHmmssfffff) & datOrdenante.NIF
    End Function

#End Region

End Class