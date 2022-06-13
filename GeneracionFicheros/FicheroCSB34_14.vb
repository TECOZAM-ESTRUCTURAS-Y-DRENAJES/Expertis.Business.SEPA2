#Region " Constantes Modelo CSB34_14 "

Public Module CodigoOperacionCSB34_14
    Public ORDENES_TRANSFERENCIA_EMISION_CHEQUES As String = "ORD"
    Public TRANSFERENCIA_SEPA As String = "SCT"
    Public OTRAS_TRANSFERENCIAS As String = "OTR"
    Public CHEQUES_BANCARIOS_NOMINA As String = "CHQ"
End Module

Public Module NumeroDatoCSB34_14
    Public CABECERA As String = "001"

    Public TRANSFERENCIA_SEPA_TIPO1 As String = "002"
    Public TRANSFERENCIA_SEPA_TIPO2 As String = "003"
    Public TRANSFERENCIA_SEPA_TIPO3 As String = "004"
    Public TRANSFERENCIA_SEPA_TIPO4 As String = "005"

    Public TRANSFERENCIA_OTRAS_TIPO1 As String = "006"
    Public TRANSFERENCIA_OTRAS_TIPO2 As String = "007"

    Public TRANSFERENCIA_CHEQUE_TIPO1 As String = "008"
    Public TRANSFERENCIA_CHEQUE_TIPO2 As String = "009"

End Module

Public Module CodigoRegistroCSB34_14
    Public REG_CABECERA_GENERAL As String = "01"
    Public REG_TOTALES_GENERAL As String = "99"

    Public REG_CABECERA As String = "02"
    Public REG_BENEFICIARIO As String = "03"
    Public REG_TOTALES As String = "04"
End Module

Public Module DetalleCargo
    Public SinDetalle As Integer = 0
    Public ConDetalle As Integer = 1
End Module

Public Module IdentificacionCuenta
    Public IBAN As String = "A"
    Public Otros As String = "B"
End Module

Public Module ClaveGastos
    Public PorCuentaDelOrdenante As Integer = 1
    Public PorCuentaDelBeneficiario As Integer = 2
    Public Compartidos As Integer = 3
End Module

Public Module PropositoTransferenciaCheque
    Public Nomina As Integer = 1
    Public Pension As Integer = 2
    Public OtrosConceptos As Integer = 3
End Module

#End Region

#Region " Definición de Tipos de Datos para los Registros de Totales "

Public Class RegTotalesTransferenciaSEPA
    Inherits RegistroTotales

End Class

Public Class RegTotalesTransferenciaOTRAS
    Inherits RegistroTotales

End Class

Public Class RegTotalesCHEQUES
    Inherits RegistroTotales

End Class

#End Region

Public Class FicheroCSB34_14

    <Task()> Public Shared Function GenerarFichero(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider) As List(Of String)
        services.RegisterService(data, GetType(DataGenerarFichero))
        ProcessServer.ExecuteTask(Of DataGenerarFichero)(AddressOf PrepararInfoGeneralFichero, data, services)

        Dim datFichero As New DataAddRegistroFichero
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroCabeceraGeneral, datFichero, services)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistrosTransferenciasSEPA, datFichero, services)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistrosTransferenciasOtras, datFichero, services)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistrosCheques, datFichero, services)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroTotalesGeneral, datFichero, services)

        Return datFichero.Fichero
    End Function

#Region " Métodos Auxiliares para obtener información del sistema "

    <Task()> Public Shared Sub PrepararInfoGeneralFichero(ByVal data As DataGenerarFichero, ByVal services As ServiceProvider)

        Dim datosBanco As DatosBancoPropioFicheros = ProcessServer.ExecuteTask(Of Object, DatosBancoPropioFicheros)(AddressOf FicherosGeneral.GetDatosBancoPropio, data, services)
        services.RegisterService(datosBanco, GetType(DatosBancoPropioFicheros))

        Dim datosOrdenante As DatosOrdenante = ProcessServer.ExecuteTask(Of Object, DatosOrdenante)(AddressOf FicherosGeneral.GetDatosOrdenante, Nothing, services)
        services.RegisterService(datosOrdenante, GetType(DatosOrdenante))

        Dim ProcInfo As New ProcessInfoFichero
        ProcInfo.IDProcess = data.IDProcess
        ProcInfo.FechaEmision = data.FechaEmision
        ProcInfo.LiquidacionGastosObras = data.LiquidacionGastosObras
        'IBIS. SERGIO - 21/02/19
        ProcInfo.strTipoFichero = data.strTipoFichero
        'FIN
        services.RegisterService(ProcInfo, GetType(ProcessInfoFichero))
    End Sub

#End Region

#Region " Cabecera y Totales "

    <Task()> Public Shared Sub FichCSB34_14_RegistroCabeceraGeneral(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim datBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()

        '//NOTA: Se incluirán en la línea en el orden en que aparezcan en esta lista.
        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_CABECERA_GENERAL))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.ORDENES_TRANSFERENCIA_EMISION_CHEQUES))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB34_14.CABECERA))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante: NIF", String.Empty, True, enumTipoCampo.Alfanumerico, 9, datOrdenante.NIF))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante: Sufijo", String.Empty, True, enumTipoCampo.Alfanumerico, 3, datBanco.SufijoRemesas))
        lstRegistro.Add(New DataCampoRegistro("Fecha de Creación del Fichero", String.Empty, True, enumTipoCampo.Fecha, 8, Today, FormatosFechas.AAAAMMDD))
        lstRegistro.Add(New DataCampoRegistro("Fecha de Ejecución Ordenes (AT-07)", String.Empty, True, enumTipoCampo.Fecha, 8, ProcInfo.FechaEmision, FormatosFechas.AAAAMMDD))
        lstRegistro.Add(New DataCampoRegistro("Identificación de la Cuenta del Ordenante", String.Empty, True, enumTipoCampo.Alfanumerico, 1, IdentificacionCuenta.IBAN))
        lstRegistro.Add(New DataCampoRegistro("Cuenta del Ordenante (AT-01)", String.Empty, True, enumTipoCampo.Alfanumerico, 34, datBanco.CodigoIBAN))
        lstRegistro.Add(New DataCampoRegistro("Detalle del Cargo", String.Empty, True, enumTipoCampo.Numerico, 1, DetalleCargo.SinDetalle))
        lstRegistro.Add(New DataCampoRegistro("Nombre del Ordenante (AT-02)", String.Empty, True, enumTipoCampo.Alfanumerico, 70, datOrdenante.Nombre))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Ordenante (AT-03)", String.Empty, False, enumTipoCampo.Alfanumerico, 50, datOrdenante.Direccion))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Ordenante (AT-03) Cos.Postal - Poblacion", String.Empty, False, enumTipoCampo.Alfanumerico, 50, datOrdenante.CodigoPostal + datOrdenante.Poblacion))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Ordenante (AT-03) Provincia", String.Empty, False, enumTipoCampo.Alfanumerico, 40, datOrdenante.Provincia))
        lstRegistro.Add(New DataCampoRegistro("País del Ordenante (AT-03)", String.Empty, False, enumTipoCampo.Alfanumerico, 2, datOrdenante.ISOPais))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, True, enumTipoCampo.Alfanumerico, 311))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroTotalesGeneral(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim TotSEPA As RegTotalesTransferenciaSEPA = services.GetService(Of RegTotalesTransferenciaSEPA)()
        Dim TotOTRAS As RegTotalesTransferenciaOTRAS = services.GetService(Of RegTotalesTransferenciaOTRAS)()
        Dim TotCHEQUES As RegTotalesCHEQUES = services.GetService(Of RegTotalesCHEQUES)()

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_TOTALES_GENERAL))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.ORDENES_TRANSFERENCIA_EMISION_CHEQUES))
        lstRegistro.Add(New DataCampoRegistro("Total de Importes General", String.Empty, True, enumTipoCampo.Numerico, 17, TotSEPA.TotalImportes + TotOTRAS.TotalImportes + TotCHEQUES.TotalImportes))
        lstRegistro.Add(New DataCampoRegistro("Número de Registros", String.Empty, True, enumTipoCampo.Numerico, 8, TotSEPA.NumRegistros + TotOTRAS.NumRegistros + TotCHEQUES.NumRegistros))
        lstRegistro.Add(New DataCampoRegistro("Total de Registros", String.Empty, True, enumTipoCampo.Numerico, 10, TotSEPA.TotalRegistros + TotOTRAS.TotalRegistros + TotCHEQUES.TotalRegistros + 2)) '// 2 regs más: cabecera + totales
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 560))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

#End Region

#Region " Transferencias SEPA "

    <Task()> Public Shared Sub FichCSB34_14_RegistrosTransferenciasSEPA(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If Not ProcInfo.OrigenDatos Is Nothing Then ProcInfo.OrigenDatos.Rows.Clear()

        Dim fTransferenciasSEPA As New Filter
        fTransferenciasSEPA.Add(New GuidFilterItem("IDProcess", ProcInfo.IDProcess))
        fTransferenciasSEPA.Add(New BooleanFilterItem("SEPA", True))

        Dim ViewName As String = "vSEPA_frmPagosGenerarFichero_34_14"
        If ProcInfo.LiquidacionGastosObras Then
            ViewName = "vSEPA_LiquidacionGastos"
        End If

        Dim dtPagos As DataTable = New BE.DataEngine().Filter(ViewName, fTransferenciasSEPA)
        If Not dtPagos Is Nothing Then
            Dim PagosSinIDCuenta As List(Of DataRow) = (From c In dtPagos _
                                                        Where c.IsNull("CodigoIBAN")).ToList()

            If Not PagosSinIDCuenta Is Nothing AndAlso PagosSinIDCuenta.Count > 0 Then
                ApplicationService.GenerateError("Existen Pagos en los que la Cuenta Bancaria no está identificada. Revise sus datos.")
            End If
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
        End If
        If Not ProcInfo.OrigenDatos Is Nothing AndAlso ProcInfo.OrigenDatos.Rows.Count > 0 Then
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroSEPACabecera, data, services)
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroSEPABeneficiarios, data, services)
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroSEPATotales, data, services)
        End If
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroSEPACabecera(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim datosBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_CABECERA))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.TRANSFERENCIA_SEPA))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante: NIF", String.Empty, True, enumTipoCampo.Alfanumerico, 9, datOrdenante.NIF))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante: Sufijo", String.Empty, True, enumTipoCampo.Alfanumerico, 3, datosBanco.SufijoRemesas))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 578))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
        Dim TotSEPA As RegTotalesTransferenciaSEPA = services.GetService(Of RegTotalesTransferenciaSEPA)()
        TotSEPA.TotalRegistros += 1
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroSEPABeneficiarios(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroSEPABeneficiarios_T1, data, services)
        'ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroSEPABeneficiarios_T2, data, services)
        'ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroSEPABeneficiarios_T3, data, services)
        'ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroSEPABeneficiarios_T4, data, services)
    End Sub

    <Task()> Public Shared Function GetConceptoPagos(ByVal drPago As DataRow, ByVal services As ServiceProvider) As String
        Dim strConcepto As String = String.Empty
        Dim dtParametro As DataTable = New BE.DataEngine().Filter("tbParametro", New StringFilterItem("IDParametro", "FRAPAGOAGR"))
        Dim NPagoAgrupado As String = String.Empty
        If dtParametro.Rows.Count > 0 Then
            NPagoAgrupado = dtParametro.Rows(0)("Valor") & String.Empty
        End If

        If drPago("NFactura") & String.Empty = NPagoAgrupado Then
            '  If drPago("NFactura") = New Parametro().NFacturaPagoAgupado Then ' AppParams.NFacturaPagoAgrupado Then
            Dim lstFras As List(Of Object) = ProcessServer.ExecuteTask(Of Integer, List(Of Object))(AddressOf FicherosGeneral.GetFacturasPagoAgrupado, drPago("IDPago"), services)
            If lstFras.Count > 0 Then strConcepto = "Factura Numero " & Join(lstFras.ToArray, ",")
        Else : strConcepto = "Factura Numero " & drPago("SuFactura")
        End If

        Return strConcepto
    End Function


    <Task()> Public Shared Sub FichCSB34_14_RegistroSEPABeneficiarios_T1(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_BENEFICIARIO))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.TRANSFERENCIA_SEPA))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB34_14.TRANSFERENCIA_SEPA_TIPO1))
        lstRegistro.Add(New DataCampoRegistro("Referencia del Ordenante (AT-41)", "IDPago", False, enumTipoCampo.Alfanumerico, 35))
        lstRegistro.Add(New DataCampoRegistro("Identificador de la Cuenta del Beneficiario", String.Empty, True, enumTipoCampo.Alfanumerico, 1, IdentificacionCuenta.IBAN))
        lstRegistro.Add(New DataCampoRegistro("Cuenta del Beneficiario (AT-20)", "CodigoIBAN", True, enumTipoCampo.Alfanumerico, 34))
        lstRegistro.Add(New DataCampoRegistro("Importe de Transferencia (AT-04)", "ImpVencimientoA", True, enumTipoCampo.Numerico, 11))
        lstRegistro.Add(New DataCampoRegistro("Clave de Gastos", String.Empty, True, enumTipoCampo.Numerico, 1, ClaveGastos.Compartidos))
        lstRegistro.Add(New DataCampoRegistro("BIC Entidad del Beneficiario (AT-23)", "SWIFT", False, enumTipoCampo.Alfanumerico, 11))
        lstRegistro.Add(New DataCampoRegistro("Nombre del Beneficiario (AT-21)", "DescBeneficiario", True, enumTipoCampo.Alfanumerico, 70))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Beneficiario (AT-22)", "DireccionPago", False, enumTipoCampo.Alfanumerico, 50))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Beneficiario (AT-22)", "CodPostal+PoblacionPago", False, enumTipoCampo.Alfanumerico, 50))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Beneficiario (AT-22)", "ProvinciaPago", False, enumTipoCampo.Alfanumerico, 40))
        lstRegistro.Add(New DataCampoRegistro("País del Beneficiario (AT-22)", "ISOPais", False, enumTipoCampo.Alfanumerico, 2))
        lstRegistro.Add(New DataCampoRegistro("Concepto enviado por el Ordenante al Beneficiario (AT-05)", "Concepto", False, enumTipoCampo.Alfanumerico, 140))
        lstRegistro.Add(New DataCampoRegistro("Identificación de la instrucción", String.Empty, False, enumTipoCampo.Alfanumerico, 35, Space(35)))
        lstRegistro.Add(New DataCampoRegistro("Tipo de Transferencia (AT-45)", String.Empty, False, enumTipoCampo.Alfanumerico, 4, Space(4)))
        lstRegistro.Add(New DataCampoRegistro("Propósito de la Transferencia (AT-44)", String.Empty, False, enumTipoCampo.Alfanumerico, 4, Space(4)))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 99))

        Dim TotSEPA As RegTotalesTransferenciaSEPA = services.GetService(Of RegTotalesTransferenciaSEPA)()

        If Not ProcInfo.OrigenDatos.Columns.Contains("Concepto") Then
            ProcInfo.OrigenDatos.Columns.Add("Concepto", GetType(String))
            ProcInfo.OrigenDatos.Columns("Concepto").ReadOnly = False
        End If

        For Each dr As DataRow In ProcInfo.OrigenDatos.Rows
            If Not ProcInfo.LiquidacionGastosObras Then
                dr("Concepto") = ProcessServer.ExecuteTask(Of DataRow, String)(AddressOf GetConceptoPagos, dr, services)
            End If

            lstRegistro.Row = dr

            TotSEPA.NumRegistros += 1
            TotSEPA.TotalImportes += Nz(dr("ImpVencimientoA"), 0)
            TotSEPA.TotalRegistros += 1

            Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
            If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
        Next

    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroSEPABeneficiarios_T2(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        'Dim lstRegistro As New ListaCamposRegistro
        'lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_BENEFICIARIO))
        'lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.TRANSFERENCIA_SEPA))
        'lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        'lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB34_14.TRANSFERENCIA_SEPA_TIPO2))
        'lstRegistro.Add(New DataCampoRegistro("Referencia del Ordenante (AT-41)", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Tipo de Identificación del Ordenante", "", False, enumTipoCampo.Numerico, 1))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante (AT-10). Código - Organización", "", False, enumTipoCampo.Alfanumerico, 36))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante (AT-10). Emisor Código (Otro) - Organización", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante (AT-10). Código - Persona", "", False, enumTipoCampo.Alfanumerico, 36))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante (AT-10). Emisor Código (Otro) - Persona", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Nombre Ultimo Ordenante (AT-08)", "", False, enumTipoCampo.Alfanumerico, 70))
        'lstRegistro.Add(New DataCampoRegistro("Tipo de Identificación del Ultimo Ordenante", "", False, enumTipoCampo.Numerico, 1))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ultimo Ordenante (AT-09). Código - Organización", "", False, enumTipoCampo.Alfanumerico, 36))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ultimo Ordenante (AT-09). Emisor Código (Otro) - Organización", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ultimo Ordenante (AT-09). Código - Persona", "", False, enumTipoCampo.Alfanumerico, 36))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ultimo Ordenante (AT-09). Emisor Código (Otro) - Persona", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Libre", "", False, enumTipoCampo.Alfanumerico, 196))

        ''lstRegistro.Row = RowOrigenDatos

        'Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf GenerarRegistro, lstRegistro, services)
        'If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroSEPABeneficiarios_T3(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        'Dim lstRegistro As New ListaCamposRegistro
        'lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_BENEFICIARIO))
        'lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.TRANSFERENCIA_SEPA))
        'lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        'lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB34_14.TRANSFERENCIA_SEPA_TIPO3))
        'lstRegistro.Add(New DataCampoRegistro("Referencia del Ordenante (AT-41)", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Tipo de Identificación del Beneficiario", "", False, enumTipoCampo.Numerico, 1))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Beneficiario (AT-24). Código - Organización", "", False, enumTipoCampo.Alfanumerico, 36))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Beneficiario (AT-24). Emisor Código (Otro) - Organización", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Beneficiario (AT-24). Código - Persona", "", False, enumTipoCampo.Alfanumerico, 36))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Beneficiario (AT-24). Emisor Código (Otro) - Persona", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Nombre Ultimo Beneficiario (AT-28)", "", False, enumTipoCampo.Alfanumerico, 70))
        'lstRegistro.Add(New DataCampoRegistro("Tipo de Identificación del Ultimo Beneficiario", "", False, enumTipoCampo.Numerico, 1))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ultimo Beneficiario (AT-29). Código - Organización", "", False, enumTipoCampo.Alfanumerico, 36))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ultimo Beneficiario (AT-29). Emisor Código (Otro) - Organización", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ultimo Beneficiario (AT-29). Código - Persona", "", False, enumTipoCampo.Alfanumerico, 36))
        'lstRegistro.Add(New DataCampoRegistro("Identificación del Ultimo Beneficiario (AT-29). Emisor Código (Otro) - Persona", "", False, enumTipoCampo.Alfanumerico, 35))
        'lstRegistro.Add(New DataCampoRegistro("Libre", "", False, enumTipoCampo.Alfanumerico, 196))

        ''lstRegistro.Row = RowOrigenDatos

        'Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf GenerarRegistro, lstRegistro, services)
        'If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroSEPABeneficiarios_T4(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        'Dim lstRegistro As New ListaCamposRegistro
        'lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_BENEFICIARIO))
        'lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.TRANSFERENCIA_SEPA))
        'lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        'lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB34_14.TRANSFERENCIA_SEPA_TIPO4))

        'lstRegistro.Add(New DataCampoRegistro("Libre", "", False, enumTipoCampo.Alfanumerico, 587))

        '' lstRegistro.Row = RowOrigenDatos

        'Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf GenerarRegistro, lstRegistro, services)
        'If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroSEPATotales(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim TotSEPA As RegTotalesTransferenciaSEPA = services.GetService(Of RegTotalesTransferenciaSEPA)()
        TotSEPA.TotalRegistros += 1

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_TOTALES))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.TRANSFERENCIA_SEPA))
        lstRegistro.Add(New DataCampoRegistro("Total de Importes", String.Empty, True, enumTipoCampo.Numerico, 17, TotSEPA.TotalImportes))
        lstRegistro.Add(New DataCampoRegistro("Número de Registros", String.Empty, True, enumTipoCampo.Numerico, 8, TotSEPA.NumRegistros))
        lstRegistro.Add(New DataCampoRegistro("Total de Registros", String.Empty, True, enumTipoCampo.Numerico, 10, TotSEPA.TotalRegistros))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 560))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

#End Region

#Region " Otras Transferencias "

    <Task()> Public Shared Sub FichCSB34_14_RegistrosTransferenciasOtras(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If Not ProcInfo.OrigenDatos Is Nothing Then ProcInfo.OrigenDatos.Rows.Clear()
        Dim fTransferenciasOtras As New Filter
        fTransferenciasOtras.Add(New GuidFilterItem("IDProcess", ProcInfo.IDProcess))
        fTransferenciasOtras.Add(New BooleanFilterItem("ChequeTalon", False))
        fTransferenciasOtras.Add(New BooleanFilterItem("Trasferencia", True))
        fTransferenciasOtras.Add(New BooleanFilterItem("SEPA", False))

        Dim ViewName As String = "vSEPA_frmPagosGenerarFichero_34_14"
        If ProcInfo.LiquidacionGastosObras Then
            ViewName = "vSEPA_LiquidacionGastos"
        End If
        Dim dtPagos As DataTable = New BE.DataEngine().Filter(ViewName, fTransferenciasOtras)
        If Not dtPagos Is Nothing Then
            Dim PagosSinIDCuenta As List(Of DataRow) = (From c In dtPagos _
                                                       Where c.IsNull("CodigoIBAN")).ToList()

            If Not PagosSinIDCuenta Is Nothing AndAlso PagosSinIDCuenta.Count > 0 Then
                ApplicationService.GenerateError("Existen Pagos en los que la Cuenta Bancaria no está identificada. Revise sus datos.")
            End If
            ProcInfo.OrigenDatos = dtPagos.Copy
        End If
        If Not ProcInfo.OrigenDatos Is Nothing AndAlso ProcInfo.OrigenDatos.Rows.Count > 0 Then
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroOtrasCabecera, data, services)
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroOtrasBeneficiarios, data, services)
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroOtrasTotales, data, services)
        End If

    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroOtrasCabecera(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim datosBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_CABECERA))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.OTRAS_TRANSFERENCIAS))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante: NIF", String.Empty, True, enumTipoCampo.Alfanumerico, 9, datOrdenante.NIF))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante: Sufijo", String.Empty, True, enumTipoCampo.Alfanumerico, 3, datosBanco.SufijoRemesas))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 578))


        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)

        Dim TotOTRAS As RegTotalesTransferenciaOTRAS = services.GetService(Of RegTotalesTransferenciaOTRAS)()
        TotOTRAS.TotalRegistros += 1
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroOtrasBeneficiarios(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroOtrasBeneficiarios_T1, data, services)
        ' ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroOtrasBeneficiarios_T2, data, services)
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroOtrasBeneficiarios_T1(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)

        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_BENEFICIARIO))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.OTRAS_TRANSFERENCIAS))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB34_14.TRANSFERENCIA_OTRAS_TIPO1))
        lstRegistro.Add(New DataCampoRegistro("Nombre del Ultimo Ordenante", String.Empty, False, enumTipoCampo.Alfanumerico, 35, datOrdenante.Nombre))
        lstRegistro.Add(New DataCampoRegistro("Identificador de la Cuenta del Beneficiario", String.Empty, True, enumTipoCampo.Alfanumerico, 1, IdentificacionCuenta.IBAN))
        lstRegistro.Add(New DataCampoRegistro("Cuenta del Beneficiario", "CodigoIBAN", True, enumTipoCampo.Alfanumerico, 34))
        lstRegistro.Add(New DataCampoRegistro("Importe de Transferencia ", "ImpVencimientoA", True, enumTipoCampo.Numerico, 11))
        lstRegistro.Add(New DataCampoRegistro("Clave de Gastos", String.Empty, True, enumTipoCampo.Numerico, 1, ClaveGastos.Compartidos))
        lstRegistro.Add(New DataCampoRegistro("BIC Entidad del Beneficiario", "SWIFT", True, enumTipoCampo.Alfanumerico, 11))
        lstRegistro.Add(New DataCampoRegistro("Nombre del Beneficiario", "DescBeneficiario", True, enumTipoCampo.Alfanumerico, 35))
        lstRegistro.Add(New DataCampoRegistro("Dirección y País del Beneficiario)", "DireccionPago+CodPostal+PoblacionPago+ProvinciaPago+ISOPais", False, enumTipoCampo.Alfanumerico, 105))
        lstRegistro.Add(New DataCampoRegistro("Concepto enviado por el Ordenante al Beneficiario", "Concepto", False, enumTipoCampo.Alfanumerico, 72))
        lstRegistro.Add(New DataCampoRegistro("Referencia para el Beneficiario", String.Empty, False, enumTipoCampo.Alfanumerico, 13))
        lstRegistro.Add(New DataCampoRegistro("Propósito de la Transferencia", String.Empty, False, enumTipoCampo.Numerico, 1, PropositoTransferenciaCheque.OtrosConceptos))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 268))

        Dim TotOTRAS As RegTotalesTransferenciaOTRAS = services.GetService(Of RegTotalesTransferenciaOTRAS)()
        If Not ProcInfo.OrigenDatos.Columns.Contains("Concepto") Then
            ProcInfo.OrigenDatos.Columns.Add("Concepto", GetType(String))
            ProcInfo.OrigenDatos.Columns("Concepto").ReadOnly = False
        End If

        For Each dr As DataRow In ProcInfo.OrigenDatos.Rows
            If Not ProcInfo.LiquidacionGastosObras Then
                dr("Concepto") = ProcessServer.ExecuteTask(Of DataRow, String)(AddressOf GetConceptoPagos, dr, services)
            End If
            lstRegistro.Row = dr

            TotOTRAS.NumRegistros += 1
            TotOTRAS.TotalImportes += Nz(dr("ImpVencimientoA"), 0)
            TotOTRAS.TotalRegistros += 1

            Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
            If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
        Next
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroOtrasBeneficiarios_T2(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        'Dim lstRegistro As New ListaCamposRegistro
        'lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_BENEFICIARIO))
        'lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.OTRAS_TRANSFERENCIAS))
        'lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        'lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB34_14.TRANSFERENCIA_OTRAS_TIPO2))
        'lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 587))


        'Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf GenerarRegistro, lstRegistro, services)
        'If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
        'Dim TotOTRAS As RegTotalesTransferenciaOTRAS = services.GetService(Of RegTotalesTransferenciaOTRAS)()
        'TotOTRAS.TotalRegistros += 1
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroOtrasTotales(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim TotOTRAS As RegTotalesTransferenciaOTRAS = services.GetService(Of RegTotalesTransferenciaOTRAS)()

        TotOTRAS.TotalRegistros += 1
        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_TOTALES))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.OTRAS_TRANSFERENCIAS))
        lstRegistro.Add(New DataCampoRegistro("Total de Importes", String.Empty, True, enumTipoCampo.Numerico, 17, TotOTRAS.TotalImportes))
        lstRegistro.Add(New DataCampoRegistro("Número de Registros", String.Empty, True, enumTipoCampo.Numerico, 8, TotOTRAS.NumRegistros))
        lstRegistro.Add(New DataCampoRegistro("Total de Registros", String.Empty, True, enumTipoCampo.Numerico, 10, TotOTRAS.TotalRegistros))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 560))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

#End Region

#Region " Cheques "

    <Task()> Public Shared Sub FichCSB34_14_RegistrosCheques(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If Not ProcInfo.OrigenDatos Is Nothing Then ProcInfo.OrigenDatos.Rows.Clear()
        Dim fTransferenciasCheques As New Filter
        fTransferenciasCheques.Add(New GuidFilterItem("IDProcess", ProcInfo.IDProcess))
        fTransferenciasCheques.Add(New BooleanFilterItem("ChequeTalon", True))
        fTransferenciasCheques.Add(New BooleanFilterItem("Trasferencia", True))

        Dim ViewName As String = "vSEPA_frmPagosGenerarFichero_34_14"
        If ProcInfo.LiquidacionGastosObras Then
            ViewName = "vSEPA_LiquidacionGastos"
        End If
        Dim dtPagos As DataTable = New BE.DataEngine().Filter(ViewName, fTransferenciasCheques)
        If Not dtPagos Is Nothing Then
            Dim PagosSinIDCuenta As List(Of DataRow) = (From c In dtPagos _
                                                      Where c.IsNull("CodigoIBAN")).ToList()

            If Not PagosSinIDCuenta Is Nothing AndAlso PagosSinIDCuenta.Count > 0 Then
                ApplicationService.GenerateError("Existen Pagos en los que la Cuenta Bancaria no está identificada. Revise sus datos.")
            End If
            ProcInfo.OrigenDatos = dtPagos.Copy
        End If
        If Not ProcInfo.OrigenDatos Is Nothing AndAlso ProcInfo.OrigenDatos.Rows.Count > 0 Then
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroChequesCabecera, data, services)
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroChequesBeneficiarios, data, services)
            ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroChequesTotales, data, services)
        End If
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroChequesCabecera(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()
        Dim datosBanco As DatosBancoPropioFicheros = services.GetService(Of DatosBancoPropioFicheros)()

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_CABECERA))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.CHEQUES_BANCARIOS_NOMINA))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante: NIF", String.Empty, True, enumTipoCampo.Alfanumerico, 9, datOrdenante.NIF))
        lstRegistro.Add(New DataCampoRegistro("Identificación del Ordenante: Sufijo", String.Empty, True, enumTipoCampo.Alfanumerico, 3, datosBanco.SufijoRemesas))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 578))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)

        Dim TotCHEQUES As RegTotalesCHEQUES = services.GetService(Of RegTotalesCHEQUES)()
        TotCHEQUES.TotalRegistros += 1
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroChequesBeneficiarios(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroChequesBeneficiarios_T1, data, services)
        ProcessServer.ExecuteTask(Of DataAddRegistroFichero)(AddressOf FichCSB34_14_RegistroChequesBeneficiarios_T2, data, services)
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroChequesBeneficiarios_T1(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim ProcInfo As ProcessInfoFichero = services.GetService(Of ProcessInfoFichero)()
        If ProcInfo.OrigenDatos Is Nothing OrElse ProcInfo.OrigenDatos.Rows.Count = 0 Then Exit Sub

        Dim datOrdenante As DatosOrdenante = services.GetService(Of DatosOrdenante)()

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_BENEFICIARIO))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.CHEQUES_BANCARIOS_NOMINA))
        lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB34_14.TRANSFERENCIA_CHEQUE_TIPO1))
        lstRegistro.Add(New DataCampoRegistro("Referencia del Ordenante ", "CIF", True, enumTipoCampo.Alfanumerico, 35))
        lstRegistro.Add(New DataCampoRegistro("Nombre del Ultimo Ordenante", String.Empty, False, enumTipoCampo.Alfanumerico, 70, datOrdenante.Nombre))
        lstRegistro.Add(New DataCampoRegistro("Importe del Cheque", "ImpVencimientoA", True, enumTipoCampo.Numerico, 11))
        lstRegistro.Add(New DataCampoRegistro("Nombre del Beneficiario", "DescBeneficiario", True, enumTipoCampo.Alfanumerico, 70))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Beneficiario ", "DireccionPago", False, enumTipoCampo.Alfanumerico, 50))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Beneficiario ", "CodPostal+PoblacionPago", False, enumTipoCampo.Alfanumerico, 50))
        lstRegistro.Add(New DataCampoRegistro("Dirección del Beneficiario ", "ProvinciaPago", False, enumTipoCampo.Alfanumerico, 40))
        lstRegistro.Add(New DataCampoRegistro("País del Beneficiario", "ISOPais", False, enumTipoCampo.Alfanumerico, 2))
        lstRegistro.Add(New DataCampoRegistro("Propósito/Concepto del Cheque", String.Empty, True, enumTipoCampo.Numerico, 1, PropositoTransferenciaCheque.OtrosConceptos))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 258))


        Dim TotCHEQUES As RegTotalesCHEQUES = services.GetService(Of RegTotalesCHEQUES)()

        'If Not ProcInfo.OrigenDatos.Columns.Contains("Concepto") Then
        '    ProcInfo.OrigenDatos.Columns.Add("Concepto", GetType(String))
        '    ProcInfo.OrigenDatos.Columns("Concepto").ReadOnly = False
        'End If

        For Each dr As DataRow In ProcInfo.OrigenDatos.Rows
            '   dr("Concepto") = ProcessServer.ExecuteTask(Of DataRow, String)(AddressOf GetConceptoPagos, dr, services)
            lstRegistro.Row = dr

            TotCHEQUES.NumRegistros += 1
            TotCHEQUES.TotalImportes += Nz(dr("ImpVencimientoA"), 0)
            TotCHEQUES.TotalRegistros += 1

            Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
            If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
        Next
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroChequesBeneficiarios_T2(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        'Dim lstRegistro As New ListaCamposRegistro
        'lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_BENEFICIARIO))
        'lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.CHEQUES_BANCARIOS_NOMINA))
        'lstRegistro.Add(New DataCampoRegistro("Versión Cuaderno", String.Empty, True, enumTipoCampo.Numerico, 5, CodigoCuadernoSEPA.CSB34_14))
        'lstRegistro.Add(New DataCampoRegistro("Número de Dato", String.Empty, True, enumTipoCampo.Numerico, 3, NumeroDatoCSB34_14.TRANSFERENCIA_CHEQUE_TIPO2))
        'lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 587))

        'Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf GenerarRegistro, lstRegistro, services)
        'If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)

        'Dim TotCHEQUES As RegTotalesCHEQUES = services.GetService(Of RegTotalesCHEQUES)()
        'TotCHEQUES.TotalRegistros += 1
    End Sub

    <Task()> Public Shared Sub FichCSB34_14_RegistroChequesTotales(ByVal data As DataAddRegistroFichero, ByVal services As ServiceProvider)
        Dim TotCHEQUES As RegTotalesCHEQUES = services.GetService(Of RegTotalesCHEQUES)()
        TotCHEQUES.TotalRegistros += 1

        Dim lstRegistro As New ListaCamposRegistro
        lstRegistro.Add(New DataCampoRegistro("Código de Registro", String.Empty, True, enumTipoCampo.Numerico, 2, CodigoRegistroCSB34_14.REG_TOTALES))
        lstRegistro.Add(New DataCampoRegistro("Código de Operación", String.Empty, True, enumTipoCampo.Alfanumerico, 3, CodigoOperacionCSB34_14.CHEQUES_BANCARIOS_NOMINA))
        lstRegistro.Add(New DataCampoRegistro("Total de Importes", String.Empty, True, enumTipoCampo.Numerico, 17, TotCHEQUES.TotalImportes))
        lstRegistro.Add(New DataCampoRegistro("Número de Registros", String.Empty, True, enumTipoCampo.Numerico, 8, TotCHEQUES.NumRegistros))
        lstRegistro.Add(New DataCampoRegistro("Total de Registros", String.Empty, True, enumTipoCampo.Numerico, 10, TotCHEQUES.TotalRegistros))
        lstRegistro.Add(New DataCampoRegistro("Libre", String.Empty, False, enumTipoCampo.Alfanumerico, 560))

        Dim strRegistro As String = ProcessServer.ExecuteTask(Of ListaCamposRegistro, String)(AddressOf FicherosGeneral.GenerarRegistro, lstRegistro, services)
        If Length(strRegistro) > 0 Then data.AddRegistro(strRegistro)
    End Sub

#End Region

End Class

