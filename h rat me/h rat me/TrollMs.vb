Option Explicit On
Imports System.IO
Imports System.Net.Sockets

Public Class TrollMs
    Dim Client As TcpClient
    Dim strHostName As String = System.Net.Dns.GetHostName()
    Dim MyLocIp As String = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()



    Private Sub Timer1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length > 0 Then
            Try
                Client = New TcpClient(MainWindow.Label1.Text, 8000)
                Dim Writer As New StreamWriter(Client.GetStream())
                Writer.Write("</> " & TextBox1.Text & " <\>")
                Writer.Flush()
                RichTextBox1.Text = RichTextBox1.Text + Environment.NewLine + "Command sent: " + TextBox1.Text
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TrollMs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class