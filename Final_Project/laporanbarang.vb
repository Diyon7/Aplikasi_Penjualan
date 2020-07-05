Imports System.Data.Odbc
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class laporanbarang
    Dim cetakdatabarang As laporandatabarang
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        ds = New DataSet
        ds.Clear()
        cetakdatabarang = New laporandatabarang
        cetakdatabarang.SetDataSource(ds)
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.ReportSource = cetakdatabarang
    End Sub
End Class