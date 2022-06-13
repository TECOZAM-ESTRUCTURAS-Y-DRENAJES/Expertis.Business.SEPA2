Public Class Mandato
    Inherits Solmicro.Expertis.Engine.BE.BusinessHelper

#Region " Constructor "

    Public Sub New()
        MyBase.New(cnEntidad)
    End Sub
    Private Const cnEntidad As String = "tbMaestroMandato"

#End Region

#Region " RegisterAddnewTasks  "

    Protected Overrides Sub RegisterAddnewTasks(ByVal addnewProcess As Engine.BE.BusinessProcesses.Process)
        MyBase.RegisterAddnewTasks(addnewProcess)
        addnewProcess.AddTask(Of DataRow)(AddressOf AsignarIdentificador)
        addnewProcess.AddTask(Of DataRow)(AddressOf GetContadorPredeterminado)
        addnewProcess.AddTask(Of DataRow)(AddressOf GetOtrosValoresPredeterminados)
    End Sub

    <Task()> Public Shared Sub AsignarIdentificador(ByVal data As DataRow, ByVal services As ServiceProvider)
        If Nz(data("IDMandato"), 0) = 0 Then data("IDMandato") = AdminData.GetAutoNumeric
    End Sub

    <Task()> Public Shared Sub GetContadorPredeterminado(ByVal data As DataRow, ByVal services As ServiceProvider)
        If data.RowState = DataRowState.Added Then
            Dim datCont As New ContadorSEPA.DatosDefaultCounterValueSEPA(data, "Mandato", "NMandato")
            ProcessServer.ExecuteTask(Of ContadorSEPA.DatosDefaultCounterValueSEPA)(AddressOf ContadorSEPA.LoadDefaultCounterValue, datCont, services)
        End If
    End Sub

    <Task()> Public Shared Sub GetOtrosValoresPredeterminados(ByVal data As DataRow, ByVal services As ServiceProvider)
        ProcessServer.ExecuteTask(Of DataRow)(AddressOf AsignarIdentificador, data, services)

        data("Fecha") = Today
        data("Caducado") = False
        data("Predeterminado") = False

        data("Estado") = CInt(BusinessEnum.MandatoEstado.PdteFirma)
        data("IDTipoMandato") = CInt(BusinessEnum.TipoMandato.CORE)
        data("TipoPago") = CInt(BusinessEnum.MandatoTipoPago.Recurrente)
    End Sub

#End Region

#Region " RegisterValidateTasks "

    Protected Overrides Sub RegisterValidateTasks(ByVal validateProcess As Engine.BE.BusinessProcesses.Process)
        MyBase.RegisterValidateTasks(validateProcess)
        validateProcess.AddTask(Of DataRow)(AddressOf ValidarRegistroExistente)
        validateProcess.AddTask(Of DataRow)(AddressOf ValidarCamposObligatorios)
        validateProcess.AddTask(Of DataRow)(AddressOf ValidarRegistroPredeterminado)
    End Sub

    <Task()> Public Shared Sub ValidarRegistroExistente(ByVal data As DataRow, ByVal services As ServiceProvider)
        If data.RowState = DataRowState.Added AndAlso (Length(data("IDMandato")) > 0 OrElse Length(data("NMandato")) > 0) Then
            Dim fMdto As New Filter(FilterUnionOperator.Or)
            If Nz(data("IDMandato")) <> 0 Then fMdto.Add(New NumberFilterItem("IDMandato", data("IDMandato")))
            If Length(data("NMandato")) <> 0 Then fMdto.Add(New StringFilterItem("NMandato", data("NMandato")))
            Dim dtMandato As DataTable = New Mandato().Filter(fMdto)
            If Not dtMandato Is Nothing AndAlso dtMandato.Rows.Count > 0 Then
                ApplicationService.GenerateError("Ese Mandato ya existe en el Sistema.")
            End If
        End If
    End Sub

    <Task()> Public Shared Sub ValidarCamposObligatorios(ByVal data As DataRow, ByVal services As ServiceProvider)
        If Length(data("NMandato")) = 0 Then ApplicationService.GenerateError("Debe indicar un Nº Mandato.")
        If Length(data("Fecha")) = 0 Then ApplicationService.GenerateError("Debe indicar una Fecha.")
        If Length(data("IDCliente")) = 0 AndAlso Length(data("IDProveedor")) = 0 Then
            ApplicationService.GenerateError("Debe indicar un Cliente/Proveedor.")
        End If

        If Length(data("IDCliente")) > 0 AndAlso Length(data("IDProveedor")) > 0 Then
            ApplicationService.GenerateError("El mandato sólo debe ser para Cliente o Proveedor. Revise sus datos.")
        End If

        If Length(data("IDCliente")) > 0 AndAlso Nz(data("IDClienteBanco"), 0) = 0 AndAlso (Nz(data("Predeterminado")) OrElse Nz(data("Estado"), -1) = CInt(BusinessEnum.MandatoEstado.Aceptado)) Then
            ApplicationService.GenerateError("Debe indicar el Banco del Cliente.")
        End If

        If Length(data("IDProveedor")) > 0 AndAlso Length(data("SuMandato")) = 0 Then
            ApplicationService.GenerateError("Debe indicar Su Nº Mandato.")
        End If
        If Length(data("IDProveedor")) > 0 AndAlso Length(data("IDBancoPropio")) = 0 Then
            ApplicationService.GenerateError("Debe indicar el Banco Propio del Proveedor.")
        End If
    End Sub


    <Task()> Public Shared Sub ValidarRegistroPredeterminado(ByVal data As DataRow, ByVal services As ServiceProvider)
        If data.RowState = DataRowState.Added OrElse _
          (data.RowState = DataRowState.Modified AndAlso _
            (data("IDCliente") & String.Empty <> data("IDCliente", DataRowVersion.Original) & String.Empty OrElse _
             Nz(data("IDClienteBanco"), -1) <> Nz(data("IDClienteBanco", DataRowVersion.Original), -1) OrElse _
             data("Predeterminado") <> data("Predeterminado", DataRowVersion.Original))) Then

            If Length(data("IDCliente")) > 0 AndAlso Nz(data("Predeterminado")) AndAlso Nz(data("IDClienteBanco"), -1) <> -1 Then
                Dim fMdtoCltePred As New Filter
                fMdtoCltePred.Add(New StringFilterItem("IDCliente", data("IDCliente")))
                fMdtoCltePred.Add(New NumberFilterItem("IDClienteBanco", data("IDClienteBanco")))
                fMdtoCltePred.Add(New BooleanFilterItem("Predeterminado", True))
                Dim dtMandato As DataTable = New Mandato().Filter(fMdtoCltePred)
                If Not dtMandato Is Nothing AndAlso dtMandato.Rows.Count > 0 Then
                    ApplicationService.GenerateError("Ya existe en el Sistema un Mandato predeterminado para el Cliente {0} y el Banco {1}.", Quoted(data("IDCliente")), Quoted(data("IDClienteBanco")))
                End If
            End If
        End If
    End Sub


#End Region

#Region " RegisterUpdateTasks "

    Protected Overrides Sub RegisterUpdateTasks(ByVal updateProcess As Engine.BE.BusinessProcesses.Process)
        MyBase.RegisterUpdateTasks(updateProcess)
        updateProcess.AddTask(Of DataRow)(AddressOf AsignarIdentificador)
        updateProcess.AddTask(Of DataRow)(AddressOf AsignarNMandato)
        updateProcess.AddTask(Of DataRow)(AddressOf PredeterminarMandato)
    End Sub

    <Task()> Public Shared Sub AsignarNMandato(ByVal data As DataRow, ByVal services As ServiceProvider)
        If data.RowState = DataRowState.Added Then
            If Length(data("NMandato")) = 0 Then
                If Length(data("IdContador")) > 0 Then
                    data("NMandato") = ProcessServer.ExecuteTask(Of String, String)(AddressOf ContadorSEPA.CounterValueID, data("IDContador"), services)
                Else
                    Dim datContador As New ContadorSEPA.DatosDefaultCounterValueSEPA(data, "Mandato", "NMandato")
                    ProcessServer.ExecuteTask(Of ContadorSEPA.DatosDefaultCounterValueSEPA)(AddressOf ContadorSEPA.LoadDefaultCounterValue, datContador, services)
                    If Length(data("IDContador")) > 0 Then
                        data("NMandato") = ProcessServer.ExecuteTask(Of String, String)(AddressOf ContadorSEPA.CounterValueID, data("IDContador"), services)
                    Else
                        ApplicationService.GenerateError("No se ha configurado contador predeterminado para Mandatos.")
                    End If
                End If
            Else
                If Length(data("IdContador")) > 0 Then data("NMandato") = ProcessServer.ExecuteTask(Of String, String)(AddressOf ContadorSEPA.CounterValueID, data("IDContador"), services)
                Dim dtMandato As DataTable = New Mandato().Filter(New StringFilterItem("NMandato", data("NMandato")))
                If Not dtMandato Is Nothing AndAlso dtMandato.Rows.Count > 0 Then
                    ApplicationService.GenerateError("Ese Nº Mandato ya existe en la Base de Datos")
                End If
            End If
        End If
    End Sub

    <Task()> Public Shared Sub PredeterminarMandato(ByVal data As DataRow, ByVal services As ServiceProvider)
        If data.RowState = DataRowState.Added OrElse _
         (data.RowState = DataRowState.Modified AndAlso _
           (data("IDCliente") & String.Empty <> data("IDCliente", DataRowVersion.Original) & String.Empty OrElse _
            Nz(data("IDClienteBanco"), -1) <> Nz(data("IDClienteBanco", DataRowVersion.Original), -1))) Then

            If Length(data("IDCliente")) > 0 AndAlso Nz(data("IDClienteBanco"), -1) <> -1 Then
                Dim fMdtoCltePred As New Filter
                fMdtoCltePred.Add(New StringFilterItem("IDCliente", data("IDCliente")))
                fMdtoCltePred.Add(New NumberFilterItem("IDClienteBanco", data("IDClienteBanco")))
                Dim dtMandato As DataTable = New Mandato().Filter(fMdtoCltePred)
                If dtMandato Is Nothing OrElse dtMandato.Rows.Count = 0 Then
                    data("Predeterminado") = True
                End If
            End If
        End If
    End Sub



#End Region

#Region " Business Rules "

    Public Overrides Function GetBusinessRules() As Engine.BE.BusinessRules
        Dim oBRL As New BusinessRules
        oBRL.Add("IDCliente", AddressOf CambioCliente)
        Return oBRL
    End Function

    <Task()> Public Shared Sub CambioCliente(ByVal data As BusinessRuleData, ByVal services As ServiceProvider)
        data.Current("IDClienteBanco") = System.DBNull.Value
    End Sub

#End Region

    <Task()> Public Shared Sub AsignarMandatoPredeterminadoCliente(ByVal IDCobros As Object(), ByVal services As ServiceProvider)
        If IDCobros Is Nothing OrElse IDCobros.Count = 0 Then Exit Sub
        Dim f As New Filter
        f.Add(New InListFilterItem("IDCobro", IDCobros, FilterType.Numeric))

        f.Add(New IsNullFilterItem("IDMandato", True))

        f.Add(New IsNullFilterItem("IDCliente", False))
        f.Add(New IsNullFilterItem("IDClienteBanco", False))

        f.Add(New IsNullFilterItem("IDFormaPago", False))
        f.Add(New BooleanFilterItem("CobroRemesable", True))


        Dim dtCobrosMandato As DataTable = AdminData.GetData("vSEPA_frmCobrosMandato", f, Nothing, "IDCliente, IDClienteBanco")
        dtCobrosMandato.TableName = "Cobro"
        Dim IDClienteAnt As String
        Dim IDClienteBancoAnt As Integer
        Dim IDMandato As Integer

        Dim fMdto As New Filter
        For Each dr As DataRow In dtCobrosMandato.Select(Nothing, "IDCliente, IDClienteBanco")
            If IDClienteAnt <> dr("IDCliente") OrElse IDClienteBancoAnt <> dr("IDClienteBanco") Then
                IDMandato = -1

                fMdto.Clear()
                fMdto.Add(New StringFilterItem("IDCliente", dr("IDCliente")))
                fMdto.Add(New NumberFilterItem("IDClienteBanco", dr("IDClienteBanco")))
                fMdto.Add(New BooleanFilterItem("Caducado", False))
                fMdto.Add(New NumberFilterItem("Estado", CInt(BusinessEnum.MandatoEstado.Aceptado)))
                fMdto.Add(New BooleanFilterItem("Predeterminado", True))
                Dim dtMandato As DataTable = New Mandato().Filter(fMdto)
                If dtMandato.Rows.Count > 0 Then
                    IDMandato = dtMandato.Rows(0)("IDMandato")
                End If
                IDClienteAnt = dr("IDCliente")
                IDClienteBancoAnt = dr("IDClienteBanco")
            End If

            If IDMandato <> -1 Then
                dr("IDMandato") = IDMandato
            End If
        Next
        BusinessHelper.UpdateTable(dtCobrosMandato)
    End Sub

End Class
