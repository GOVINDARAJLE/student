
Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim MyConn As New MySqlConnection
        Dim COMMAND As MySqlCommand
        Dim READER As MySqlDataReader
        MyConn.ConnectionString = "server=localhost;userid=root;password=1213as45;persistsecurityinfo=True;database=mydatabase"

        Try
            MyConn.Open()

            Dim Query As String
            Query = "select * from mydatabase.logininfo where usename='" & MaskedTextBox1.Text & "' and password ='" & MaskedTextBox2.Text & "'"
            COMMAND = New MySqlCommand(Query, MyConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count += 1

            End While
            If count = 1 Then
                Dim dialogResult1 = MessageBox.Show("Successful")
                Form2.Show()
                Me.Hide()
            ElseIf count > 1 Then
                MessageBox.Show("Duplicate")
            Else
                MessageBox.Show("Not Correct")

            End If
            MyConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
