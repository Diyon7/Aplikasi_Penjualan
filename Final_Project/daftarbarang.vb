Imports System.Data.Odbc
Public Class daftarbarang
    Private Sub daftarbarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        da = New OdbcDataAdapter("select * from barang", conn)
        ds = New DataSet
        da.Fill(ds, "barang")
        DataGridView1.DataSource = ds.Tables("barang")
        DataGridView1.ReadOnly = True
    End Sub
End Class