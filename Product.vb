Imports MySql.Data.MySqlClient
Public Class Product
    Dim myconn As New MySqlConnection
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
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
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox8.Text = ""
        RichTextBox1.Text = ""
        ComboBox1.Text = ""
    End Sub

    Sub tampil()
        Call konek()
        myadapter = New MySqlDataAdapter("select * from tbbarang", myconn)
        mydata = New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        DataGridView1.Columns(0).HeaderText = "Product Code"
        DataGridView1.Columns(1).HeaderText = "Product Name"
        DataGridView1.Columns(2).HeaderText = "Material"
        DataGridView1.Columns(3).HeaderText = "Size"
        DataGridView1.Columns(4).HeaderText = "Remarks"
        DataGridView1.Columns(5).HeaderText = "Stock"
        DataGridView1.Columns(6).HeaderText = "Years"
        DataGridView1.Columns(7).HeaderText = "Selling Price"
        myconn.Close()

        ''For i As Integer = 0 To DataGridView1.Rows.Count - 1
        ''If DataGridView1.Rows(i).Cells(5).Value < 5 Then
        ''DataGridView1.Rows(i).Cells(5).Style.BackColor = Color.Red
        ''MsgBox("Low On Stock")
        ''End If
        ''Next
        TextBox1.Focus()
    End Sub

    Private Sub Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Date.Now.Year - 10 To Date.Now.Year + 10 (u/ buat tahun dari 10 tahun sebelum tahun sekarang & 10 tahun setelah tahun sekarang)
        For i = 2010 To Date.Now.Year
            ComboBox1.Items.Add(i)
            ComboBox1.Text = "Year"
        Next
        Call tampil()


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox8.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        myadapter = New MySqlDataAdapter("select * from tbbarang where kodeBrg like '%" & TextBox8.Text & "%' or namaBrg like '%" & TextBox8.Text & "%' or materialBrg like '%" & TextBox8.Text & "%' or ukuranBrg like '%" & TextBox8.Text & "%' or cttnBrg like '%" & TextBox8.Text & "%' or stockBrg like '%" & TextBox8.Text & "%' or thnBrg like '%" & TextBox8.Text & "%' or hrgBrg like '%" & TextBox8.Text & "%'", myconn)
        mydata = New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        myconn.Close()
        Call kosong()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or RichTextBox1.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        Else
            Call konek()
            Dim mydatareader As MySqlDataReader
            mycommand = New MySqlCommand("select * from tbbarang where kodeBrg = '" & TextBox1.Text & "'", myconn)
            mydatareader = mycommand.ExecuteReader
            mydatareader.Read()
            If Not mydatareader.HasRows Then
                Call konek()
                mycommand = New MySqlCommand("insert into tbbarang values('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & RichTextBox1.Text & "', '" & TextBox5.Text & "', '" & ComboBox1.Text & "', '" & TextBox6.Text & "')", myconn)
                mycommand.ExecuteNonQuery()
                myconn.Close()
                MsgBox("Data has been saved", MsgBoxStyle.OkOnly)
                Call kosong()
                Call tampil()
            Else
                MsgBox("Product code has already recorded!", MsgBoxStyle.Information)
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or RichTextBox1.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        If MsgBox("Edit the data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            mycommand = New MySqlCommand("update tbbarang set namaBrg = '" & TextBox2.Text & "', materialBrg = '" & TextBox3.Text & "', ukuranBrg = '" & TextBox4.Text & "', cttnBrg = '" & RichTextBox1.Text & "', stockBrg = '" & TextBox5.Text & "', thnBrg = '" & ComboBox1.Text & "', hrgBrg = '" & TextBox6.Text & "' where kodeBrg = '" & TextBox1.Text & "'", myconn)
            mycommand.ExecuteNonQuery()
            myconn.Close()
            MsgBox("Data has been edited", MsgBoxStyle.OkOnly)
            Call kosong()
            Call tampil()
        Else
            MsgBox("No data has been edited", MsgBoxStyle.OkOnly)
            Call kosong()
            Call tampil()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Call kosong()
        Call tampil()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or RichTextBox1.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        If MsgBox("Are you sure want to delete the data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            mycommand = New MySqlCommand("delete from tbbarang where kodeBrg = '" & TextBox1.Text & "'", myconn)
            mycommand.ExecuteNonQuery()
            myconn.Close()
            MsgBox("Data has been deleted", MsgBoxStyle.OkOnly)
            Call kosong()
            Call tampil()
        Else
            MsgBox("No data has been deleted", MsgBoxStyle.OkOnly)
            Call kosong()
            Call tampil()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        Dim harga As Double
        harga = TextBox6.Text
        TextBox6.Text = harga
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Home.Show()
        Hide()
    End Sub
End Class