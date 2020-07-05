Imports System.Data.Odbc
Public Class formmasterbarang

    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        ComboBox1.Enabled = False

        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button1.Text = "tutup"
        Button2.Text = "input"
        Button3.Text = "edit"
        Button4.Text = "hapus"
        Call koneksi()
        da = New OdbcDataAdapter("select * from barang", conn)
        ds = New DataSet
        da.Fill(ds, "barang")
        DataGridView1.DataSource = ds.Tables("barang")
        DataGridView1.ReadOnly = True

    End Sub

    Sub siapisi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        ComboBox1.Enabled = True
        Call munculsatuan()
    End Sub

    Sub munculsatuan()
        Call koneksi()
        cmd = New OdbcCommand("select distinct satuanbarang from barang", conn)
        rd = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While rd.Read
            ComboBox1.Items.Add(rd.Item("satuanbarang"))
        Loop
    End Sub

    Private Sub formmasterbarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            bant = ""
            TextBox1.Enabled = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()

            Call koneksi()
            TextBox2.Focus()

            cmd = New OdbcCommand("SELECT CASE WHEN MAX(CONVERT(SUBSTRING(kodebarang,3,7), SIGNED INTEGER))+1 is null THEN 1 ELSE MAX(CONVERT(SUBSTRING(kodebarang,5,7), SIGNED INTEGER))+1 END FROM barang", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            TextBox1.Text = rd.Item(0)
            For i As Integer = 1 To 7 - TextBox1.TextLength
                bant = bant
            Next
            TextBox1.Text = "BRG00" & bant & TextBox1.Text
            rd.Close()
            cmd.Dispose()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                'Call koneksi()
                Dim inputdata As String = "insert into barang values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox5.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "')"
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
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                Call koneksi()
                Dim updatedata As String = "Update barang set namabarang='" & TextBox2.Text & "', jenisbarang= '" & TextBox5.Text & "', hargabarang='" & TextBox3.Text & "', jumlahbarang='" & TextBox4.Text & "', satuanbarang='" & ComboBox1.Text & "' where kodebarang='" & TextBox1.Text & "'"
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
            cmd = New OdbcCommand("Select * From barang Where kodebarang ='" & TextBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                MsgBox("kode harus dimasukkan")
            Else
                TextBox1.Text = rd.Item("kodebarang")
                TextBox2.Text = rd.Item("namabarang")
                TextBox5.Text = rd.Item("jenisbarang")
                TextBox3.Text = rd.Item("hargabarang")
                TextBox4.Text = rd.Item("jumlahbarang")
                ComboBox1.Text = rd.Item("satuanbarang")
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
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                Call koneksi()
                Dim hapusdata As String = "delete from barang where kodebarang='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(hapusdata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("hapus berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
    '    If Not IsNumeric(TextBox3.Text) = True Then
    '        MsgBox("harus angka")
    '    End If
    'End Sub

    'Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
    '    If Not IsNumeric(TextBox4.Text) = True Then
    '        MsgBox("harus angka")
    '    End If
    'End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

End Class