Public Class frmMain
    Dim objArchivoTexto As ClsArchivoTexto
    Dim objExpediente As ClsExpedientes
    Dim lstExpedientes As List(Of ClsExpedientes)
    Dim objContenedorOrigen As ClsDiccionario
    Dim objContenedorDestino As ClsDiccionario

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        objArchivoTexto = New ClsArchivoTexto
        objArchivoTexto.Leer("C:\pru\txt\expedientes.txt")
        ConvertirTextoA_Lista(objArchivoTexto.ArrTexto, lstExpedientes)
        objContenedorOrigen = New ClsDiccionario("C:\pru\txt\contenedoresOrigen.txt")
        objContenedorDestino = New ClsDiccionario("C:\pru\txt\contenedoresDestino.txt")
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objArchivoTexto = New ClsArchivoTexto
        objExpediente = New ClsExpedientes
        lstExpedientes = New List(Of ClsExpedientes)
    End Sub

    Sub ConvertirTextoA_Lista(arrTexto As ArrayList, lstExpedientes As List(Of ClsExpedientes))
        For Each linea In arrTexto
            objExpediente.IntNumExpediente = DameElemento(0, linea)
            objExpediente.IntCaja = DameElemento(1, linea)
            objExpediente.IntBalda = DameElemento(2, linea)
            objExpediente.IntCaja2 = DameElemento(3, linea)
            objExpediente.IntContenedorOrigen = DameElemento(4, linea)
            objExpediente.IntContenedorDestino = DameElemento(5, linea)

            lstExpedientes.Add(objExpediente)
        Next
    End Sub

    Private Function DameElemento(intElemento As Integer, strLinea As String) As Long
        If String.IsNullOrEmpty(strLinea.Split(",")(intElemento).ToString.Trim()) Then
            Return -1
        Else
            Return strLinea.Split(",")(intElemento).ToString.Trim()
        End If
    End Function

End Class
