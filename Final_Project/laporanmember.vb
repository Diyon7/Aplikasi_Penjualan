Imports System.Data.Odbc
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class laporanmember
    Dim cetakdatamember As laporandatamember
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        ds = New DataSet
        ds.Clear()
        cetakdatamember = New laporandatamember
        cetakdatamember.SetDataSource(ds)
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.ReportSource = cetakdatamember
    End Sub
End Class