Public Class K3LibraryView
    ReadOnly nl As String = Environment.NewLine
    Dim las_find_lib As Integer = -1
    Dim las_find_str_lib As String = ""
    Const tabc As Char = Chr(9)
    Const csv As Char = ","

    Dim las_find_pview As Integer
    Dim las_find_str_pview As String
    Private Sub TFIND_preview()
        preview_list.SelectedItems.Clear()
        las_find_pview = -1
        las_find_str_pview = t_find.Text
        For i = 0 To preview_list.Items.Count - 1
            If preview_list.Items(i).ToString.ToLower.Contains(t_find.Text.ToLower) Then
                las_find_pview = i
                Exit For
            End If
        Next
        If las_find_pview >= 0 Then
            preview_list.Focus()
            ' t_find.Visible = False
            preview_list.SelectedIndices.Add(las_find_pview)

            ' lb_pl.FocusedItem = lb_pl.Items(las_find_pl)
            '  lb_pl.EnsureVisible(las_find_pl)
        End If
    End Sub

    Private Sub TFINDNEXT_preview()
        Dim lfnd As Integer = las_find_pview
        For i = las_find_pview + 1 To preview_list.Items.Count - 1
            If preview_list.Items(i).ToString.ToLower.Contains(t_find.Text.ToLower) Then
                las_find_pview = i
                Exit For
            End If
        Next
        If las_find_pview > lfnd Then
            ' lb_pl.Focus()
            '   lb_pl.Items(las_find_pl).Selected = True
            preview_list.SelectedIndices.Add(las_find_pview)
            ' lb_pl.FocusedItem = lb_pl.Items(las_find_pl)
            '  lb_pl.EnsureVisible(las_find_pl)
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If
    End Sub


    Private Sub TFIND_library()
        lb_Library.SelectedItems.Clear()
            las_find_lib = -1
            las_find_str_lib = t_find.Text
            For i = 0 To lb_Library.Items.Count - 1
            If lb_Library.Items(i).Text.ToString.ToLower.Contains(t_find.Text.ToLower) Then
                las_find_lib = i
                Exit For
            End If
            Next
            If las_find_lib >= 0 Then
            lb_Library.Focus()
            lb_Library.FocusedItem = lb_Library.Items(las_find_lib)
            lb_Library.EnsureVisible(las_find_lib)
            lb_Library.Items(las_find_lib).Selected = True
            End If
    End Sub
    Private Sub TFINDNEXT_library()
        If las_find_lib < 0 Then Exit Sub
        Dim lfnd As Integer = las_find_lib
        For i = las_find_lib + 1 To lb_Library.Items.Count - 1
            If lb_Library.Items(i).Text.ToString.ToLower.Contains(t_find.Text.ToLower) Then
                las_find_lib = i
                Exit For
            End If
        Next
        If las_find_lib > lfnd Then
            'lb_Library.Focus()
            lb_Library.Items(lfnd).Selected = False
            lb_Library.FocusedItem = lb_Library.Items(las_find_lib)
            lb_Library.EnsureVisible(las_find_lib)
            lb_Library.Items(las_find_lib).Selected = True

        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If
    End Sub
    Dim _findInPreview As Boolean = False
    Private Sub t_find_KeyPRESS(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles t_find.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If _findInPreview Then
                    preview_list.Focus()
                Else
                    lb_Library.Focus()
                End If

            Case Keys.Enter
                If _findInPreview Then
                    TFIND_preview()
                Else
                    TFIND_library()
                End If
        End Select
    End Sub
    '-----------------------------------------------------------------------------------------------

    '-----------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------
    Private Sub lb_Library_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_Library.ItemActivate

        If lb_Library.SelectedIndices.Count = 0 Then
            ShowStatMsg("No action")
            Exit Sub
        End If
        
        If K3PlaylistView.lb_pl.Enabled = False Then
            ShowStatMsg("[Busy : " + K3PlaylistView._remdC.ToString + " %]")
            Exit Sub
        End If

        Dim _app2ded As Integer = 0
        For i = 0 To lb_Library.SelectedIndices.Count - 1
            Select Case lb_Library.SelectedItems(i).ImageIndex
                Case 2  'is a dir
                    If My.Computer.FileSystem.DirectoryExists(lb_Library.SelectedItems(i).Tag.ToString) Then
                        k3main.drop_AppendCi_dir(lb_Library.SelectedItems(i).Tag)
                        _app2ded += 1
                    End If

                Case 1  'is a file
                    If My.Computer.FileSystem.FileExists(lb_Library.SelectedItems(i).Tag.ToString) Then
                        k3main.drop_AppendCi_file(lb_Library.SelectedItems(i).Tag)
                        _app2ded += 1
                    End If

                Case 0  ' is a playlis
                    If My.Computer.FileSystem.FileExists(lb_Library.SelectedItems(i).Tag.ToString) Then
                        k3main.drop_AppendCi_pl(lb_Library.SelectedItems(i).Tag)
                        _app2ded += 1
                    End If

            End Select
        Next
        If _app2ded = 1 Then
            ShowStatMsg("Added to Current Playlist :: " + lb_Library.SelectedItems(0).Text)
        Else
            ShowStatMsg("Added " + _app2ded.ToString + " item(s) to Current Playlist")
        End If

        If k3main.xsproxy.Auto_Play Then
            If k3main.CiTrack < 0 And K3PlaylistView.lb_pl.Items.Count > 0 Then
                k3main.pvt_tryAUTOPLAY(IIf(k3main.xsproxy.Random_start, -1, 0))
            End If
        End If
    End Sub
   
  

    Private Sub lb_Library_KeyPRESS(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lb_Library.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                HideClose(True)
            Case Keys.X
                If e.Control Then
                    ShowStatMsg(k3main.pvt_ClearPlaylist())
                End If
            Case Keys.C
                If e.Control Then CopyToolStripMenuItem1_Click(Nothing, Nothing)
            Case Keys.V
                If e.Control Then PasteToolStripMenuItem1_Click(Nothing, Nothing)
            Case Keys.P

                CurrentPlaylistToolStripMenuItem_Click(Nothing, Nothing)
            Case Keys.F
                If e.Control Then
                    _findInPreview = False
                    t_find.Visible = True
                    t_find.Focus()
                End If
            Case Keys.F3
                TFINDNEXT_library()
            Case Keys.F1, Keys.Space
                PlaylistItemToolStripMenuItem_click(Nothing, Nothing)
            Case Keys.L
                If e.Control Then lb_Library.SelectedItems.Clear()
            Case Keys.A
                If e.Control Then
                    For i = 0 To lb_Library.Items.Count - 1
                        lb_Library.Items(i).Selected = True
                    Next
                End If
            Case Keys.G
                If e.Control Then
                    If lb_Library.View = 3 Then
                        k3main.xsproxy.Library_View_Style = 4
                    Else
                        k3main.xsproxy.Library_View_Style = 3
                    End If
                    lb_Library.RedrawItems(0, lb_Library.Items.Count - 1, False)
                End If
            Case Keys.M
                If e.Control Then
                    If e.Shift Then
                        MarkAllToolStripMenuItem_Click(Nothing, Nothing)
                    Else
                        MarkItemsToolStripMenuItem_Click(Nothing, Nothing)
                    End If
                End If

            Case Keys.U
                If e.Control Then
                    If e.Shift Then
                        UnMarkAllToolStripMenuItem_Click(Nothing, Nothing)
                    Else
                        UnMarkItemsToolStripMenuItem_Click(Nothing, Nothing)
                    End If
                End If

            Case Keys.Delete
                RemoveMarkedToolStripMenuItem_Click(Nothing, Nothing)
                '===================================================================================================================
            Case Keys.Add
                If e.Shift Then
                    If Not e.Control Then
                        Me.Size = New Size(Me.Width + 5, Me.Height)
                        ' K3LibraryView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Location = New Point(Me.Location.X, Me.Location.Y + 1)
                    End If
                Else
                    If e.Control Then
                        Me.Size = New Size(Me.Width, Me.Height + 5)
                        '  K3LibraryView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Opacity += 0.05
                    End If
                End If

            Case Keys.Subtract
                If e.Shift Then
                    If Not e.Control Then
                        Me.Size = New Size(Me.Width - 5, Me.Height)
                        '  K3LibraryView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Location = New Point(Me.Location.X, Me.Location.Y - 1)
                    End If
                Else
                    If e.Control Then
                        Me.Size = New Size(Me.Width, Me.Height - 5)
                        '  K3LibraryView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Opacity -= 0.05
                    End If
                End If
            Case Keys.Multiply
                If e.Shift Then
                    If Not e.Control Then
                        Me.Size = New Size(Me.Width + 1, Me.Height)
                        '   K3LibraryView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Location = New Point(Me.Location.X + 1, Me.Location.Y)
                    End If
                Else
                    If e.Control Then
                        
                        Me.Size = New Size(Me.Width, Me.Height + 1)
                        '  K3LibraryView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Opacity += 0.01
                    End If
                End If
            Case Keys.Divide
                If e.Shift Then
                    If Not e.Control Then
                        Me.Size = New Size(Me.Width - 1, Me.Height)
                        '     K3LibraryView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Location = New Point(Me.Location.X - 1, Me.Location.Y)
                    End If
                Else
                    If e.Control Then
                        Me.Size = New Size(Me.Width, Me.Height - 1)
                        'K3LibraryView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Opacity -= 0.01
                    End If
                End If
                '===================================================================================================================
        End Select
    End Sub

 
    Friend Sub Pl2Lib_AppendSelected()
        If K3PlaylistView.lb_pl.SelectedItems.Count = 0 Then Exit Sub
        'If lb_Library.SelectedItems.Count <> 1 Then
        '    MsgBox("Can append tracks to only one playlist at a time." + nl + nl + "Please select one playlist item from library.", vbInformation)
        '    Exit Sub
        'End If
        If _marked.Count = 0 Then Exit Sub

        For i = 0 To _marked.Count - 1
            If lb_Library.Items(_marked(i)).ImageIndex = 0 Then
                'If MsgBox("Append " + K3PlaylistView.lb_pl.SelectedIndices.Count.ToString + " item(s) to  Playlist '" + lb_Library.SelectedItems(0).Text + "'?", vbYesNo + vbQuestion) = vbYes Then
                If Not My.Computer.FileSystem.FileExists(lb_Library.Items(_marked(i)).Tag) Then Continue For
                Dim rw As New IO.StreamWriter(lb_Library.Items(_marked(i)).Tag, True)
                For ii = 0 To K3PlaylistView.lb_pl.SelectedItems.Count - 1
                    rw.WriteLine(K3PlaylistView.lb_pl.SelectedItems(ii).Tag)
                Next
                rw.Close()
                rw.Dispose()
            End If
            ' End If
        Next
        
    End Sub
  
    Friend Sub Pl2Lib_SaveSelected()
        If K3PlaylistView.lb_pl.SelectedItems.Count = 0 Then Exit Sub
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim rw As New IO.StreamWriter(sfd.FileName, False)
            For i = 0 To K3PlaylistView.lb_pl.SelectedItems.Count - 1
                rw.WriteLine(K3PlaylistView.lb_pl.SelectedItems(i).Tag)
            Next
            rw.Close()
            rw.Dispose()

            '3 add to library - dont add if already exsist
            For i = 0 To lb_Library.Items.Count - 1
                If lb_Library.Items(i).Tag.ToString.ToLower = sfd.FileName.ToLower Then Exit Sub
            Next
            k3main.drop_AddNew_FileBM(sfd.FileName, False)
            k3main.xVar_Lib_Dirty = True
        End If
    End Sub

    Private Sub K3LibraryView_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        HideClose(False)
    End Sub
    Private Sub HideClose(ByVal _hide As Boolean)
        k3main.ini_28_LIB_LOC = Me.Location
        k3main.ini_29_LIB_SIZE = Me.Size
        k3main.xsproxy.Dialog_Opacity = Me.Opacity
        If _hide Then Me.Hide()
    End Sub
    Dim pram_mdpt As New Point(-1, -1)
    Dim m_down_lh As Boolean = False
    Dim m_down_lv As Boolean = False
    Dim m_down_lib As Boolean = False
    Private Sub K3LibraryView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        If Me.Width - e.X <= 5 Then
            m_down_lh = True
            If Me.Height - e.Y <= 5 Then
                m_down_lv = True
                Me.Cursor = Cursors.PanSE
            Else
                m_down_lv = False
                Me.Cursor = Cursors.PanEast
            End If
        Else
            m_down_lh = False
            If Me.Height - e.Y <= 5 Then
                m_down_lv = True
                Me.Cursor = Cursors.PanSouth
            Else
                m_down_lv = False
            End If
        End If

        pram_mdpt.X = -e.X   '  l_main.Location.X + e.X
        pram_mdpt.Y = -e.Y   '  l_main.Location.Y + e.Y
        m_down_lib = True
    End Sub

    Private Sub K3LibraryView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If Not m_down_lib Then Exit Sub

        If m_down_lh Then
            If m_down_lv Then
                'size diagonally
                Me.Height += e.Y + pram_mdpt.Y
                Me.Width += e.X + pram_mdpt.X
            Else
                'size horizontal
                Me.Width += e.X + pram_mdpt.X
            End If
        Else
            If m_down_lv Then
                'size vertically
                Me.Height += e.Y + pram_mdpt.Y
            Else
                'move
                pram_mdpt.X += (e.X + Me.Location.X)
                pram_mdpt.Y += (e.Y + Me.Location.Y)
                k3main.xsproxy.Library_Location = pram_mdpt
            End If
        End If

        Me.Cursor = Cursors.NoMove2D
        m_down_lib = False
    End Sub

    Private Sub K3LibraryView_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not k3main._loadedlib Then Me.Close()
        '    Me.Cursor = Cursors.SizeAll
        '  Me.Size = k3main.xsproxy.Library_Size
        'Me.Location = k3main.xsproxy.Library_Location
        lb_Library.Focus()
        If lb_Library.SelectedIndices.Count > 0 Then
            lb_Library.FocusedItem = lb_Library.Items(lb_Library.SelectedIndices(lb_Library.SelectedIndices.Count - 1))
            lb_Library.EnsureVisible(lb_Library.FocusedItem.Index)
        Else
            If lb_Library.Items.Count > 0 Then
                lb_Library.FocusedItem = lb_Library.Items(0)
                lb_Library.Items(0).Selected = True
                lb_Library.EnsureVisible(0)
            End If
        End If

    End Sub
  
   
    Private Sub t_find_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles t_find.LostFocus
        t_find.Visible = False
    End Sub

  
   
  
   
    Private Sub ShowStatMsg(ByVal msg As String)
        If status_worker.Enabled Then status_worker.Stop()
        stat_lab.Text = msg
        stat_lab.Visible = True
        status_worker.Start()
    End Sub
    Dim _xmsg As String = ""

    Private Sub status_worker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status_worker.Tick
        status_worker.Stop()
        stat_lab.Text = ""
        stat_lab.Visible = False
        '   If Not lb_Library.Focused Then lb_Library.Focus()
    End Sub



    Dim _marked As New List(Of Integer)
    Private Sub MarkItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkItemsToolStripMenuItem.Click, MarkedItemsToolStripMenuItem.Click
        If lb_Library.SelectedIndices.Count = 0 Then
            ShowStatMsg("No action")
            Exit Sub
        End If
        '  _marked.Clear()
        For i = 0 To lb_Library.SelectedIndices.Count - 1
            If Not _marked.Contains(lb_Library.SelectedIndices(i)) Then _marked.Add(lb_Library.SelectedIndices(i))
            lb_Library.SelectedItems(i).ForeColor = Color.MediumBlue
        Next
        ShowStatMsg("Total " + _marked.Count.ToString + " Marked item(s).")
    End Sub
    Private Sub UnMarkItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnMarkItemsToolStripMenuItem.Click
        If lb_Library.SelectedIndices.Count = 0 Then
            ShowStatMsg("No action")
            Exit Sub
        End If
        '_marked.Clear()
        For i = 0 To lb_Library.SelectedIndices.Count - 1
            _marked.Remove(lb_Library.SelectedIndices(i))
            '_marked.Add(lb_Library.SelectedIndices(i))
            lb_Library.SelectedItems(i).ForeColor = Color.Black
        Next
        ShowStatMsg("Total " + _marked.Count.ToString + " Marked item(s).")
    End Sub
    Private Sub MarkAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkAllToolStripMenuItem.Click
        '   If lb_Library.SelectedIndices.Count = 0 Then Exit Sub
        '  _marked.Clear()
        For i = 0 To lb_Library.Items.Count - 1
            _marked.Add(i)
            lb_Library.Items(i).ForeColor = Color.MediumBlue
        Next
        ShowStatMsg("Total " + _marked.Count.ToString + " Marked item(s).")
    End Sub
    Private Sub UnMarkAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnmarkAllToolStripMenuItem.Click
        For i = 0 To _marked.Count - 1
            lb_Library.Items(_marked(i)).ForeColor = Color.Black
        Next
        _marked.Clear()
        ShowStatMsg("Total " + _marked.Count.ToString + " Marked item(s).")
    End Sub


    Private Sub RemoveMarkedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveMarkedToolStripMenuItem.Click
        If _marked.Count > 0 Then
            If MsgBox("Remove Marked Library item(s)?" + nl + nl + _marked.Count.ToString + " Item(s) marked.", vbYesNo) = vbYes Then
                Dim selind(0 To _marked.Count - 1) As Integer
                _marked.CopyTo(selind)
                _marked.Clear()
                Array.Sort(selind)
                For i = selind.Length - 1 To 0 Step -1
                    lb_Library.Items.RemoveAt(selind(i))
                Next
                k3main.xVar_Lib_Dirty = True

                'lb_Library.Items.Remove
                ShowStatMsg("Removed all marked item(s).")
            End If
        Else
            ShowStatMsg("No action")
        End If
    End Sub
    Private Sub RemoveDuplicatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveDuplicatesToolStripMenuItem1.Click
        '
        If lb_Library.Items.Count > 3000 Then
            If MsgBox("Too many items, search may take extreamly long time. Do you want to continue?", vbYesNo + vbQuestion + vbDefaultButton2) = vbNo Then
                Exit Sub
            End If
        End If
        For i = 0 To _marked.Count - 1
            lb_Library.Items(_marked(i)).ForeColor = Color.Black
        Next
        _marked.Clear()
        '     If e.Control Then
        If lb_Library.Enabled = False Then Exit Sub
        If lb_Library.Items.Count < 2 Then Exit Sub
        lb_Library.Enabled = False
        Dim titems As Integer = 0
        'search duplicates
        Dim ci_dx As Integer = 0
        Dim ci_ex As Integer = 0
        Dim ci_comps As String
        While True
            ci_comps = lb_Library.Items(ci_dx).Tag.ToString.ToLower

            ci_ex = ci_dx
            While True
                ci_ex += 1
                If ci_ex >= lb_Library.Items.Count Then Exit While
                If lb_Library.Items(ci_ex).Tag.ToString.ToLower = ci_comps Then
                    lb_Library.Items.RemoveAt(ci_ex)
                    titems += 1
                    ci_ex -= 1
                End If

            End While
            ci_dx += 1
            If ci_dx >= lb_Library.Items.Count Then Exit While
        End While


        lb_Library.Enabled = True
        If titems = 0 Then
            ShowStatMsg("No duplicate items found in Library")
        Else
            ShowStatMsg("Removed " + titems.ToString + " duplicate item(s) from Library")
            k3main.xVar_Lib_Dirty = True
        End If
        '   End If
    End Sub
    Private Sub OpenInExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenInExplorerToolStripMenuItem.Click
        If lb_Library.SelectedIndices.Count <> 1 Then
            ShowStatMsg("No Action - Select Single item to open")
            Exit Sub
        End If

        Dim fpath As String = ""
        fpath = lb_Library.SelectedItems(0).Tag.ToString
        If lb_Library.SelectedItems(0).ImageIndex <> 2 Then
            Dim dirpath As String = fpath.Remove(fpath.LastIndexOf("\"))
            '  MsgBox(("explorer.exe /select,""" + fpath + """"))
            'If My.Computer.FileSystem.FileExists(fpath) Then Process.Start("\explorer.exe /select,""" + fpath + """")
            If My.Computer.FileSystem.DirectoryExists(dirpath) Then
                Process.Start(dirpath)
                HideClose(True)
            Else
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If


        Else
            If My.Computer.FileSystem.DirectoryExists(fpath) Then
                Process.Start(fpath)
                HideClose(True)
            Else
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If

        End If

    End Sub
    Private Sub CheckForNonExistingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindInvalidItemsToolStripMenuItem.Click
        Dim empty_ind As New List(Of Integer)
        For i = 0 To lb_Library.Items.Count - 1
            If lb_Library.Items(i).ImageIndex = 2 Then
                If Not (My.Computer.FileSystem.DirectoryExists(lb_Library.Items(i).Tag.ToString)) Then empty_ind.Add(i)
            Else
                If Not (My.Computer.FileSystem.FileExists(lb_Library.Items(i).Tag.ToString)) Then empty_ind.Add(i)
            End If
        Next
        If empty_ind.Count > 0 Then
            lb_Library.SelectedItems.Clear()
            'Dim invitem As String = ""
            For i = 0 To empty_ind.Count - 1
                ' invitem += i.ToString + ".[@" + empty_ind(i).ToString + "] " + lb_Library.Items(empty_ind(i)).Text + nl + " PATH::" + lb_Library.Items(empty_ind(i)).Tag.ToString + nl + nl
                lb_Library.Items(empty_ind(i)).Selected = True
            Next
            ShowStatMsg("Found " + empty_ind.Count.ToString + " non-exsistant library item(s)")
            lb_Library.EnsureVisible(lb_Library.SelectedIndices(0))
            lb_Library.FocusedItem = lb_Library.SelectedItems(0)

        Else
            ShowStatMsg("All Library items exsist on disk")
        End If
        ' End If

    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        HideClose(True)
    End Sub
    Private Sub AppendCurrentTrackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendCurrentTrackToolStripMenuItem.Click
    
        If k3main.pvt_GetState < 2 Then
            ShowStatMsg("No Track is playing")
            Exit Sub
        End If
        If lb_Library.SelectedIndices.Count = 0 Then
            k3main.t_shortcut_MarkFav()
            ShowStatMsg("Added current track to Library.")
            Exit Sub
        End If

        Dim _pvturl As String = k3main.pvt_GetURL
        Dim _appended2 As Integer = 0
        Dim _pvtlib As String = ""
        For Each lvi As ListViewItem In lb_Library.SelectedItems
            If lvi.ImageIndex = 0 Then 'is a playlist
                If Not My.Computer.FileSystem.FileExists(lvi.Tag) Then Continue For
                _appended2 += 1
                If lbloaded And preview_list.Tag = lvi.Tag Then
                    '   _lb_close_clear(Nothing, Nothing)
                    lbprv_Path.Add(_pvturl)
                    lbprv_Name.Add(pvt_GetFileName(_pvturl))
                    preview_list.DataSource = Nothing
                    preview_list.DataSource = lbprv_Name
                    lab_counte.Text = lbprv_Path.Count.ToString + " item(s)"
                    _pvtlib = lvi.Text
                    Dim rw As New IO.StreamWriter(lvi.Tag, True)
                    rw.WriteLine(_pvturl)
                    rw.Close()
                    rw.Dispose()
                Else
                    _pvtlib = lvi.Text
                    Dim rw As New IO.StreamWriter(lvi.Tag, True)
                    rw.WriteLine(_pvturl)
                    rw.Close()
                    rw.Dispose()
                End If

            End If
        Next
        If _appended2 = 0 Then
            ShowStatMsg("No Action - Can add to library or playlists only. Please select a playlist.")
        Else
            If _appended2 = 1 Then
                ShowStatMsg("Added " + _pvturl + " to " + _pvtlib)
            Else

                ShowStatMsg("Added " + _pvturl + " to " + _appended2.ToString + " Playlist(s).")
            End If
        End If


    End Sub

    Private Sub cms_libview_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms_libview.Opening
        If k3main.pvt_GetState < 2 Then
            AppendCurrentTrackToolStripMenuItem.Enabled = False
            '  PlaylistItemToolStripMenuItem.Enabled = False
        Else
            AppendCurrentTrackToolStripMenuItem.Enabled = True
            '  PlaylistItemToolStripMenuItem.Enabled = True
        End If
        If pvt_clipboardCount() = 0 Then
            PasteToolStripMenuItem1.Enabled = False
        Else
            PasteToolStripMenuItem1.Enabled = True
        End If
    End Sub


    ' Dim xVarShowPreview As Boolean = True
    Private Sub PlaylistItemToolStripMenuItem_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlaylistItemToolStripMenuItem.Click
        If lb_Library.SelectedItems.Count = 1 Then
            Select Case lb_Library.SelectedItems(0).ImageIndex
                Case 0
                    'pl
                    _lb_Show_pl(lb_Library.SelectedItems(0).Tag, True, False)
                Case 2
                    _lb_Show_pl(lb_Library.SelectedItems(0).Tag, False, True)
                    'folder
                Case Else
                    ShowStatMsg("This item is not a Folder or a Playlist")
            End Select
        Else
            ShowStatMsg("Select One Folder or Playlist to view")
        End If

    End Sub
    Dim lbprv_Name As New List(Of String)
    Dim lbprv_Path As New List(Of String)
    Dim lbloaded As Boolean = False
    Dim lbdirty As Boolean = False
    Dim lbIsPL As Boolean = False
    Dim lbIsSubdirs As Boolean = False
    Private Sub _lb_Show_pl(ByVal path As String, ByVal _isPL As Boolean, ByVal _subdirs As Boolean)
        If lbloaded Then _lb_close_clear(Nothing, Nothing)
        
        lbIsSubdirs = _subdirs
        lbIsPL = _isPL
        If _isPL Then
            If Not k3main.pvt_LoadFilesFromPList(path, lbprv_Path) Then
                ShowStatMsg("Can't Load this Playlist from disk")
                Exit Sub
            End If
        Else
            If Not My.Computer.FileSystem.DirectoryExists(path) Then
                ShowStatMsg("Can't Load this Directory from disk")
                Exit Sub
            End If
            Dim rlso As ObjectModel.ReadOnlyCollection(Of String)
            If _subdirs Then
                rlso = My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories, k3main.ini_7_FILE_TYPES)
            Else
                rlso = My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchTopLevelOnly, k3main.ini_7_FILE_TYPES)
            End If
            For Each s As String In rlso
                lbprv_Path.Add(s)
            Next

        End If

        For i = 0 To lbprv_Path.Count - 1
            lbprv_Name.Add(pvt_GetFileName(lbprv_Path(i)))
        Next
        Panel_preview.Visible = True
        preview_list.DataSource = lbprv_Name
        preview_list.Tag = path
        lab_preview.Text = pvt_GetFileName(path)
        lab_counte.Text = lbprv_Path.Count.ToString + " item(s)"
        lbloaded = True
        pvt_SetDSdirty(False)
        preview_list.Focus()

    End Sub
   
    Private Function pvt_GetFileName(ByVal path As String) As String
        If path.Contains("\") Then
            Return path.Substring(path.LastIndexOf("\")).Remove(0, 1)
        Else
            Return "?"
        End If
    End Function
    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        If Not lbloaded Then Exit Sub
        _lb_Show_pl(preview_list.Tag, lbIsPL, lbIsSubdirs)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Not lbloaded Then Exit Sub
        If Not lbIsPL Then
            ShowStatMsg("Only Playlists can be saved...")
            Exit Sub
        End If

        pvt_SetDSdirty(Not k3main.pvt_SaveFilesToPL(preview_list.Tag.ToString, lbprv_Path))
        If lbdirty Then
            ShowStatMsg("Failed")
        Else
            ShowStatMsg("Saved")

        End If
    End Sub

    Private Sub _lb_close_clear(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        preview_list.DataSource = Nothing
        preview_list.Items.Clear()
        preview_list.Tag = ""
        lbprv_Name.Clear()
        lbprv_Path.Clear()
        lab_preview.Text = ""
        lab_counte.Text = lbprv_Path.Count.ToString + " item(s)"
        Panel_preview.Visible = False
        lbloaded = False
        pvt_SetDSdirty(False)
        lb_Library.Focus()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        If Not lbloaded Then Exit Sub
        If lbprv_Path.Count <> 0 Then pvt_SetDSdirty(True)
        lbprv_Path.Clear()
        lbprv_Name.Clear()
        preview_list.DataSource = Nothing
        preview_list.DataSource = lbprv_Name
        lab_counte.Text = lbprv_Path.Count.ToString + " item(s)"
    End Sub

    Private Sub RemoveSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveSelectedToolStripMenuItem.Click
        If Not lbloaded Then Exit Sub
        If preview_list.SelectedIndices.Count = 0 Then Exit Sub
        Dim sids(0 To preview_list.SelectedIndices.Count - 1) As Integer

        preview_list.SelectedIndices.CopyTo(sids, 0)
        Array.Sort(sids)
        For i = sids.Length - 1 To 0 Step -1
            lbprv_Path.RemoveAt(sids(i))
            lbprv_Name.RemoveAt(sids(i))
        Next
        pvt_SetDSdirty(True)
        ' If lbprv_Path.Count <> 0 Then pvt_SetDSdirty(True)
        ' lbprv_Path.Clear()
        ' lbprv_Name.Clear()
        preview_list.DataSource = Nothing
        preview_list.DataSource = lbprv_Name
        lab_counte.Text = lbprv_Path.Count.ToString + " item(s)"
    End Sub
    Private Sub AppendMarkedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendMarkedToolStripMenuItem.Click
        If Not lbloaded Then Exit Sub
        Dim _items_perloop As Integer = 0
        For i = 0 To _marked.Count - 1
            If lb_Library.Items(_marked(i)).Tag = preview_list.Tag Then Continue For 'skip appending to self
            Dim path As String = lb_Library.Items(_marked(i)).Tag
            Try
                Select Case lb_Library.Items(_marked(i)).ImageIndex
                    Case 2
                        Dim rlso As ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories, k3main.ini_7_FILE_TYPES)
                        For Each s As String In rlso
                            lbprv_Path.Add(s)
                            lbprv_Name.Add(pvt_GetFileName(s))
                        Next
                        If rlso.Count > 0 Then pvt_SetDSdirty(True)
                        _items_perloop += rlso.Count
                    Case 1
                        lbprv_Path.Add(lb_Library.Items(_marked(i)).Tag)
                        lbprv_Name.Add(pvt_GetFileName(lb_Library.Items(_marked(i)).Tag))
                        pvt_SetDSdirty(True)
                        '  rw.WriteLine(lb_Library.Items(_marked(i)).Tag)
                        _items_perloop += 1
                    Case 0
                        Dim rlso As New List(Of String)
                        If k3main.pvt_LoadFilesFromPList(path, rlso) Then
                            For Each s As String In rlso
                                'rw.WriteLine(s)
                                lbprv_Path.Add(s)
                                lbprv_Name.Add(pvt_GetFileName(s))
                            Next
                            If rlso.Count > 0 Then pvt_SetDSdirty(True)
                            _items_perloop += rlso.Count
                        End If
                End Select
                '  _items_perloop += 1

            Catch ex As Exception

            End Try

        Next
        preview_list.DataSource = Nothing
        preview_list.DataSource = lbprv_Name
        lab_counte.Text = lbprv_Path.Count.ToString + " item(s)"
        ShowStatMsg("Appended " + _items_perloop.ToString + " item(s)")
    End Sub
    Private Sub pvt_SetDSdirty(ByVal d As Boolean)
        lbdirty = d
        If d Then
            lab_preview.ForeColor = Color.OrangeRed
        Else
            lab_preview.ForeColor = Color.Black
        End If
    End Sub

    Private Sub NewPlaylistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPlaylistToolStripMenuItem.Click
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim rw As New IO.StreamWriter(sfd.FileName, False)
            rw.Close()
            rw.Dispose()

            '3 add to library - dont add if already exsist
            '      For i = 0 To lb_Library.Items.Count - 1
            '          If lb_Library.Items(i).Tag.ToString.ToLower = sfd.FileName.ToLower Then Exit Sub
            '      Next
            k3main.drop_AddNew_FileBM(sfd.FileName, True)
            k3main.xVar_Lib_Dirty = True
            ShowStatMsg("Created New Playlist @ " + sfd.FileName)
        End If
    End Sub

    Private Sub cms_plist_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms_plist.Opening
        SaveToolStripMenuItem.Enabled = lbdirty
        If _marked.Count = 0 Then
            AppendMarkedToolStripMenuItem.Enabled=False
        Else
            AppendMarkedToolStripMenuItem.Enabled = True
        End If
        If pvt_clipboardCount() = 0 Then
            PasteToolStripMenuItem.Enabled = False
        Else
            PasteToolStripMenuItem.Enabled = True
        End If
        If preview_list.SelectedIndices.Count = 0 Then
            PlaySelectedToolStripMenuItem.Enabled = False
            QueueSelectedToolStripMenuItem.Enabled = False
            RemoveSelectedToolStripMenuItem.Enabled = False
        Else
            PlaySelectedToolStripMenuItem.Enabled = True
            QueueSelectedToolStripMenuItem.Enabled = True
            RemoveSelectedToolStripMenuItem.Enabled = True
        End If
    End Sub


    Private Sub preview_list_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles preview_list.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                pvt_lbPreview_ItemActivate(Not e.Control)
            Case Keys.Escape
                _lb_close_clear(Nothing, Nothing)
            Case Keys.Delete
                RemoveSelectedToolStripMenuItem_Click(Nothing, Nothing)
            Case Keys.C
                If e.Control Then
                    e.SuppressKeyPress = True
                    CopyToolStripMenuItem_Click(Nothing, Nothing)
                End If

            Case Keys.V
                If e.Control Then
                    e.SuppressKeyPress = True
                    PasteToolStripMenuItem_Click(Nothing, Nothing)
                End If

            Case Keys.S

                If e.Control Then
                    e.SuppressKeyPress = True
                    SaveToolStripMenuItem_Click(Nothing, Nothing)
                End If

            Case Keys.R

                If e.Control Then
                    e.SuppressKeyPress = True
                    ClearToolStripMenuItem_Click(Nothing, Nothing)
                End If

            Case Keys.M
                If e.Control Then
                    e.SuppressKeyPress = True
                    AppendMarkedToolStripMenuItem_Click(Nothing, Nothing)
                End If

            Case Keys.A

                If e.Control Then
                    e.SuppressKeyPress = True
                    SelectAllToolStripMenuItem_Click(Nothing, Nothing)
                End If

            Case Keys.L
                If e.Control Then
                    e.SuppressKeyPress = True
                    SelectNoneToolStripMenuItem_Click(Nothing, Nothing)
                End If
            Case Keys.F
                If e.Control Then
                    e.SuppressKeyPress = True
                    _findInPreview = True
                    t_find.Visible = True
                    t_find.Focus()
                End If
            Case Keys.F3
                TFINDNEXT_preview()
            Case Keys.Multiply
                k3main.xsproxy.Library_Preview_Width -= 5
            Case Keys.Divide
                k3main.xsproxy.Library_Preview_Width += 5
        End Select
    End Sub

    Private Sub pvt_lbPreview_ItemActivate(ByVal _playnow As Boolean)
        If preview_list.SelectedIndices.Count = 0 Then Exit Sub
        If K3PlaylistView.lb_pl.Enabled = False Then
            ShowStatMsg("[Busy : " + K3PlaylistView._remdC.ToString + " %]")
            Exit Sub
        End If
        '   If _clearPL Then k3main.pvt_ClearPlaylist()
        Dim data(0 To preview_list.SelectedIndices.Count - 1) As String
        For i = 0 To data.Length - 1
            data(i) = lbprv_Path(preview_list.SelectedIndices(i))
        Next
        Dim nos_items As Integer = k3main.pvt_Append2Playlist(data)
        'If ini_15_AUTO_PLAY Then pvt_tryAUTOPLAY(K3PlaylistView.lb_pl.Items.Count - nos_items)
        If _playnow Then k3main.pvt_tryAUTOPLAY(K3PlaylistView.lb_pl.Items.Count - nos_items)
        ShowStatMsg("Added " + nos_items.ToString + " item(s) to Current Playlist.")
    End Sub

    Private Sub PlaySelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlaySelectedToolStripMenuItem.Click
        pvt_lbPreview_ItemActivate(True)
    End Sub

 

    Private Sub preview_list_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles preview_list.MouseDoubleClick
        pvt_lbPreview_ItemActivate(True)
    End Sub
    Private Sub QueueSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueueSelectedToolStripMenuItem.Click
        pvt_lbPreview_ItemActivate(False)
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        For i = 0 To preview_list.Items.Count - 1
            preview_list.SelectedIndices.Add(i)
        Next
    End Sub
    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        preview_list.SelectedItems.Clear()
    End Sub

    Private Sub cms_markeditemsL_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms_markeditemsL.Opening
        If _marked.Count = 0 Then
            RemoveMarkedToolStripMenuItem.Enabled = False
        Else
            RemoveMarkedToolStripMenuItem.Enabled = True
        End If
        If lb_Library.SelectedIndices.Count = 0 Then
            MarkItemsToolStripMenuItem.Enabled = False
            UnMarkItemsToolStripMenuItem.Enabled = False
        Else
            MarkItemsToolStripMenuItem.Enabled = True
            UnMarkItemsToolStripMenuItem.Enabled = True
        End If
    End Sub

    '=====================================================

    Friend _remdC As Single
    'Friend _switch As Boolean
    Private Sub pl_worker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Lib_worker.DoWork

        Dim titems As Integer = 0
        'search duplicates
        Dim ci_dx As Integer = 0
        Dim ci_ex As Integer = 0
        Dim ci_comps As String

        While True
            ci_comps = lbprv_Path(ci_dx).ToLower

            ci_ex = ci_dx
            _remdC = Math.Round((ci_dx / lbprv_Path.Count) * 100, 2)
            While True
                ci_ex += 1
                'pl_worker.ReportProgress(1, ci_ex)

                If ci_ex >= lbprv_Path.Count Then Exit While
                If lbprv_Path(ci_ex).ToLower = ci_comps Then
                    _wait_progress = True
                    Lib_worker.ReportProgress(0, ci_ex)

                    While _wait_progress
                    End While
                    titems += 1
                    ci_ex -= 1
                End If

            End While
            ci_dx += 1
            If ci_dx >= lbprv_Path.Count Then Exit While
        End While

        e.Result = titems
    End Sub
    Dim _wait_progress As Boolean = False
    Private Sub pl_worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Lib_worker.ProgressChanged
        lbprv_Path.RemoveAt(e.UserState)
        lbprv_Name.RemoveAt(e.UserState)
        lab_counte.Text = lbprv_Path.Count.ToString + " / " + preview_list.Items.Count.ToString + " [" + _remdC.ToString + "]"
        _wait_progress = False
    End Sub

    Private Sub pl_worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Lib_worker.RunWorkerCompleted

        If e.Result = 0 Then
            '  MsgBox("No duplicate items found in Playlist", vbInformation)
            ShowStatMsg("No duplicates")
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        Else
            ShowStatMsg(e.Result.ToString + " duplicate(s)")
            pvt_SetDSdirty(True)
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            '  MsgBox("Removed " + e.Result.ToString + " duplicate item(s) from Playlist", vbInformation)
        End If
        preview_list.Enabled = True
        PlaylistItemToolStripMenuItem.Enabled = True
        cms_plist.Enabled = True
        preview_list.DataSource = Nothing
        preview_list.DataSource = lbprv_Name
        lab_counte.Text = lbprv_Path.Count.ToString + " item(s)"
    End Sub


    Private Sub RemoveDuplicatesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveDuplicatesToolStripMenuItem.Click
        If Not lbloaded Then Exit Sub
        If preview_list.Items.Count = 0 Then Exit Sub
        If Lib_worker.IsBusy Then Exit Sub
        preview_list.Enabled = False
        PlaylistItemToolStripMenuItem.Enabled = False
        cms_plist.Enabled = False
        ' lb_Library.Focus()
        Lib_worker.RunWorkerAsync()

    End Sub
    Dim _Clipboard As List(Of String)() = {New List(Of String), New List(Of String), New List(Of String)}  '0 for pl 1 for file 2 for folder
    Const CLIP_PL As Byte = 0
    Const CLIP_FILE As Byte = 1
    Const CLIP_DIR As Byte = 2
    Private Sub pvt_clipClearBoard()
        For i = 0 To _Clipboard.Length - 1
            _Clipboard(i).Clear()
        Next
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        If preview_list.SelectedIndices.Count = 0 Then Exit Sub
        pvt_clipClearBoard()
        '  Dim cpc As Integer = 0
        For i = 0 To preview_list.SelectedIndices.Count - 1
            'copy only files
            _Clipboard(CLIP_FILE).Add(lbprv_Path(preview_list.SelectedIndices(i)))
        Next
        ShowStatMsg("Copied " + _Clipboard(CLIP_FILE).Count.ToString + " item(s)")
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        If Not lbloaded Then Exit Sub
        If pvt_clipboardCount() = 0 Then Exit Sub

        For i = 0 To _Clipboard(CLIP_FILE).Count - 1
            lbprv_Path.Add(_Clipboard(CLIP_FILE)(i))
            lbprv_Name.Add(pvt_GetFileName(_Clipboard(CLIP_FILE)(i)))
        Next
        If _Clipboard(CLIP_FILE).Count > 0 Then pvt_SetDSdirty(True)

        For i = 0 To _Clipboard(CLIP_DIR).Count - 1
            Dim cdir As String = _Clipboard(CLIP_DIR)(i)
            If Not My.Computer.FileSystem.DirectoryExists(cdir) Then Continue For
            Dim rlso As ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(cdir, FileIO.SearchOption.SearchAllSubDirectories, k3main.ini_7_FILE_TYPES)
            For Each s As String In rlso
                lbprv_Path.Add(s)
                lbprv_Name.Add(pvt_GetFileName(s))
            Next
            If rlso.Count > 0 Then pvt_SetDSdirty(True)
        Next
        For i = 0 To _Clipboard(CLIP_PL).Count - 1
            Dim rlso As New List(Of String)
            If k3main.pvt_LoadFilesFromPList(_Clipboard(CLIP_PL)(i), rlso) Then
                For Each s As String In rlso
                    'rw.WriteLine(s)
                    lbprv_Path.Add(s)
                    lbprv_Name.Add(pvt_GetFileName(s))
                Next
                If rlso.Count > 0 Then pvt_SetDSdirty(True)
            End If
        Next


        preview_list.DataSource = Nothing
        preview_list.DataSource = lbprv_Name
        lab_counte.Text = lbprv_Path.Count.ToString + " item(s)"
        ShowStatMsg("Pasted " + pvt_clipboardCount().ToString + " item(s)")

    End Sub

    Private Sub CopyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        If lb_Library.SelectedIndices.Count = 0 Then Exit Sub
        pvt_clipClearBoard()
        Dim cdir As String
        '  Dim cpc As Integer = 0
        For i = 0 To lb_Library.SelectedItems.Count - 1
            cdir = lb_Library.SelectedItems(i).Tag

            Select Case lb_Library.SelectedItems(i).ImageIndex
                Case 0
                    If My.Computer.FileSystem.FileExists(cdir) Then _Clipboard(CLIP_PL).Add(cdir)
                Case 1
                    If My.Computer.FileSystem.FileExists(cdir) Then _Clipboard(CLIP_FILE).Add(cdir)
                Case 2
                    If My.Computer.FileSystem.DirectoryExists(cdir) Then _Clipboard(CLIP_DIR).Add(cdir)
            End Select

        Next
        ShowStatMsg("Copied " + pvt_clipboardCount.ToString + " item(s)")
    End Sub
    Private Function pvt_clipboardCount() As Integer
        Dim res As Integer = 0
        For i = 0 To _Clipboard.Length - 1
            res += _Clipboard(i).Count
        Next
        Return res
    End Function

    Private Sub PasteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem1.Click
        '   If Not lbloaded Then Exit Sub
        If pvt_clipboardCount() = 0 Then Exit Sub
        For i = 0 To _Clipboard.Length - 1
            k3main.pvt_Append2Library(_Clipboard(i).ToArray)
        Next
        k3main.xVar_Lib_Dirty = True
        'pvt_SetDSdirty(True)
        ShowStatMsg("Pasted " + pvt_clipboardCount().ToString + " item(s)")

    End Sub

    Private Sub CurrentPlaylistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentPlaylistToolStripMenuItem.Click
        k3main.PlaylistToolStripMenuItem_Click(Nothing, Nothing)
    End Sub


    Private Sub lb_Library_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lb_Library.SelectedIndexChanged

    End Sub


    Dim preview_sizer As Point
    Dim preview_md = False
    Private Sub Panel_preview_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel_preview.MouseDown, lab_preview.MouseDown
        preview_md = True
        preview_sizer = e.Location
    End Sub

    Private Sub Panel_preview_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel_preview.MouseUp, lab_preview.MouseUp
        If Not preview_md Then Exit Sub
        Panel_preview.Width += (preview_sizer.X - e.Location.X)
        preview_md = False
    End Sub

    Private Sub lb_Library_DragEnter(sender As Object, e As DragEventArgs) Handles lb_Library.DragEnter
        If e.Data.GetDataPresent(Windows.Forms.DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy ' (+) sign
            'e.Effect = DragDropEffects.Link     ' (shortcur curved arraow) sign
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub lb_Library_DragDrop(sender As Object, e As DragEventArgs) Handles lb_Library.DragDrop
        k3main.pvt_Append2Library(e.Data.GetData(Windows.Forms.DataFormats.FileDrop))
    End Sub



End Class