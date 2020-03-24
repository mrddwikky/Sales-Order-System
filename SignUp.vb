Imports MySql.Data.MySqlClient
Public Class SignUp
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand

    Sub konek()
        myconn = New MySqlConnection("server='localhost';user id='root';password='';database='salesorder'")
        myconn.Open()
    End Sub

    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Isi data dengan lengkap", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        mycommand = New MySqlCommand("insert into tbadmin values('""','" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "', '" & TextBox3.Text & "','" & TextBox4.Text & "')", myconn)
        mycommand.ExecuteNonQuery()
        myconn.Close()
        Call kosong()
        MsgBox("Data tersimpan", MsgBoxStyle.OkOnly)
        LogIn.Show()
        Hide()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HomeToolStripMenuItem.Click
        Front.Show()
        Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LogIn.Show()
        Hide()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
            ErrorProvider1.SetError(TextBox3, "Use number")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub
End Class