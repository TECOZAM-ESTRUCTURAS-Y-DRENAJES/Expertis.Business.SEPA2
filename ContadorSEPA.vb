Public Class ContadorSEPA


    <Serializable()> _
   Public Class DatosDefaultCounterValueSEPA
        Public row As DataRow
        Public EntityName As String
        Public FieldName As String
        Public CounterIDFieldName As String

        Public Sub New()
        End Sub

        Public Sub New(ByVal row As DataRow, ByVal EntityName As String, ByVal FieldName As String, Optional ByVal CounterIDFieldName As String = Nothing)
            Me.row = row
            Me.EntityName = EntityName
            Me.FieldName = FieldName
            If Length(CounterIDFieldName) > 0 Then Me.CounterIDFieldName = CounterIDFieldName
        End Sub
    End Class

    <Task()> Public Shared Sub LoadDefaultCounterValue(ByVal data As DatosDefaultCounterValueSEPA, ByVal services As ServiceProvider)
        If Length(data.CounterIDFieldName) = 0 Then data.CounterIDFieldName = "IDContador"
        Dim oDC As DefaultCounterSEPA = ProcessServer.ExecuteTask(Of String, DefaultCounterSEPA)(AddressOf GetDefaultCounterValue, data.EntityName, services)
        If Not oDC Is Nothing Then
            data.row(data.FieldName) = oDC.CounterValue
            data.row(data.CounterIDFieldName) = oDC.CounterID
        End If
    End Sub

    <Task()> Public Shared Function GetDefaultCounterValue(ByVal EntityName As String, ByVal services As ServiceProvider) As DefaultCounterSEPA
        Dim dtCont As DataTable = ProcessServer.ExecuteTask(Of String, DataTable)(AddressOf CounterDefault, EntityName, services)
        If Not dtCont Is Nothing AndAlso dtCont.Rows.Count <> 0 Then
            Dim oRslt As New DefaultCounterSEPA
            oRslt.CounterID = dtCont.Rows(0)("IDContador")
            Dim StDatos As New DatosFormatCounterSEPA(dtCont.Rows(0)("Numerico"), dtCont.Rows(0)("Contador"), dtCont.Rows(0)("Longitud"), dtCont.Rows(0)("Texto") & String.Empty)
            oRslt.CounterValue = ProcessServer.ExecuteTask(Of DatosFormatCounterSEPA, String)(AddressOf FormatCounter, StDatos, services)
            Return oRslt
        End If
    End Function

    <Task()> Public Shared Function CounterDefault(ByVal strIdEntity As String, ByVal services As ServiceProvider) As DataTable
        Return AdminData.Execute("GetCounterDefault", False, strIdEntity)
    End Function


    <Task()> Public Shared Function CounterValueID(ByVal strIdCounter As String, ByVal services As ServiceProvider) As String
        Dim dttCounter As DataTable
        Dim dtrCounter As DataRow
        Dim strCounterValue As String

        Dim mMe As BusinessHelper = BusinessHelper.CreateBusinessObject("Contador")     'debido a que esta función es shared
        dttCounter = mMe.SelOnPrimaryKey(strIdCounter)
        If Not dttCounter Is Nothing Then
            If dttCounter.Rows.Count > 0 Then
                dtrCounter = dttCounter.Rows(0)
                strCounterValue = ProcessServer.ExecuteTask(Of DataRow, String)(AddressOf FormatCounterDr, dtrCounter, services)
                dtrCounter("Contador") = CInt(dtrCounter("Contador")) + 1
                mMe.Update(dttCounter)
                Return strCounterValue
            End If
        End If
    End Function


    <Task()> Public Shared Function FormatCounterDr(ByVal rwCounter As DataRow, ByVal services As ServiceProvider) As String
        Dim EsNumerico As Boolean
        Dim texto As String
        Dim longitud As Integer
        Dim ValorContador As Integer

        EsNumerico = rwCounter("Numerico")
        ValorContador = rwCounter("Contador")

        If Not rwCounter.IsNull("Longitud") Then
            longitud = rwCounter("Longitud")
        End If
        If rwCounter.IsNull("Texto") Then
            texto = String.Empty
        Else
            texto = rwCounter("Texto")
        End If
        Dim StDatos As New DatosFormatCounterSEPA
        StDatos.Numeric = EsNumerico
        StDatos.Len = longitud
        StDatos.Text = texto
        StDatos.Counter = ValorContador
        Return ProcessServer.ExecuteTask(Of DatosFormatCounterSEPA, String)(AddressOf FormatCounter, StDatos, services)
    End Function


    <Serializable()> _
   Public Class DatosFormatCounterSEPA
        Public Numeric As Boolean
        Public Counter As Integer
        Public Len As Integer
        Public Text As String

        Public Sub New()
        End Sub

        Public Sub New(ByVal Numeric As Boolean, ByVal Counter As Integer, ByVal Len As Integer, ByVal Text As String)
            Me.Numeric = Numeric
            Me.Counter = Counter
            Me.Len = Len
            Me.Text = Text
        End Sub
    End Class

    <Task()> Public Shared Function FormatCounter(ByVal data As DatosFormatCounterSEPA, ByVal services As ServiceProvider) As String
        Dim strCounter As String = CStr(data.Counter)
        If data.Numeric Then
        Else
            Dim intPad As Integer = data.Len - Len(strCounter) - Len(data.Text)
            If intPad > 0 Then
                strCounter = data.Text & New String("0", intPad) & strCounter
            Else
                strCounter = data.Text & strCounter
            End If
        End If
        Return strCounter
    End Function


    <Serializable()> _
    Public Class DefaultCounterSEPA
        Public CounterValue As String
        Public CounterID As String
    End Class

End Class
