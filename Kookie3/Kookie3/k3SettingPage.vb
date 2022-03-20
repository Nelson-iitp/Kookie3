'   If e.KeyCode = Keys.Enter Then Process.Start(" https://spookyisgod.wordpress.com/kookie3help/")
Public Class k3SettingPage

    ReadOnly nl As String = Environment.NewLine

    Private Sub AllControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tabSetting.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub lsdev_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ls_dev.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.Enter Then ls_dev_MouseDoubleClick(Nothing, Nothing)
    End Sub
    Private Sub ls_dev_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ls_dev.MouseDoubleClick
        If ls_dev.SelectedIndices.Count <> 1 Then Exit Sub
        k3main.reini_click(ls_dev.SelectedIndex)
    End Sub


    Friend ci_dev As Integer = -1

    Private Sub k3SettingPage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        k3main.pvt_Close_ME(False)
        k3main.lasloc = Me.Location
        k3main.lassize = Me.Size
    End Sub
    Private Sub k3SettingPage_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        k3main.RefDevs()
        tmediainfo.Text = k3main.GetMediaInfoStr
        propgrid.SelectedObject = k3main.xsproxy
        Me.Location = k3main.lasloc
        If k3main.lassize.Height <> 0 Then
            Me.Size = k3main.lassize
        End If


    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Select Case tabSetting.SelectedIndex
            Case 0  'media
                tmediainfo.Text = k3main.GetMediaInfoStr
            Case 1  'status
                ' tstatusinfo.Text = k3main.GetInfoStr
                propgrid.SelectedObject = k3main.xsproxy
            Case 2  'dev
                k3main.RefDevs()
        End Select
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


End Class