Imports System.ComponentModel
Imports System.IO.Pipes
Imports Un4seen.Bass
Imports Un4seen.Bass.AddOn


Public Class k3main
#Region "Constants"
    Friend ReadOnly k3_lib_path As String = My.Application.Info.DirectoryPath + k3_lib_file
    ReadOnly nl As String = Environment.NewLine
    Friend Const tabc As Char = Chr(9)
    Friend Const csv As Char = ","
    Const _xVar_arg_ini As Char = "*"

    Const k3_lib_file As String = "\k3.lib"
    Const k3_ini_file As String = "\k3.ini"   ' the default configuration file to looke for
    Const const_playlist_ext As String = ".k3p" 'the default playlist extension
    Const const_label_reset_text As String = "Kookie3"  'reset label text
    Const SETF_DIR As Char = ":"
    Const SETF_FILE As Char = "."
    Friend Const const_vis_seek_h As Integer = 7          'vis_seek.Height = 7
    Friend Const hue_minangle As Double = 0.5
    Const mp_sleep_interval As Integer = 250
    Const const_vol_len As Single = 0.001
    Const const_seek_len As Double = 5
    Const const_seekbar_max As Integer = 1000   'set vis_seek.maximum to this value
    Const _xVar_valid_s As Char = "."
    Const _xVar_valid_e As Char = ":"
    Const const_pipeName As String = "k3p"
    Const const_pBuffLen As Integer = 1024
#End Region
 
#Region "other vars"
    Friend xVar_LOOP_SINGLE As Boolean
    Friend xvar_play_backward As Boolean = False
    Friend xVar_Lib_Dirty As Boolean = False
    Friend CiTrack As Integer = -1     'the current track being played

    Friend lasloc As New Point(0, 0)
    Friend lassize As New Size(0, 0)
    Dim jRand As New Random(DateTime.Now.Millisecond)
    Friend xvar_tempimg As Image
    Friend _loadedlib As Boolean = False
    Dim _xCloseME As Boolean = False
    Dim _xLoadArgs As Boolean = False
    Dim _x1instance As Boolean = False
#End Region
#Region "Setting_Variables"

    Friend K3_ini_setting As K3Settings
    Friend ini_0_DROP_2PL As Boolean = True
    Friend ini_1_HIDE_SEEK As Boolean = False ' can bw either empty|BG|FG
    Friend ini_2_HUE_SHIFT As Boolean = True
    Friend ini_3_HUE_SHIFT_DEG As Double = 0.5
    Friend ini_4_LIB_GROUP As View = Windows.Forms.View.Tile
    Friend ini_5_OPACITY As Double = 0.9
    Friend ini_6_MSG As String = "Keep Calm && Enjoy Music"
    Friend ini_7_FILE_TYPES As String() = {"*.mp3", "*.mp4", "*.wav", "*.wma", "*.mp2", "*.mp1", "*.ogg", "*.aiff", "*.flac"}
    Friend ini_8_FONT As Font = New Font("Calibri", 12, FontStyle.Regular)
    Friend ini_9_SIZE As New Size(200, 36)
    Friend ini_10_LOC As New Point((My.Computer.Screen.WorkingArea.Width - ini_9_SIZE.Width) / 2, (My.Computer.Screen.WorkingArea.Height - ini_9_SIZE.Height) / 2)
    Friend ini_11_DOPACITY As Double = 0.9
    Friend ini_12_BGCOL As Color = Color.FromArgb(167, 36, 30)
    Friend ini_13_FGCOL As Color = Color.FromArgb(255, 255, 255)
    Friend ini_14_DEL_UNPLAYBLE As Boolean = True
    Friend ini_15_AUTO_PLAY As Boolean = True
    Friend ini_16_HIDE_LABEL As Boolean = False
    Friend ini_17_RANDOM_START As Boolean = False
    Friend ini_18_TRANS_KEY As String = ""
    Friend ini_19_HIDE_TASK As Boolean = False
    Friend ini_20_SHOW_ART As Boolean = False
    Friend ini_21_DOCK_ART As Windows.Forms.DockStyle = DockStyle.Left
    Friend ini_22_CUSTOM_ART As String = ""
    Friend ini_23_ON_TOP As Boolean = True
    Friend ini_24_ALWAYS_CART As Boolean = False
    Friend ini_25_DOCK_SEEK As Windows.Forms.DockStyle = DockStyle.Bottom
    Friend ini_26_LIB_FONT As Font = New Font("Calibri", 12, FontStyle.Regular)
    Friend ini_27_PL_FONT As Font = New Font("Calibri", 12, FontStyle.Regular)
    Friend ini_28_LIB_LOC As Point = New Point(0, 0)
    Friend ini_29_LIB_SIZE As Size = New Size(My.Computer.Screen.WorkingArea.Width, My.Computer.Screen.WorkingArea.Height)
    Friend ini_30_PL_LOC As Point = New Point(0, 0)
    Friend ini_31_PL_SIZE As Size = New Size(My.Computer.Screen.WorkingArea.Width, My.Computer.Screen.WorkingArea.Height)
    Friend ini_32_PL_COLWID As Integer = 500
    Friend ini_33_PL_BW As Boolean = True
    Friend ini_34_ART_BG As Color = Color.FromArgb(167, 36, 30)
    Friend ini_35_ART_BG_MATCH As Boolean = True
    Friend ini_36_PREVIEW_WID As Integer = 250
    Friend ini_37_HUE_SHIFT_FORE As Boolean = False
    Friend ini_38_HUE_SHIFT_DEG_FORE As Double = 0.5
    Friend ini_39_LABEL_ALIGN As System.Drawing.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
    Friend ini_40_MULTILINE_LABEL As Boolean = False
    ReadOnly _iniNAMES As String() = {"0_dargdrop_playlist",
                                    "1_hide_seek",
                                    "2_hue_shift",
                                    "3_hue_shift_angle",
                                    "4_group_view",
                                    "5_opacity",
                                    "6_start_msg",
                                    "7_file_types",
                                    "8_font_family",
                                "9_size",
                                        "10_location",
                                    "11_dialog_title",
                                        "12_bgcol",
                                        "13_fgcol",
                                        "14_del_unplayble",
                                        "15_auto_play",
                                        "16_hide_label",
                                        "17_rand_start",
                                        "18_trans_key",
                                        "19_hide_task",
                                        "20_show_art",
                                        "21_dock_art",
                                        "22_custom_art",
                                        "23_on_top",
                                        "24_always_cart",
                                      "25_dock_seek",
                                      "26_lib_font",
                                      "27_pl_font",
                                      "28_lib_loc",
                                      "29_lib_size",
                                      "30_pl_loc",
                                      "31_pl_size",
                                      "32_pl_col",
                                      "33_pl_bw",
                                      "34_art_bg",
                                      "35_art_bgcol",
                                      "36_preview_wid",
                                      "37_hue_shift_fore",
                                      "38_hue_shift_angle_fore",
                                      "39_label_align",
                                      "40_multiline_label"}



#End Region

#Region "Startup-Sequence"

    Private Sub pvt0_SaveSetting()
        K3_ini_setting.WriteProperty(_iniNAMES(0), ini_0_DROP_2PL.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(1), ini_1_HIDE_SEEK.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(2), ini_2_HUE_SHIFT.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(3), ini_3_HUE_SHIFT_DEG.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(4), Convert.ToByte(ini_4_LIB_GROUP).ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(5), Math.Round(ini_5_OPACITY, 2).ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(6), ini_6_MSG)
        K3_ini_setting.WriteProperty(_iniNAMES(7), xS_ArraytoCSVString(ini_7_FILE_TYPES))
        K3_ini_setting.WriteProperty(_iniNAMES(8), ini_8_FONT.FontFamily.Name + csv + ini_8_FONT.Size.ToString + csv + Convert.ToByte(ini_8_FONT.Style).ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(9), ini_9_SIZE.Width.ToString + csv + ini_9_SIZE.Height.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(10), ini_10_LOC.X.ToString + csv + ini_10_LOC.Y.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(11), ini_11_DOPACITY.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(12), ini_12_BGCOL.R.ToString + csv + ini_12_BGCOL.G.ToString + csv + ini_12_BGCOL.B.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(13), ini_13_FGCOL.R.ToString + csv + ini_13_FGCOL.G.ToString + csv + ini_13_FGCOL.B.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(14), ini_14_DEL_UNPLAYBLE.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(15), ini_15_AUTO_PLAY.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(16), ini_16_HIDE_LABEL.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(17), ini_17_RANDOM_START.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(18), ini_18_TRANS_KEY)
        K3_ini_setting.WriteProperty(_iniNAMES(19), ini_19_HIDE_TASK.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(20), ini_20_SHOW_ART.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(21), Convert.ToByte(ini_21_DOCK_ART).ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(22), ini_22_CUSTOM_ART)
        K3_ini_setting.WriteProperty(_iniNAMES(23), ini_23_ON_TOP.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(24), ini_24_ALWAYS_CART.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(25), Convert.ToByte(ini_25_DOCK_SEEK).ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(26), ini_26_LIB_FONT.FontFamily.Name + csv + ini_26_LIB_FONT.Size.ToString + csv + Convert.ToByte(ini_26_LIB_FONT.Style).ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(27), ini_27_PL_FONT.FontFamily.Name + csv + ini_27_PL_FONT.Size.ToString + csv + Convert.ToByte(ini_27_PL_FONT.Style).ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(28), ini_28_LIB_LOC.X.ToString + csv + ini_28_LIB_LOC.Y.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(29), ini_29_LIB_SIZE.Width.ToString + csv + ini_29_LIB_SIZE.Height.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(30), ini_30_PL_LOC.X.ToString + csv + ini_30_PL_LOC.Y.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(31), ini_31_PL_SIZE.Width.ToString + csv + ini_31_PL_SIZE.Height.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(32), ini_32_PL_COLWID.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(33), ini_33_PL_BW.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(34), ini_34_ART_BG.R.ToString + csv + ini_34_ART_BG.G.ToString + csv + ini_34_ART_BG.B.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(35), ini_35_ART_BG_MATCH.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(36), ini_36_PREVIEW_WID.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(37), ini_37_HUE_SHIFT_FORE.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(38), ini_38_HUE_SHIFT_DEG_FORE.ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(39), Convert.ToInt32(ini_39_LABEL_ALIGN).ToString)
        K3_ini_setting.WriteProperty(_iniNAMES(40), ini_40_MULTILINE_LABEL.ToString)
        K3_ini_setting.FlushToDisk()
    End Sub
    Private Sub _keepAddingDefault(ByVal clear As Boolean)
        'since the xOVERWRITE is off it wont overwrite exsisting settings
        If clear Then K3_ini_setting._ClearSetting()
        K3_ini_setting._AddSetting(_iniNAMES(0), ini_0_DROP_2PL.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(1), ini_1_HIDE_SEEK.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(2), ini_2_HUE_SHIFT.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(3), ini_3_HUE_SHIFT_DEG.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(4), Convert.ToByte(ini_4_LIB_GROUP).ToString)
        K3_ini_setting._AddSetting(_iniNAMES(5), Math.Round(ini_5_OPACITY, 2).ToString)
        K3_ini_setting._AddSetting(_iniNAMES(6), ini_6_MSG)
        K3_ini_setting._AddSetting(_iniNAMES(7), xS_ArraytoCSVString(ini_7_FILE_TYPES))
        K3_ini_setting._AddSetting(_iniNAMES(8), ini_8_FONT.FontFamily.Name + csv + ini_8_FONT.Size.ToString + csv + Convert.ToByte(ini_8_FONT.Style).ToString)
        K3_ini_setting._AddSetting(_iniNAMES(9), ini_9_SIZE.Width.ToString + csv + ini_9_SIZE.Height.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(10), ini_10_LOC.X.ToString + csv + ini_10_LOC.Y.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(11), ini_11_DOPACITY.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(12), ini_12_BGCOL.R.ToString + csv + ini_12_BGCOL.G.ToString + csv + ini_12_BGCOL.B.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(13), ini_13_FGCOL.R.ToString + csv + ini_13_FGCOL.G.ToString + csv + ini_13_FGCOL.B.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(14), ini_14_DEL_UNPLAYBLE.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(15), ini_15_AUTO_PLAY.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(16), ini_16_HIDE_LABEL.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(17), ini_17_RANDOM_START.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(18), ini_18_TRANS_KEY)
        K3_ini_setting._AddSetting(_iniNAMES(19), ini_19_HIDE_TASK.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(20), ini_20_SHOW_ART.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(21), Convert.ToByte(ini_21_DOCK_ART).ToString)
        K3_ini_setting._AddSetting(_iniNAMES(22), ini_22_CUSTOM_ART)
        K3_ini_setting._AddSetting(_iniNAMES(23), ini_23_ON_TOP.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(24), ini_24_ALWAYS_CART.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(25), Convert.ToByte(ini_25_DOCK_SEEK).ToString)
        K3_ini_setting._AddSetting(_iniNAMES(26), ini_26_LIB_FONT.FontFamily.Name + csv + ini_26_LIB_FONT.Size.ToString + csv + Convert.ToByte(ini_26_LIB_FONT.Style).ToString)
        K3_ini_setting._AddSetting(_iniNAMES(27), ini_27_PL_FONT.FontFamily.Name + csv + ini_27_PL_FONT.Size.ToString + csv + Convert.ToByte(ini_27_PL_FONT.Style).ToString)
        K3_ini_setting._AddSetting(_iniNAMES(28), ini_28_LIB_LOC.X.ToString + csv + ini_28_LIB_LOC.Y.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(29), ini_29_LIB_SIZE.Width.ToString + csv + ini_29_LIB_SIZE.Height.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(30), ini_30_PL_LOC.X.ToString + csv + ini_30_PL_LOC.Y.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(31), ini_31_PL_SIZE.Width.ToString + csv + ini_31_PL_SIZE.Height.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(32), ini_32_PL_COLWID.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(33), ini_33_PL_BW.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(34), ini_34_ART_BG.R.ToString + csv + ini_34_ART_BG.G.ToString + csv + ini_34_ART_BG.B.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(35), ini_35_ART_BG_MATCH.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(36), ini_36_PREVIEW_WID.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(37), ini_37_HUE_SHIFT_FORE.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(38), ini_38_HUE_SHIFT_DEG_FORE.ToString)
        K3_ini_setting._AddSetting(_iniNAMES(39), Convert.ToInt32(ini_39_LABEL_ALIGN).ToString)
        K3_ini_setting._AddSetting(_iniNAMES(40), ini_40_MULTILINE_LABEL.ToString)
    End Sub
    Private Function pvt1_loadSettings() As Boolean
        'First Check for Configuration file in     Dim k3_ini_file As String = "\k3.ini"
        If K3_ini_setting.ReloadFromDisk() Then  'check if loaded success
            If Not K3_ini_setting.CheckExsist(_iniNAMES) Then _keepAddingDefault(False) 'not all settings exsist
            pvt11_loadvars()
            Return True
        Else
            If Not K3_ini_setting.FlushToDisk() Then Return False
            _keepAddingDefault(True)
            Return K3_ini_setting.FlushToDisk
        End If

    End Function
    Friend Sub pvt11_loadvars()
        On Error Resume Next
        Dim sisr As String()
        Dim tf As FontStyle
        '   On Error Resume Next
        ini_0_DROP_2PL = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(0)))
        ini_1_HIDE_SEEK = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(1)))
        ini_2_HUE_SHIFT = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(2)))
        ini_3_HUE_SHIFT_DEG = Convert.ToDouble(K3_ini_setting.ReadProperty(_iniNAMES(3)))
        ini_4_LIB_GROUP = Convert.ToByte(K3_ini_setting.ReadProperty(_iniNAMES(4)))
        ini_5_OPACITY = Convert.ToDouble(K3_ini_setting.ReadProperty(_iniNAMES(5)))
        ini_6_MSG = (K3_ini_setting.ReadProperty(_iniNAMES(6)))
        ini_7_FILE_TYPES = (K3_ini_setting.ReadProperty(_iniNAMES(7))).Split(csv)

        sisr = (K3_ini_setting.ReadProperty(_iniNAMES(8))).Split(csv)
        tf = Convert.ToByte(sisr(2))
        ini_8_FONT = New Font(sisr(0), Convert.ToSingle(sisr(1)), tf)

        sisr = K3_ini_setting.ReadProperty(_iniNAMES(9)).Split(csv)
        ini_9_SIZE = New Size(Convert.ToInt32(sisr(0)), Convert.ToInt32(sisr(1)))
        sisr = K3_ini_setting.ReadProperty(_iniNAMES(10)).Split(csv)
        ini_10_LOC = New Point(Convert.ToInt32(sisr(0)), Convert.ToInt32(sisr(1)))

        ini_11_DOPACITY = Convert.ToDouble(K3_ini_setting.ReadProperty(_iniNAMES(11)))

        sisr = K3_ini_setting.ReadProperty(_iniNAMES(12)).Split(csv)
        ini_12_BGCOL = Color.FromArgb(Convert.ToByte(sisr(0)), Convert.ToByte(sisr(1)), Convert.ToByte(sisr(2)))

        sisr = K3_ini_setting.ReadProperty(_iniNAMES(13)).Split(csv)
        ini_13_FGCOL = Color.FromArgb(Convert.ToByte(sisr(0)), Convert.ToByte(sisr(1)), Convert.ToByte(sisr(2)))

        ini_14_DEL_UNPLAYBLE = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(14)))
        ini_15_AUTO_PLAY = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(15)))
        ini_16_HIDE_LABEL = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(16)))
        ini_17_RANDOM_START = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(17)))
        ini_18_TRANS_KEY = K3_ini_setting.ReadProperty(_iniNAMES(18))

        ini_19_HIDE_TASK = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(19)))
        ini_20_SHOW_ART = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(20)))
        ini_21_DOCK_ART = Convert.ToByte(K3_ini_setting.ReadProperty(_iniNAMES(21)))
        ini_22_CUSTOM_ART = (K3_ini_setting.ReadProperty(_iniNAMES(22)))
        ini_23_ON_TOP = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(23)))
        ini_24_ALWAYS_CART = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(24)))
        ini_25_DOCK_SEEK = Convert.ToByte(K3_ini_setting.ReadProperty(_iniNAMES(25)))

        sisr = (K3_ini_setting.ReadProperty(_iniNAMES(26))).Split(csv)
        tf = Convert.ToByte(sisr(2))
        ini_26_LIB_FONT = New Font(sisr(0), Convert.ToSingle(sisr(1)), tf)

        sisr = (K3_ini_setting.ReadProperty(_iniNAMES(27))).Split(csv)
        tf = Convert.ToByte(sisr(2))
        ini_27_PL_FONT = New Font(sisr(0), Convert.ToSingle(sisr(1)), tf)


        sisr = K3_ini_setting.ReadProperty(_iniNAMES(28)).Split(csv)
        ini_28_LIB_LOC = New Point(Convert.ToInt32(sisr(0)), Convert.ToInt32(sisr(1)))
        sisr = K3_ini_setting.ReadProperty(_iniNAMES(29)).Split(csv)
        ini_29_LIB_SIZE = New Size(Convert.ToInt32(sisr(0)), Convert.ToInt32(sisr(1)))

        sisr = K3_ini_setting.ReadProperty(_iniNAMES(30)).Split(csv)
        ini_30_PL_LOC = New Point(Convert.ToInt32(sisr(0)), Convert.ToInt32(sisr(1)))
        sisr = K3_ini_setting.ReadProperty(_iniNAMES(31)).Split(csv)
        ini_31_PL_SIZE = New Size(Convert.ToInt32(sisr(0)), Convert.ToInt32(sisr(1)))

        ini_32_PL_COLWID = Convert.ToInt32(K3_ini_setting.ReadProperty(_iniNAMES(32)))
        ini_33_PL_BW = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(33)))

        sisr = K3_ini_setting.ReadProperty(_iniNAMES(34)).Split(csv)
        ini_34_ART_BG = Color.FromArgb(Convert.ToByte(sisr(0)), Convert.ToByte(sisr(1)), Convert.ToByte(sisr(2)))

        ini_35_ART_BG_MATCH = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(35)))
        ini_36_PREVIEW_WID = Convert.ToInt32(K3_ini_setting.ReadProperty(_iniNAMES(36)))

        ini_37_HUE_SHIFT_FORE = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(37)))
        ini_38_HUE_SHIFT_DEG_FORE = Convert.ToDouble(K3_ini_setting.ReadProperty(_iniNAMES(38)))
        ini_39_LABEL_ALIGN = Convert.ToInt32(K3_ini_setting.ReadProperty(_iniNAMES(39)))
        ini_40_MULTILINE_LABEL = Convert.ToBoolean(K3_ini_setting.ReadProperty(_iniNAMES(40)))
    End Sub
    
    Private Function pvt2_applySetting() As Boolean
        Try
            _applyTOPMost(ini_23_ON_TOP)
            _applySHOWINTASK(Not ini_19_HIDE_TASK)
            K3LibraryView.lb_Library.View = ini_4_LIB_GROUP
            Me.Opacity = ini_5_OPACITY
            Me.Size = ini_9_SIZE
            K3LibraryView.Opacity = ini_11_DOPACITY
            K3PlaylistView.Opacity = ini_11_DOPACITY
            Me.Location = ini_10_LOC
            vis_l_main.Font = ini_8_FONT
            vis_l_main.TextAlign = ini_39_LABEL_ALIGN
            xsproxy.Libray_Font = ini_26_LIB_FONT
           
            K3PlaylistView.lb_pl.Font = ini_27_PL_FONT
            K3PlaylistView.lb_pl.ColumnWidth = ini_32_PL_COLWID
            K3LibraryView.Panel_preview.Width = ini_36_PREVIEW_WID
            vis_l_main.BackColor = ini_12_BGCOL
            vis_l_main.ForeColor = ini_13_FGCOL
            vis_seek.ForeColor = vis_l_main.BackColor
            vis_seek.BackColor = vis_l_main.ForeColor

            vis_seek.Visible = Not ini_1_HIDE_SEEK
            If ini_35_ART_BG_MATCH Then
                vis_pic.BackColor = vis_l_main.BackColor
            Else
                vis_pic.BackColor = ini_34_ART_BG
            End If

            vis_pic.Visible = ini_20_SHOW_ART
            vis_pic.Dock = ini_21_DOCK_ART
            vis_seek.Dock = ini_25_DOCK_SEEK
            If My.Computer.FileSystem.FileExists(ini_22_CUSTOM_ART) Then
                Try
                    vis_pic.InitialImage = Image.FromFile(ini_22_CUSTOM_ART)
                Catch ex As Exception
                End Try
            End If
            pvt_setVis_picImage(Nothing)
            Me.TransparencyKey = pvt_rgbcsv2Color(ini_18_TRANS_KEY)

            K3LibraryView.Location = ini_28_LIB_LOC
            K3LibraryView.Size = ini_29_LIB_SIZE
            K3PlaylistView.Location = ini_30_PL_LOC
            K3PlaylistView.Size = ini_31_PL_SIZE
            k3SettingPage.Width = My.Computer.Screen.WorkingArea.Width * 0.5
            k3SettingPage.Height = My.Computer.Screen.WorkingArea.Height
            pvt_UpdateTitle()
            '  _applyDIALOGS(ini_11_DIALOG_TITLE)

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Friend Sub _applyTOPMost(ByVal v As Boolean)
        Me.TopMost = v
        K3LibraryView.TopMost = v
        K3PlaylistView.TopMost = v
        '   k3SettingPage.TopMost = v
    End Sub
    Friend Sub _applySHOWINTASK(ByVal v As Boolean)
        Me.ShowInTaskbar = Not v
        Me.ShowInTaskbar = v
        K3LibraryView.ShowInTaskbar = v
        K3PlaylistView.ShowInTaskbar = v

        '   k3SettingPage.TopMost = v
    End Sub


    Private Sub k3main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _xCloseME = False
        _xLoadArgs = False
        _x1instance = False
        Dim s_args As ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        'ipc pipes here
        Dim _pipe As System.IO.Pipes.NamedPipeServerStream = Nothing
        'first try to run pipe server
        Try
            Dim _psec As New PipeSecurity()
            _psec.SetAccessRule(New System.IO.Pipes.PipeAccessRule("Everyone", PipeAccessRights.ReadWrite, Security.AccessControl.AccessControlType.Allow))
            _pipe = New System.IO.Pipes.NamedPipeServerStream(const_pipeName, IO.Pipes.PipeDirection.In, 1, IO.Pipes.PipeTransmissionMode.Message, IO.Pipes.PipeOptions.None, const_pBuffLen, 0, _psec)
            ipc_worker.RunWorkerAsync(_pipe)
        Catch ex As Exception
            'server already running            'pass the commandline args
            _xCloseME = True
            _x1instance = True
        End Try

        If _xCloseME Then 'server already running            'pass the commandline args if any
            If s_args.Count > 0 Then
                Try
                    Dim pipeC As New System.IO.Pipes.NamedPipeClientStream(".", const_pipeName, PipeDirection.Out)
                    pipeC.Connect()
                    Dim Message As String = ""
                    For i = 0 To s_args.Count - 1
                        If Not s_args(i).StartsWith(_xVar_arg_ini) Then
                            Message += s_args(i) + "?"
                        End If
                    Next
                    If Message.Trim <> "" Then
                        Dim bRequest As Byte() = System.Text.Encoding.Unicode.GetBytes(Message)
                        pipeC.Write(bRequest, 0, bRequest.Length)
                    End If
                    pipeC.Close()
                Catch ex As Exception
                End Try
            End If
        Else
            'xclose is false            'server was started ' new single instance
            If s_args.Count = 0 Then
                K3_ini_setting = New K3Settings(My.Application.Info.DirectoryPath + k3_ini_file, False, _iniNAMES, _xVar_valid_s, _xVar_valid_e)
            Else
                'check if files have *
                If s_args(0).StartsWith(_xVar_arg_ini) Then
                    K3_ini_setting = New K3Settings(s_args(0).Remove(0, 1), False, _iniNAMES, _xVar_valid_s, _xVar_valid_e)
                    If Not My.Computer.FileSystem.FileExists(s_args(0).Remove(0, 1)) Then If MsgBox("Sepcified setting does not exist." + nl + nl + s_args(0) + nl + nl + "Create it now?", vbYesNo + vbQuestion) = vbNo Then _xCloseME = True
                Else
                    'MsgBox("Argument does not specify a Setting file, using default")
                    _xLoadArgs = True
                    K3_ini_setting = New K3Settings(My.Application.Info.DirectoryPath + k3_ini_file, False, _iniNAMES, _xVar_valid_s, _xVar_valid_e)

                End If
            End If

            If Not _xCloseME Then
                If pvt1_loadSettings() Then
                    If pvt2_applySetting() Then
                        pvt1_Init_On_Device(-1)   'at last initiate bass
                        '  pvt_()
                    Else
                        _xCloseME = True
                    End If
                Else
                    _xCloseME = True
                End If
            End If
        End If
    End Sub
    Private Sub k3main_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _xCloseME Then
            If Not _x1instance Then
                Dim msgst As String = "Kookie3 has encountered internal error during loading procedure, this may be due to invalid settings file." + nl + nl
                If My.Computer.FileSystem.FileExists(K3_ini_setting.FilePath) Then
                    msgst += "Please delete any exsisting Configuration file or Use a valid Configuration file and restart Kookie3" + nl + nl + "Your Configuration File is located here : '" + K3_ini_setting.FilePath + "'" + nl + nl + "Delete this configuration file now?"
                    If MsgBox(msgst, vbYesNo + vbCritical) = vbYes Then
                        My.Computer.FileSystem.DeleteFile(K3_ini_setting.FilePath)
                    End If
                Else
                    msgst += "Please Use/Create a valid Configuration file and restart Kookie3" + nl + nl + "Your Configuration File cannot be found here : '" + K3_ini_setting.FilePath + "'"
                    MsgBox(msgst, vbCritical)
                End If

                MsgBox("Kookie will now exit.", vbInformation)
            End If
            Me.Close()
        Else
            gfx = vis_seek.CreateGraphics
            '  _applySHOWINTASK(Not ini_19_HIDE_TASK)
            If Not _loadedlib Then _loadedlib = LoadLIBfile()
            Me.Focus()
            ShowMsg(ini_6_MSG)
            If _xLoadArgs Then
                '============================================loading args
                pvt_Append2Playlist(My.Application.CommandLineArgs.ToArray)
                If ini_15_AUTO_PLAY Then pvt_tryAUTOPLAY(IIf(ini_17_RANDOM_START, -1, 0))
                '============================================end loading args
            End If
        End If
    End Sub

    Private Sub ipc_worker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ipc_worker.DoWork
        If IsNothing(e.Argument) Then Exit Sub
        Dim _pipe As System.IO.Pipes.NamedPipeServerStream = e.Argument

        Dim _pBuff() As Byte
        Dim message As String
        Dim cbRead As Integer
        _pBuff = Array.CreateInstance(GetType(Byte), const_pBuffLen)
        While (True)

            _pipe.WaitForConnection()
            Do
                cbRead = _pipe.Read(_pBuff, 0, const_pBuffLen)
                message = System.Text.Encoding.Unicode.GetString(_pBuff).TrimEnd(ControlChars.NullChar)
                If message.Trim <> "" Then ipc_worker.ReportProgress(1, message)
            Loop While Not _pipe.IsMessageComplete
            ' _pipe.WaitForPipeDrain()
            _pipe.Disconnect()
        End While
        If Not IsNothing(_pipe) Then _pipe.Close()
    End Sub
    Private Sub ipc_worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles ipc_worker.ProgressChanged
        'when launching from explorer, dont clear the current playlist
        If K3PlaylistView.lb_pl.Enabled = False Then
            ShowMsg("[Busy : " + K3PlaylistView._remdC.ToString + " %]")
            Exit Sub
        End If
        Dim nos_items As Integer = pvt_Append2Playlist(e.UserState.ToString.Split("?"))
        If ini_15_AUTO_PLAY Then pvt_tryAUTOPLAY(K3PlaylistView.lb_pl.Items.Count - nos_items)
    End Sub

    Friend Sub pvt_Close_ME(ByVal _doclose As Boolean)
        SaveLIBfile()
        pvt0_SaveSetting()
        If _doclose Then Me.Close()
    End Sub
    Friend Sub pvt_tryAUTOPLAY(ByVal from_index As Integer)
        If from_index < 0 Then from_index = jRand.Next(0, (K3PlaylistView.lb_pl.Items.Count)) 'Math.Floor((Rnd() * (K3PlaylistView.lb_pl.Items.Count)))
        CiTrack = from_index
        pvt_skipInvalid()
    End Sub

#End Region

#Region "User Interaction"
    Private Sub vis_seek_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles vis_seek.MouseClick
        'modified media seek
        If mp_STATE > 1 Then
            Dim percent As Decimal = ((e.X - draw_pad.X) / (vis_seek.Width - draw_pad.X * 2) * mp_LEN) ' (((e.X) / (vis_seek.Width)) * mp_LEN)
            Dim b2l As Long = Convert.ToInt64(percent)
            Bass.BASS_ChannelSetPosition(mp_HANDLE, b2l)
            mp_POS = Bass.BASS_ChannelGetPosition(mp_HANDLE)

            pvt_RefreshSeekBar(True)
        End If
    End Sub
    Private Sub t_cmd_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles t_cmd.MouseWheel, vis_l_main.MouseWheel, vis_pic.MouseWheel
        '   ShowMsg("we" + DateTime.Now.Millisecond.ToString)
        If e.Delta < 0 Then
            Bass.BASS_SetVolume(Bass.BASS_GetVolume - const_vol_len * 5)
        Else
            Bass.BASS_SetVolume(Bass.BASS_GetVolume + const_vol_len * 5)
        End If
        ShowMsg(Math.Round(Bass.BASS_GetVolume * 100, 0).ToString + " %")
    End Sub
    Private Sub t_seek_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles vis_seek.MouseWheel
        '   ShowMsg("we" + DateTime.Now.Millisecond.ToString)
        If e.Delta < 0 Then
            media_seek(-const_seek_len)
        Else
            media_seek(+const_seek_len)
        End If
        '   ShowMsg(Math.Round(Bass.BASS_GetVolume * 100, 0).ToString + " %")
    End Sub
    Private Sub t_cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles t_cmd.GotFocus
        ' My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
    End Sub

    Private Sub t_cmd_KEYPRESSING(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles t_cmd.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                pvt_Close_ME(True)
            Case Keys.P
                PlaylistToolStripMenuItem_Click(Nothing, Nothing)
            Case Keys.L
                LibraryToolStripMenuItem_Click(Nothing, Nothing)
            Case Keys.Up
                If e.Control Then
                    If e.Shift Then
                        Bass.BASS_SetVolume(Bass.BASS_GetVolume + const_vol_len * 10)
                    Else
                        Bass.BASS_SetVolume(Bass.BASS_GetVolume + const_vol_len * 5)
                    End If
                Else
                    If e.Shift Then
                        Bass.BASS_SetVolume(Bass.BASS_GetVolume + const_vol_len * 2)
                    Else
                        Bass.BASS_SetVolume(Bass.BASS_GetVolume + const_vol_len)
                    End If
                End If
                ShowMsg(Math.Round(Bass.BASS_GetVolume * 100, 0).ToString + " %")
            Case Keys.Down
                If e.Control Then
                    If e.Shift Then
                        Bass.BASS_SetVolume(Bass.BASS_GetVolume - const_vol_len * 10)
                    Else
                        Bass.BASS_SetVolume(Bass.BASS_GetVolume - const_vol_len * 5)
                    End If
                Else
                    If e.Shift Then
                        Bass.BASS_SetVolume(Bass.BASS_GetVolume - const_vol_len * 2)
                    Else
                        Bass.BASS_SetVolume(Bass.BASS_GetVolume - const_vol_len)
                    End If
                End If
                ShowMsg(Math.Round(Bass.BASS_GetVolume * 100, 0).ToString + " %")
            Case Keys.Right
                If e.Shift Then
                    If e.Control Then
                        media_seek(const_seek_len * 24) ' 2mins
                    Else
                        media_seek(const_seek_len)      ' 5secs
                    End If

                Else
                    If e.Control Then
                        media_seek(const_seek_len * 6) '30 secs
                    Else
                        media_PlayNext(True)
                    End If
                End If
            Case Keys.Left
                If e.Shift Then
                    If e.Control Then
                        media_seek(-const_seek_len * 24)
                    Else
                        media_seek(-const_seek_len)
                    End If

                Else
                    If e.Control Then
                        media_seek(-const_seek_len * 6)
                    Else
                        media_PlayPrev(True)
                    End If
                End If
            Case Keys.Space
                Select Case mp_STATE
                    Case Media_MPstate.mp_empty
                        media_LoadMedia(mp_URL, True, False)
                    Case Media_MPstate.mp_loaded, Media_MPstate.mp_paued ' new/Ready
                        media_playmedia(e.Control)
                    Case Media_MPstate.mp_playing
                        If e.Control Then
                            media_playmedia(True)
                        Else
                            media_pausemedia()
                        End If
                End Select
            Case Keys.X
                If e.Control Then
                    ShowMsg(pvt_ClearPlaylist())
                End If
            Case Keys.Add
                If e.Shift Then
                    If Not e.Control Then
                        xsproxy.Form_Size = New Size(Me.Width + 5, Me.Height)
                    Else
                        xsproxy.Form_Location = New Point(Me.Location.X, Me.Location.Y + 1)
                    End If
                Else
                    If e.Control Then
                        xsproxy.Form_Size = New Size(Me.Width, Me.Height + 5)
                    Else
                        xsproxy.Form_Opacity += 0.05
                        ' Me.Opacity += 0.05
                    End If
                End If

            Case Keys.Subtract
                If e.Shift Then
                    If Not e.Control Then
                        xsproxy.Form_Size = New Size(Me.Width - 5, Me.Height)
                    Else
                        xsproxy.Form_Location = New Point(Me.Location.X, Me.Location.Y - 1)
                    End If
                Else
                    If e.Control Then
                        xsproxy.Form_Size = New Size(Me.Width, Me.Height - 5)
                    Else
                        xsproxy.Form_Opacity -= 0.05
                    End If
                End If
            Case Keys.Multiply
                If e.Shift Then
                    If Not e.Control Then
                        xsproxy.Form_Size = New Size(Me.Width + 1, Me.Height)
                    Else
                        xsproxy.Form_Location = New Point(Me.Location.X + 1, Me.Location.Y)
                    End If
                Else
                    If e.Control Then
                        xsproxy.Form_Size = New Size(Me.Width, Me.Height + 1)
                    Else
                        xsproxy.Form_Opacity += 0.01
                    End If
                End If
            Case Keys.Divide
                If e.Shift Then
                    If Not e.Control Then
                        xsproxy.Form_Size = New Size(Me.Width - 1, Me.Height)
                    Else
                        xsproxy.Form_Location = New Point(Me.Location.X - 1, Me.Location.Y)
                    End If
                Else
                    If e.Control Then
                        xsproxy.Form_Size = New Size(Me.Width, Me.Height - 1)
                    Else
                        xsproxy.Form_Opacity -= 0.01
                    End If
                End If
            Case Keys.D
                xsproxy.File_Drop_to_Playlist = Not xsproxy.File_Drop_to_Playlist
            Case Keys.O
                If e.Control Then
                    ImportConfigToolStripMenuItem_Click(Nothing, Nothing)
                End If
            Case Keys.S
                If e.Control Then
                    If e.Shift Then
                        ExportConfigToolStripMenuItem_Click(Nothing, Nothing)
                    Else
                        SaveCurrentConfigToolStripMenuItem_Click(Nothing, Nothing)
                    End If

                Else
                    If Not e.Shift Then
                        ShiffleOnceToolStripMenuItem_Click()
                    Else
                        'shift+S - save current as back color
                        xsproxy.Color_Back = vis_l_main.BackColor
                        ShowMsg("Saved BackColor")
                    End If
                End If
            Case Keys.R
                If e.Control Then
                    xsproxy.Reversed_Playlist = Not xsproxy.Reversed_Playlist
                Else
                    If e.Shift Then
                        _RepetePlaylist = Not _RepetePlaylist
                        ShowMsg("Loop Playlist::" + _RepetePlaylist.ToString)
                    Else
                        xsproxy.Repeat_Single_Track = Not xsproxy.Repeat_Single_Track
                    End If

                End If

            Case Keys.A
                Dim imgd As New OpenFileDialog
                imgd.Title = "Choose Custom Image..."
                If imgd.ShowDialog = DialogResult.OK Then
                    xsproxy.Art_Default = imgd.FileName
                End If
            Case Keys.Enter
                ReinitializeDefaultDeviceToolStripMenuItem_Click(Nothing, Nothing)

            Case Keys.F
                t_shortcut_MarkFav()
                ' My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Question)
            Case Keys.T        'Hue shifter
                If e.Control Then
                    If Not e.Shift Then xsproxy.Always_On_Top = Not xsproxy.Always_On_Top
                Else
                    xsproxy.Hue_Shift_Enabled = Not xsproxy.Hue_Shift_Enabled
                End If
            Case Keys.H
                If e.Control Then
                    If Not e.Shift Then
                        xsproxy.SeekBar_Hide = Not xsproxy.SeekBar_Hide
                    End If
                Else
                    If e.Shift Then
                        xsproxy.Hide_in_TaskBar = Not xsproxy.Hide_in_TaskBar
                    Else
                        xsproxy.Label_Hide = Not xsproxy.Label_Hide
                    End If
                End If

            Case Keys.I
                MediaInfoToolStripMenuItem_Click(Nothing, Nothing)
            Case Keys.E
                ConfigurationToolStripMenuItem_Click(Nothing, Nothing)
            Case Keys.V
                StatusInfoToolStripMenuItem_Click(Nothing, Nothing)
                ' Case Keys.K
                '  KeyboardControlsToolStripMenuItem_Click(Nothing, Nothing)
            Case Keys.C
                If e.Control Then
                    CenterScreenToolStripMenuItem_Click(Nothing, Nothing)
                Else
                    If IsOutOfBounds() Then
                        CenterScreenToolStripMenuItem_Click(Nothing, Nothing)
                    End If
                End If
            Case Keys.B
                If e.Control Then
                    AutoSizeToolStripMenuItem_Click(Nothing, Nothing)
                End If
            Case Keys.F1
                VisitWebsiteToolStripMenuItem_Click(Nothing, Nothing)
            Case Keys.F2
                AppDirToolStripMenuItem_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub t_shortcut_ReInit(ByVal rdev As Integer)
        Dim lasuri As String = ""
        Dim lasplay As Boolean = False
        If mp_STATE > 2 Then
            If mp_STATE = Media_MPstate.mp_playing Then lasplay = True
            lasuri = mp_URL
        End If
        pvt1_Init_On_Device(rdev)
        If lasuri <> "" Then media_LoadMedia(lasuri, lasplay, True)
        ShowMsg("ReInitialize...")
    End Sub
    Friend Sub t_shortcut_MarkFav()
        If mp_STATE > 1 And mp_URL <> "" And _loadedlib Then
            drop_AddNew_FileBM(mp_URL, False)
            xVar_Lib_Dirty = True
            ShowMsg("Added 2 Library")
        End If
    End Sub

    Dim _RepetePlaylist As Boolean = False
#End Region


#Region "Movement"
    Dim pram_mdn As Byte = 4 ' 0 = move 1= wright, 2=hbot 3=corner, 4= nothing
    Dim pram_mdpt As New Point(-1, -1)
    Const const_mov_margin As Integer = 3
    Dim m_down_label, m_down_pic As Boolean
    Private Sub lMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles vis_l_main.MouseDown ', vis_pic.MouseDown
        Dim xmovd As Boolean = IIf(vis_l_main.Width - e.X > const_mov_margin, False, True)
        Dim ymovd As Boolean = IIf(vis_l_main.Height - e.Y > const_mov_margin, False, True)
        pram_mdn = 0
        If xmovd Then pram_mdn += 1
        If ymovd Then pram_mdn += 2 'width left
        '  pram_md = True
        pram_mdpt.X = -e.X   '  l_main.Location.X + e.X
        pram_mdpt.Y = -e.Y   '  l_main.Location.Y + e.Y

        Select Case pram_mdn
            Case 0
                sender.Cursor = Cursors.NoMove2D
            Case 1
                sender.Cursor = Cursors.PanEast
            Case 2
                sender.Cursor = Cursors.PanSouth
            Case 3
                sender.Cursor = Cursors.PanSE
        End Select
        m_down_label = True
    End Sub
    
    Private Sub lMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles vis_l_main.MouseUp ', vis_pic.MouseDown
        If Not m_down_label Then Exit Sub
        Select Case pram_mdn
            Case 0
                '   sender.Cursor = Cursors.NoMove2D
                pram_mdpt.X += (e.X + Me.Location.X)
                pram_mdpt.Y += (e.Y + Me.Location.Y)
                xsproxy.Form_Location = pram_mdpt
            Case 1
                'sender.Cursor = Cursors.PanEast
                xsproxy.Form_Size = New Size(Me.Width + e.X + pram_mdpt.X, Me.Height)
            Case 2
                ' sender.Cursor = Cursors.PanSouth
                xsproxy.Form_Size = New Size(Me.Width, Me.Height + e.Y + pram_mdpt.Y)
            Case 3
                ' sender.Cursor = Cursors.PanSE
                xsproxy.Form_Size = New Size(Me.Width + pram_mdpt.X + e.X, Me.Height + pram_mdpt.Y + e.Y)
        End Select


        pram_mdn = 4
        sender.Cursor = Cursors.Default
        m_down_label = False
    End Sub

    Private Sub pMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles vis_pic.MouseDown
        pram_mdpt.X = -e.X   '  l_main.Location.X + e.X
        pram_mdpt.Y = -e.Y   '  l_main.Location.Y + e.Y
        vis_pic.Cursor = Cursors.NoMove2D
        m_down_pic = True
    End Sub
    Private Sub pMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles vis_pic.MouseUp

        If Not m_down_pic Then Exit Sub
        pram_mdpt.X += (e.X + Me.Location.X)
        pram_mdpt.Y += (e.Y + Me.Location.Y)
        xsproxy.Form_Location = pram_mdpt
        vis_pic.Cursor = Cursors.Default
        m_down_pic = False
    End Sub


    Dim me_in As Boolean = False
    Private Sub vis_l_main_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles vis_l_main.MouseEnter ', vis_pic.MouseEnter
        me_in = True
        vis_l_main.Refresh()
    End Sub

    Private Sub vis_l_main_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles vis_l_main.MouseLeave ', vis_pic.MouseLeave
        me_in = False
        vis_l_main.Refresh()
    End Sub

  
  Private Sub k3main_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        'AutoDraw_Inc(True)
        vis_seek.Refresh()
    End Sub


    Private Sub vis_l_main_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles vis_l_main.Paint
        If me_in Then
            Dim npen As New Pen(vis_l_main.ForeColor)
            e.Graphics.DrawLine(npen, 0, vis_l_main.Height - const_mov_margin, vis_l_main.Width, vis_l_main.Height - const_mov_margin)
            e.Graphics.DrawLine(npen, vis_l_main.Width - const_mov_margin, 0, vis_l_main.Width - const_mov_margin, vis_l_main.Height)

            e.Graphics.DrawString(IIf(ini_0_DROP_2PL, "P", "L"), vis_l_main.Font, New SolidBrush(vis_l_main.ForeColor), vis_l_main.Width - vis_l_main.Font.Height, 0)
        
        End If
    End Sub
#End Region


#Region "MediaPlayer"
    '======================= "Media Player Variables"
    Dim mp_TAG As New Tags.TAG_INFO
    Dim mp_TAG_EXIST As Boolean = False
    Dim mp_URL As String = ""          'the filepath
    Dim mp_POS As Long = 0            'the current position on stream
    Dim mp_LEN As Long = 1              'total len in bytes
    Dim mp_HANDLE As Integer = 0    'the stream handel of loaded file
    dim mp_STATE As Media_MPstate  '>0 means initialized ; >1 means stream loaded; >2 means o/p started
    Dim mp_TIMER_ON As Boolean = False
    Dim ReCol As Color
    Dim ReColF As Color
    Dim mp_TITLE As String
    Enum Media_MPstate As Byte
        mp_null = 0 '=========== nothing
        mp_empty = 1  '============= initialized
        mp_loaded = 2 '=================loaded media
        mp_playing = 3 '============== output started
        mp_paued = 4 '============== output started
    End Enum
    Private Sub pvt0_Free_On_Device()
        '  If mp_STATE > 1 Then media_FreeMedia()
        mp_TIMER_ON = False
        Bass.BASS_Free()
        mp_STATE = (Media_MPstate.mp_null)
    End Sub
    Private Function pvt1_Init_On_Device(ByVal rdev As Integer) As Boolean
        pvt0_Free_On_Device()
        If Bass.BASS_Init(rdev, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero) Then
            mp_STATE = (Media_MPstate.mp_empty)
            Return True
        Else
            mp_STATE = (Media_MPstate.mp_null)
            Return False
            'MsgBox("Error Initializing Bass Library, Halt and Exit.", vbCritical)
        End If
    End Function

    Dim draw_pad As New Point(1, 1)
    Dim gfx As Graphics
    Dim dbad As SolidBrush = New SolidBrush(ini_12_BGCOL)
    Private Sub AutoDraw(ByVal _clear As Boolean)
        Static _AA(0 To 4) As Integer
        Static siz As Single = 0

        dbad.Color = vis_l_main.BackColor
        siz = vis_seekValue * ((vis_seek.Width) - draw_pad.X * 2)
        _AA = {draw_pad.X, draw_pad.Y, siz, vis_seek.Height - draw_pad.Y * 2}

        ' gfx could be nothing
        If _clear Then gfx.Clear(vis_seek.BackColor)
        gfx.FillRectangle(dbad, _AA(0), _AA(1), _AA(2), _AA(3))
    End Sub
    Private Sub vis_seek_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles vis_seek.Paint
        gfx = e.Graphics
        If vis_seekValueP > vis_seekValue Then
            AutoDraw(True)
        Else
            AutoDraw(False)
        End If
    End Sub
    Dim vis_seekValue As Decimal = 1
    Dim vis_seekValueP As Decimal = 0
    Private Sub pvt_RefreshSeekBar(ByVal _redraw As Boolean)

        vis_seekValueP = vis_seekValue
        vis_seekValue = (mp_POS / mp_LEN)
        If vis_seekValue > 1 Then vis_seekValue = 1
        If _redraw Then

            gfx = vis_seek.CreateGraphics
            If vis_seekValueP > vis_seekValue Then
                AutoDraw(True)
            Else
                AutoDraw(False)
            End If
        End If

    End Sub
    Private Sub mp_timer_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles mp_TIMER.DoWork
        '  gfx = vis_seek.CreateGraphics
        Dim isact As Integer
        Dim hsl_col As Single()
        Dim hsl_colF As Single()
        While mp_TIMER_ON
            If mp_HANDLE <> 0 Then
                isact = Bass.BASS_ChannelIsActive(mp_HANDLE)
                Select Case isact
                    Case BASSActive.BASS_ACTIVE_PLAYING
                        If ini_2_HUE_SHIFT Then
                            hsl_col = RGB_HSL(vis_l_main.BackColor)
                            hsl_col(0) += (0.002777777778 * ini_3_HUE_SHIFT_DEG) Mod 1        '1.0 degree
                            'hsl_col(0) += (0.001388888889) Mod 1        ' 0.5 degree
                            ReCol = HSL_RGB(hsl_col(0), hsl_col(1), hsl_col(2))
                        End If
                        If ini_37_HUE_SHIFT_FORE Then
                            hsl_colF = RGB_HSL(vis_l_main.ForeColor)
                            hsl_colF(0) += (0.002777777778 * ini_38_HUE_SHIFT_DEG_FORE) Mod 1        '1.0 degree
                            ReColF = HSL_RGB(hsl_colF(0), hsl_colF(1), hsl_colF(2))
                        End If
                        mp_POS = Bass.BASS_ChannelGetPosition(mp_HANDLE)
                        mp_TIMER.ReportProgress(isact, mp_POS)
                        Threading.Thread.Sleep(mp_sleep_interval)
                    Case BASSActive.BASS_ACTIVE_PAUSED, BASSActive.BASS_ACTIVE_STOPPED, BASSActive.BASS_ACTIVE_PAUSED_DEVICE '0
                        mp_TIMER_ON = False
                        mp_TIMER.ReportProgress(isact)
                        Threading.Thread.Sleep(mp_sleep_interval)
                    Case BASSActive.BASS_ACTIVE_STALLED
                        mp_TIMER.ReportProgress(isact)
                        Threading.Thread.Sleep(mp_sleep_interval)
                End Select
            Else
                mp_TIMER_ON = False
                mp_TIMER.ReportProgress(5)
            End If
        End While
    End Sub
    Private Sub mp_timer_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles mp_TIMER.ProgressChanged
        Select Case e.ProgressPercentage
            Case BASSActive.BASS_ACTIVE_PLAYING     '1
                pvt_RefreshSeekBar(Not (ini_2_HUE_SHIFT Or ini_37_HUE_SHIFT_FORE))
                If ini_2_HUE_SHIFT Then
                    vis_l_main.BackColor = ReCol
                    vis_seek.ForeColor = ReCol
                    '      
                    If ini_35_ART_BG_MATCH Then vis_pic.BackColor = ReCol

                End If
                If ini_37_HUE_SHIFT_FORE Then
                    vis_l_main.ForeColor = ReColF
                    vis_seek.BackColor = ReColF
                    '      
                    '  If ini_35_ART_BG_MATCH Then vis_pic.BackColor = ReCol

                End If
            Case BASSActive.BASS_ACTIVE_PAUSED      '3
                pvt_RefreshSeekBar(True)
            Case BASSActive.BASS_ACTIVE_STOPPED     '0
                mp_STATE = Media_MPstate.mp_loaded
                If xVar_LOOP_SINGLE Then
                    media_playmedia(True)
                Else
                    If xvar_play_backward Then
                        media_PlayPrev(False)
                    Else
                        media_PlayNext(False)
                    End If
                End If
            Case BASSActive.BASS_ACTIVE_PAUSED_DEVICE '4
                If pvt1_Init_On_Device(-1) Then
                    media_LoadMedia(mp_URL, True, True)
                End If
            Case BASSActive.BASS_ACTIVE_STALLED     '2
                ShowMsg("...")
            Case Else
                mp_STATE = Media_MPstate.mp_null
        End Select
        '  RaiseEvent ReportStateChanged(e.ProgressPercentage, e.UserState)
    End Sub
    Private Sub mp_timer_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles mp_TIMER.RunWorkerCompleted
        pvt_RefreshSeekBar(True)
        If mp_TIMER_ON Then
            '   MsgBox(" woopsie")
            mp_TIMER.RunWorkerAsync()
        End If
    End Sub

    Friend Sub media_FreeMedia(ByVal resetview As Boolean)
        mp_TIMER_ON = False
        If mp_HANDLE <> 0 Then
            Bass.BASS_ChannelStop(mp_HANDLE)
            Bass.BASS_StreamFree(mp_HANDLE)
            mp_HANDLE = 0
        End If
        If resetview Then
            mp_LEN = 1
            mp_POS = 0
            mp_TITLE = ""
            mp_TAG_EXIST = False
            If ini_35_ART_BG_MATCH Then
                vis_pic.BackColor = vis_l_main.BackColor
            Else
                vis_pic.BackColor = ini_34_ART_BG
            End If
            pvt_setVis_picImage(Nothing)
            Update_VIS_TEXT()
            'vis_l_main.Text = IIf(ini_16_HIDE_LABEL, "", const_label_reset_text).ToString
            PlayToolStripMenuItem.Text = "Pl&ay"
            pvt_RefreshSeekBar(True)
        End If
        mp_STATE = (Media_MPstate.mp_empty)
    End Sub

    Friend Function media_LoadMedia(ByVal path As String, ByVal playit As Boolean, ByVal resumeU As Boolean) As Boolean
        ' create a stream channel from a file
        If mp_STATE > 1 Then media_FreeMedia(False) '>1 means loaded, playing or paused
        mp_URL = path
        mp_HANDLE = Bass.BASS_StreamCreateFile(path, 0, 0, BASSFlag.BASS_DEFAULT)
        If mp_HANDLE <> 0 Then
            'loaded succesfully
            mp_LEN = Bass.BASS_ChannelGetLength(mp_HANDLE)
            If Not resumeU Then mp_POS = 0
            mp_TAG = New Tags.TAG_INFO
            mp_STATE = (Media_MPstate.mp_loaded)

            mp_TAG_EXIST = Tags.BassTags.BASS_TAG_GetFromFile(mp_HANDLE, mp_TAG)
            xvar_tempimg = Nothing
            '    mp_TITLE = mp_URL
            pvt_UpdateTitle()


            PlayToolStripMenuItem.Text = "Pl&ay"
            pvt_RefreshSeekBar(True)
            If ini_16_HIDE_LABEL Then
                ShowMsg(mp_TITLE)
            Else
                Update_VIS_TEXT()
            End If
            If resumeU Then
                media_seek(Bass.BASS_ChannelBytes2Seconds(mp_HANDLE, mp_POS))
            End If
            If playit Then
                media_playmedia()
            End If
            If k3SettingPage.Visible Then k3SettingPage.tmediainfo.Text = GetMediaInfoStr()
            Return True
        Else
            mp_LEN = 1
            mp_POS = 0
            mp_TAG_EXIST = False
            Me.BackgroundImage = Nothing
            ' Update_VIS_TEXT()
            pvt_RefreshSeekBar(True)
            ShowMsg("Can't Load Track!")
            If k3SettingPage.Visible Then k3SettingPage.tmediainfo.Text = GetMediaInfoStr()
            Return False
        End If
    End Function
    Private Sub pvt_UpdateTitle()
        mp_TITLE = mp_URL
        If mp_TAG_EXIST Then
            mp_TITLE = mp_TAG.title
            If mp_TITLE.Trim = "" Then
                mp_TITLE = mp_URL
                If mp_TITLE.Contains("\") Then mp_TITLE = mp_URL.Substring(mp_URL.LastIndexOf("\")).Remove(0, 1)
                If mp_TITLE.Contains(".") Then mp_TITLE = mp_TITLE.Remove(mp_TITLE.LastIndexOf("."))
            Else
                If ini_40_MULTILINE_LABEL Then
                    mp_TITLE += Environment.NewLine + mp_TAG.artist + Environment.NewLine + mp_TAG.album + Environment.NewLine + mp_TAG.year
                Else
                    If mp_TAG.artist <> "" Then mp_TITLE += " - " + mp_TAG.artist
                End If


            End If
            If mp_TAG.PictureCount > 0 Then xvar_tempimg = mp_TAG.PictureGet(0).PictureImage
            If ini_24_ALWAYS_CART Then
                pvt_setVis_picImage(Nothing)
            Else
                pvt_setVis_picImage(xvar_tempimg)
            End If
        Else
            pvt_setVis_picImage(Nothing)
            If mp_TITLE.Contains("\") Then mp_TITLE = mp_URL.Substring(mp_URL.LastIndexOf("\")).Remove(0, 1)
            If mp_TITLE.Contains(".") Then mp_TITLE = mp_TITLE.Remove(mp_TITLE.LastIndexOf("."))
        End If
    End Sub
    Private Sub media_playmedia(Optional ByVal reset As Boolean = False)
        If mp_STATE > 1 Then
            If Bass.BASS_ChannelPlay(mp_HANDLE, reset) Then
                mp_STATE = (Media_MPstate.mp_playing)
                PlayToolStripMenuItem.Text = "P&ause"
                mp_TIMER_ON = True
                If Not mp_TIMER.IsBusy Then mp_TIMER.RunWorkerAsync()
            Else
                'COuld not play - may be device unplugged - check
                '   If ci = BASSActive.BASS_ACTIVE_PAUSED_DEVICE Then
                t_shortcut_ReInit(-1)
                media_LoadMedia(mp_URL, False, False)
                If mp_STATE <= 1 Then Exit Sub
                If Bass.BASS_ChannelPlay(mp_HANDLE, reset) Then
                    mp_STATE = (Media_MPstate.mp_playing)
                    PlayToolStripMenuItem.Text = "P&ause"
                    mp_TIMER_ON = True
                    If Not mp_TIMER.IsBusy Then mp_TIMER.RunWorkerAsync()
                End If
                End If
        End If
    End Sub
    Private Sub media_pausemedia()
        If mp_STATE = Media_MPstate.mp_playing Then
            If Bass.BASS_ChannelPause(mp_HANDLE) Then
                mp_STATE = (Media_MPstate.mp_paued)
                PlayToolStripMenuItem.Text = "Pl&ay"
                mp_TIMER_ON = False
            End If
        End If
    End Sub
    Private Sub media_seek(ByVal len As Double)
        If mp_STATE > 1 Then
            mp_POS = Bass.BASS_ChannelGetPosition(mp_HANDLE)
            Dim b2l As Long = Bass.BASS_ChannelSeconds2Bytes(mp_HANDLE, len) + mp_POS
            Bass.BASS_ChannelSetPosition(mp_HANDLE, b2l)
            mp_POS = Bass.BASS_ChannelGetPosition(mp_HANDLE)
            pvt_RefreshSeekBar(True)
        End If
    End Sub

    Private Function GetRandomColor() As Color()
        Dim rc As Single() = RGB_HSL(ini_12_BGCOL)
        Dim rcf As Single() = RGB_HSL(ini_13_FGCOL)
        Dim rndx As Single = Rnd()
        Return {HSL_RGB((rc(0) + rndx * 2) Mod 1, rc(1), rc(2)), HSL_RGB((rcf(0) + rndx * 2) Mod 1, rcf(1), rcf(2))}
    End Function
    Friend Sub pvt_skipInvlid_prev()
        If ini_14_DEL_UNPLAYBLE Then
            While True
                If CiTrack < K3PlaylistView.lb_pl.Items.Count Then
                    If Not media_LoadMedia(K3PlaylistView.lb_pl.Items(CiTrack).Tag, True, False) Then
                        K3PlaylistView.lb_pl.Items.RemoveAt(CiTrack)
                        CiTrack -= 1
                        If CiTrack < 0 Then CiTrack = K3PlaylistView.lb_pl.Items.Count - 1
                        If CiTrack < 0 Then Exit While
                    Else
                        Exit While
                    End If
                Else
                    If K3PlaylistView.lb_pl.Items.Count > 0 Then
                        CiTrack = 0
                    Else
                        CiTrack = -1
                        Exit While
                    End If
                End If
            End While
        Else
            Dim nos_try As Integer = 0

            While True
                If CiTrack < K3PlaylistView.lb_pl.Items.Count Then
                    If Not media_LoadMedia(K3PlaylistView.lb_pl.Items(CiTrack).Tag, True, False) Then
                        ' K3PlaylistView.lb_pl.Items.RemoveAt(CiTrack)
                        CiTrack -= 1
                        If CiTrack < 0 Then CiTrack = K3PlaylistView.lb_pl.Items.Count - 1
                        If CiTrack < 0 Then Exit While
                    Else
                        Exit While
                    End If
                Else
                    If K3PlaylistView.lb_pl.Items.Count > 0 Then
                        CiTrack = 0
                    Else
                        CiTrack = -1
                        Exit While
                    End If
                End If
                If nos_try >= K3PlaylistView.lb_pl.Items.Count Then Exit While
            End While
        End If
    End Sub
    Friend Sub pvt_skipInvalid()
        If ini_14_DEL_UNPLAYBLE Then
            While True
                If CiTrack < K3PlaylistView.lb_pl.Items.Count Then
                    If Not media_LoadMedia(K3PlaylistView.lb_pl.Items(CiTrack).Tag, True, False) Then
                        K3PlaylistView.lb_pl.Items.RemoveAt(CiTrack)
                    Else
                        Exit While
                    End If
                Else
                    If K3PlaylistView.lb_pl.Items.Count > 0 Then
                        CiTrack = 0
                    Else
                        CiTrack = -1
                        Exit While
                    End If
                End If
            End While
        Else
            Dim nos_try As Integer = 0
            While True
                If CiTrack < K3PlaylistView.lb_pl.Items.Count Then
                    If Not media_LoadMedia(K3PlaylistView.lb_pl.Items(CiTrack).Tag, True, False) Then
                        CiTrack += 1
                        nos_try += 1
                    Else
                        Exit While
                    End If
                Else
                    If K3PlaylistView.lb_pl.Items.Count > 0 Then
                        CiTrack = 0
                    Else
                        CiTrack = -1
                        Exit While
                    End If
                End If
                If nos_try >= K3PlaylistView.lb_pl.Items.Count Then Exit While
            End While
        End If
    End Sub
    Private Sub media_PlayNext(ByVal manual As Boolean)
        If CiTrack < 0 Then Exit Sub

        If CiTrack >= K3PlaylistView.lb_pl.Items.Count - 1 Then
            CiTrack = 0
            If Not manual Then
                If Not _RepetePlaylist Then
                    ' CiTrack = -1
                    PlayToolStripMenuItem.Text = "Pl&ay"
                    CiTrack = K3PlaylistView.lb_pl.Items.Count - 1
                    Exit Sub
                End If
                
            End If

        Else
            CiTrack += 1
        End If
        

        Dim CA As Color() = GetRandomColor()
        If ini_2_HUE_SHIFT Then
            vis_l_main.BackColor = CA(0)
            If ini_35_ART_BG_MATCH Then
                vis_pic.BackColor = vis_l_main.BackColor
            Else
                vis_pic.BackColor = ini_34_ART_BG
            End If
            vis_seek.ForeColor = vis_l_main.BackColor
        End If

        If ini_37_HUE_SHIFT_FORE Then
            vis_l_main.ForeColor = CA(1)
            vis_seek.BackColor = vis_l_main.ForeColor
        End If

        If manual Then
            media_LoadMedia(K3PlaylistView.lb_pl.Items(CiTrack).Tag, True, False)
        Else
            pvt_skipInvalid()
        End If

    End Sub
    Private Sub media_PlayPrev(ByVal manual As Boolean)
        If CiTrack < 0 Then Exit Sub
        If CiTrack = 0 Or CiTrack > K3PlaylistView.lb_pl.Items.Count - 1 Then
            CiTrack = K3PlaylistView.lb_pl.Items.Count - 1
            If Not manual Then
                If Not _RepetePlaylist Then
                    PlayToolStripMenuItem.Text = "Pl&ay"
                    CiTrack = 0
                    Exit Sub
                End If
                
            End If

        Else
            CiTrack -= 1
        End If
        Dim CA As Color() = GetRandomColor()
        If ini_2_HUE_SHIFT Then
            vis_l_main.BackColor = CA(0)
            If ini_35_ART_BG_MATCH Then
                vis_pic.BackColor = vis_l_main.BackColor
            Else
                vis_pic.BackColor = ini_34_ART_BG
            End If
            vis_seek.ForeColor = vis_l_main.BackColor
        End If

        If ini_37_HUE_SHIFT_FORE Then
            vis_l_main.ForeColor = CA(1)
            vis_seek.BackColor = vis_l_main.ForeColor
        End If

        If manual Then
            media_LoadMedia(K3PlaylistView.lb_pl.Items(CiTrack).Tag, True, False)
        Else
            pvt_skipInvlid_prev()
        End If

    End Sub

    Private Sub ShiffleOnceToolStripMenuItem_Click()
        K3PlaylistView.media_shufflePlaylist()
        ' My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        ShowMsg("Shuffled Playlist")
    End Sub
#End Region


#Region "DragDrop"
    Friend Sub pvt_Append2Library(ByVal data As String())
        If Not _loadedlib Then Exit Sub
        For Each dst As String In data
            If My.Computer.FileSystem.DirectoryExists(dst) Then
                'add this directory to bookmarks
                drop_AddNew_DirBM(dst)
                xVar_Lib_Dirty = True
            Else
                If My.Computer.FileSystem.FileExists(dst) Then
                    'add this file to file bookmarks
                    drop_AddNew_FileBM(dst, False)
                    xVar_Lib_Dirty = True
                Else
                    ' do nothing
                End If
            End If
        Next
    End Sub
    'group      pl(0); file(1) dir(2)
    Private Sub drop_AddNew_DirBM(ByVal path As String)
        'Mybm_dir.Add(path)
        Dim name As String = path.Substring(path.LastIndexOf("\")).Remove(0, 1)
        Dim ti As New ListViewItem(name, 2)
        ti.Tag = path
        ti.Group = K3LibraryView.lb_Library.Groups(2)
        K3LibraryView.lb_Library.Items.Add(ti)

    End Sub
    Friend Sub drop_AddNew_FileBM(ByVal path As String, ByVal _setVisible As Boolean)
        '   Mybm_file.Add(path)
        Dim name As String = path.Substring(path.LastIndexOf("\")).Remove(0, 1)
        Dim iidx As Integer = 1
        If name.EndsWith(const_playlist_ext) Then
            iidx = 0
        End If
        Dim ti As New ListViewItem(name, iidx)
        ti.Tag = path
        ti.Group = K3LibraryView.lb_Library.Groups(iidx)
        K3LibraryView.lb_Library.Items.Add(ti)
        If _setVisible Then
            K3LibraryView.lb_Library.SelectedItems.Clear()
            ti.Selected = True
            K3LibraryView.lb_Library.EnsureVisible(ti.Index)

        End If

    End Sub
    
    Friend Function pvt_Append2Playlist(ByVal data As String()) As Integer
        '   If _clear Then pvt_ClearPlaylist()
        Dim res As Integer = 0
        'appends a list of string to playlist
        For Each dst As String In data
            If My.Computer.FileSystem.DirectoryExists(dst) Then
                'is a directory => scan directory and add append files to current playlist
                res += drop_AppendCi_dir(dst)
            Else
                If My.Computer.FileSystem.FileExists(dst) Then
                    If dst.EndsWith(const_playlist_ext) Then
                        'is a playlist => load this playlist file and append to current playlist
                        res += drop_AppendCi_pl(dst)
                    Else
                        'is a normal file => append this file to current playlist
                        drop_AppendCi_file(dst)
                        res += 1
                    End If
                Else
                    ' is nither a file nor a dir = doesnt exsist
                    ' do nothing
                End If
            End If
        Next
        Return res
    End Function
    Friend Sub drop_AppendCi_file(ByVal path As String)
        ' If Not My.Computer.FileSystem.FileExists(path) Then Exit Sub
        '
        Dim ti As New K3PlaylistView.K3PlayListItem(path)
        K3PlaylistView.lb_pl.Items.Add(ti)
        '   Return 1
    End Sub
    Friend Function drop_AppendCi_dir(ByVal path As String) As Integer
        '  If Not My.Computer.FileSystem.DirectoryExists(path) Then Exit Sub

        Dim rlso As ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories, ini_7_FILE_TYPES)
        For Each s As String In rlso
            drop_AppendCi_file(s)
        Next
        Return rlso.Count
    End Function
    Friend Function drop_AppendCi_pl(ByVal path As String) As Integer
        ' If Not My.Computer.FileSystem.FileExists(path) Then Exit Sub

        Dim rlso As New List(Of String)
        If pvt_LoadFilesFromPList(path, rlso) Then
            For Each s As String In rlso
                drop_AppendCi_file(s)
            Next
            Return rlso.Count
        Else
            Return 0
        End If

    End Function
    Friend Function pvt_ClearPlaylist() As String

        If K3PlaylistView.lb_pl.Enabled = False Then
            Return ("[Busy : " + K3PlaylistView._remdC.ToString + " %]")
        Else
            CiTrack = -1
            media_FreeMedia(True)
            K3PlaylistView.lb_pl.Items.Clear()
            Return ("Cleared Playlist")
        End If
    End Function

    Private Sub Form1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(Windows.Forms.DataFormats.FileDrop) Then
            If ini_0_DROP_2PL Then
                e.Effect = DragDropEffects.Copy ' (+) sign
            Else
                e.Effect = DragDropEffects.Link     ' (shortcur curved arraow) sign
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub Form1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim data As String() = e.Data.GetData(Windows.Forms.DataFormats.FileDrop)
        'determine what the data contains   ' may have files and/or folders
        If xsproxy.File_Drop_to_Playlist Then
            'when drag-dropped dont clear play list
            If K3PlaylistView.lb_pl.Enabled = False Then
                ShowMsg("[Busy : " + K3PlaylistView._remdC.ToString + " %]")
                Exit Sub
            End If
            pvt_Append2Playlist(data)
            If xsproxy.Auto_Play Then
                If CiTrack < 0 And K3PlaylistView.lb_pl.Items.Count > 0 Then
                    pvt_tryAUTOPLAY(IIf(xsproxy.Random_start, -1, 0))
                End If
            End If
        Else
            pvt_Append2Library(data)
        End If
    End Sub

#End Region

#Region "ToolMenus"
    Private Sub LibraryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibraryToolStripMenuItem.Click
        If _loadedlib Then
            'K3LibraryView.ShowDialog()
            K3LibraryView.Show()
            K3LibraryView.BringToFront()
        Else
            ShowMsg("Can't load Library")
        End If
    End Sub
    Friend Sub PlaylistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlaylistToolStripMenuItem.Click
        If K3PlaylistView.lb_pl.Enabled = False Then
            ShowMsg("[Busy : " + K3PlaylistView._remdC.ToString + " %]")
        Else
            K3PlaylistView.Show()
            K3PlaylistView.BringToFront()
        End If

    End Sub

    Private Sub PlayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayToolStripMenuItem.Click
        Select Case mp_STATE
            Case Media_MPstate.mp_loaded, Media_MPstate.mp_paued ' new/Ready
                media_playmedia()
            Case Media_MPstate.mp_playing
                media_pausemedia()
        End Select
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        If mp_STATE > 1 Then media_playmedia(True)
    End Sub

    Private Sub NextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextToolStripMenuItem.Click
        media_PlayNext(True)
    End Sub

    Private Sub PrevToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrevToolStripMenuItem.Click
        media_PlayPrev(True)
    End Sub
    Private Sub FocusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FocusToolStripMenuItem.Click
        Me.BringToFront()
        Me.Focus()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        pvt_Close_ME(True)
    End Sub


    Private Sub ReinitializeDefaultDeviceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReinitializeDefaultDeviceToolStripMenuItem.Click
        t_shortcut_ReInit(-1)

    End Sub
    Private Sub MediaInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoToolStripMenuItem.Click
        k3SettingPage.tabSetting.SelectTab(0)
        k3SettingPage.Show()
    End Sub

    Private Sub StatusInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusInfoToolStripMenuItem.Click
        k3SettingPage.tabSetting.SelectTab(2)
        k3SettingPage.Show()
    End Sub
    Private Sub VisitWebsiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisitWebsiteToolStripMenuItem.Click
        Process.Start("https://spookyisgod.wordpress.com/kookie3help/")
        ShowMsg("Visit Website")
    End Sub
    Private Sub AppDirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppDirToolStripMenuItem.Click
        Process.Start(My.Application.Info.DirectoryPath)
        ShowMsg("App Directory")
    End Sub
    Private Sub ConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurationToolStripMenuItem.Click
        k3SettingPage.tabSetting.SelectTab(1)
        k3SettingPage.Show()
    End Sub
    Private Sub ImportConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportConfigToolStripMenuItem.Click
        Dim ofdf As New OpenFileDialog
        ofdf.Title = "Import Configuration..."
        If ofdf.ShowDialog = DialogResult.OK Then
            pvt_applyconfig(ofdf.FileName)
            ShowMsg("Applying Config")
        End If
    End Sub

    Private Sub ExportConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportConfigToolStripMenuItem.Click

        Dim sfdf As New SaveFileDialog
        sfdf.Title = "Export Configuration..."
        If sfdf.ShowDialog = Windows.Forms.DialogResult.OK Then
            If K3_ini_setting.CopyToDisk_AS(sfdf.FileName) Then
                ShowMsg("Saved Config")
            Else
                ShowMsg("Cannot Save Config")
            End If
        End If
    End Sub

    Private Sub SaveCurrentConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveCurrentConfigToolStripMenuItem.Click
        pvt_Close_ME(False)
        ShowMsg("Saved Changes")
    End Sub

    Private Sub AutoSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSizeToolStripMenuItem.Click
        If vis_pic.Visible = False Then Exit Sub
        If ini_21_DOCK_ART > 2 Then
            'is let right
            xsproxy.Form_Size = New Size(vis_pic.Width + const_vis_seek_h + xsproxy.Label_Font.Height, Me.Height)
        Else
            'is top bot
            xsproxy.Form_Size = New Size(Me.Width, vis_pic.Height + const_vis_seek_h + xsproxy.Label_Font.Height)
        End If
        ShowMsg("Auto-Sized")
    End Sub

    Private Sub CenterScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterScreenToolStripMenuItem.Click
        CenterToScreen()
        ShowMsg("Centered")
    End Sub

#End Region

#Region "Shared Functions"

    Friend Shared Function pvt_LoadFilesFromPList(ByVal plpath As String, ByRef res As List(Of String)) As Boolean
        '   Dim res As New List(Of String)
        Dim rl As String
        Try
            res.Clear()
            Dim rr As New FileIO.TextFieldParser(plpath)
            While Not rr.EndOfData
                rl = rr.ReadLine
                If rl <> "" Then res.Add(rl)
            End While
            rr.Close()
            rr.Dispose()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
    Friend Shared Function pvt_SaveFilesToPL(ByVal plpath As String, ByRef newls As List(Of String)) As Boolean
        Try
            Dim rw As New IO.StreamWriter(plpath, False)
            For Each rl As String In newls
                rw.WriteLine(rl)
            Next
            rw.Close()
            rw.Dispose()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Shared Function RGB_HSL(ByVal rgb As Color) As Single()
        Dim r As Byte = rgb.R
        Dim g As Byte = rgb.G
        Dim b As Byte = rgb.B
        Dim h, s, l As Single

        Dim var_R As Single = (r / 255)
        Dim var_G As Single = (g / 255)
        Dim var_B As Single = (b / 255)

        Dim var_Min As Single = Math.Min(Math.Min(var_R, var_G), var_B)    '//Min. value of RGB
        Dim var_Max As Single = Math.Max(Math.Max(var_R, var_G), var_B)     '//Max. value of RGB
        Dim del_Max As Single = var_Max - var_Min                      '//Delta RGB value

        l = (var_Max + var_Min) / 2

        If (del_Max = 0) Then
            h = 0
            s = 0
        Else
            '===========
            If (l < 0.5) Then
                s = del_Max / (var_Max + var_Min)
            Else
                s = del_Max / (2 - var_Max - var_Min)
            End If

            Dim del_R = (((var_Max - var_R) / 6) + (del_Max / 2)) / del_Max
            Dim del_G = (((var_Max - var_G) / 6) + (del_Max / 2)) / del_Max
            Dim del_B = (((var_Max - var_B) / 6) + (del_Max / 2)) / del_Max

            If (var_R = var_Max) Then
                h = del_B - del_G
            ElseIf (var_G = var_Max) Then
                h = (1 / 3) + del_R - del_B
            ElseIf (var_B = var_Max) Then
                h = (2 / 3) + del_G - del_R
            End If

            If (h < 0) Then h += 1
            If (h > 1) Then h -= 1
            '=========
        End If

        Return {h, s, l}
    End Function
    Shared Function HSL_RGB(ByVal h As Single, ByVal s As Single, ByVal l As Single) As Color
        Dim r, g, b As Byte
        Dim var_1, var_2 As Single
        If s = 0 Then
            r = l * 255
            g = l * 255
            b = l * 255

        Else
            If (l < 0.5) Then
                var_2 = l * (1 + s)
            Else
                var_2 = (l + s) - (s * l)
            End If

            var_1 = 2 * l - var_2
            r = 255 * Hue_2_RGB(var_1, var_2, h + (1 / 3))
            g = 255 * Hue_2_RGB(var_1, var_2, h)
            b = 255 * Hue_2_RGB(var_1, var_2, h - (1 / 3))

        End If
        Return Color.FromArgb(r, g, b)
    End Function
    Shared Function Hue_2_RGB(ByVal v1 As Single, ByVal v2 As Single, ByVal vH As Single) As Single          ' //Function Hue_2_RGB
        If (vH < 0) Then vH += 1
        If (vH > 1) Then vH -= 1
        If ((6 * vH) < 1) Then Return (v1 + (v2 - v1) * 6 * vH)
        If ((2 * vH) < 1) Then Return (v2)
        If ((3 * vH) < 2) Then Return (v1 + (v2 - v1) * ((2 / 3) - vH) * 6)
        Return (v1)
    End Function

    Shared Function xS_ArraytoCSVString(ByVal a As String()) As String
        Dim res As String = ""
        For i = 0 To a.Length - 1
            res += a(i) + csv
        Next
        Return res.Remove(res.Length - 1, 1)
    End Function

    Shared Function pvt_Color2rgbcsv(ByVal c As Color) As String
        If c = Color.Empty Then Return ""
        Return c.R.ToString + csv + c.G.ToString + csv + c.B.ToString
    End Function
    Shared Function pvt_rgbcsv2Color(ByVal s As String) As Color
        If s = "" Then Return Color.Empty
        Dim ss As String() = s.Split(csv)
        Return Color.FromArgb(Convert.ToByte(ss(0)), Convert.ToByte(ss(1)), Convert.ToByte(ss(2)))
    End Function
#End Region



    Friend Sub pvt_applyconfig(ByVal path As String)
        '        Dim nts As New K3Settings(path, False)
        If K3_ini_setting.ReloadFromDisk_As(path) Then
            ' K3_ini_setting.
            pvt11_loadvars()
            pvt2_applySetting()
        Else

        End If
    End Sub
    Public Class K3Settings
        Dim c_valid_start As Char = "."
        Dim c_valid_end As Char = ":"
        Dim inames As String()
        Dim my_path As String
        Dim my_hash As Hashtable

        Dim xVar_OVERWRITE_DUPS As Boolean
        Dim xVar_Dirty As Boolean
        Public Sub New(ByVal path As String, ByVal OverWrite_Dup As Boolean, ByVal ini_names_array As String(), Optional ByVal valid_start_char As Char = ".", Optional ByVal valid_end_char As Char = ":")
            my_path = path
            my_hash = New Hashtable
            inames = ini_names_array
            xVar_Dirty = False
            xVar_OVERWRITE_DUPS = OverWrite_Dup
            c_valid_start = valid_start_char
            c_valid_end = valid_end_char
        End Sub

        Public Function ReadProperty(ByVal set_key As String) As String
            If my_hash.ContainsKey(set_key) Then
                Return my_hash(set_key)
            Else
                Return Nothing
            End If
        End Function
        Public Function WriteProperty(ByVal set_key As String, ByVal set_val As String) As Boolean
            ' If set_val = Nothing Then Return False
            If my_hash.ContainsKey(set_key) Then
                my_hash(set_key) = set_val
                xVar_Dirty = True
                Return True
            Else
                Return False
            End If

        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return my_hash.Count
            End Get
        End Property
        Public ReadOnly Property isDirty As Boolean
            Get
                Return xVar_Dirty
            End Get
        End Property
        Public ReadOnly Property FilePath As String
            Get
                Return my_path
            End Get
        End Property
        Public Property OverWrite_Duplicates As Boolean
            Get
                Return xVar_OVERWRITE_DUPS
            End Get
            Set(ByVal value As Boolean)
                xVar_OVERWRITE_DUPS = value
            End Set
        End Property
        Public Function CopyToDisk_AS(ByVal pathx As String) As Boolean
            Try
                Dim rw As New IO.StreamWriter(pathx)
                For Each k As String In my_hash.Keys
                    rw.WriteLine(c_valid_start + k + c_valid_end + my_hash(k).ToString)
                Next
                rw.Close()
                rw.Dispose()
                ' xVar_Dirty = False
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function FlushToDisk() As Boolean
            Try
                Dim rw As New IO.StreamWriter(my_path)
                For Each k As String In my_hash.Keys
                    rw.WriteLine(c_valid_start + k + c_valid_end + my_hash(k).ToString)
                Next
                rw.Close()
                rw.Dispose()
                xVar_Dirty = False
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function ReloadFromDisk() As Boolean
            Try
                _ClearSetting()            '    Dim res As New K3Settings(path, OverWrite_Duplicates)
                Dim rr As New FileIO.TextFieldParser(my_path)
                Dim rl As String
                While Not rr.EndOfData
                    rl = rr.ReadLine
                    If Not (rl.StartsWith(c_valid_start) And rl.Contains(c_valid_end)) Then Continue While
                    Dim set_key As String = rl.Substring(1, rl.IndexOf(c_valid_end))
                    If set_key = c_valid_end Then Continue While
                    Dim set_val As String = rl.Substring(rl.IndexOf(c_valid_end))
                    'If set_val = c_valid_end Then set_val = "" 'is blank value
                    '-----------------addsetting sub
                    Dim set_lable As String = set_key.Remove(set_key.Length - 1, 1)

                    If inames.Contains(set_lable) Then
                        _AddSetting(set_lable, set_val.Remove(0, 1))
                    End If
                End While
                rr.Close()
                rr.Dispose()
                xVar_Dirty = False
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function ReloadFromDisk_As(ByVal pathx As String) As Boolean
            Try
                _ClearSetting()            '    Dim res As New K3Settings(path, OverWrite_Duplicates)
                Dim rr As New FileIO.TextFieldParser(pathx)
                Dim rl As String
                While Not rr.EndOfData
                    rl = rr.ReadLine
                    If Not (rl.StartsWith(c_valid_start) And rl.Contains(c_valid_end)) Then Continue While
                    Dim set_key As String = rl.Substring(1, rl.IndexOf(c_valid_end))
                    If set_key = c_valid_end Then Continue While
                    Dim set_val As String = rl.Substring(rl.IndexOf(c_valid_end))
                    'If set_val = c_valid_end Then set_val = "" 'is blank value
                    '-----------------addsetting sub
                    Dim set_lable As String = set_key.Remove(set_key.Length - 1, 1)
                    If inames.Contains(set_lable) Then
                        _AddSetting(set_key.Remove(set_key.Length - 1, 1), set_val.Remove(0, 1))
                    End If
                End While
                rr.Close()
                rr.Dispose()
                xVar_Dirty = False
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Sub AddSetting(ByVal set_key As String, ByVal set_val As String)
            If my_hash.ContainsKey(set_key) Then
                If xVar_OVERWRITE_DUPS Then
                    my_hash(set_key) = set_val
                    xVar_Dirty = True
                End If

            Else
                my_hash.Add(set_key, set_val)
                xVar_Dirty = True
            End If
        End Sub
        Public Sub _AddSetting(ByVal set_key As String, ByVal set_val As String)
            If my_hash.ContainsKey(set_key) Then
                If xVar_OVERWRITE_DUPS Then
                    my_hash(set_key) = set_val
                    ' xVar_Dirty = True
                End If

            Else
                my_hash.Add(set_key, set_val)
                '  xVar_Dirty = True
            End If
        End Sub
        Public Sub RemoveSetting(ByVal set_key As String)
            If my_hash.ContainsKey(set_key) Then
                my_hash.Remove(set_key)
                xVar_Dirty = True
            End If
        End Sub
        Public Sub _RemoveSetting(ByVal set_key As String)
            If my_hash.ContainsKey(set_key) Then
                my_hash.Remove(set_key)
                '  xVar_Dirty = True
            End If
        End Sub
        Public Sub ClearSetting()
            If my_hash.Count = 0 Then Exit Sub
            my_hash.Clear()
            xVar_Dirty = True
        End Sub
        Public Sub _ClearSetting()
            my_hash.Clear()
        End Sub

        Public Function CheckExsist(ByVal set_keys As String()) As Boolean
            For i = 0 To set_keys.Length - 1
                If Not my_hash.ContainsKey(set_keys(i)) Then Return False
            Next
            Return True
        End Function
        '===========================================

    End Class

    Friend Function LoadLIBfile() As Boolean
        '  If _loaded Then Return True
        Dim _doload As Boolean = False
        If Not My.Computer.FileSystem.FileExists(k3_lib_path) Then
            Dim cresult As MsgBoxResult = MsgBox("No Default Library exists. Create one now?", vbYesNo + vbQuestion)
            Select Case cresult
                Case vbYes
                    Try
                        Dim rw As New IO.StreamWriter(k3_lib_path, False)
                        rw.WriteLine("")
                        rw.Close()
                        rw.Dispose()
                        ShowMsg("Empty Lib Created")
                        _doload = True
                    Catch ex As Exception
                        MsgBox("Cannot Create Lib")
                    End Try
                Case vbNo
                    ShowMsg("Lib not Created")
            End Select
        Else
            _doload = True
        End If

        If _doload Then
            Try
                Dim rw As New FileIO.TextFieldParser(k3_lib_path)
                Dim rl As String = ""

                While Not rw.EndOfData
                    rl = rw.ReadLine
                    If rl = "" Then Continue While
                    Select Case rl(0)
                        Case SETF_DIR
                            drop_AddNew_DirBM(rl.Remove(0, 1))
                        Case SETF_FILE
                            drop_AddNew_FileBM(rl.Remove(0, 1), False)
                        Case Else
                    End Select
                End While

                rw.Dispose()
                rw.Close()
                Return True
            Catch ex As Exception
                Return False
            End Try

        Else
            Return False
        End If
    End Function
    Friend Function SaveLIBfile() As Boolean
        If Not _loadedlib Then Return False
        If Not xVar_Lib_Dirty Then Return True
        If My.Computer.FileSystem.FileExists(k3_lib_path) Then
            Try
                Dim rw As New IO.StreamWriter(k3_lib_path, False)
                For i = 0 To K3LibraryView.lb_Library.Items.Count - 1
                    Select Case K3LibraryView.lb_Library.Items(i).ImageIndex
                        Case 2
                            rw.Write(SETF_DIR)
                        Case 1, 0
                            rw.Write(SETF_FILE)

                        Case Else
                            rw.Write("?")
                    End Select
                    rw.WriteLine(K3LibraryView.lb_Library.Items(i).Tag.ToString)
                Next
                rw.Dispose()
                rw.Close()
                xVar_Lib_Dirty = False
            Catch ex As Exception
                Return False
            End Try
            Return True
        Else
            Return False
        End If
    End Function

    Friend Sub ShowMsg(ByVal msg As String)
        If msg_timer.Enabled Then msg_timer.Stop()
        vis_l_main.Text = msg
        msg_timer.Start()

    End Sub
    Private Sub msg_timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msg_timer.Tick
        Update_VIS_TEXT()
        msg_timer.Stop()
    End Sub

    Friend Sub RefDevs()
        k3SettingPage.ls_dev.Items.Clear()
        Dim getinfo As BASS_DEVICEINFO() = Bass.BASS_GetDeviceInfos
        Dim atinit As Integer = -1
        Dim ins As String = "Found " + getinfo.Length.ToString + " devices" + nl
        For i = 0 To getinfo.Length - 1
            '    ins += "[" + i.ToString + "]  " + getinfo(i).name + nl '+ tabc + getinfo(i).type.ToString + nl
            k3SettingPage.ls_dev.Items.Add(getinfo(i).name)
            If getinfo(i).IsInitialized Then atinit = i
        Next
        'Dim sp As String = InputBox(ins, "Select new device", "-1")
        'Dim rd As Integer
        If atinit >= 0 Then
            k3SettingPage.ls_dev.SelectedIndices.Add(atinit)
        End If
        '   k3SettingPage.Label2.Text = k3SettingPage.Label2.Tag.ToString + " [" + getinfo.Length.ToString + "]"
        k3SettingPage.ci_dev = atinit

    End Sub
    Friend Sub reini_click(ByVal rdev As Integer)
        t_shortcut_ReInit(rdev)
        RefDevs()
    End Sub

    Private Function IsOutOfBounds() As Boolean
        Dim res As Rectangle = Rectangle.Intersect(My.Computer.Screen.Bounds, New Rectangle(Me.Location, Me.Size))
        Return res.IsEmpty
    End Function
    Friend Function GetMediaInfoStr() As String
        Dim res As String = "Media Information" + nl
        res += "=====================================" + nl
        res += "Current Track" + tabc + (CiTrack + 1).ToString + " of " + K3PlaylistView.lb_pl.Items.Count.ToString + nl
        ' If mp_URL.Contains("\") Then MsgBox("OK") mp_URL.Substring( mp_URL.LastIndexOf("\") ).Remove(0, 1)
        '   res += "Current Label" + tabc + mp_TITLE + nl
        'res += "Current Label" + tabc + IIf(mp_URL.Contains("\"), (mp_URL.Substring(mp_URL.LastIndexOf("\")).Remove(0, 1)), mp_URL) + nl
        Dim _time_sec As Integer = Convert.ToInt32(Bass.BASS_ChannelBytes2Seconds(mp_HANDLE, mp_LEN))
        Dim minu, secu As Integer
        minu = Math.DivRem(_time_sec, 60, secu)
        res += "Duration" + tabc + tabc + minu.ToString + ":" + secu.ToString + nl
        res += "=====================================" + nl
        If mp_TAG_EXIST Then
            'res += "Tags" + nl
            'res += "=====================================" + nl
            res += "Title" + tabc + tabc + mp_TAG.title + nl
            res += "Artist" + tabc + tabc + mp_TAG.artist + nl
            res += "Album" + tabc + tabc + mp_TAG.album + nl
            res += "Year" + tabc + tabc + mp_TAG.year + nl
            res += "=====================================" + nl
            res += "Track        " + tabc + mp_TAG.track + nl
            res += "Genre        " + tabc + mp_TAG.genre + nl
            res += "Album-Artists" + tabc + mp_TAG.albumartist + nl
            res += "Composer     " + tabc + mp_TAG.composer + nl
            res += "Producer     " + tabc + mp_TAG.producer + nl
            res += "Publisher    " + tabc + mp_TAG.publisher + nl
            res += "Encoded by   " + tabc + mp_TAG.encodedby + nl
            res += "Bit-rate     " + tabc + mp_TAG.bitrate.ToString + nl
            res += "Duration     " + tabc + Math.Round(mp_TAG.duration, 0).ToString + " seconds" + nl
            ' res += "File-Name    " + tabc + mp_TAG.filename + nl
            res += "Comments     " + tabc + mp_TAG.comment + nl
            res += "=====================================" + nl
            'res += "=====================================" + nl
            'res += "Conductor" + tabc + mp_TAG.conductor + nl
            'res += "Disc" + tabc + mp_TAG.disc + nl
            ' res += "Lyricist" + tabc + mp_TAG.lyricist + nl
            '  res += "Mood" + tabc + mp_TAG.mood + nl
            ' res += "Rating" + tabc + mp_TAG.rating + nl
            ' res += "Remixer" + tabc + mp_TAG.remixer + nl
            '    Else
            'res += " No Tags Exsist" + nl

        End If
        res += nl + "File-Name" + nl + mp_URL
        '   Un4seen.Bass.BASSActive.i
        'res += "File Extension Wildcards in Directory Scan" + nl + xS_ArraytoCSVString(ini_7_FILE_TYPES) + nl + nl
        Return res
    End Function
    Public ReadOnly Property pvt_GetState As Media_MPstate
        Get
            Return mp_STATE
        End Get
    End Property
    Public ReadOnly Property pvt_GetURL As String
        Get
            Return mp_URL
        End Get
    End Property


    Friend Sub pvt_setVis_picImage(ByVal img As Image)
        If IsNothing(img) Then
            vis_pic.Image = vis_pic.InitialImage
            vis_pic.Tag = True
            '  xvar_tempimg = Nothing
        Else
            '  xvar_tempimg = img
            vis_pic.Image = img
            vis_pic.Tag = False

        End If
        pvt_SetPICSIZE()
    End Sub
    Private Sub pvt_SetPICSIZE()
        If vis_pic.Image.Height < vis_pic.Height And vis_pic.Image.Width < vis_pic.Width Then
            vis_pic.SizeMode = PictureBoxSizeMode.CenterImage
        Else
            vis_pic.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub
    Private Sub vis_pic_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles vis_pic.Resize
        Select Case vis_pic.Dock
            Case DockStyle.Left, DockStyle.Right
                vis_pic.Width = vis_pic.Height
            Case DockStyle.Bottom, DockStyle.Top
                vis_pic.Height = vis_pic.Width
        End Select

        'Update_VIS_TEXT()
        If IsNothing(vis_pic.Image) Then Exit Sub
        pvt_SetPICSIZE()
    End Sub
    Private Sub vis_pic_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vis_pic.SizeChanged
        ShowMsg("Resizing...")
    End Sub
    Friend Sub Update_VIS_TEXT()
        If ini_16_HIDE_LABEL Then
            vis_l_main.Text = ""
        Else
            If mp_HANDLE = 0 Then
                vis_l_main.Text = const_label_reset_text

            Else
                vis_l_main.Text = mp_TITLE ' mp_URL.Substring(mp_URL.LastIndexOf("\")).Remove(0, 1)
            End If
        End If

    End Sub



    Friend xsproxy As New K3proxyprop()
    Public Class K3proxyprop
        ' <Category(""), Description("")> _
        Public Sub New()
        End Sub

#Region "Apprearance c"

        <Category("Appearance"), Description("ForeColor for the Media Label and BackColor for the Seekbar")> _
        Public Property Color_Fore As Color
            Get
                Return k3main.ini_13_FGCOL
            End Get
            Set(ByVal value As Color)
                k3main.ini_13_FGCOL = value
                k3main.vis_l_main.ForeColor = value
                k3main.vis_seek.BackColor = value
            End Set
        End Property

        <Category("Appearance"), Description("BackColor for the Media Label and ForeColor for the Seekbar")> _
        Public Property Color_Back As Color
            Get
                Return k3main.ini_12_BGCOL
            End Get
            Set(ByVal value As Color)
                k3main.ini_12_BGCOL = value
                k3main.vis_l_main.BackColor = value
                k3main.vis_seek.ForeColor = value
                If k3main.ini_35_ART_BG_MATCH Then
                    k3main.vis_pic.BackColor = k3main.vis_l_main.BackColor
                Else
                    k3main.vis_pic.BackColor = k3main.ini_34_ART_BG
                End If
            End Set
        End Property

        <Category("Appearance"), Description("This color will appear transparent on the UI")> _
        Public Property Color_Transparent As Color
            Get
                Return k3main.TransparencyKey
            End Get
            Set(ByVal value As Color)
                k3main.TransparencyKey = value
                k3main.ini_18_TRANS_KEY = k3main.pvt_Color2rgbcsv(value)
            End Set
        End Property

        <Category("Appearance"), Description("Hide the Media Label")> _
        Public Property Label_Hide() As Boolean
            Get
                Return k3main.ini_16_HIDE_LABEL
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_16_HIDE_LABEL = value
                If k3main.ini_16_HIDE_LABEL Then
                    k3main.ShowMsg("Hidden Labels")
                Else
                    k3main.Update_VIS_TEXT()
                End If
            End Set
        End Property
        '  Dim _validAlign As Integer() = {1, 2, 4, 16, 32, 64, 256, 512, 1024}
        <Category("Appearance"), Description("Text alignment for Media Label")> _
        Public Property Label_Alignment As System.Drawing.ContentAlignment
            Get
                Return k3main.ini_39_LABEL_ALIGN
            End Get
            Set(ByVal value As System.Drawing.ContentAlignment)
                '  If _validAlign.Contains(value) Then
                k3main.vis_l_main.TextAlign = value
                k3main.ini_39_LABEL_ALIGN = value
                '  End If

            End Set
        End Property

        <Category("Appearance"), Description("Font Style for Media Label")> _
        Public Property Label_Font As Font
            Get
                Return k3main.ini_8_FONT
            End Get
            Set(ByVal value As Font)
                Try
                    k3main.vis_l_main.Font = value
                    k3main.ini_8_FONT = k3main.vis_l_main.Font
                Catch ex As Exception
                    MsgBox(ex.Message, vbExclamation)
                End Try
            End Set
        End Property
        <Category("Appearance"), Description("Show Multi-line Media Label")> _
        Public Property Label_Multiline As Boolean
            Get
                Return k3main.ini_40_MULTILINE_LABEL
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_40_MULTILINE_LABEL = value
                k3main.pvt_UpdateTitle()
                k3main.Update_VIS_TEXT()
            End Set
        End Property

        <Category("Appearance"), Description("Hide the SeekBar")> _
        Public Property SeekBar_Hide As Boolean
            Get
                Return k3main.ini_1_HIDE_SEEK
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_1_HIDE_SEEK = value
                k3main.vis_seek.Visible = Not value
                k3main.ShowMsg("Hide Seekbar is " + value.ToString)
            End Set
        End Property

        <Category("Appearance"), Description("Dock Style for SeekBar")> _
        Public Property SeekBar_Dock As DockStyle
            Get
                Return k3main.ini_25_DOCK_SEEK
            End Get
            Set(ByVal value As DockStyle)
                'Dim prevdock As DockStyle = k3main.ini_25_DOCK_SEEK
                'Dim doswp As Boolean = False
                Select Case value
                    Case DockStyle.Fill, DockStyle.None, DockStyle.Left, DockStyle.Right
                        MsgBox("Seek bar can be docked Top or Bottom only", vbExclamation)
                        Exit Property
                        'Case DockStyle.Top, DockStyle.Bottom
                End Select
                k3main.vis_seek.Dock = value
                k3main.ini_25_DOCK_SEEK = value
                k3main.ShowMsg("Dock Seek" + k3main.ini_25_DOCK_SEEK.ToString)

            End Set
        End Property

        <Category("Appearance"), Description("UI Opacity value between 0.0 to 1.0")> _
        Public Property Form_Opacity As Double
            Get
                Return k3main.ini_5_OPACITY
            End Get
            Set(ByVal value As Double)
                If value > 1 Then
                    value = 1
                ElseIf value < 0 Then
                    value = 0
                End If
                k3main.Opacity = value
                k3main.ini_5_OPACITY = value
            End Set
        End Property

        <Category("Appearance"), Description("On Screen Location of TopLeft Corner of the UI")> _
        Public Property Form_Location As Point
            Get
                Return k3main.ini_10_LOC
            End Get
            Set(ByVal value As Point)
                k3main.Location = value
                k3main.ini_10_LOC = value
            End Set
        End Property

        <Category("Appearance"), Description("Size of the UI")> _
        Public Property Form_Size As Size
            Get
                Return k3main.ini_9_SIZE
            End Get
            Set(ByVal value As Size)
                k3main.Size = value
                k3main.ini_9_SIZE = value
            End Set
        End Property

        <Category("Appearance"), Description("View Style of Library. {Details} and {LargeIcon} is Not Valid selection value")> _
        Public Property Library_View_Style() As View
            Get
                Return k3main.ini_4_LIB_GROUP
            End Get
            Set(ByVal value As View)
                Select Case value

                    Case View.Details, View.LargeIcon
                        '  MsgBox("Details and LargeIcon is Not Valid selection value", vbExclamation)
                    Case Else
                        k3main.ini_4_LIB_GROUP = value
                        K3LibraryView.lb_Library.View = value
                End Select
            End Set
        End Property

        <Category("Appearance"), Description("Font Style for Libray View")> _
        Public Property Libray_Font As Font
            Get
                Return k3main.ini_26_LIB_FONT
            End Get
            Set(ByVal value As Font)
                Try
                    K3LibraryView.lb_Library.Font = value
                    K3LibraryView.preview_list.Font = value
                    K3LibraryView.lab_preview.Font = value
                    k3main.ini_26_LIB_FONT = K3LibraryView.lb_Library.Font
                Catch ex As Exception
                    MsgBox(ex.Message, vbExclamation)
                End Try
            End Set
        End Property

        <Category("Appearance"), Description("On Screen Location of TopLeft Corner of the Library UI")> _
        Public Property Library_Location As Point
            Get
                Return k3main.ini_28_LIB_LOC
            End Get
            Set(ByVal value As Point)
                K3LibraryView.Location = value
                k3main.ini_28_LIB_LOC = value
            End Set
        End Property

        <Category("Appearance"), Description("Size of the Library UI")> _
        Public Property Library_Size As Size
            Get
                Return k3main.ini_29_LIB_SIZE
            End Get
            Set(ByVal value As Size)
                K3LibraryView.Size = value
                k3main.ini_29_LIB_SIZE = value
            End Set
        End Property

        <Category("Appearance"), Description("Width of the item viewer and editor on the Library")> _
        Public Property Library_Preview_Width As Integer
            Get
                Return k3main.ini_36_PREVIEW_WID
            End Get
            Set(ByVal value As Integer)
                K3LibraryView.Panel_preview.Width = value
                k3main.ini_36_PREVIEW_WID = value
            End Set
        End Property

        <Category("Appearance"), Description("Font Style for the Playlist")> _
        Public Property Playlist_Font As Font
            Get
                Return k3main.ini_27_PL_FONT
            End Get
            Set(ByVal value As Font)
                Try
                    k3main.ini_27_PL_FONT = value
                    K3PlaylistView.lb_pl.Font = k3main.ini_27_PL_FONT
                Catch ex As Exception
                    MsgBox(ex.Message, vbExclamation)
                End Try
            End Set
        End Property

        <Category("Appearance"), Description("On Screen Location of TopLeft Corner of the Playlist UI")> _
        Public Property Playlist_Location As Point
            Get
                Return k3main.ini_30_PL_LOC
            End Get
            Set(ByVal value As Point)
                K3PlaylistView.Location = value
                k3main.ini_30_PL_LOC = value
            End Set
        End Property

        <Category("Appearance"), Description("Size of the Playlist UI")> _
        Public Property Playlist_Size As Size
            Get
                Return k3main.ini_31_PL_SIZE
            End Get
            Set(ByVal value As Size)
                K3PlaylistView.Size = value
                k3main.ini_31_PL_SIZE = value
            End Set
        End Property

        <Category("Appearance"), Description("Coloumn Width of the Playlist UI")> _
        Public Property Playlist_Col_Width As Integer
            Get
                Return k3main.ini_32_PL_COLWID
            End Get
            Set(ByVal value As Integer)
                K3PlaylistView.lb_pl.ColumnWidth = value
                k3main.ini_32_PL_COLWID = value
            End Set
        End Property

        <Category("Appearance"), Description("Display Playlists in (Black and White) OR (match color with UI)")> _
        Public Property Playlist_BnW() As Boolean
            Get
                Return k3main.ini_33_PL_BW
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_33_PL_BW = value
                If k3main.ini_33_PL_BW Then
                    K3PlaylistView.lb_pl.BackColor = Color.Black
                    K3PlaylistView.lb_pl.ForeColor = Color.White
                Else
                    K3PlaylistView.lb_pl.BackColor = k3main.vis_l_main.BackColor
                    K3PlaylistView.lb_pl.ForeColor = k3main.vis_l_main.ForeColor
                End If
                k3main.ShowMsg("B&W Playlist is " + value.ToString)
            End Set
        End Property

        <Category("Appearance"), Description("Opacity of Library and Playlists withing 0.0 to 1.0")> _
        Public Property Dialog_Opacity() As Double
            Get
                Return k3main.ini_11_DOPACITY
            End Get
            Set(ByVal value As Double)
                If value > 1 Then
                    value = 1
                ElseIf value < 0 Then
                    value = 0
                End If
                k3main.ini_11_DOPACITY = value
                K3LibraryView.Opacity = value
                K3PlaylistView.Opacity = value
                'k3main.ShowMsg("D " + value.ToString)
            End Set
        End Property

        <Category("Appearance"), Description("Hides Kookie3 in the Windows TaskBar")> _
        Public Property Hide_in_TaskBar() As Boolean
            Get
                Return k3main.ini_19_HIDE_TASK
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_19_HIDE_TASK = value
                k3main._applySHOWINTASK(Not value)
                k3main.ShowMsg("Hide in Taskbar is " + value.ToString)
            End Set
        End Property

        <Category("Appearance"), Description("Sets Kookie3 as the Top-Most Window")> _
        Public Property Always_On_Top() As Boolean
            Get
                Return k3main.ini_23_ON_TOP
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_23_ON_TOP = value
                k3main._applyTOPMost(value)
                k3main.ShowMsg("Always On Top is " + value.ToString)
            End Set
        End Property




#End Region

#Region "art C"

        <Category("Art"), Description("Shows the Album-Art if available")> _
        Public Property Art_Show() As Boolean
            Get
                Return k3main.ini_20_SHOW_ART
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_20_SHOW_ART = value
                k3main.vis_pic.Visible = value
                If value Then
                    k3main.ShowMsg("Show Album Art")
                Else
                    k3main.ShowMsg("Hide Album Art")
                End If
            End Set
        End Property

        <Category("Art"), Description("Dock Style for the Album-Art")> _
        Public Property Art_Dock As DockStyle
            Get
                Return k3main.ini_21_DOCK_ART
            End Get
            Set(ByVal value As DockStyle)
                Dim prevdock As DockStyle = k3main.ini_21_DOCK_ART
                Dim doswp As Boolean = False
                Select Case value
                    Case DockStyle.Fill, DockStyle.None
                        MsgBox("Art can be docked Top, Bottom, Left or Right only", vbExclamation)
                        Exit Property
                    Case DockStyle.Left, DockStyle.Right
                        If prevdock < 3 Then doswp = True
                    Case DockStyle.Top, DockStyle.Bottom
                        If prevdock > 2 Then doswp = True
                End Select
                If doswp Then
                    Dim swp As New Size(k3main.Height, k3main.Width)
                    k3main.Size = swp
                End If
                k3main.vis_pic.Dock = value
                k3main.ini_21_DOCK_ART = value
                k3main.ShowMsg("Dock " + k3main.ini_21_DOCK_ART.ToString)

            End Set
        End Property

        <Category("Art"), Description("Default Art to show when Album-Art is unavailable")> _
        Public Property Art_Default() As String
            Get
                Return k3main.ini_22_CUSTOM_ART
            End Get
            Set(ByVal value As String)
                k3main.ini_22_CUSTOM_ART = value
                Try
                    k3main.vis_pic.InitialImage = Image.FromFile(value)
                Catch ex As Exception
                End Try
                If k3main.vis_pic.Tag Then k3main.pvt_setVis_picImage(Nothing)
            End Set
        End Property

        <Category("Art"), Description("Never display the Album-Art")> _
        Public Property Art_Always_Show_Default() As Boolean
            Get
                Return k3main.ini_24_ALWAYS_CART
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_24_ALWAYS_CART = value
                If value Then
                    k3main.pvt_setVis_picImage(Nothing)
                Else
                    k3main.pvt_setVis_picImage(k3main.xvar_tempimg)
                End If

                k3main.ShowMsg("Custom Art is " + value.ToString)

            End Set
        End Property

        <Category("Art"), Description("BackColor for the Art box")> _
        Public Property Art_ColorBG() As Color
            Get
                Return k3main.ini_34_ART_BG
            End Get
            Set(ByVal value As Color)
                k3main.ini_34_ART_BG = value
                If Not k3main.ini_35_ART_BG_MATCH Then
                    k3main.vis_pic.BackColor = value
                End If
            End Set
        End Property

        <Category("Art"), Description("Matches the color of Art box and Labels (overrides Art_ColorBG)")> _
        Public Property Art_MatchBG() As Boolean
            Get
                Return k3main.ini_35_ART_BG_MATCH
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_35_ART_BG_MATCH = value
                If value Then
                    k3main.vis_pic.BackColor = k3main.vis_l_main.BackColor
                    'k3main.ini_34_ART_BG = k3main.ini_12_BGCOL
                Else
                    k3main.vis_pic.BackColor = k3main.ini_34_ART_BG
                End If
            End Set
        End Property

#End Region

#Region "Behaviour C"

        <Category("Behaviour"), Description("Loop single track forever")> _
        Public Property Repeat_Single_Track() As Boolean
            Get
                Return k3main.xVar_LOOP_SINGLE
            End Get
            Set(ByVal value As Boolean)
                k3main.xVar_LOOP_SINGLE = value
                k3main.ShowMsg("Repeat is " + value.ToString)
            End Set
        End Property

        <Category("Behaviour"), Description("Reverse the direction of playing through the current playlist")> _
        Public Property Reversed_Playlist() As Boolean
            Get
                Return k3main.xvar_play_backward
            End Get
            Set(ByVal value As Boolean)
                k3main.xvar_play_backward = value
                k3main.ShowMsg("Playlist Reverse is " + value.ToString)
            End Set
        End Property

        <Category("Behaviour"), Description("Choose where to send the files that are drag-dropped to the UI")> _
        Public Property File_Drop_to_Playlist() As Boolean
            Get
                Return k3main.ini_0_DROP_2PL
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_0_DROP_2PL = value
                k3main.ShowMsg("Drag-Drop :: " + IIf(value, "Playlist", "Library").ToString)
            End Set
        End Property

        <Category("Behaviour"), Description("Enables automatic playing of media when added to Kookie3")> _
        Public Property Auto_Play() As Boolean
            Get
                Return k3main.ini_15_AUTO_PLAY
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_15_AUTO_PLAY = value
                k3main.ShowMsg("Auto-Play is " + value.ToString)
            End Set
        End Property

        <Category("Behaviour"), Description("Enables choosing a random starting media when multiple media are added to Kookie")> _
        Public Property Random_start() As Boolean
            Get
                Return k3main.ini_17_RANDOM_START
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_17_RANDOM_START = value
                k3main.ShowMsg("Random-Play is " + value.ToString)
            End Set
        End Property

        <Category("Behaviour"), Description("Automatically removes those media from current playlist that cannot be played")> _
        Public Property Auto_Remove_Unplayble() As Boolean
            Get
                Return k3main.ini_14_DEL_UNPLAYBLE
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_14_DEL_UNPLAYBLE = value

                k3main.ShowMsg(IIf(value, "Auto Remove Unplayable", "Dont Remove Unplayable"))
            End Set
        End Property

#End Region

#Region "others c"

        <Category("Others"), Description("Enables Hue-Shifting of the BackColor while any media is being played")> _
        Public Property Hue_Shift_Enabled() As Boolean
            Get
                Return k3main.ini_2_HUE_SHIFT
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_2_HUE_SHIFT = value
                k3main.ShowMsg("Hue shifter is " + value.ToString)
            End Set
        End Property

        <Category("Others"), Description("The angle by which to shift the Hue of current BackColor. Values can be negative, but magnitude should be at least 0.5")> _
        Public Property Hue_Shift_Angle As Double
            Get
                Return k3main.ini_3_HUE_SHIFT_DEG
            End Get
            Set(ByVal value As Double)

                Dim uipd As Double = 0
                Try
                    uipd = Convert.ToDouble(value) Mod 360
                    If uipd <> 0 Then
                        If Math.Abs(uipd) >= k3main.hue_minangle Then
                            k3main.ini_3_HUE_SHIFT_DEG = uipd
                        End If
                    End If
                Catch ex As Exception
                End Try
                k3main.ShowMsg("Shift by " + k3main.ini_3_HUE_SHIFT_DEG.ToString + " *")
            End Set
        End Property

        <Category("Others"), Description("Enables Hue-Shifting of the ForeColor while any media is being played")> _
        Public Property Hue_Shift_Fore_Enabled() As Boolean
            Get
                Return k3main.ini_37_HUE_SHIFT_FORE
            End Get
            Set(ByVal value As Boolean)
                k3main.ini_37_HUE_SHIFT_FORE = value
                k3main.ShowMsg("Hue shifter is " + value.ToString)
            End Set
        End Property

        <Category("Others"), Description("The angle by which to shift the Hue of current ForeColor. Values can be negative, but magnitude should be at least 0.5")> _
        Public Property Hue_Shift_Fore_Angle As Double
            Get
                Return k3main.ini_38_HUE_SHIFT_DEG_FORE
            End Get
            Set(ByVal value As Double)

                Dim uipd As Double = 0
                Try
                    uipd = Convert.ToDouble(value) Mod 360
                    If uipd <> 0 Then
                        If Math.Abs(uipd) >= k3main.hue_minangle Then
                            k3main.ini_38_HUE_SHIFT_DEG_FORE = uipd
                        End If
                    End If
                Catch ex As Exception
                End Try
                k3main.ShowMsg("Shift by " + k3main.ini_38_HUE_SHIFT_DEG_FORE.ToString + " *")
            End Set
        End Property

        <Category("Others"), Description("Display this message at the launch of Kookie3")> _
        Public Property Startup_Message() As String
            Get
                Return k3main.ini_6_MSG
            End Get
            Set(ByVal value As String)
                k3main.ini_6_MSG = value
                k3main.ShowMsg(value)
            End Set
        End Property

        <Category("Others"), Description("Select the file extensions to look for when scanning folders or drag-dropped items")> _
        Public Property File_Types As String
            Get
                Return k3main.xS_ArraytoCSVString(k3main.ini_7_FILE_TYPES)
            End Get
            Set(ByVal value As String)
                Try
                    k3main.ini_7_FILE_TYPES = value.Split(k3main.csv)
                Catch ex As Exception
                End Try
            End Set
        End Property


#End Region

#Region "Readonly C"

        <Category("ReadOnly"), Description("Internal Status of Media Player Control")> _
        Public ReadOnly Property Internal_Status As k3main.Media_MPstate
            Get
                Return k3main.pvt_GetState
            End Get
        End Property
        <Category("ReadOnly"), Description("Indicates if load from Library file was succesful or not during the start up. If False, means that you will not be able to access the Library.")> _
        Public ReadOnly Property LibraryLoaded As Boolean
            Get
                Return k3main._loadedlib
            End Get
        End Property
        <Category("ReadOnly"), Description("Indicates if any changes were made to the Library since loast load or save")> _
        Public ReadOnly Property LibraryDirty As Boolean
            Get
                Return k3main.xVar_Lib_Dirty
            End Get
        End Property
        <Category("ReadOnly"), Description("Application Directory")> _
        Public ReadOnly Property App_Location As String
            Get
                Return My.Application.Info.DirectoryPath
            End Get
        End Property
        <Category("ReadOnly"), Description("Location of Current Library file")> _
        Public ReadOnly Property Library_File As String
            Get
                Return k3main.k3_lib_path
            End Get
        End Property
        <Category("ReadOnly"), Description("Location of Current Configuration file")> _
        Public ReadOnly Property Config_File As String
            Get
                Return k3main.K3_ini_setting.FilePath
            End Get
        End Property


#End Region

    End Class

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        ConfigurationToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub vis_l_main_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vis_l_main.Click

    End Sub
End Class

