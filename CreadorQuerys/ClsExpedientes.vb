Public Class ClsExpedientes
    Private _intNumExpediente As Long
    Private _intCaja As Short
    Private _intBalda As Short
    Private _intCaja2 As Short
    Private _intContenedorOrigen As Long
    Private _intContenedorDestino As Long

    Sub New()
    End Sub

    Sub New(numExpediente, caja, balda, caja2, conteOrigen, conteDestino)
        _intNumExpediente = numExpediente
        _intCaja = caja
        _intBalda = balda
        _intCaja2 = caja2
        _intContenedorOrigen = conteOrigen
        _intContenedorDestino = conteDestino
    End Sub

    

    Public Property IntNumExpediente As Long
        Get
            Return _intNumExpediente
        End Get
        Set(value As Long)
            _intNumExpediente = value
        End Set
    End Property

    Public Property IntCaja As Short
        Get
            Return _intCaja
        End Get
        Set(value As Short)
            If IsNothing(value) Then
                _intCaja = -1
            Else
                _intCaja = value
            End If
        End Set
    End Property

    Public Property IntBalda As Short
        Get
            Return _intBalda
        End Get
        Set(value As Short)
            If IsNothing(value) Then
                value = -1
            Else
                _intBalda = value
            End If
        End Set
    End Property

    Public Property IntCaja2 As Short
        Get
            Return _intCaja2
        End Get
        Set(value As Short)
            If IsNothing(value) Then
                value = -1
            Else
                _intCaja2 = value
            End If
        End Set
    End Property

    Public Property IntContenedorOrigen As Long
        Get
            Return _intContenedorOrigen
        End Get
        Set(value As Long)
            _intContenedorOrigen = value
        End Set
    End Property

    Public Property IntContenedorDestino As Long
        Get
            Return _intContenedorDestino
        End Get
        Set(value As Long)
            _intContenedorDestino = value
        End Set
    End Property

    

End Class

