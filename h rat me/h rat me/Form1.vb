Option Explicit On
Imports System.IO
Imports System.Net.Sockets

Public Class Form1
    Dim Client As TcpClient



    Private Sub Button2_Click(sender As Object, e As EventArgs)
        If (TextBox2.Text.Length > 0) Then
            Try
                Client = New TcpClient(TextBox2.Text, 8000)

                Dim boln As Boolean = If(Client.Available, True, True)
                If (boln) Then
                    Dim Writer As New StreamWriter(Client.GetStream())
                    Writer.Write("</> " & "Test" & " <\>")
                    Writer.Flush()
                    'MsgBox("active connection to H.R.a.T")
                    Button3.BackColor = Color.Green
                    Label4.Text = "TARGET FOUND"
                    Button3.Enabled = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        tools.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'callum dont enable these 2
        'tools.Label2.Text = TextBox2.Text
        'tools.Show()
        MainWindow.Label1.Text = TextBox2.Text
        MainWindow.Show()


        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class