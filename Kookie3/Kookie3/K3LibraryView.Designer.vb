<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K3LibraryView
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Playlists", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Files", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Folders", System.Windows.Forms.HorizontalAlignment.Left)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K3LibraryView))
        Me.lb_Library = New System.Windows.Forms.ListView()
        Me.cms_libview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AppendCurrentTrackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaylistItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenInExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MarkedItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cms_markeditemsL = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MarkItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnMarkItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnmarkAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveMarkedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibraryItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cms_LibitemsL = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindInvalidItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveDuplicatesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CurrentPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lib_icons = New System.Windows.Forms.ImageList(Me.components)
        Me.t_find = New System.Windows.Forms.TextBox()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.Lib_worker = New System.ComponentModel.BackgroundWorker()
        Me.status_worker = New System.Windows.Forms.Timer(Me.components)
        Me.stat_lab = New System.Windows.Forms.Label()
        Me.preview_list = New System.Windows.Forms.ListBox()
        Me.lab_preview = New System.Windows.Forms.Label()
        Me.Panel_preview = New System.Windows.Forms.Panel()
        Me.cms_plist = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.PlaySelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueueSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppendMarkedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveDuplicatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lab_counte = New System.Windows.Forms.Label()
        Me.cms_libview.SuspendLayout()
        Me.cms_markeditemsL.SuspendLayout()
        Me.cms_LibitemsL.SuspendLayout()
        Me.Panel_preview.SuspendLayout()
        Me.cms_plist.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_Library
        '
        Me.lb_Library.AllowDrop = True
        Me.lb_Library.AutoArrange = False
        Me.lb_Library.BackColor = System.Drawing.Color.White
        Me.lb_Library.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lb_Library.ContextMenuStrip = Me.cms_libview
        Me.lb_Library.Cursor = System.Windows.Forms.Cursors.Default
        Me.lb_Library.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_Library.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Library.ForeColor = System.Drawing.Color.Black
        ListViewGroup1.Header = "Playlists"
        ListViewGroup1.Name = "group_k3p"
        ListViewGroup2.Header = "Files"
        ListViewGroup2.Name = "group_file"
        ListViewGroup3.Header = "Folders"
        ListViewGroup3.Name = "group_dir"
        Me.lb_Library.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.lb_Library.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lb_Library.HideSelection = False
        Me.lb_Library.LargeImageList = Me.lib_icons
        Me.lb_Library.Location = New System.Drawing.Point(3, 23)
        Me.lb_Library.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_Library.Name = "lb_Library"
        Me.lb_Library.Size = New System.Drawing.Size(34, 242)
        Me.lb_Library.SmallImageList = Me.lib_icons
        Me.lb_Library.TabIndex = 1
        Me.lb_Library.UseCompatibleStateImageBehavior = False
        Me.lb_Library.View = System.Windows.Forms.View.Tile
        '
        'cms_libview
        '
        Me.cms_libview.BackColor = System.Drawing.Color.Beige
        Me.cms_libview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendCurrentTrackToolStripMenuItem, Me.PlaylistItemToolStripMenuItem, Me.OpenInExplorerToolStripMenuItem, Me.ToolStripSeparator2, Me.MarkedItemsToolStripMenuItem, Me.LibraryItemsToolStripMenuItem, Me.ToolStripSeparator1, Me.CopyToolStripMenuItem1, Me.PasteToolStripMenuItem1, Me.ToolStripSeparator3, Me.CurrentPlaylistToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.cms_libview.Name = "cms_libview"
        Me.cms_libview.ShowImageMargin = False
        Me.cms_libview.ShowItemToolTips = False
        Me.cms_libview.Size = New System.Drawing.Size(160, 220)
        '
        'AppendCurrentTrackToolStripMenuItem
        '
        Me.AppendCurrentTrackToolStripMenuItem.Name = "AppendCurrentTrackToolStripMenuItem"
        Me.AppendCurrentTrackToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AppendCurrentTrackToolStripMenuItem.Text = "Add Current Track"
        '
        'PlaylistItemToolStripMenuItem
        '
        Me.PlaylistItemToolStripMenuItem.Name = "PlaylistItemToolStripMenuItem"
        Me.PlaylistItemToolStripMenuItem.ShortcutKeyDisplayString = "Space"
        Me.PlaylistItemToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PlaylistItemToolStripMenuItem.Text = "View Item"
        '
        'OpenInExplorerToolStripMenuItem
        '
        Me.OpenInExplorerToolStripMenuItem.Name = "OpenInExplorerToolStripMenuItem"
        Me.OpenInExplorerToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.OpenInExplorerToolStripMenuItem.Text = "Open in Explorer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(156, 6)
        '
        'MarkedItemsToolStripMenuItem
        '
        Me.MarkedItemsToolStripMenuItem.DropDown = Me.cms_markeditemsL
        Me.MarkedItemsToolStripMenuItem.Name = "MarkedItemsToolStripMenuItem"
        Me.MarkedItemsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.MarkedItemsToolStripMenuItem.Text = "Mark Items"
        '
        'cms_markeditemsL
        '
        Me.cms_markeditemsL.BackColor = System.Drawing.Color.Beige
        Me.cms_markeditemsL.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarkItemsToolStripMenuItem, Me.UnMarkItemsToolStripMenuItem, Me.MarkAllToolStripMenuItem, Me.UnmarkAllToolStripMenuItem, Me.RemoveMarkedToolStripMenuItem})
        Me.cms_markeditemsL.Name = "cms_markeditemsL"
        Me.cms_markeditemsL.OwnerItem = Me.MarkedItemsToolStripMenuItem
        Me.cms_markeditemsL.ShowImageMargin = False
        Me.cms_markeditemsL.ShowItemToolTips = False
        Me.cms_markeditemsL.Size = New System.Drawing.Size(183, 114)
        '
        'MarkItemsToolStripMenuItem
        '
        Me.MarkItemsToolStripMenuItem.Name = "MarkItemsToolStripMenuItem"
        Me.MarkItemsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+M"
        Me.MarkItemsToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.MarkItemsToolStripMenuItem.Text = "Mark Selected"
        '
        'UnMarkItemsToolStripMenuItem
        '
        Me.UnMarkItemsToolStripMenuItem.Name = "UnMarkItemsToolStripMenuItem"
        Me.UnMarkItemsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+U"
        Me.UnMarkItemsToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.UnMarkItemsToolStripMenuItem.Text = "UnMark Selected"
        '
        'MarkAllToolStripMenuItem
        '
        Me.MarkAllToolStripMenuItem.Name = "MarkAllToolStripMenuItem"
        Me.MarkAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+M"
        Me.MarkAllToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.MarkAllToolStripMenuItem.Text = "Mark &All"
        '
        'UnmarkAllToolStripMenuItem
        '
        Me.UnmarkAllToolStripMenuItem.Name = "UnmarkAllToolStripMenuItem"
        Me.UnmarkAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+U"
        Me.UnmarkAllToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.UnmarkAllToolStripMenuItem.Text = "Unmark All"
        '
        'RemoveMarkedToolStripMenuItem
        '
        Me.RemoveMarkedToolStripMenuItem.Name = "RemoveMarkedToolStripMenuItem"
        Me.RemoveMarkedToolStripMenuItem.ShortcutKeyDisplayString = "Delete"
        Me.RemoveMarkedToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.RemoveMarkedToolStripMenuItem.Text = "Remove Marked"
        '
        'LibraryItemsToolStripMenuItem
        '
        Me.LibraryItemsToolStripMenuItem.DropDown = Me.cms_LibitemsL
        Me.LibraryItemsToolStripMenuItem.Name = "LibraryItemsToolStripMenuItem"
        Me.LibraryItemsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.LibraryItemsToolStripMenuItem.Text = "Library Actions"
        '
        'cms_LibitemsL
        '
        Me.cms_LibitemsL.BackColor = System.Drawing.Color.Beige
        Me.cms_LibitemsL.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewPlaylistToolStripMenuItem, Me.FindInvalidItemsToolStripMenuItem, Me.RemoveDuplicatesToolStripMenuItem1})
        Me.cms_LibitemsL.Name = "cms_markeditemsL"
        Me.cms_LibitemsL.OwnerItem = Me.LibraryItemsToolStripMenuItem
        Me.cms_LibitemsL.ShowImageMargin = False
        Me.cms_LibitemsL.ShowItemToolTips = False
        Me.cms_LibitemsL.Size = New System.Drawing.Size(151, 70)
        '
        'NewPlaylistToolStripMenuItem
        '
        Me.NewPlaylistToolStripMenuItem.Name = "NewPlaylistToolStripMenuItem"
        Me.NewPlaylistToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.NewPlaylistToolStripMenuItem.Text = "Create New Playlist"
        '
        'FindInvalidItemsToolStripMenuItem
        '
        Me.FindInvalidItemsToolStripMenuItem.Name = "FindInvalidItemsToolStripMenuItem"
        Me.FindInvalidItemsToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.FindInvalidItemsToolStripMenuItem.Text = "Find Invalid Items"
        '
        'RemoveDuplicatesToolStripMenuItem1
        '
        Me.RemoveDuplicatesToolStripMenuItem1.Name = "RemoveDuplicatesToolStripMenuItem1"
        Me.RemoveDuplicatesToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.RemoveDuplicatesToolStripMenuItem1.Text = "Remove Duplicates"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(156, 6)
        '
        'CopyToolStripMenuItem1
        '
        Me.CopyToolStripMenuItem1.Name = "CopyToolStripMenuItem1"
        Me.CopyToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+C"
        Me.CopyToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.CopyToolStripMenuItem1.Text = "Copy"
        '
        'PasteToolStripMenuItem1
        '
        Me.PasteToolStripMenuItem1.Name = "PasteToolStripMenuItem1"
        Me.PasteToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+V"
        Me.PasteToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.PasteToolStripMenuItem1.Text = "Paste"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(156, 6)
        '
        'CurrentPlaylistToolStripMenuItem
        '
        Me.CurrentPlaylistToolStripMenuItem.Name = "CurrentPlaylistToolStripMenuItem"
        Me.CurrentPlaylistToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+P"
        Me.CurrentPlaylistToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CurrentPlaylistToolStripMenuItem.Text = "Show Playlist"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Escape"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ExitToolStripMenuItem.Text = "Close"
        '
        'lib_icons
        '
        Me.lib_icons.ImageStream = CType(resources.GetObject("lib_icons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.lib_icons.TransparentColor = System.Drawing.Color.Transparent
        Me.lib_icons.Images.SetKeyName(0, "icon_pl.jpg")
        Me.lib_icons.Images.SetKeyName(1, "icon_file.jpg")
        Me.lib_icons.Images.SetKeyName(2, "icon_dir.jpg")
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
        Me.t_find.Size = New System.Drawing.Size(284, 20)
        Me.t_find.TabIndex = 0
        Me.t_find.TabStop = False
        Me.t_find.Tag = "0"
        Me.t_find.Visible = False
        '
        'sfd
        '
        Me.sfd.DefaultExt = "k3p"
        Me.sfd.Filter = "Kookie3 Saved Playlist|*.k3p"
        Me.sfd.Title = "Save Playlist as..."
        '
        'Lib_worker
        '
        Me.Lib_worker.WorkerReportsProgress = True
        '
        'status_worker
        '
        Me.status_worker.Interval = 3000
        '
        'stat_lab
        '
        Me.stat_lab.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.stat_lab.Cursor = System.Windows.Forms.Cursors.Default
        Me.stat_lab.Dock = System.Windows.Forms.DockStyle.Top
        Me.stat_lab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.stat_lab.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stat_lab.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stat_lab.Location = New System.Drawing.Point(3, 23)
        Me.stat_lab.Name = "stat_lab"
        Me.stat_lab.Size = New System.Drawing.Size(34, 30)
        Me.stat_lab.TabIndex = 2
        Me.stat_lab.Text = "_"
        Me.stat_lab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.stat_lab.Visible = False
        '
        'preview_list
        '
        Me.preview_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.preview_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.preview_list.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.preview_list.FormattingEnabled = True
        Me.preview_list.ItemHeight = 19
        Me.preview_list.Location = New System.Drawing.Point(0, 19)
        Me.preview_list.Name = "preview_list"
        Me.preview_list.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.preview_list.Size = New System.Drawing.Size(250, 204)
        Me.preview_list.TabIndex = 2
        '
        'lab_preview
        '
        Me.lab_preview.AutoSize = True
        Me.lab_preview.Dock = System.Windows.Forms.DockStyle.Top
        Me.lab_preview.ForeColor = System.Drawing.Color.Black
        Me.lab_preview.Location = New System.Drawing.Point(0, 0)
        Me.lab_preview.Name = "lab_preview"
        Me.lab_preview.Size = New System.Drawing.Size(0, 19)
        Me.lab_preview.TabIndex = 5
        '
        'Panel_preview
        '
        Me.Panel_preview.ContextMenuStrip = Me.cms_plist
        Me.Panel_preview.Controls.Add(Me.preview_list)
        Me.Panel_preview.Controls.Add(Me.lab_counte)
        Me.Panel_preview.Controls.Add(Me.lab_preview)
        Me.Panel_preview.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel_preview.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel_preview.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Panel_preview.Location = New System.Drawing.Point(37, 23)
        Me.Panel_preview.Name = "Panel_preview"
        Me.Panel_preview.Size = New System.Drawing.Size(250, 242)
        Me.Panel_preview.TabIndex = 6
        Me.Panel_preview.Visible = False
        '
        'cms_plist
        '
        Me.cms_plist.BackColor = System.Drawing.Color.Beige
        Me.cms_plist.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.ToolStripSeparator4, Me.PlaySelectedToolStripMenuItem, Me.QueueSelectedToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.AppendMarkedToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.SelectNoneToolStripMenuItem, Me.ClearToolStripMenuItem, Me.RemoveSelectedToolStripMenuItem, Me.RemoveDuplicatesToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.cms_plist.Name = "cms_markeditemsL"
        Me.cms_plist.ShowImageMargin = False
        Me.cms_plist.ShowItemToolTips = False
        Me.cms_plist.Size = New System.Drawing.Size(193, 296)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SaveToolStripMenuItem.Text = "Save to Disk"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.RefreshToolStripMenuItem.Text = "Reload From Disk"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(189, 6)
        '
        'PlaySelectedToolStripMenuItem
        '
        Me.PlaySelectedToolStripMenuItem.Name = "PlaySelectedToolStripMenuItem"
        Me.PlaySelectedToolStripMenuItem.ShortcutKeyDisplayString = "Enter"
        Me.PlaySelectedToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PlaySelectedToolStripMenuItem.Text = "Play Selected"
        '
        'QueueSelectedToolStripMenuItem
        '
        Me.QueueSelectedToolStripMenuItem.Name = "QueueSelectedToolStripMenuItem"
        Me.QueueSelectedToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Enter"
        Me.QueueSelectedToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.QueueSelectedToolStripMenuItem.Text = "Queue Selected"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'AppendMarkedToolStripMenuItem
        '
        Me.AppendMarkedToolStripMenuItem.Name = "AppendMarkedToolStripMenuItem"
        Me.AppendMarkedToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+M"
        Me.AppendMarkedToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.AppendMarkedToolStripMenuItem.Text = "Paste Marked"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'SelectNoneToolStripMenuItem
        '
        Me.SelectNoneToolStripMenuItem.Name = "SelectNoneToolStripMenuItem"
        Me.SelectNoneToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+L"
        Me.SelectNoneToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SelectNoneToolStripMenuItem.Text = "Select None"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+R"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ClearToolStripMenuItem.Text = "Remove All"
        '
        'RemoveSelectedToolStripMenuItem
        '
        Me.RemoveSelectedToolStripMenuItem.Name = "RemoveSelectedToolStripMenuItem"
        Me.RemoveSelectedToolStripMenuItem.ShortcutKeyDisplayString = "Delete"
        Me.RemoveSelectedToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.RemoveSelectedToolStripMenuItem.Text = "Remove Selected"
        '
        'RemoveDuplicatesToolStripMenuItem
        '
        Me.RemoveDuplicatesToolStripMenuItem.Name = "RemoveDuplicatesToolStripMenuItem"
        Me.RemoveDuplicatesToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.RemoveDuplicatesToolStripMenuItem.Text = "Remove Duplicates"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeyDisplayString = "Escape"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'lab_counte
        '
        Me.lab_counte.AutoSize = True
        Me.lab_counte.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lab_counte.ForeColor = System.Drawing.Color.Black
        Me.lab_counte.Location = New System.Drawing.Point(0, 223)
        Me.lab_counte.Name = "lab_counte"
        Me.lab_counte.Size = New System.Drawing.Size(0, 19)
        Me.lab_counte.TabIndex = 6
        '
        'K3LibraryView
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(292, 270)
        Me.Controls.Add(Me.stat_lab)
        Me.Controls.Add(Me.lb_Library)
        Me.Controls.Add(Me.Panel_preview)
        Me.Controls.Add(Me.t_find)
        Me.Cursor = System.Windows.Forms.Cursors.NoMove2D
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K3LibraryView"
        Me.Opacity = 0.92R
        Me.Padding = New System.Windows.Forms.Padding(3, 3, 5, 5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "K3 Library"
        Me.TopMost = True
        Me.cms_libview.ResumeLayout(False)
        Me.cms_markeditemsL.ResumeLayout(False)
        Me.cms_LibitemsL.ResumeLayout(False)
        Me.Panel_preview.ResumeLayout(False)
        Me.Panel_preview.PerformLayout()
        Me.cms_plist.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_Library As System.Windows.Forms.ListView
    Friend WithEvents t_find As System.Windows.Forms.TextBox
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lib_icons As System.Windows.Forms.ImageList
    Friend WithEvents Lib_worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents cms_libview As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlaylistItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents status_worker As System.Windows.Forms.Timer
    Friend WithEvents stat_lab As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LibraryItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendCurrentTrackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkedItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cms_markeditemsL As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UnmarkAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveMarkedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cms_LibitemsL As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveDuplicatesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindInvalidItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents preview_list As System.Windows.Forms.ListBox
    Friend WithEvents lab_preview As System.Windows.Forms.Label
    Friend WithEvents Panel_preview As System.Windows.Forms.Panel
    Friend WithEvents cms_plist As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendMarkedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewPlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlaySelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QueueSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnMarkItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveDuplicatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lab_counte As System.Windows.Forms.Label
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CurrentPlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
