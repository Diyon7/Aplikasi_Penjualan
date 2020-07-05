Imports System.Data.Odbc

Public Class supplier
    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        ComboBox1.Enabled = False

        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button1.Text = "tutup"
        Button2.Text = "supplier baru"
        Button3.Text = "tambah stok"
        Button4.Text = "hapus"
        Call koneksi()
        da = New OdbcDataAdapter("select * from supplier", conn)
        ds = New DataSet
        da.Fill(ds, "supplier")
        DataGridView1.DataSource = ds.Tables("supplier")
        DataGridView1.ReadOnly = True

    End Sub

    Sub siapisi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        ComboBox1.Enabled = True
        Call munculsatuan()
    End Sub

    Sub munculsatuan()
        Call koneksi()
        cmd = New OdbcCommand("select distinct kodebarang from barang", conn)
        rd = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While rd.Read
            ComboBox1.Items.Add(rd.Item("kodebarang"))
        Loop
    End Sub
    Dim bant As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "supplier baru" Then
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
            TextBox6.Clear()

            Call koneksi()
            TextBox2.Focus()

            cmd = New OdbcCommand("SELECT CASE WHEN MAX(CONVERT(SUBSTRING(kodesupplier,3,7), SIGNED INTEGER))+1 is null THEN 1 ELSE MAX(CONVERT(SUBSTRING(kodesupplier,5,7), SIGNED INTEGER))+1 END FROM supplier", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            TextBox1.Text = rd.Item(0)
            For i As Integer = 1 To 7 - TextBox1.TextLength
                bant = bant
            Next
            TextBox1.Text = "SB00" & TextBox1.Text
            rd.Close()
            cmd.Dispose()
            'If Not ComboBox1.Text = "" Then
            '    cmd = New OdbcCommand("Select * From barang Where kodebarang ='" & ComboBox1.Text & "'", conn)
            '    rd = cmd.ExecuteReader
            '    rd.Read()
            '    TextBox8.Text = rd.Item("jumlahbarang")
            'End If
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                Dim inputdata As String = "insert into supplier values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "')"
                cmd = New OdbcCommand(inputdata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("input berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            cmd = New OdbcCommand("Select * From supplier Where kodesupplier ='" & TextBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                MsgBox("kode harus dimasukkan")
            Else
                TextBox1.Text = rd.Item("kodesupplier")
                TextBox2.Text = rd.Item("namasupplier")
                TextBox3.Text = rd.Item("alamatsupplier")
                TextBox4.Text = rd.Item("teleponsupplier")
                TextBox5.Text = rd.Item("hargasupplier")
                ComboBox1.Text = rd.Item("kodebarang")
            End If
            cmd = New OdbcCommand("Select * From barang Where kodebarang ='" & ComboBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            TextBox8.Text = rd.Item("jumlahbarang")
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
            TextBox1.Enabled = True
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = True
            ComboBox1.Enabled = False
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                Call koneksi()
                Dim hapusdata As String = "delete from supplier where kodesupplier='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(hapusdata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("hapus berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "tambah stok" Then
            Button3.Text = "simpan"
            Button2.Enabled = False
            Button4.Enabled = False
            Button1.Text = "batal"
            TextBox1.Enabled = True
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = True
            ComboBox1.Enabled = False
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
                MsgBox("silahkan isi kode supplier terus enter")
            Else
                Call koneksi()
                Dim updatedata As String = "Update barang set jumlahbarang='" & TextBox9.Text & "' where kodebarang='" & ComboBox1.Text & "'"
                cmd = New OdbcCommand(updatedata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("tambah stok berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then
            TextBox9.Text = TextBox8.Text
        Else
            TextBox9.Text = Val(TextBox8.Text) + Val(TextBox6.Text)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        daftarbarang.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        cmd = New OdbcCommand("Select * From barang Where kodebarang ='" & ComboBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        TextBox8.Text = rd.Item("jumlahbarang")
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox9.Text = TextBox8.Text
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Button6.Text = "edit" Then
            Button6.Text = "simpan"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button1.Text = "batal"
            Call siapisi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                Call koneksi()
                Dim updatedata As String = "Update supplier set namasupplier='" & TextBox2.Text & "', alamatsupplier= '" & TextBox3.Text & "', teleponsupplier='" & TextBox4.Text & "', hargasupplier='" & TextBox5.Text & "', kodebarang='" & ComboBox1.Text & "' where kodesupplier='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(updatedata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("update berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub
End Class