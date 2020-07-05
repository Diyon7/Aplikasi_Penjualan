Imports System.Data.Odbc
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class cetak
    Dim cetakj As New strukpenjualan

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        koneksi()
        'cmd = conn.CreateCommand
        'cmd.CommandText = "SELECT jual1.nojual, jual1.tgljual, jual1.jamjual, jual1.itemjual, jual1.totaljual, jual1.dibayar, jual1.kembali, admin1.namaadmin, pelanggan1.kodepelanggan, pelanggan1.namapelanggan, detailjual1.kodebarang, detailjual1.namabarang, detailjual1.hargajual, detailjual1.jumlahjual, detailjual1.subtotal FROM   ((final_project_pdekstop.detailjual detailjual1 INNER JOIN final_project_pdekstop.jual jual1 ON detailjual1.nojual=jual1.nojual) INNER JOIN final_project_pdekstop.admin admin1 ON jual1.kodeadmin=admin1.kodeadmin) INNER JOIN final_project_pdekstop.pelanggan pelanggan1 ON jual1.kodepelanggan=pelanggan1.kodepelanggan where jual1.nojual ='" & formtransaksijual.lblnojual.Text & "'"
        'da = New OdbcDataAdapter()
        'da.SelectCommand = cmd
        'da.SelectCommand.CommandTimeout = 500000
        'ds = New DataSet
        'ds.Clear()
        'da.Fill(ds, "cetaks")
        'cetakj = New strukjualan
        'cetakj.SetDataSource(ds)
        cetakj.Refresh()
        CrystalReportViewer1.SelectionFormula = "totext ({jual1.nojual}) ='" & formtransaksijual.lblnojual.Text & "'"
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.ReportSource = cetakj
    End Sub

    Private Sub CrystalReportViewer2_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer2.Load
        koneksi()
        cmd = conn.CreateCommand
        cmd.CommandText = "SELECT jual1.nojual, jual1.tgljual, jual1.jamjual, jual1.itemjual, jual1.totaljual, jual1.dibayar, jual1.kembali, admin1.namaadmin, pelanggan1.kodepelanggan, pelanggan1.namapelanggan, detailjual1.kodebarang, detailjual1.namabarang, detailjual1.hargajual, detailjual1.jumlahjual, detailjual1.subtotal FROM   ((final_project_pdekstop.detailjual detailjual1 INNER JOIN final_project_pdekstop.jual jual1 ON detailjual1.nojual=jual1.nojual) INNER JOIN final_project_pdekstop.admin admin1 ON jual1.kodeadmin=admin1.kodeadmin) INNER JOIN final_project_pdekstop.pelanggan pelanggan1 ON jual1.kodepelanggan=pelanggan1.kodepelanggan where jual1.nojual like'%" & formtransaksijual.lblnojual.Text & "%'"
        da = New OdbcDataAdapter()
        da.SelectCommand = cmd
        da.SelectCommand.CommandTimeout = 500000
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "cetaks")
        cetakj = New strukpenjualan
        cetakj.SetDataSource(ds)
        'cetakj.Refresh()
        CrystalReportViewer1.SelectionFormula = "totext ({jual1.nojual}) ='" & formtransaksijual.lblnojual.Text & "'"
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.ReportSource = cetakj
    End Sub
End Class