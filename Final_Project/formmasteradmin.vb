Imports System.Data.Odbc
Public Class formmasteradmin

    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False

        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button1.Text = "tutup"
        Button2.Text = "input"
        Button3.Text = "edit"
        Button4.Text = "hapus"
        Call koneksi()
        da = New OdbcDataAdapter("select kodeadmin, namaadmin, leveladmin from admin", conn)
        ds = New DataSet
        da.Fill(ds, "admin")
        DataGridView1.DataSource = ds.Tables("admin")
        DataGridView1.ReadOnly = True

    End Sub

    Sub siapisi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox1.Items.Add("admin")
        ComboBox1.Items.Add("kasir")
        ComboBox1.Items.Add("gudang")
    End Sub

    Private Sub formmasteradmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub

    Dim bant As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "input" Then
            Button2.Text = "simpan"
            Button3.Enabled = False
            Button4.Enabled = False
            Button1.Text = "batal"
            Call siapisi()
            Call koneksi()
            TextBox1.Enabled = False
            TextBox2.Focus()
            cmd = New OdbcCommand("SELECT CASE WHEN MAX(CONVERT(SUBSTRING(kodeadmin,3,7), SIGNED INTEGER))+1 is null THEN 1 ELSE MAX(CONVERT(SUBSTRING(kodeadmin,5,7), SIGNED INTEGER))+1 END FROM admin", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            TextBox1.Text = rd.Item(0)
            For i As Integer = 1 To 7 - TextBox1.TextLength
                bant = bant
            Next
            TextBox1.Text = "ADM00" & bant & TextBox1.Text
            rd.Close()
            cmd.Dispose()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                Call koneksi()
                Dim inputdata As String = "insert into admin values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "')"
                cmd = New OdbcCommand(inputdata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("input berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "edit" Then
            Button3.Text = "simpan"
            Button2.Enabled = False
            Button4.Enabled = False
            Button1.Text = "batal"
            Call siapisi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                Call koneksi()
                Dim updatedata As String = "Update admin set namaadmin='" & TextBox2.Text & "', passwordadmin='" & TextBox3.Text & "', leveladmin='" & ComboBox1.Text & "' where kodeadmin='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(updatedata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("update berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            cmd = New OdbcCommand("Select * From admin Where kodeadmin ='" & TextBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                MsgBox("kode harus dimasukkan")
            Else
                TextBox1.Text = rd.Item("kodeadmin")
                TextBox2.Text = rd.Item("namaadmin")
                TextBox3.Text = rd.Item("passwordadmin")
                ComboBox1.Text = rd.Item("leveladmin")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "tutup" Then
            Me.Close()
        Else
            Call kondisiawal()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "hapus" Then
            Button4.Text = "delete"
            Button2.Enabled = False
            Button3.Enabled = False
            Button1.Text = "batal"
            Call siapisi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                Call koneksi()
                Dim hapusdata As String = "delete from admin where kodeadmin='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(hapusdata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("hapus berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub
End Class