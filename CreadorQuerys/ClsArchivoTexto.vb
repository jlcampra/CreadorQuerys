Imports System
Imports System.IO
Imports System.Text

Public Class ClsArchivoTexto
    Private _fsArchivoTxt As FileStream
    Private _srRchivoTxt As StreamReader
    Private _arrTexto As ArrayList

    Public Property ArrTexto As ArrayList
        Get
            Return _arrTexto
        End Get
        Protected Set(value As ArrayList)
            _arrTexto = value
        End Set
    End Property

    Public Sub CrearArchivo(strDirectorio As String)
        ' Crear y sobreescribir el fichero de la variable strDirectorio
        _fsArchivoTxt = File.Create(strDirectorio)
    End Sub

    Public Sub Escribir()
        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")
        _fsArchivoTxt.Write(info, 0, info.Length)
        _fsArchivoTxt.Close()
        _fsArchivoTxt.Dispose()
    End Sub

    Public Sub Leer(strDirectorio As String)
        Try
            _arrTexto = New ArrayList
            _srRchivoTxt = New StreamReader(strDirectorio)

            Do While _srRchivoTxt.Peek() >= 0
                _arrTexto.Add(_srRchivoTxt.ReadLine())
            Loop
            _srRchivoTxt.Close()
            _srRchivoTxt.Dispose()
        Catch e As Exception
        End Try
    End Sub


End Class
