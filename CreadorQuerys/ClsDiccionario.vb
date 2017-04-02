Public Class ClsDiccionario
    Private _dicDiccionario As Dictionary(Of Long, Long)
    Private _objArchivoTexto As ClsArchivoTexto
    Private _srtPrimerElemento As String
    Private _strSegundoElemento As String

    Sub New(strDirectorio As String)
        _dicDiccionario = New Dictionary(Of Long, Long)
        _objArchivoTexto = New ClsArchivoTexto
        RellenarDiccionario(strDirectorio)
    End Sub

    Public Property DicDiccionario As Dictionary(Of Long, Long)
        Get
            Return _dicDiccionario
        End Get
        Set(value As Dictionary(Of Long, Long))
            _dicDiccionario = value
        End Set
    End Property

    Public Sub RellenarDiccionario(strDirectorio As String)
        _objArchivoTexto.Leer(strDirectorio)
        For Each strLinea In _objArchivoTexto.ArrTexto
            _srtPrimerElemento = strLinea.Split(" ")(0).ToString.Trim()
            _strSegundoElemento = strLinea.Split(" ")(1).ToString.Trim()
            _dicDiccionario.Add(_srtPrimerElemento, _strSegundoElemento)
        Next
    End Sub
End Class
