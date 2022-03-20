<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K3PlaylistView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K3PlaylistView))
        Me.lb_pl = New System.Windows.Forms.ListBox()
        Me.cms_pl_view = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShuffleOnceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SimpleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtendedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectedItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveInNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppendToMarkedPlaylistsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveDuplicatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenInExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.t_find = New System.Windows.Forms.TextBox()
        Me.pl_worker = New System.ComponentModel.BackgroundWorker()
        Me.cms_pl_view.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_pl
        '
        Me.lb_pl.AllowDrop = True
        Me.lb_pl.BackColor = System.Drawing.Color.Black
        Me.lb_pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lb_pl.ColumnWidth = 500
        Me.lb_pl.ContextMenuStrip = Me.cms_pl_view
        Me.lb_pl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_pl.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_pl.ForeColor = System.Drawing.Color.White
        Me.lb_pl.ItemHeight = 19
        Me.lb_pl.Location = New System.Drawing.Point(3, 23)
        Me.lb_pl.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_pl.MultiColumn = True
        Me.lb_pl.Name = "lb_pl"
        Me.lb_pl.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lb_pl.Size = New System.Drawing.Size(346, 269)
        Me.lb_pl.TabIndex = 1
        Me.lb_pl.TabStop = False
        Me.lb_pl.UseTabStops = False
        '
        'cms_pl_view
        '
        Me.cms_pl_view.BackColor = System.Drawing.Color.Beige
        Me.cms_pl_view.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayToolStripMenuItem, Me.ShuffleOnceToolStripMenuItem, Me.SelectToolStripMenuItem, Me.SelectedItemsToolStripMenuItem, Me.ToolStripSeparator1, Me.RemoveDuplicatesToolStripMenuItem, Me.OpenInExplorerToolStripMenuItem, Me.ClearToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.cms_pl_view.Name = "cms_pl_view"
        Me.cms_pl_view.ShowImageMargin = False
        Me.cms_pl_view.ShowItemToolTips = False
        Me.cms_pl_view.Size = New System.Drawing.Size(158, 186)
        '
        'PlayToolStripMenuItem
        '
        Me.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        Me.PlayToolStripMenuItem.ShortcutKeyDisplayString = "Enter"
        Me.PlayToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PlayToolStripMenuItem.Text = "&Play Now"
        '
        'ShuffleOnceToolStripMenuItem
        '
        Me.ShuffleOnceToolStripMenuItem.Name = "ShuffleOnceToolStripMenuItem"
        Me.ShuffleOnceToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S"
        Me.ShuffleOnceToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ShuffleOnceToolStripMenuItem.Text = "Shuffle Once"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SimpleToolStripMenuItem, Me.ExtendedToolStripMenuItem})
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SelectToolStripMenuItem.Text = "Select Mode"
        '
        'SimpleToolStripMenuItem
        '
        Me.SimpleToolStripMenuItem.Name = "SimpleToolStripMenuItem"
        Me.SimpleToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.SimpleToolStripMenuItem.Text = "Simple"
        '
        'ExtendedToolStripMenuItem
        '
        Me.ExtendedToolStripMenuItem.Name = "ExtendedToolStripMenuItem"
        Me.ExtendedToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ExtendedToolStripMenuItem.Text = "Extended"
        '
        'SelectedItemsToolStripMenuItem
        '
        Me.SelectedItemsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveInNewToolStripMenuItem, Me.AppendToMarkedPlaylistsToolStripMenuItem, Me.RemoveFromPlaylistToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.ClearSelectionToolStripMenuItem})
        Me.SelectedItemsToolStripMenuItem.Name = "SelectedItemsToolStripMenuItem"
        Me.SelectedItemsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SelectedItemsToolStripMenuItem.Text = "Selected Items"
        '
        'SaveInNewToolStripMenuItem
        '
        Me.SaveInNewToolStripMenuItem.Name = "SaveInNewToolStripMenuItem"
        Me.SaveInNewToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.SaveInNewToolStripMenuItem.Text = "Save in New Playlist"
        '
        'AppendToMarkedPlaylistsToolStripMenuItem
        '
        Me.AppendToMarkedPlaylistsToolStripMenuItem.Name = "AppendToMarkedPlaylistsToolStripMenuItem"
        Me.AppendToMarkedPlaylistsToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AppendToMarkedPlaylistsToolStripMenuItem.Text = "Append to Marked Playlists"
        '
        'RemoveFromPlaylistToolStripMenuItem
        '
        Me.RemoveFromPlaylistToolStripMenuItem.Name = "RemoveFromPlaylistToolStripMenuItem"
        Me.RemoveFromPlaylistToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.RemoveFromPlaylistToolStripMenuItem.Text = "Remove from Playlist"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'ClearSelectionToolStripMenuItem
        '
        Me.ClearSelectionToolStripMenuItem.Name = "ClearSelectionToolStripMenuItem"
        Me.ClearSelectionToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ClearSelectionToolStripMenuItem.Text = "Select None"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(154, 6)
        '
        'RemoveDuplicatesToolStripMenuItem
        '
        Me.RemoveDuplicatesToolStripMenuItem.Name = "RemoveDuplicatesToolStripMenuItem"
        Me.RemoveDuplicatesToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.RemoveDuplicatesToolStripMenuItem.Text = "Remove Duplicates"
        '
        'OpenInExplorerToolStripMenuItem
        '
        Me.OpenInExplorerToolStripMenuItem.Name = "OpenInExplorerToolStripMenuItem"
        Me.OpenInExplorerToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.OpenInExplorerToolStripMenuItem.Text = "Open in Explorer"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ClearToolStripMenuItem.Text = "Clear Playlist"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Esc"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExitToolStripMenuItem.Text = "Close"
        '
        't_find
        '
        Me.t_find.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.t_find.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.t_find.Cursor = System.Windows.Forms.Cursors.Default
        Me.t_find.Dock = System.Windows.Forms.DockStyle.Top
        Me.t_find.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_find.Location = New System.Drawing.Point(3, 3)
        Me.t_find.Name = "t_find"
        Me.t_find.Size = New System.Drawing.Size(346, 20)
        Me.t_find.TabIndex = 2
        Me.t_find.TabStop = False
        Me.t_find.Tag = "0"
        Me.t_find.Visible = False
        '
        'pl_worker
        '
        Me.pl_worker.WorkerReportsProgress = True
        '
        'K3PlaylistView
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(354, 297)
        Me.Controls.Add(Me.lb_pl)
        Me.Controls.Add(Me.t_find)
        Me.Cursor = System.Windows.Forms.Cursors.NoMove2D
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K3PlaylistView"
        Me.Opacity = 0.9R
        Me.Padding = New System.Windows.Forms.Padding(3, 3, 5, 5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "K3 Playlist"
        Me.TopMost = True
        Me.cms_pl_view.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_pl As System.Windows.Forms.ListBox
    Friend WithEvents t_find As System.Windows.Forms.TextBox
    Friend WithEvents pl_worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents cms_pl_view As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PlayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SimpleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtendedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectedItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveInNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendToMarkedPlaylistsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveFromPlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShuffleOnceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveDuplicatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
