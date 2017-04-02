Imports System
Imports System.IO
Imports System.Text

Public Class ClsArchivoTexto
    Private _fsArchivoTxt As FileStream
    Private _srRchivoTxt As StreamReader
    Private _arrTexto As ArrayList
    Private _strRutaSalida As String

    Public Property StrRutaSalida As String
        Get
            Return _strRutaSalida
        End Get
        Set(value As String)
            _strRutaSalida = value
        End Set
    End Property

    Public Property ArrTexto As ArrayList
        Get
            Return _arrTexto
        End Get
        Protected Set(value As ArrayList)
            _arrTexto = value
        End Set
    End Property

    Public Sub Escribir(arrQuerys As ArrayList)
        If Not File.Exists(_strRutaSalida) Then
            Using sw As StreamWriter = File.CreateText(_strRutaSalida)
                For Each strQuery In arrQuerys
                    sw.WriteLine(strQuery)
                Next
                sw.Close()
                sw.Dispose()

            End Using
        End If
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
