<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class k3SettingPage
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(k3SettingPage))
        Me.cms_settings = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ls_dev = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.propgrid = New System.Windows.Forms.PropertyGrid()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tmediainfo = New System.Windows.Forms.TextBox()
        Me.tabSetting = New System.Windows.Forms.TabControl()
        Me.cms_settings.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tabSetting.SuspendLayout()
        Me.SuspendLayout()
        '
        'cms_settings
        '
        Me.cms_settings.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.cms_settings.Name = "cms_settings"
        Me.cms_settings.Size = New System.Drawing.Size(114, 48)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ExitToolStripMenuItem.Text = "Close"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Panel2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 27)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(503, 331)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Devices"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ls_dev)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(503, 331)
        Me.Panel2.TabIndex = 14
        '
        'ls_dev
        '
        Me.ls_dev.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ls_dev.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ls_dev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ls_dev.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ls_dev.FormattingEnabled = True
        Me.ls_dev.ItemHeight = 19
        Me.ls_dev.Location = New System.Drawing.Point(0, 0)
        Me.ls_dev.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ls_dev.Name = "ls_dev"
        Me.ls_dev.Size = New System.Drawing.Size(503, 331)
        Me.ls_dev.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.propgrid)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(503, 331)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'propgrid
        '
        Me.propgrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.propgrid.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propgrid.Location = New System.Drawing.Point(0, 0)
        Me.propgrid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.propgrid.Name = "propgrid"
        Me.propgrid.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.propgrid.Size = New System.Drawing.Size(503, 331)
        Me.propgrid.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tmediainfo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(503, 331)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Media Info"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tmediainfo
        '
        Me.tmediainfo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tmediainfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tmediainfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tmediainfo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tmediainfo.Location = New System.Drawing.Point(0, 0)
        Me.tmediainfo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tmediainfo.Multiline = True
        Me.tmediainfo.Name = "tmediainfo"
        Me.tmediainfo.ReadOnly = True
        Me.tmediainfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tmediainfo.Size = New System.Drawing.Size(503, 331)
        Me.tmediainfo.TabIndex = 0
        '
        'tabSetting
        '
        Me.tabSetting.ContextMenuStrip = Me.cms_settings
        Me.tabSetting.Controls.Add(Me.TabPage1)
        Me.tabSetting.Controls.Add(Me.TabPage2)
        Me.tabSetting.Controls.Add(Me.TabPage4)
        Me.tabSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabSetting.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSetting.Location = New System.Drawing.Point(0, 0)
        Me.tabSetting.Margin = New System.Windows.Forms.Padding(0)
        Me.tabSetting.Name = "tabSetting"
        Me.tabSetting.SelectedIndex = 0
        Me.tabSetting.Size = New System.Drawing.Size(511, 362)
        Me.tabSetting.TabIndex = 14
        '
        'k3SettingPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(511, 362)
        Me.Controls.Add(Me.tabSetting)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Snow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "k3SettingPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Kookie3 Options"
        Me.cms_settings.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.tabSetting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cms_settings As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ls_dev As System.Windows.Forms.ListBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents propgrid As System.Windows.Forms.PropertyGrid
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tmediainfo As System.Windows.Forms.TextBox
    Friend WithEvents tabSetting As System.Windows.Forms.TabControl
End Class
