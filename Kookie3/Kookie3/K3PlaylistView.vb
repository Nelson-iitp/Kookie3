Public Class K3PlaylistView
    ReadOnly nl As String = Environment.NewLine
    Dim las_find_pl As Integer = -1
    Dim las_find_str_pl As String = ""
    Public Structure K3PlayListItem
        Dim _name As String
        Dim _path As String
        Public Sub New(ByVal path As String)
            _path = path
            If _path.Contains("\") Then
                _name = path.Substring(path.LastIndexOf("\")).Remove(0, 1)
            Else
                _name = "?"
            End If

        End Sub
        Public Overrides Function ToString() As String
            Return _name
        End Function
        Public ReadOnly Property Tag As String
            Get
                Return _path
            End Get
        End Property
        Public ReadOnly Property Text As String
            Get
                Return _name
            End Get
        End Property
    End Structure
    Private Sub t_find_KeyPRESS(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles t_find.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                lb_pl.Focus()
            Case Keys.Enter
                TFIND_playlist()
        End Select
    End Sub
    Private Sub t_find_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles t_find.LostFocus
        t_find.Visible = False
    End Sub

    Private Sub lb_pl_ItemActivate()
        If lb_pl.SelectedItems.Count = 0 Then Exit Sub
        k3main.CiTrack = (lb_pl.SelectedIndices(lb_pl.SelectedIndices.Count - 1))
        k3main.media_LoadMedia(lb_pl.Items(k3main.CiTrack).Tag, True, False)
    End Sub

    Private Sub lb_PL_KeyPRESS(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lb_pl.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If pl_worker.IsBusy Then pl_worker.CancelAsync()
                '   Me.DialogResult = Windows.Forms.DialogResult.OK
                HideClose(True)
            Case Keys.Enter
                lb_pl_ItemActivate()
            Case Keys.A
                If e.Control Then
                    e.SuppressKeyPress = True
                    For i = 0 To lb_pl.Items.Count - 1
                        lb_pl.SelectedIndices.Add(i)
                    Next
                End If
            Case Keys.F
                If e.Control Then
                    e.SuppressKeyPress = True
                    t_find.Visible = True
                    t_find.Focus()
                End If
            Case Keys.Space
                e.SuppressKeyPress = True
                lb_pl.SelectedIndices.Clear()
                lb_pl.SelectedIndices.Add(k3main.CiTrack)
            Case Keys.X
                If e.Control Then
                    e.SuppressKeyPress = True
                    k3main.pvt_ClearPlaylist()
                End If
            Case Keys.S
                If e.Control Then
                    e.SuppressKeyPress = True
                    media_shufflePlaylist()
                End If
            Case Keys.L
                If e.Control Then
                    e.SuppressKeyPress = True
                    lb_pl.SelectedItems.Clear()
                End If
            Case Keys.F3
                TFINDNEXT_playlist()
            Case Keys.Delete
                _Del_Selected()
                '===================================================================================================================
            Case Keys.Add
                If e.Shift Then
                    If Not e.Control Then
                        Me.Size = New Size(Me.Width + 5, Me.Height)
                        '   K3PlaylistView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Location = New Point(Me.Location.X, Me.Location.Y + 1)
                    End If
                Else
                    If e.Control Then
                        Me.Size = New Size(Me.Width, Me.Height + 5)
                        '  K3PlaylistView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Opacity += 0.05
                    End If
                End If

            Case Keys.Subtract
                If e.Shift Then
                    If Not e.Control Then
                        Me.Size = New Size(Me.Width - 5, Me.Height)
                        '  K3PlaylistView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Location = New Point(Me.Location.X, Me.Location.Y - 1)
                    End If
                Else
                    If e.Control Then
                        Me.Size = New Size(Me.Width, Me.Height - 5)
                        '  K3PlaylistView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Opacity -= 0.05
                    End If
                End If
            Case Keys.Multiply
                If e.Shift Then
                    If Not e.Control Then
                        Me.Size = New Size(Me.Width + 1, Me.Height)
                        ' K3PlaylistView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Location = New Point(Me.Location.X + 1, Me.Location.Y)
                    End If
                Else
                    If e.Control Then
                        Me.Size = New Size(Me.Width, Me.Height + 1)
                        ' K3PlaylistView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Opacity += 0.01
                    End If
                End If
            Case Keys.Divide
                If e.Shift Then
                    If Not e.Control Then
                        Me.Size = New Size(Me.Width - 1, Me.Height)
                        ' K3PlaylistView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Location = New Point(Me.Location.X - 1, Me.Location.Y)
                    End If
                Else
                    If e.Control Then
                        Me.Size = New Size(Me.Width, Me.Height - 1)
                        '  K3PlaylistView_ResizeEnd(Nothing, Nothing)
                    Else
                        Me.Opacity -= 0.01
                    End If
                End If
                '===================================================================================================================
        End Select


    End Sub
    Private Sub _Del_Selected()
        If lb_pl.SelectedIndices.Count > 0 Then
            If MsgBox("Delete Selected Playlist item(s)?" + nl + nl + lb_pl.SelectedIndices.Count.ToString + " Item(s) selected.", vbYesNo) = vbYes Then
                Dim selind(0 To lb_pl.SelectedIndices.Count - 1) As Integer
                lb_pl.SelectedIndices.CopyTo(selind, 0)
                Array.Sort(selind)
                Dim rein As Boolean = False
                Dim lasplay As Boolean = False
                For i = selind.Length - 1 To 0 Step -1
                    If selind(i) > k3main.CiTrack Then
                        'no effect
                    ElseIf selind(i) < k3main.CiTrack Then
                        k3main.CiTrack -= 1
                    Else 'is equal
                        k3main.media_FreeMedia(True) 'Stop media playing
                        rein = True
                    End If
                    lb_pl.Items.RemoveAt(selind(i))
                Next
                If k3main.CiTrack >= lb_pl.Items.Count Then k3main.CiTrack = lb_pl.Items.Count - 1

                If k3main.xsproxy.Auto_Play Then
                    If rein And k3main.CiTrack >= 0 Then
                        k3main.pvt_skipInvalid()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub _remDups()
        If lb_pl.Enabled = False Then Exit Sub
        If lb_pl.Items.Count < 2 Then Exit Sub
        ' If lb_pl.Items.Count > 3000 Then
        If MsgBox("Starting duplicate removal procedure..." + nl + nl + "WARNING: This will stop playing current media and no media can be played during the procedure. Search may take long time depending on the number of items in the playlist." + nl + nl + "Proceed to remove duplicates?", vbYesNo + vbQuestion + vbDefaultButton2) = vbYes Then
        Else
            Exit Sub
        End If
        '   End If

        lb_pl.Enabled = False
        k3main.CiTrack = -1
        '  k3main.media_FreeMedia(True)
        HideClose(True)
        pl_worker.RunWorkerAsync()


    End Sub
    Private Sub TFIND_playlist()
        lb_pl.SelectedItems.Clear()
        las_find_pl = -1
        las_find_str_pl = t_find.Text
        For i = 0 To lb_pl.Items.Count - 1
            If lb_pl.Items(i).Text.ToLower.Contains(t_find.Text.ToLower) Then
                las_find_pl = i
                Exit For
            End If
        Next
        If las_find_pl >= 0 Then
            lb_pl.Focus()
            ' t_find.Visible = False
            lb_pl.SelectedIndices.Add(las_find_pl)

            ' lb_pl.FocusedItem = lb_pl.Items(las_find_pl)
            '  lb_pl.EnsureVisible(las_find_pl)
        End If
    End Sub

    Private Sub TFINDNEXT_playlist()
        Dim lfnd As Integer = las_find_pl
        For i = las_find_pl + 1 To lb_pl.Items.Count - 1
            If lb_pl.Items(i).Text.ToLower.Contains(t_find.Text.ToLower) Then
                las_find_pl = i
                Exit For
            End If
        Next
        If las_find_pl > lfnd Then
            ' lb_pl.Focus()
            '   lb_pl.Items(las_find_pl).Selected = True
            lb_pl.SelectedIndices.Add(las_find_pl)
            ' lb_pl.FocusedItem = lb_pl.Items(las_find_pl)
            '  lb_pl.EnsureVisible(las_find_pl)
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If
    End Sub
    Dim krand As New Random(DateTime.Now.Millisecond)
    ' Dim shuffleprob As Single = 0.5
    Friend Sub media_shufflePlaylist()
        'bring ci to top
        Dim ic As Integer = lb_pl.Items.Count
        If ic < 4 Then Exit Sub

        Dim temp As Object
        Dim tempi As Integer = k3main.CiTrack
        If tempi > 0 Then
            temp = lb_pl.Items(tempi)
            lb_pl.Items.RemoveAt(tempi)
            lb_pl.Items.Insert(0, temp) 'bring it to zero
            k3main.CiTrack = 0
        End If
        'ic = 
        'randomly choose and move itms to end
        For i = 1 To (ic / 2) Step 1
            tempi = krand.Next(1, ic - 1)
            temp = lb_pl.Items(tempi)
            lb_pl.Items.RemoveAt(tempi)
            lb_pl.Items.Add(temp)       'move to end
        Next

    End Sub

    Private Sub K3PlaylistView_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        HideClose(False)
    End Sub
    Private Sub HideClose(ByVal _hide As Boolean)
        k3main.ini_30_PL_LOC = Me.Location
        k3main.ini_31_PL_SIZE = Me.Size
        k3main.xsproxy.Dialog_Opacity = Me.Opacity
        If _hide Then Me.Hide()
    End Sub
    Dim pram_mdpt As New Point(-1, -1)
    Dim m_down_plh As Boolean = False
    Dim m_down_plv As Boolean = False
    Dim m_down_pl As Boolean = False
    Private Sub K3PlaylistView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        If Me.Width - e.X <= 5 Then
            m_down_plh = True
            If Me.Height - e.Y <= 5 Then
                m_down_plv = True
                Me.Cursor = Cursors.PanSE
            Else
                m_down_plv = False
                Me.Cursor = Cursors.PanEast
            End If
        Else
            m_down_plh = False
            If Me.Height - e.Y <= 5 Then
                m_down_plv = True
                Me.Cursor = Cursors.PanSouth
            Else
                m_down_plv = False
            End If
        End If
       
        pram_mdpt.X = -e.X   '  l_main.Location.X + e.X
        pram_mdpt.Y = -e.Y   '  l_main.Location.Y + e.Y
        m_down_pl = True
    End Sub

    Private Sub K3PlaylistView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If Not m_down_pl Then Exit Sub

        If m_down_plh Then
            If m_down_plv Then
                'size diagonally
                Me.Height += e.Y + pram_mdpt.Y
                Me.Width += e.X + pram_mdpt.X
            Else
                'size horizontal
                Me.Width += e.X + pram_mdpt.X
            End If
        Else
            If m_down_plv Then
                'size vertically
                Me.Height += e.Y + pram_mdpt.Y
            Else
                'move
                pram_mdpt.X += (e.X + Me.Location.X)
                pram_mdpt.Y += (e.Y + Me.Location.Y)
                k3main.xsproxy.Playlist_Location = pram_mdpt
            End If
        End If
      
        Me.Cursor = Cursors.NoMove2D
        'm_down_plh = False
        'm_down_plv = False
        m_down_pl = False
    End Sub
    Private Sub K3PlaylistView_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If k3main.xsproxy.Playlist_BnW Then
            lb_pl.BackColor = Color.Black
            lb_pl.ForeColor = Color.White
        Else
            lb_pl.BackColor = k3main.vis_l_main.BackColor
            lb_pl.ForeColor = k3main.vis_l_main.ForeColor
        End If
        
        lb_pl.Focus()

        If lb_pl.SelectedIndices.Count > 0 Then
            '  lb_pl.FocusedItem = lb_Library.Items(lb_Library.SelectedIndices(lb_Library.SelectedIndices.Count - 1))
            ' lb_Library.EnsureVisible(lb_Library.FocusedItem.Index)
        Else
            If lb_pl.Items.Count > 0 Then
                ' lb_pl.Items(0).Selected = True
            End If
        End If
    End Sub

    Private Sub lb_pl_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lb_pl.MouseDoubleClick
        '   If lb_pl.SelectedIndices.Count = 0 Then Exit Sub
        lb_pl_ItemActivate()
    End Sub
    Friend _remdC As Single
    'Friend _switch As Boolean
    Private Sub pl_worker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles pl_worker.DoWork

        Dim titems As Integer = 0
        'search duplicates
        Dim ci_dx As Integer = 0
        Dim ci_ex As Integer = 0
        Dim ci_comps As String

        While True
            ci_comps = lb_pl.Items(ci_dx).Tag.ToString.ToLower

            ci_ex = ci_dx
            _remdC = Math.Round((ci_dx / lb_pl.Items.Count) * 100, 2)
            While True
                ci_ex += 1
                'pl_worker.ReportProgress(1, ci_ex)

                If ci_ex >= lb_pl.Items.Count Then Exit While
                If lb_pl.Items(ci_ex).Tag.ToString.ToLower = ci_comps Then
                    _wait_progress = True
                    pl_worker.ReportProgress(0, ci_ex)

                    While _wait_progress
                    End While
                    titems += 1
                    ci_ex -= 1
                End If

            End While
            ci_dx += 1
            If ci_dx >= lb_pl.Items.Count Then Exit While
        End While

        e.Result = titems
    End Sub
    Dim _wait_progress As Boolean = False
    Private Sub pl_worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles pl_worker.ProgressChanged
        lb_pl.Items.RemoveAt(e.UserState)
        _wait_progress = False
    End Sub

    Private Sub pl_worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles pl_worker.RunWorkerCompleted
        lb_pl.Enabled = True
        If e.Result = 0 Then
            '  MsgBox("No duplicate items found in Playlist", vbInformation)
            k3main.ShowMsg("No duplicates")
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        Else
            k3main.ShowMsg(e.Result.ToString + " duplicate(s)")
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            '  MsgBox("Removed " + e.Result.ToString + " duplicate item(s) from Playlist", vbInformation)
        End If
    End Sub

  

   
    Private Sub PlayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayToolStripMenuItem.Click
        lb_pl_ItemActivate()
    End Sub

    Private Sub SaveInNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveInNewToolStripMenuItem.Click
        If lb_pl.SelectedIndices.Count = 0 Then
            For i = 0 To lb_pl.Items.Count - 1
                lb_pl.SelectedIndices.Add(i)
            Next
        End If
        K3LibraryView.Pl2Lib_SaveSelected()
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
    End Sub

    Private Sub AppendToMarkedPlaylistsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendToMarkedPlaylistsToolStripMenuItem.Click
    
            If lb_pl.SelectedIndices.Count = 0 Then
                For i = 0 To lb_pl.Items.Count - 1
                    lb_pl.SelectedIndices.Add(i)
                Next
            End If
            K3LibraryView.Pl2Lib_AppendSelected()
       
    End Sub

    Private Sub RemoveFromPlaylistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveFromPlaylistToolStripMenuItem.Click
        _Del_Selected()
    End Sub

    Private Sub SimpleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleToolStripMenuItem.Click
        lb_pl.SelectionMode = SelectionMode.MultiSimple
    End Sub

    Private Sub ExtendedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtendedToolStripMenuItem.Click
        lb_pl.SelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub ClearSelectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearSelectionToolStripMenuItem.Click
        lb_pl.ClearSelected()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click

        For i = 0 To lb_pl.Items.Count - 1
            lb_pl.SelectedIndices.Add(i)
        Next

    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        k3main.pvt_ClearPlaylist()
    End Sub

    Private Sub ShuffleOnceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShuffleOnceToolStripMenuItem.Click
        media_shufflePlaylist()
    End Sub

    Private Sub RemoveDuplicatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveDuplicatesToolStripMenuItem.Click
        _remDups()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If pl_worker.IsBusy Then pl_worker.CancelAsync()
        HideClose(True)
    End Sub

    Private Sub OpenInExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenInExplorerToolStripMenuItem.Click
        If lb_pl.SelectedIndices.Count <> 1 Then Exit Sub
        Dim fpath As String = lb_pl.SelectedItems(0).Tag.ToString
        Dim dirpath As String = fpath.Remove(fpath.LastIndexOf("\"))
        If My.Computer.FileSystem.DirectoryExists(dirpath) Then
            Process.Start(dirpath)
            HideClose(True)
        End If
    End Sub


    Private Sub lb_pl_DragEnter(sender As Object, e As DragEventArgs) Handles lb_pl.DragEnter
        If e.Data.GetDataPresent(Windows.Forms.DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link     ' (shortcur curved arraow) sign
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lb_pl_DragDrop(sender As Object, e As DragEventArgs) Handles lb_pl.DragDrop
        Dim data As String() = e.Data.GetData(Windows.Forms.DataFormats.FileDrop)
        'determine what the data contains   ' may have files and/or folders
        'when drag-dropped dont clear play list
        If Not lb_pl.Enabled Then Exit Sub
        'k3main.ShowMsg("[Busy : " + Me._remdC.ToString + " %]")
        k3main.pvt_Append2Playlist(data)
        If k3main.xsproxy.Auto_Play Then
            If k3main.CiTrack < 0 And lb_pl.Items.Count > 0 Then
                k3main.pvt_tryAUTOPLAY(IIf(k3main.xsproxy.Random_start, -1, 0))
            End If
        End If

    End Sub
End Class









