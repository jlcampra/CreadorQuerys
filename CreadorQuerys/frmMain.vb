Public Class frmMain
    Dim objArchivoTexto As ClsArchivoTexto

    Dim lstExpedientes As List(Of ClsExpedientes)
    Dim dicContenedorOrigen As ClsDiccionario
    Dim dicContenedorDestino As ClsDiccionario
    Dim objUpdate As ClsUpdate
    Dim arrQuerysUpdates As ArrayList

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objArchivoTexto = New ClsArchivoTexto
        objArchivoTexto.StrRutaSalida = "C:\pru\txt\querys.sql"
        lstExpedientes = New List(Of ClsExpedientes)
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        objArchivoTexto.Leer("C:\pru\txt\expedientes.txt")
        ConvertirTextoA_Lista(objArchivoTexto.ArrTexto, lstExpedientes)
        dicContenedorOrigen = New ClsDiccionario("C:\pru\txt\contenedoresOrigen.txt")
        dicContenedorDestino = New ClsDiccionario("C:\pru\txt\contenedoresDestino.txt")
        objUpdate = New ClsUpdate("S000405")
        arrQuerysUpdates = New ArrayList
        arrQuerysUpdates = objUpdate.DameQuerys(lstExpedientes, dicContenedorOrigen, dicContenedorDestino)
        objArchivoTexto.Escribir(arrQuerysUpdates)

        MessageBox.Show("Archivo creado en: " & vbCrLf & objArchivoTexto.StrRutaSalida, "Proceso correcto")
    End Sub

    Sub ConvertirTextoA_Lista(arrTexto As ArrayList, lstExpedientes As List(Of ClsExpedientes))
        Dim objExpediente As ClsExpedientes = New ClsExpedientes

        For Each linea In arrTexto
            objExpediente = New ClsExpedientes

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
