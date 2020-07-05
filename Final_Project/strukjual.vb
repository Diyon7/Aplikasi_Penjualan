Imports System.Data.Odbc
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class strukjual
    Dim cetakj As New strukpenjualan

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        ds = New DataSet
        ds.Clear()
        cetakj = New strukpenjualan
        cetakj.SetDataSource(ds)
        CrystalReportViewer1.SelectionFormula = "totext ({jual1.nojual}) ='" & formtransaksijual.lblnojual.Text & "'"
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.ReportSource = cetakj
    End Sub
End Class