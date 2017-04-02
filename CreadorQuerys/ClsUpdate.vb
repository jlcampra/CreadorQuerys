Public Class ClsUpdate
    Private _strTabla As String

    Sub New(strTabla As String)
        _strTabla = strTabla
    End Sub

    Public Function DameQuerys(lstExpedientes As List(Of ClsExpedientes),
                                objDicOrigen As ClsDiccionario, objDicDestino As ClsDiccionario) As ArrayList
        Dim arrQuerys As ArrayList = New ArrayList
        For Each objLstExpediente In lstExpedientes
            arrQuerys.Add(DameQuery(objLstExpediente, objDicOrigen, objDicDestino))
        Next


        Return arrQuerys
    End Function

    Private Function DameQuery(objLstExpediente As ClsExpedientes, objDicOrigen As ClsDiccionario, objDicDestino As ClsDiccionario) As Object
        Dim strQuery As String = String.Empty


        strQuery = "UPDATE " & _strTabla & _
                   " SET ID_CONTENEDOR = " & objDicDestino.DameSegundoElemento(objLstExpediente.IntContenedorDestino.ToString) & _
                   " where NUM_EXPEDIENTE = " & objLstExpediente.IntNumExpediente & _
                   " AND ID_CONTENEDOR = " & objDicOrigen.DameSegundoElemento(objLstExpediente.IntContenedorOrigen.ToString) & _
                   " AND BALDA = " & objLstExpediente.IntBalda
        If objLstExpediente.IntCaja > -1 Then
            strQuery = strQuery + " AND CAJA = " & objLstExpediente.IntCaja
        End If
        If objLstExpediente.IntCaja2 > -1 Then
            strQuery = strQuery + " AND CAJA2 = " & objLstExpediente.IntCaja2
        End If

        strQuery = strQuery & ";" & vbCrLf & "COMMIT;" & vbCrLf

        Return strQuery
    End Function

    

End Class
