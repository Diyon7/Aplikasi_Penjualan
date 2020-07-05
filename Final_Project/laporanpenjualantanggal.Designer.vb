<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class laporanpenjualantanggal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tanggallaporan = New System.Windows.Forms.DateTimePicker()
        Me.lihat = New System.Windows.Forms.Button()
        Me.laporanpenjualanberdasartanggal = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.laporanpenjualan1 = New Final_Project.laporanpenjualan()
        Me.SuspendLayout()
        '
        'tanggallaporan
        '
        Me.tanggallaporan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tanggallaporan.Location = New System.Drawing.Point(92, 13)
        Me.tanggallaporan.Name = "tanggallaporan"
        Me.tanggallaporan.Size = New System.Drawing.Size(200, 22)
        Me.tanggallaporan.TabIndex = 0
        Me.tanggallaporan.Value = New Date(2020, 6, 13, 0, 0, 0, 0)
        '
        'lihat
        '
        Me.lihat.Location = New System.Drawing.Point(400, 15)
        Me.lihat.Name = "lihat"
        Me.lihat.Size = New System.Drawing.Size(75, 23)
        Me.lihat.TabIndex = 1
        Me.lihat.Text = "Lihat"
        Me.lihat.UseVisualStyleBackColor = True
        '
        'laporanpenjualanberdasartanggal
        '
        Me.laporanpenjualanberdasartanggal.ActiveViewIndex = 0
        Me.laporanpenjualanberdasartanggal.AutoSize = True
        Me.laporanpenjualanberdasartanggal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.laporanpenjualanberdasartanggal.Cursor = System.Windows.Forms.Cursors.Default
        Me.laporanpenjualanberdasartanggal.Location = New System.Drawing.Point(12, 44)
        Me.laporanpenjualanberdasartanggal.Name = "laporanpenjualanberdasartanggal"
        Me.laporanpenjualanberdasartanggal.ReportSource = Me.laporanpenjualan1
        Me.laporanpenjualanberdasartanggal.Size = New System.Drawing.Size(1144, 756)
        Me.laporanpenjualanberdasartanggal.TabIndex = 2
        Me.laporanpenjualanberdasartanggal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'laporanpenjualantanggal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 733)
        Me.Controls.Add(Me.laporanpenjualanberdasartanggal)
        Me.Controls.Add(Me.lihat)
        Me.Controls.Add(Me.tanggallaporan)
        Me.Name = "laporanpenjualantanggal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "laporanpenjualantanggal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tanggallaporan As DateTimePicker
    Friend WithEvents lihat As Button
    Friend WithEvents laporanpenjualanberdasartanggal As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents laporanpenjualan1 As laporanpenjualan
End Class
