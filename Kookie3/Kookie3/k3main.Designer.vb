<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class k3main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(k3main))
        Me.mp_TIMER = New System.ComponentModel.BackgroundWorker()
        Me.vis_l_main = New System.Windows.Forms.Label()
        Me.cms_vis_l_main = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrevToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibraryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cms_settings = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImportConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveCurrentConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppDirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReinitializeDefaultDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CenterScreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.VisitWebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FocusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.t_cmd = New System.Windows.Forms.TextBox()
        Me.cdbox = New System.Windows.Forms.ColorDialog()
        Me.msg_timer = New System.Windows.Forms.Timer(Me.components)
        Me.fontdig = New System.Windows.Forms.FontDialog()
        Me.ipc_worker = New System.ComponentModel.BackgroundWorker()
        Me.vis_seek = New System.Windows.Forms.PictureBox()
        Me.noteIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.vis_pic = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cms_vis_l_main.SuspendLayout()
        Me.cms_settings.SuspendLayout()
        CType(Me.vis_seek, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vis_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mp_TIMER
        '
        Me.mp_TIMER.WorkerReportsProgress = True
        Me.mp_TIMER.WorkerSupportsCancellation = True
        '
        'vis_l_main
        '
        Me.vis_l_main.AutoEllipsis = True
        Me.vis_l_main.BackColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.vis_l_main.ContextMenuStrip = Me.cms_vis_l_main
        Me.vis_l_main.Cursor = System.Windows.Forms.Cursors.Default
        Me.vis_l_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vis_l_main.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vis_l_main.ForeColor = System.Drawing.Color.White
        Me.vis_l_main.Location = New System.Drawing.Point(29, 0)
        Me.vis_l_main.Margin = New System.Windows.Forms.Padding(0)
        Me.vis_l_main.Name = "vis_l_main"
        Me.vis_l_main.Size = New System.Drawing.Size(171, 29)
        Me.vis_l_main.TabIndex = 1
        Me.vis_l_main.Text = "Kookie3"
        Me.vis_l_main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cms_vis_l_main
        '
        Me.cms_vis_l_main.BackColor = System.Drawing.Color.Beige
        Me.cms_vis_l_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayToolStripMenuItem, Me.RestartToolStripMenuItem, Me.NextToolStripMenuItem, Me.PrevToolStripMenuItem, Me.InfoToolStripMenuItem, Me.PlaylistToolStripMenuItem, Me.LibraryToolStripMenuItem, Me.ToolStripSeparator1, Me.SettingsToolStripMenuItem, Me.FocusToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.cms_vis_l_main.Name = "cms_vis_l_main"
        Me.cms_vis_l_main.ShowImageMargin = False
        Me.cms_vis_l_main.ShowItemToolTips = False
        Me.cms_vis_l_main.Size = New System.Drawing.Size(151, 230)
        '
        'PlayToolStripMenuItem
        '
        Me.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        Me.PlayToolStripMenuItem.ShortcutKeyDisplayString = "Space"
        Me.PlayToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.PlayToolStripMenuItem.Tag = "P&ause"
        Me.PlayToolStripMenuItem.Text = "Pl&ay"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Space), System.Windows.Forms.Keys)
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.RestartToolStripMenuItem.Text = "&Restart"
        '
        'NextToolStripMenuItem
        '
        Me.NextToolStripMenuItem.Name = "NextToolStripMenuItem"
        Me.NextToolStripMenuItem.ShortcutKeyDisplayString = "->"
        Me.NextToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.NextToolStripMenuItem.Text = "&Next Track"
        '
        'PrevToolStripMenuItem
        '
        Me.PrevToolStripMenuItem.Name = "PrevToolStripMenuItem"
        Me.PrevToolStripMenuItem.ShortcutKeyDisplayString = "<-"
        Me.PrevToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.PrevToolStripMenuItem.Text = "Pre&v Track"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.ShortcutKeyDisplayString = "I"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.InfoToolStripMenuItem.Text = "Media &Info"
        '
        'PlaylistToolStripMenuItem
        '
        Me.PlaylistToolStripMenuItem.Name = "PlaylistToolStripMenuItem"
        Me.PlaylistToolStripMenuItem.ShortcutKeyDisplayString = "P"
        Me.PlaylistToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.PlaylistToolStripMenuItem.Text = "&Playlist"
        '
        'LibraryToolStripMenuItem
        '
        Me.LibraryToolStripMenuItem.Name = "LibraryToolStripMenuItem"
        Me.LibraryToolStripMenuItem.ShortcutKeyDisplayString = "L"
        Me.LibraryToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.LibraryToolStripMenuItem.Text = "&Library"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(147, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDown = Me.cms_settings
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.ShortcutKeyDisplayString = ""
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.SettingsToolStripMenuItem.Text = "S&ettings"
        '
        'cms_settings
        '
        Me.cms_settings.BackColor = System.Drawing.Color.Beige
        Me.cms_settings.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportConfigToolStripMenuItem, Me.SaveCurrentConfigToolStripMenuItem, Me.ExportConfigToolStripMenuItem, Me.ConfigurationToolStripMenuItem, Me.AppDirToolStripMenuItem, Me.ToolStripSeparator3, Me.StatusInfoToolStripMenuItem, Me.ReinitializeDefaultDeviceToolStripMenuItem, Me.ToolStripSeparator2, Me.CenterScreenToolStripMenuItem, Me.AutoSizeToolStripMenuItem, Me.ToolStripSeparator4, Me.VisitWebsiteToolStripMenuItem})
        Me.cms_settings.Name = "cms_vis_l_main"
        Me.cms_settings.ShowImageMargin = False
        Me.cms_settings.ShowItemToolTips = False
        Me.cms_settings.Size = New System.Drawing.Size(219, 242)
        '
        'ImportConfigToolStripMenuItem
        '
        Me.ImportConfigToolStripMenuItem.Name = "ImportConfigToolStripMenuItem"
        Me.ImportConfigToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O"
        Me.ImportConfigToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ImportConfigToolStripMenuItem.Text = "Load Config"
        '
        'SaveCurrentConfigToolStripMenuItem
        '
        Me.SaveCurrentConfigToolStripMenuItem.Name = "SaveCurrentConfigToolStripMenuItem"
        Me.SaveCurrentConfigToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S"
        Me.SaveCurrentConfigToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.SaveCurrentConfigToolStripMenuItem.Text = "Save Config"
        '
        'ExportConfigToolStripMenuItem
        '
        Me.ExportConfigToolStripMenuItem.Name = "ExportConfigToolStripMenuItem"
        Me.ExportConfigToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S"
        Me.ExportConfigToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ExportConfigToolStripMenuItem.Text = "Save As Config"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.ShortcutKeyDisplayString = "E"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ConfigurationToolStripMenuItem.Text = "Show Configuration"
        '
        'AppDirToolStripMenuItem
        '
        Me.AppDirToolStripMenuItem.Name = "AppDirToolStripMenuItem"
        Me.AppDirToolStripMenuItem.ShortcutKeyDisplayString = "F2"
        Me.AppDirToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AppDirToolStripMenuItem.Text = "Open App Directory"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(215, 6)
        '
        'StatusInfoToolStripMenuItem
        '
        Me.StatusInfoToolStripMenuItem.Name = "StatusInfoToolStripMenuItem"
        Me.StatusInfoToolStripMenuItem.ShortcutKeyDisplayString = "V"
        Me.StatusInfoToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.StatusInfoToolStripMenuItem.Text = "Select Audio Device"
        Me.StatusInfoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'ReinitializeDefaultDeviceToolStripMenuItem
        '
        Me.ReinitializeDefaultDeviceToolStripMenuItem.Name = "ReinitializeDefaultDeviceToolStripMenuItem"
        Me.ReinitializeDefaultDeviceToolStripMenuItem.ShortcutKeyDisplayString = "Enter"
        Me.ReinitializeDefaultDeviceToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ReinitializeDefaultDeviceToolStripMenuItem.Text = "Reinitialize Default Device"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(215, 6)
        '
        'CenterScreenToolStripMenuItem
        '
        Me.CenterScreenToolStripMenuItem.Name = "CenterScreenToolStripMenuItem"
        Me.CenterScreenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C"
        Me.CenterScreenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.CenterScreenToolStripMenuItem.Text = "Center Screen UI"
        '
        'AutoSizeToolStripMenuItem
        '
        Me.AutoSizeToolStripMenuItem.Name = "AutoSizeToolStripMenuItem"
        Me.AutoSizeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+B"
        Me.AutoSizeToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AutoSizeToolStripMenuItem.Text = "Auto-Size UI"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(215, 6)
        '
        'VisitWebsiteToolStripMenuItem
        '
        Me.VisitWebsiteToolStripMenuItem.Name = "VisitWebsiteToolStripMenuItem"
        Me.VisitWebsiteToolStripMenuItem.ShortcutKeyDisplayString = "F1"
        Me.VisitWebsiteToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.VisitWebsiteToolStripMenuItem.Text = "Visit Website"
        Me.VisitWebsiteToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'FocusToolStripMenuItem
        '
        Me.FocusToolStripMenuItem.Name = "FocusToolStripMenuItem"
        Me.FocusToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.FocusToolStripMenuItem.Text = "&Focus"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Escape"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        't_cmd
        '
        Me.t_cmd.AcceptsReturn = True
        Me.t_cmd.AcceptsTab = True
        Me.t_cmd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.t_cmd.Location = New System.Drawing.Point(-2, 0)
        Me.t_cmd.Margin = New System.Windows.Forms.Padding(0)
        Me.t_cmd.MaxLength = 7
        Me.t_cmd.Name = "t_cmd"
        Me.t_cmd.ReadOnly = True
        Me.t_cmd.Size = New System.Drawing.Size(1, 13)
        Me.t_cmd.TabIndex = 0
        '
        'msg_timer
        '
        Me.msg_timer.Interval = 3000
        '
        'fontdig
        '
        Me.fontdig.Color = System.Drawing.SystemColors.ControlText
        Me.fontdig.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontdig.FontMustExist = True
        Me.fontdig.MaxSize = 100
        Me.fontdig.MinSize = 4
        Me.fontdig.ShowEffects = False
        '
        'ipc_worker
        '
        Me.ipc_worker.WorkerReportsProgress = True
        '
        'vis_seek
        '
        Me.vis_seek.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.vis_seek.Location = New System.Drawing.Point(0, 29)
        Me.vis_seek.Margin = New System.Windows.Forms.Padding(0)
        Me.vis_seek.Name = "vis_seek"
        Me.vis_seek.Size = New System.Drawing.Size(200, 7)
        Me.vis_seek.TabIndex = 2
        Me.vis_seek.TabStop = False
        Me.vis_seek.Tag = "1000"
        '
        'noteIcon
        '
        Me.noteIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.noteIcon.ContextMenuStrip = Me.cms_vis_l_main
        Me.noteIcon.Icon = CType(resources.GetObject("noteIcon.Icon"), System.Drawing.Icon)
        Me.noteIcon.Text = "Kookie3"
        Me.noteIcon.Visible = True
        '
        'vis_pic
        '
        Me.vis_pic.BackColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.vis_pic.ContextMenuStrip = Me.cms_vis_l_main
        Me.vis_pic.Dock = System.Windows.Forms.DockStyle.Left
        Me.vis_pic.InitialImage = CType(resources.GetObject("vis_pic.InitialImage"), System.Drawing.Image)
        Me.vis_pic.Location = New System.Drawing.Point(0, 0)
        Me.vis_pic.Margin = New System.Windows.Forms.Padding(0)
        Me.vis_pic.Name = "vis_pic"
        Me.vis_pic.Size = New System.Drawing.Size(29, 29)
        Me.vis_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.vis_pic.TabIndex = 3
        Me.vis_pic.TabStop = False
        Me.vis_pic.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.vis_l_main)
        Me.Panel1.Controls.Add(Me.vis_pic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 29)
        Me.Panel1.TabIndex = 4
        '
        'k3main
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(200, 36)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.vis_seek)
        Me.Controls.Add(Me.t_cmd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(300, 300)
        Me.Name = "k3main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Kookie3"
        Me.TopMost = True
        Me.cms_vis_l_main.ResumeLayout(False)
        Me.cms_settings.ResumeLayout(False)
        CType(Me.vis_seek, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vis_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mp_TIMER As System.ComponentModel.BackgroundWorker
    Friend WithEvents vis_l_main As System.Windows.Forms.Label
    Friend WithEvents t_cmd As System.Windows.Forms.TextBox
    Friend WithEvents cdbox As System.Windows.Forms.ColorDialog
    Friend WithEvents msg_timer As System.Windows.Forms.Timer
    Friend WithEvents fontdig As System.Windows.Forms.FontDialog
    Friend WithEvents ipc_worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents cms_vis_l_main As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PlayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrevToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LibraryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents vis_seek As System.Windows.Forms.PictureBox
    Friend WithEvents noteIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents FocusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents vis_pic As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cms_settings As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StatusInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents VisitWebsiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReinitializeDefaultDeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveCurrentConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CenterScreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoSizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AppDirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
