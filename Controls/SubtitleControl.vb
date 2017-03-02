Imports System.Text.RegularExpressions
Imports System.Globalization

Imports StaxRip.UI
Imports System.ComponentModel

Class SubtitleControl
    Inherits UserControl

    Private BindingSource As New BindingSource
    Friend WithEvents bnSetNames As ButtonEx
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Private Items As New BindingList(Of SubtitleItem)

#Region " Designer "
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If

        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents bnAdd As System.Windows.Forms.Button
    Friend WithEvents bnDown As System.Windows.Forms.Button
    Friend WithEvents bnRemove As System.Windows.Forms.Button
    Friend WithEvents bnUp As System.Windows.Forms.Button
    Friend WithEvents bnBDSup2SubPP As StaxRip.UI.ButtonEx
    Friend WithEvents bnPlay As StaxRip.UI.ButtonEx
    Friend WithEvents dgv As DataGridView
    Private components As System.ComponentModel.IContainer

    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bnAdd = New System.Windows.Forms.Button()
        Me.bnDown = New System.Windows.Forms.Button()
        Me.bnRemove = New System.Windows.Forms.Button()
        Me.bnUp = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.bnSetNames = New StaxRip.UI.ButtonEx()
        Me.bnPlay = New StaxRip.UI.ButtonEx()
        Me.bnBDSup2SubPP = New StaxRip.UI.ButtonEx()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bnAdd
        '
        Me.bnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnAdd.Location = New System.Drawing.Point(6, 0)
        Me.bnAdd.Margin = New System.Windows.Forms.Padding(6, 0, 0, 6)
        Me.bnAdd.Name = "bnAdd"
        Me.bnAdd.Size = New System.Drawing.Size(133, 38)
        Me.bnAdd.TabIndex = 12
        Me.bnAdd.Text = "Add..."
        '
        'bnDown
        '
        Me.bnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnDown.Location = New System.Drawing.Point(6, 132)
        Me.bnDown.Margin = New System.Windows.Forms.Padding(6, 0, 0, 6)
        Me.bnDown.Name = "bnDown"
        Me.bnDown.Size = New System.Drawing.Size(133, 38)
        Me.bnDown.TabIndex = 10
        Me.bnDown.Text = "Down"
        '
        'bnRemove
        '
        Me.bnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnRemove.Location = New System.Drawing.Point(6, 44)
        Me.bnRemove.Margin = New System.Windows.Forms.Padding(6, 0, 0, 6)
        Me.bnRemove.Name = "bnRemove"
        Me.bnRemove.Size = New System.Drawing.Size(133, 38)
        Me.bnRemove.TabIndex = 13
        Me.bnRemove.Text = "Remove"
        '
        'bnUp
        '
        Me.bnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnUp.Location = New System.Drawing.Point(6, 88)
        Me.bnUp.Margin = New System.Windows.Forms.Padding(6, 0, 0, 6)
        Me.bnUp.Name = "bnUp"
        Me.bnUp.Size = New System.Drawing.Size(133, 38)
        Me.bnUp.TabIndex = 11
        Me.bnUp.Text = "Up"
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 28
        Me.dgv.Size = New System.Drawing.Size(400, 348)
        Me.dgv.TabIndex = 17
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.bnAdd)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnRemove)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnUp)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnDown)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnSetNames)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnPlay)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnBDSup2SubPP)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(400, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(139, 308)
        Me.FlowLayoutPanel1.TabIndex = 20
        '
        'bnSetNames
        '
        Me.bnSetNames.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnSetNames.Location = New System.Drawing.Point(6, 176)
        Me.bnSetNames.Margin = New System.Windows.Forms.Padding(6, 0, 0, 6)
        Me.bnSetNames.Size = New System.Drawing.Size(133, 38)
        Me.bnSetNames.Text = "Set Names"
        '
        'bnPlay
        '
        Me.bnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnPlay.Location = New System.Drawing.Point(6, 220)
        Me.bnPlay.Margin = New System.Windows.Forms.Padding(6, 0, 0, 6)
        Me.bnPlay.Size = New System.Drawing.Size(133, 38)
        Me.bnPlay.Text = "Play"
        '
        'bnBDSup2SubPP
        '
        Me.bnBDSup2SubPP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnBDSup2SubPP.Location = New System.Drawing.Point(6, 264)
        Me.bnBDSup2SubPP.Margin = New System.Windows.Forms.Padding(6, 0, 0, 6)
        Me.bnBDSup2SubPP.Size = New System.Drawing.Size(133, 38)
        Me.bnBDSup2SubPP.Text = "BDSup2Sub++"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(1, 2, 1, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(539, 348)
        Me.TableLayoutPanel1.TabIndex = 21
        '
        'SubtitleControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(1, 2, 1, 2)
        Me.Name = "SubtitleControl"
        Me.Size = New System.Drawing.Size(539, 348)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Sub New()
        MyBase.New()
        InitializeComponent()

        Text = "Subtitles"

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.AutoGenerateColumns = False
        dgv.ShowCellToolTips = False
        dgv.AllowUserToResizeRows = False
        dgv.AllowUserToResizeColumns = False
        dgv.RowHeadersVisible = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False

        Dim enabledColumn As New DataGridViewCheckBoxColumn
        enabledColumn.HeaderText = "Enabled"
        enabledColumn.DataPropertyName = "Enabled"
        dgv.Columns.Add(enabledColumn)

        Dim languageColumn As New DataGridViewComboBoxColumn
        languageColumn.HeaderText = "Language"
        languageColumn.Items.AddRange(Language.Languages.ToArray)
        languageColumn.DataPropertyName = "Language"
        dgv.Columns.Add(languageColumn)

        Dim nameColumn As New DataGridViewTextBoxColumn
        nameColumn.HeaderText = "Name"
        nameColumn.DataPropertyName = "Title"
        dgv.Columns.Add(nameColumn)

        Dim defaultColumn As New DataGridViewCheckBoxColumn
        defaultColumn.HeaderText = "Default"
        defaultColumn.DataPropertyName = "Default"
        dgv.Columns.Add(defaultColumn)

        Dim forcedColumn As New DataGridViewCheckBoxColumn
        forcedColumn.HeaderText = "Forced"
        forcedColumn.DataPropertyName = "Forced"
        dgv.Columns.Add(forcedColumn)

        Dim idColumn As New DataGridViewTextBoxColumn
        idColumn.ReadOnly = True
        idColumn.HeaderText = "ID"
        idColumn.DataPropertyName = "ID"
        dgv.Columns.Add(idColumn)

        Dim typeNameColumn As New DataGridViewTextBoxColumn
        typeNameColumn.ReadOnly = True
        typeNameColumn.HeaderText = "Type"
        typeNameColumn.DataPropertyName = "TypeName"
        dgv.Columns.Add(typeNameColumn)

        Dim sizeColumn As New DataGridViewTextBoxColumn
        sizeColumn.ReadOnly = True
        sizeColumn.HeaderText = "Size"
        sizeColumn.DataPropertyName = "Size"
        dgv.Columns.Add(sizeColumn)

        Dim filenameColumn As New DataGridViewTextBoxColumn
        filenameColumn.ReadOnly = True
        filenameColumn.HeaderText = "Filename"
        filenameColumn.DataPropertyName = "Filename"
        dgv.Columns.Add(filenameColumn)

        BindingSource.AllowNew = False
        BindingSource.DataSource = Items
        dgv.DataSource = BindingSource
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        UpdateControls()
    End Sub

    Private Sub bnAdd_Click(sender As Object, e As EventArgs) Handles bnAdd.Click
        Using d As New OpenFileDialog
            d.SetFilter(FileTypes.SubtitleIncludingContainers)
            d.Multiselect = True
            d.SetInitDir(s.LastSourceDir)

            If d.ShowDialog = DialogResult.OK Then
                For Each i In d.FileNames
                    AddSubtitles(Subtitle.Create(i))
                Next

                UpdateControls()
            End If
        End Using
    End Sub

    Private Sub bnRemove_Click(sender As Object, e As EventArgs) Handles bnRemove.Click
        dgv.RemoveSelection
        UpdateControls()
    End Sub

    Private Sub bnUp_Click(sender As Object, e As EventArgs) Handles bnUp.Click
        dgv.MoveSelectionUp
        UpdateControls()
    End Sub

    Private Sub bnDown_Click(sender As Object, e As EventArgs) Handles bnDown.Click
        dgv.MoveSelectionDown
        UpdateControls()
    End Sub

    Private Sub dgv_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles dgv.CellParsing
        If TypeOf dgv.CurrentCell.OwningColumn Is DataGridViewComboBoxColumn Then
            Dim editingControl = DirectCast(dgv.EditingControl, DataGridViewComboBoxEditingControl)
            e.Value = editingControl.SelectedItem
            e.ParsingApplied = True
        End If
    End Sub

    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        UpdateControls()
    End Sub

    Sub SetValues(muxer As Muxer)
        muxer.Subtitles.Clear()

        For Each i In Items
            i.Subtitle.Language = i.Language
            i.Subtitle.Enabled = i.Enabled
            i.Subtitle.Title = i.Title
            i.Subtitle.Forced = i.Forced
            i.Subtitle.Default = i.Default

            If i.Subtitle.Title Is Nothing Then i.Subtitle.Title = ""

            muxer.Subtitles.Add(i.Subtitle)
        Next
    End Sub

    Sub UpdateControls()
        Dim selected = dgv.SelectedRows.Count > 0
        Dim path = If(selected AndAlso dgv.CurrentRow.Index < Items.Count, Items(dgv.CurrentRow.Index).Subtitle.Path, "")
        bnBDSup2SubPP.Enabled = selected AndAlso {"idx", "sup"}.Contains(path.Ext)
        bnPlay.Enabled = FileTypes.SubtitleExludingContainers.Contains(path.Ext) AndAlso p.SourceFile <> ""
        bnUp.Enabled = dgv.CanMoveUp
        bnDown.Enabled = dgv.CanMoveDown
        bnSetNames.Enabled = selected
        bnRemove.Enabled = selected
    End Sub

    Sub AddSubtitles(subtitles As List(Of Subtitle))
        For Each i In subtitles
            If File.Exists(i.Path) Then
                Dim size As String

                If i.Size > 0 Then
                    If i.Size > 1024 ^ 2 Then
                        size = (i.Size / 1024 ^ 2).ToString("f1") & " MB"
                    Else
                        size = (i.Size / 1024).ToString("f1") & " KB"
                    End If
                End If

                Dim _option As String

                If i.Default AndAlso i.Forced Then
                    _option = "default, forced"
                ElseIf i.Default Then
                    _option = "default"
                ElseIf i.Forced Then
                    _option = "forced"
                Else
                    _option = ""
                End If

                Dim id As Integer

                Dim match = Regex.Match(i.Path, " ID(\d+)")

                If match.Success Then
                    id = CInt(match.Groups(1).Value)
                Else
                    id = i.StreamOrder + 1
                End If

                Dim item As New SubtitleItem
                item.Enabled = i.Enabled
                item.Language = i.Language
                item.Title = i.Title
                item.Default = i.Default
                item.Forced = i.Forced
                item.ID = id
                item.TypeName = i.TypeName
                item.Size = size
                item.Filename = Filepath.GetName(i.Path)
                item.Subtitle = i

                Items.Add(item)
            End If
        Next
    End Sub

    Class SubtitleItem
        Property Enabled As Boolean
        Property Language As Language
        Property Title As String
        Property Forced As Boolean
        Property [Default] As Boolean
        Property ID As Integer
        Property TypeName As String
        Property Size As String
        Property Filename As String
        Property Subtitle As Subtitle
    End Class

    Private Sub bnBDSup2SubPP_Click() Handles bnBDSup2SubPP.Click
        Try
            Dim st = Items(dgv.CurrentRow.Index).Subtitle
            Dim fp = st.Path

            If Filepath.GetExtFull(fp) = ".idx" Then
                fp = p.TempDir + Filepath.GetBase(p.TargetFile) + "_Temp.idx"

                Regex.Replace(File.ReadAllText(st.Path), "langidx: \d+", "langidx: " +
                    st.IndexIDX.ToString).WriteANSIFile(fp)

                FileHelp.Copy(Filepath.GetDirAndBase(st.Path) + ".sub", Filepath.GetDirAndBase(fp) + ".sub")
            End If

            g.ShellExecute(Package.BDSup2SubPP.Path, """" + fp + """")
        Catch ex As Exception
            g.ShowException(ex)
        End Try
    End Sub

    Private Sub bnPlay_Click() Handles bnPlay.Click
        If Package.MPC.VerifyOK(True) Then
            Try
                Dim st = Items(dgv.CurrentRow.Index).Subtitle
                Dim fp = st.Path

                Dim avs As New VideoScript
                avs.Engine = p.Script.Engine
                avs.Path = p.TempDir + Filepath.GetBase(p.TargetFile) + "_Play." + avs.FileType
                avs.Filters = p.Script.GetFiltersCopy

                If avs.Engine = ScriptEngine.AviSynth Then
                    If FileTypes.TextSub.Contains(Filepath.GetExt(fp)) Then
                        Dim insertCat = If(avs.IsFilterActive("Crop"), "Crop", "Source")

                        If Filepath.GetExtFull(st.Path) = ".idx" Then
                            fp = p.TempDir + Filepath.GetBase(p.TargetFile) + "_Play.idx"

                            Regex.Replace(File.ReadAllText(st.Path), "langidx: \d+", "langidx: " +
                                st.IndexIDX.ToString).WriteANSIFile(fp)

                            FileHelp.Copy(Filepath.GetDirAndBase(st.Path) + ".sub", Filepath.GetDirAndBase(fp) + ".sub")

                            avs.InsertAfter(insertCat, New VideoFilter("VobSub(""" + fp + """)"))
                        Else
                            avs.InsertAfter(insertCat, New VideoFilter("TextSubMod(""" + fp + """)"))
                        End If
                    End If

                    Dim par = Calc.GetTargetPAR

                    If Not par = New Point(1, 1) Then
                        Dim w = CInt((p.TargetHeight * Calc.GetTargetDAR) / 4) * 4
                        avs.Filters.Add(New VideoFilter("LanczosResize(" & w & "," & p.TargetHeight & ")"))
                    End If

                    Dim ap = p.Audio0

                    If Not File.Exists(ap.File) Then ap = p.Audio1

                    If File.Exists(ap.File) Then
                        avs.Filters.Add(New VideoFilter("KillAudio()"))
                        Dim nic = Audio.GetNicAudioCode(ap)

                        If nic <> "" Then
                            avs.Filters.Add(New VideoFilter(nic))
                        Else
                            avs.Filters.Add(New VideoFilter("AudioDub(last, DirectShowSource(""" + ap.File + """, video = false))"))
                        End If

                        avs.Filters.Add(New VideoFilter("DelayAudio(" & (ap.Delay / 1000).ToString(CultureInfo.InvariantCulture) & ")"))
                    End If
                End If

                avs.Synchronize(True)

                Dim subSwitch As String

                If Not FileTypes.TextSub.Contains(Filepath.GetExt(fp)) AndAlso
                    FileTypes.SubtitleExludingContainers.Contains(Filepath.GetExt(fp)) Then

                    subSwitch = "/sub """ + fp + """"
                End If

                g.Play(avs.Path, subSwitch)
            Catch ex As Exception
                g.ShowException(ex)
            End Try
        End If
    End Sub

    Private Sub bnSetNames_Click(sender As Object, e As EventArgs) Handles bnSetNames.Click
        Using td As New TaskDialog(Of Integer)
            td.MainInstruction = "Set names for all streams."

            td.AddCommandLink("Set language in English", 1)

            If CultureInfo.CurrentCulture.NeutralCulture.TwoLetterISOLanguageName <> "en" Then
                td.AddCommandLink("Set language in " + CultureInfo.CurrentCulture.NeutralCulture.DisplayName, 2)
            End If

            Select Case td.Show
                Case 1
                    For Each i In Items
                        i.Title = i.Language.CultureInfo.EnglishName
                        If i.Forced Then i.Title += " (forced)"
                    Next

                    BindingSource.ResetBindings(False)
                Case 2
                    For Each i In Items
                        i.Title = i.Language.CultureInfo.NeutralCulture.DisplayName
                        If i.Forced Then i.Title += " (forced)"
                    Next

                    BindingSource.ResetBindings(False)
            End Select
        End Using
    End Sub

    Private Sub dgv_MouseUp(sender As Object, e As MouseEventArgs) Handles dgv.MouseUp
        UpdateControls()
    End Sub

    Private Sub bnPlay_Click(sender As Object, e As EventArgs) Handles bnPlay.Click

    End Sub

    Private Sub bnBDSup2SubPP_Click(sender As Object, e As EventArgs) Handles bnBDSup2SubPP.Click

    End Sub
End Class