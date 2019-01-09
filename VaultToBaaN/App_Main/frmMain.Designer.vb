<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
    Me.mBar = New System.Windows.Forms.MenuStrip()
    Me.mConfig = New System.Windows.Forms.ToolStripMenuItem()
    Me.mConfigLoad = New System.Windows.Forms.ToolStripMenuItem()
    Me.mConfigSave = New System.Windows.Forms.ToolStripMenuItem()
    Me.MigratedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.StatusFromBaaNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.RELEASEFromTextFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.UpdateAttributesInVaultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.UpdateVaultDBInBaaNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.UpdateAttributeInVaultFromBOMXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.sBar = New System.Windows.Forms.StatusStrip()
    Me.mTab = New System.Windows.Forms.TabControl()
    Me.tabStartStop = New System.Windows.Forms.TabPage()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.qStop = New System.Windows.Forms.Button()
    Me.qStart = New System.Windows.Forms.Button()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.bnmStop = New System.Windows.Forms.Button()
    Me.bnmStart = New System.Windows.Forms.Button()
    Me.bnStop = New System.Windows.Forms.Button()
    Me.bnStart = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.cmdDirect = New System.Windows.Forms.Button()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.lumStop = New System.Windows.Forms.Button()
    Me.lumStart = New System.Windows.Forms.Button()
    Me.luStop = New System.Windows.Forms.Button()
    Me.luStart = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.grpBOM = New System.Windows.Forms.GroupBox()
    Me.cmdBom3 = New System.Windows.Forms.Button()
    Me.cmdBom0 = New System.Windows.Forms.Button()
    Me.cmdBom2 = New System.Windows.Forms.Button()
    Me.cmdBom1 = New System.Windows.Forms.Button()
    Me.xpGrp = New System.Windows.Forms.GroupBox()
    Me.xpmStop = New System.Windows.Forms.Button()
    Me.xpmStart = New System.Windows.Forms.Button()
    Me.xpStop = New System.Windows.Forms.Button()
    Me.xpStart = New System.Windows.Forms.Button()
    Me.jdGrp = New System.Windows.Forms.GroupBox()
    Me.jdmStop = New System.Windows.Forms.Button()
    Me.jdmStart = New System.Windows.Forms.Button()
    Me.jdStop = New System.Windows.Forms.Button()
    Me.jdStart = New System.Windows.Forms.Button()
    Me.tabProgress = New System.Windows.Forms.TabPage()
    Me.pmSplit = New System.Windows.Forms.SplitContainer()
    Me.pmSplit1 = New System.Windows.Forms.SplitContainer()
    Me.tabConfig = New System.Windows.Forms.TabPage()
    Me.GrdConfig = New System.Windows.Forms.DataGridView()
    Me.tabLogs = New System.Windows.Forms.TabPage()
    Me.sLogs = New System.Windows.Forms.SplitContainer()
    Me.jdLogs = New System.Windows.Forms.ListBox()
    Me.cMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.cmClearLog = New System.Windows.Forms.ToolStripMenuItem()
    Me.cmSaveLog = New System.Windows.Forms.ToolStripMenuItem()
    Me.cmFind = New System.Windows.Forms.ToolStripMenuItem()
    Me.spLogs = New System.Windows.Forms.SplitContainer()
    Me.xpLogs = New System.Windows.Forms.ListBox()
    Me.luLogs = New System.Windows.Forms.ListBox()
    Me.JDListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.JdFilesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.sfd = New System.Windows.Forms.SaveFileDialog()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.mBar.SuspendLayout()
    Me.mTab.SuspendLayout()
    Me.tabStartStop.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.grpBOM.SuspendLayout()
    Me.xpGrp.SuspendLayout()
    Me.jdGrp.SuspendLayout()
    Me.tabProgress.SuspendLayout()
    CType(Me.pmSplit, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.pmSplit.Panel2.SuspendLayout()
    Me.pmSplit.SuspendLayout()
    CType(Me.pmSplit1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.pmSplit1.SuspendLayout()
    Me.tabConfig.SuspendLayout()
    CType(Me.GrdConfig, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tabLogs.SuspendLayout()
    CType(Me.sLogs, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.sLogs.Panel1.SuspendLayout()
    Me.sLogs.Panel2.SuspendLayout()
    Me.sLogs.SuspendLayout()
    Me.cMenu.SuspendLayout()
    CType(Me.spLogs, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.spLogs.Panel1.SuspendLayout()
    Me.spLogs.Panel2.SuspendLayout()
    Me.spLogs.SuspendLayout()
    CType(Me.JDListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.JdFilesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'mBar
    '
    Me.mBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mConfig, Me.MigratedToolStripMenuItem})
    Me.mBar.Location = New System.Drawing.Point(0, 0)
    Me.mBar.Name = "mBar"
    Me.mBar.Size = New System.Drawing.Size(861, 24)
    Me.mBar.TabIndex = 0
    Me.mBar.Text = "MenuStrip1"
    '
    'mConfig
    '
    Me.mConfig.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mConfigLoad, Me.mConfigSave})
    Me.mConfig.Name = "mConfig"
    Me.mConfig.Size = New System.Drawing.Size(93, 20)
    Me.mConfig.Text = "Configuration"
    '
    'mConfigLoad
    '
    Me.mConfigLoad.Name = "mConfigLoad"
    Me.mConfigLoad.Size = New System.Drawing.Size(100, 22)
    Me.mConfigLoad.Text = "Load"
    '
    'mConfigSave
    '
    Me.mConfigSave.Name = "mConfigSave"
    Me.mConfigSave.Size = New System.Drawing.Size(100, 22)
    Me.mConfigSave.Text = "Save"
    '
    'MigratedToolStripMenuItem
    '
    Me.MigratedToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusFromBaaNToolStripMenuItem, Me.RELEASEFromTextFileToolStripMenuItem, Me.UpdateAttributesInVaultToolStripMenuItem, Me.UpdateVaultDBInBaaNToolStripMenuItem, Me.UpdateAttributeInVaultFromBOMXMLToolStripMenuItem})
    Me.MigratedToolStripMenuItem.Name = "MigratedToolStripMenuItem"
    Me.MigratedToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
    Me.MigratedToolStripMenuItem.Text = "Migrated"
    '
    'StatusFromBaaNToolStripMenuItem
    '
    Me.StatusFromBaaNToolStripMenuItem.Name = "StatusFromBaaNToolStripMenuItem"
    Me.StatusFromBaaNToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
    Me.StatusFromBaaNToolStripMenuItem.Text = "Status From BaaN"
    '
    'RELEASEFromTextFileToolStripMenuItem
    '
    Me.RELEASEFromTextFileToolStripMenuItem.Name = "RELEASEFromTextFileToolStripMenuItem"
    Me.RELEASEFromTextFileToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
    Me.RELEASEFromTextFileToolStripMenuItem.Text = "RELEASE From Text File"
    '
    'UpdateAttributesInVaultToolStripMenuItem
    '
    Me.UpdateAttributesInVaultToolStripMenuItem.Name = "UpdateAttributesInVaultToolStripMenuItem"
    Me.UpdateAttributesInVaultToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
    Me.UpdateAttributesInVaultToolStripMenuItem.Text = "Update Attributes in Vault From PLM"
    '
    'UpdateVaultDBInBaaNToolStripMenuItem
    '
    Me.UpdateVaultDBInBaaNToolStripMenuItem.Name = "UpdateVaultDBInBaaNToolStripMenuItem"
    Me.UpdateVaultDBInBaaNToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
    Me.UpdateVaultDBInBaaNToolStripMenuItem.Text = "Update VaultDB in BaaN"
    '
    'UpdateAttributeInVaultFromBOMXMLToolStripMenuItem
    '
    Me.UpdateAttributeInVaultFromBOMXMLToolStripMenuItem.Name = "UpdateAttributeInVaultFromBOMXMLToolStripMenuItem"
    Me.UpdateAttributeInVaultFromBOMXMLToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
    Me.UpdateAttributeInVaultFromBOMXMLToolStripMenuItem.Text = "Update Attribute in Vault From BOM XML"
    '
    'sBar
    '
    Me.sBar.Location = New System.Drawing.Point(0, 375)
    Me.sBar.Name = "sBar"
    Me.sBar.Size = New System.Drawing.Size(861, 22)
    Me.sBar.TabIndex = 1
    Me.sBar.Text = "StatusStrip1"
    '
    'mTab
    '
    Me.mTab.Controls.Add(Me.tabStartStop)
    Me.mTab.Controls.Add(Me.tabProgress)
    Me.mTab.Controls.Add(Me.tabConfig)
    Me.mTab.Controls.Add(Me.tabLogs)
    Me.mTab.Dock = System.Windows.Forms.DockStyle.Fill
    Me.mTab.Location = New System.Drawing.Point(0, 24)
    Me.mTab.Name = "mTab"
    Me.mTab.SelectedIndex = 0
    Me.mTab.Size = New System.Drawing.Size(861, 351)
    Me.mTab.TabIndex = 2
    '
    'tabStartStop
    '
    Me.tabStartStop.Controls.Add(Me.Button3)
    Me.tabStartStop.Controls.Add(Me.GroupBox3)
    Me.tabStartStop.Controls.Add(Me.GroupBox2)
    Me.tabStartStop.Controls.Add(Me.Button2)
    Me.tabStartStop.Controls.Add(Me.cmdDirect)
    Me.tabStartStop.Controls.Add(Me.GroupBox1)
    Me.tabStartStop.Controls.Add(Me.Button1)
    Me.tabStartStop.Controls.Add(Me.grpBOM)
    Me.tabStartStop.Controls.Add(Me.xpGrp)
    Me.tabStartStop.Controls.Add(Me.jdGrp)
    Me.tabStartStop.Location = New System.Drawing.Point(4, 22)
    Me.tabStartStop.Name = "tabStartStop"
    Me.tabStartStop.Padding = New System.Windows.Forms.Padding(3)
    Me.tabStartStop.Size = New System.Drawing.Size(853, 325)
    Me.tabStartStop.TabIndex = 1
    Me.tabStartStop.Text = "Start/Stop"
    Me.tabStartStop.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.qStop)
    Me.GroupBox3.Controls.Add(Me.qStart)
    Me.GroupBox3.Location = New System.Drawing.Point(526, 123)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(200, 100)
    Me.GroupBox3.TabIndex = 11
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Queue Watcher"
    '
    'qStop
    '
    Me.qStop.Enabled = False
    Me.qStop.Location = New System.Drawing.Point(97, 28)
    Me.qStop.Name = "qStop"
    Me.qStop.Size = New System.Drawing.Size(75, 23)
    Me.qStop.TabIndex = 7
    Me.qStop.Text = "Stop"
    Me.qStop.UseVisualStyleBackColor = True
    '
    'qStart
    '
    Me.qStart.Location = New System.Drawing.Point(16, 28)
    Me.qStart.Name = "qStart"
    Me.qStart.Size = New System.Drawing.Size(75, 23)
    Me.qStart.TabIndex = 6
    Me.qStart.Text = "Start"
    Me.qStart.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.bnmStop)
    Me.GroupBox2.Controls.Add(Me.bnmStart)
    Me.GroupBox2.Controls.Add(Me.bnStop)
    Me.GroupBox2.Controls.Add(Me.bnStart)
    Me.GroupBox2.Location = New System.Drawing.Point(270, 123)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(200, 100)
    Me.GroupBox2.TabIndex = 10
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "BaaN Upload"
    '
    'bnmStop
    '
    Me.bnmStop.Enabled = False
    Me.bnmStop.Location = New System.Drawing.Point(103, 60)
    Me.bnmStop.Name = "bnmStop"
    Me.bnmStop.Size = New System.Drawing.Size(75, 23)
    Me.bnmStop.TabIndex = 5
    Me.bnmStop.Text = "Stop Monitor"
    Me.bnmStop.UseVisualStyleBackColor = True
    '
    'bnmStart
    '
    Me.bnmStart.Enabled = False
    Me.bnmStart.Location = New System.Drawing.Point(22, 60)
    Me.bnmStart.Name = "bnmStart"
    Me.bnmStart.Size = New System.Drawing.Size(75, 23)
    Me.bnmStart.TabIndex = 4
    Me.bnmStart.Text = "Start Monitor"
    Me.bnmStart.UseVisualStyleBackColor = True
    '
    'bnStop
    '
    Me.bnStop.Enabled = False
    Me.bnStop.Location = New System.Drawing.Point(103, 28)
    Me.bnStop.Name = "bnStop"
    Me.bnStop.Size = New System.Drawing.Size(75, 23)
    Me.bnStop.TabIndex = 1
    Me.bnStop.Text = "Stop"
    Me.bnStop.UseVisualStyleBackColor = True
    '
    'bnStart
    '
    Me.bnStart.Location = New System.Drawing.Point(22, 28)
    Me.bnStart.Name = "bnStart"
    Me.bnStart.Size = New System.Drawing.Size(75, 23)
    Me.bnStart.TabIndex = 0
    Me.bnStart.Text = "Start"
    Me.bnStart.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(690, 296)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(75, 23)
    Me.Button2.TabIndex = 3
    Me.Button2.Text = "Button2"
    Me.Button2.UseVisualStyleBackColor = True
    Me.Button2.Visible = False
    '
    'cmdDirect
    '
    Me.cmdDirect.Location = New System.Drawing.Point(18, 243)
    Me.cmdDirect.Name = "cmdDirect"
    Me.cmdDirect.Size = New System.Drawing.Size(155, 23)
    Me.cmdDirect.TabIndex = 9
    Me.cmdDirect.Text = "Use Direct Property Update"
    Me.cmdDirect.UseVisualStyleBackColor = True
    Me.cmdDirect.Visible = False
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.lumStop)
    Me.GroupBox1.Controls.Add(Me.lumStart)
    Me.GroupBox1.Controls.Add(Me.luStop)
    Me.GroupBox1.Controls.Add(Me.luStart)
    Me.GroupBox1.Location = New System.Drawing.Point(18, 123)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
    Me.GroupBox1.TabIndex = 8
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Lock-Unlock Service"
    '
    'lumStop
    '
    Me.lumStop.Enabled = False
    Me.lumStop.Location = New System.Drawing.Point(103, 60)
    Me.lumStop.Name = "lumStop"
    Me.lumStop.Size = New System.Drawing.Size(75, 23)
    Me.lumStop.TabIndex = 3
    Me.lumStop.Text = "Stop Monitor"
    Me.lumStop.UseVisualStyleBackColor = True
    '
    'lumStart
    '
    Me.lumStart.Enabled = False
    Me.lumStart.Location = New System.Drawing.Point(22, 60)
    Me.lumStart.Name = "lumStart"
    Me.lumStart.Size = New System.Drawing.Size(75, 23)
    Me.lumStart.TabIndex = 2
    Me.lumStart.Text = "Start Monitor"
    Me.lumStart.UseVisualStyleBackColor = True
    '
    'luStop
    '
    Me.luStop.Enabled = False
    Me.luStop.Location = New System.Drawing.Point(103, 27)
    Me.luStop.Name = "luStop"
    Me.luStop.Size = New System.Drawing.Size(75, 23)
    Me.luStop.TabIndex = 1
    Me.luStop.Text = "Stop"
    Me.luStop.UseVisualStyleBackColor = True
    '
    'luStart
    '
    Me.luStart.Location = New System.Drawing.Point(22, 27)
    Me.luStart.Name = "luStart"
    Me.luStart.Size = New System.Drawing.Size(75, 23)
    Me.luStart.TabIndex = 0
    Me.luStart.Text = "Start"
    Me.luStart.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(770, 296)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 7
    Me.Button1.Text = "Button1"
    Me.Button1.UseVisualStyleBackColor = True
    Me.Button1.Visible = False
    '
    'grpBOM
    '
    Me.grpBOM.Controls.Add(Me.cmdBom3)
    Me.grpBOM.Controls.Add(Me.cmdBom0)
    Me.grpBOM.Controls.Add(Me.cmdBom2)
    Me.grpBOM.Controls.Add(Me.cmdBom1)
    Me.grpBOM.Location = New System.Drawing.Point(526, 7)
    Me.grpBOM.Name = "grpBOM"
    Me.grpBOM.Size = New System.Drawing.Size(200, 100)
    Me.grpBOM.TabIndex = 6
    Me.grpBOM.TabStop = False
    Me.grpBOM.Text = "BOM Export EXE"
    Me.grpBOM.Visible = False
    '
    'cmdBom3
    '
    Me.cmdBom3.Location = New System.Drawing.Point(97, 60)
    Me.cmdBom3.Name = "cmdBom3"
    Me.cmdBom3.Size = New System.Drawing.Size(75, 23)
    Me.cmdBom3.TabIndex = 6
    Me.cmdBom3.Text = "BOM3"
    Me.cmdBom3.UseVisualStyleBackColor = True
    '
    'cmdBom0
    '
    Me.cmdBom0.Location = New System.Drawing.Point(16, 28)
    Me.cmdBom0.Name = "cmdBom0"
    Me.cmdBom0.Size = New System.Drawing.Size(75, 23)
    Me.cmdBom0.TabIndex = 3
    Me.cmdBom0.Text = "BOM0"
    Me.cmdBom0.UseVisualStyleBackColor = True
    '
    'cmdBom2
    '
    Me.cmdBom2.Location = New System.Drawing.Point(16, 60)
    Me.cmdBom2.Name = "cmdBom2"
    Me.cmdBom2.Size = New System.Drawing.Size(75, 23)
    Me.cmdBom2.TabIndex = 5
    Me.cmdBom2.Text = "BOM2"
    Me.cmdBom2.UseVisualStyleBackColor = True
    '
    'cmdBom1
    '
    Me.cmdBom1.Location = New System.Drawing.Point(97, 28)
    Me.cmdBom1.Name = "cmdBom1"
    Me.cmdBom1.Size = New System.Drawing.Size(75, 23)
    Me.cmdBom1.TabIndex = 4
    Me.cmdBom1.Text = "BOM1"
    Me.cmdBom1.UseVisualStyleBackColor = True
    '
    'xpGrp
    '
    Me.xpGrp.Controls.Add(Me.xpmStop)
    Me.xpGrp.Controls.Add(Me.xpmStart)
    Me.xpGrp.Controls.Add(Me.xpStop)
    Me.xpGrp.Controls.Add(Me.xpStart)
    Me.xpGrp.Location = New System.Drawing.Point(270, 7)
    Me.xpGrp.Name = "xpGrp"
    Me.xpGrp.Size = New System.Drawing.Size(200, 100)
    Me.xpGrp.TabIndex = 2
    Me.xpGrp.TabStop = False
    Me.xpGrp.Text = "XML Processor"
    '
    'xpmStop
    '
    Me.xpmStop.Enabled = False
    Me.xpmStop.Location = New System.Drawing.Point(103, 60)
    Me.xpmStop.Name = "xpmStop"
    Me.xpmStop.Size = New System.Drawing.Size(75, 23)
    Me.xpmStop.TabIndex = 5
    Me.xpmStop.Text = "Stop Monitor"
    Me.xpmStop.UseVisualStyleBackColor = True
    '
    'xpmStart
    '
    Me.xpmStart.Enabled = False
    Me.xpmStart.Location = New System.Drawing.Point(22, 60)
    Me.xpmStart.Name = "xpmStart"
    Me.xpmStart.Size = New System.Drawing.Size(75, 23)
    Me.xpmStart.TabIndex = 4
    Me.xpmStart.Text = "Start Monitor"
    Me.xpmStart.UseVisualStyleBackColor = True
    '
    'xpStop
    '
    Me.xpStop.Enabled = False
    Me.xpStop.Location = New System.Drawing.Point(103, 28)
    Me.xpStop.Name = "xpStop"
    Me.xpStop.Size = New System.Drawing.Size(75, 23)
    Me.xpStop.TabIndex = 1
    Me.xpStop.Text = "Stop"
    Me.xpStop.UseVisualStyleBackColor = True
    '
    'xpStart
    '
    Me.xpStart.Location = New System.Drawing.Point(22, 28)
    Me.xpStart.Name = "xpStart"
    Me.xpStart.Size = New System.Drawing.Size(75, 23)
    Me.xpStart.TabIndex = 0
    Me.xpStart.Text = "Start"
    Me.xpStart.UseVisualStyleBackColor = True
    '
    'jdGrp
    '
    Me.jdGrp.Controls.Add(Me.jdmStop)
    Me.jdGrp.Controls.Add(Me.jdmStart)
    Me.jdGrp.Controls.Add(Me.jdStop)
    Me.jdGrp.Controls.Add(Me.jdStart)
    Me.jdGrp.Location = New System.Drawing.Point(18, 7)
    Me.jdGrp.Name = "jdGrp"
    Me.jdGrp.Size = New System.Drawing.Size(200, 100)
    Me.jdGrp.TabIndex = 1
    Me.jdGrp.TabStop = False
    Me.jdGrp.Text = "JOB Distributer"
    '
    'jdmStop
    '
    Me.jdmStop.Enabled = False
    Me.jdmStop.Location = New System.Drawing.Point(103, 60)
    Me.jdmStop.Name = "jdmStop"
    Me.jdmStop.Size = New System.Drawing.Size(75, 23)
    Me.jdmStop.TabIndex = 3
    Me.jdmStop.Text = "Stop Monitor"
    Me.jdmStop.UseVisualStyleBackColor = True
    '
    'jdmStart
    '
    Me.jdmStart.Enabled = False
    Me.jdmStart.Location = New System.Drawing.Point(22, 60)
    Me.jdmStart.Name = "jdmStart"
    Me.jdmStart.Size = New System.Drawing.Size(75, 23)
    Me.jdmStart.TabIndex = 2
    Me.jdmStart.Text = "Start Monitor"
    Me.jdmStart.UseVisualStyleBackColor = True
    '
    'jdStop
    '
    Me.jdStop.Enabled = False
    Me.jdStop.Location = New System.Drawing.Point(103, 27)
    Me.jdStop.Name = "jdStop"
    Me.jdStop.Size = New System.Drawing.Size(75, 23)
    Me.jdStop.TabIndex = 1
    Me.jdStop.Text = "Stop"
    Me.jdStop.UseVisualStyleBackColor = True
    '
    'jdStart
    '
    Me.jdStart.Location = New System.Drawing.Point(22, 27)
    Me.jdStart.Name = "jdStart"
    Me.jdStart.Size = New System.Drawing.Size(75, 23)
    Me.jdStart.TabIndex = 0
    Me.jdStart.Text = "Start"
    Me.jdStart.UseVisualStyleBackColor = True
    '
    'tabProgress
    '
    Me.tabProgress.Controls.Add(Me.pmSplit)
    Me.tabProgress.Location = New System.Drawing.Point(4, 22)
    Me.tabProgress.Name = "tabProgress"
    Me.tabProgress.Padding = New System.Windows.Forms.Padding(3)
    Me.tabProgress.Size = New System.Drawing.Size(853, 325)
    Me.tabProgress.TabIndex = 2
    Me.tabProgress.Text = "Progress Monitor"
    Me.tabProgress.UseVisualStyleBackColor = True
    '
    'pmSplit
    '
    Me.pmSplit.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pmSplit.Location = New System.Drawing.Point(3, 3)
    Me.pmSplit.Name = "pmSplit"
    '
    'pmSplit.Panel2
    '
    Me.pmSplit.Panel2.Controls.Add(Me.pmSplit1)
    Me.pmSplit.Size = New System.Drawing.Size(847, 319)
    Me.pmSplit.SplitterDistance = 277
    Me.pmSplit.TabIndex = 0
    '
    'pmSplit1
    '
    Me.pmSplit1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pmSplit1.Location = New System.Drawing.Point(0, 0)
    Me.pmSplit1.Name = "pmSplit1"
    Me.pmSplit1.Size = New System.Drawing.Size(566, 319)
    Me.pmSplit1.SplitterDistance = 284
    Me.pmSplit1.TabIndex = 0
    '
    'tabConfig
    '
    Me.tabConfig.Controls.Add(Me.GrdConfig)
    Me.tabConfig.Location = New System.Drawing.Point(4, 22)
    Me.tabConfig.Name = "tabConfig"
    Me.tabConfig.Padding = New System.Windows.Forms.Padding(3)
    Me.tabConfig.Size = New System.Drawing.Size(853, 325)
    Me.tabConfig.TabIndex = 0
    Me.tabConfig.Text = "Configuration"
    Me.tabConfig.UseVisualStyleBackColor = True
    '
    'GrdConfig
    '
    Me.GrdConfig.AllowUserToDeleteRows = False
    Me.GrdConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.GrdConfig.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GrdConfig.Location = New System.Drawing.Point(3, 3)
    Me.GrdConfig.Name = "GrdConfig"
    Me.GrdConfig.Size = New System.Drawing.Size(847, 319)
    Me.GrdConfig.TabIndex = 0
    '
    'tabLogs
    '
    Me.tabLogs.Controls.Add(Me.sLogs)
    Me.tabLogs.Location = New System.Drawing.Point(4, 22)
    Me.tabLogs.Name = "tabLogs"
    Me.tabLogs.Size = New System.Drawing.Size(853, 325)
    Me.tabLogs.TabIndex = 3
    Me.tabLogs.Text = "Logs"
    Me.tabLogs.UseVisualStyleBackColor = True
    '
    'sLogs
    '
    Me.sLogs.Dock = System.Windows.Forms.DockStyle.Fill
    Me.sLogs.Location = New System.Drawing.Point(0, 0)
    Me.sLogs.Name = "sLogs"
    '
    'sLogs.Panel1
    '
    Me.sLogs.Panel1.Controls.Add(Me.jdLogs)
    '
    'sLogs.Panel2
    '
    Me.sLogs.Panel2.Controls.Add(Me.spLogs)
    Me.sLogs.Size = New System.Drawing.Size(853, 325)
    Me.sLogs.SplitterDistance = 284
    Me.sLogs.TabIndex = 0
    '
    'jdLogs
    '
    Me.jdLogs.ContextMenuStrip = Me.cMenu
    Me.jdLogs.Dock = System.Windows.Forms.DockStyle.Fill
    Me.jdLogs.FormattingEnabled = True
    Me.jdLogs.Location = New System.Drawing.Point(0, 0)
    Me.jdLogs.Name = "jdLogs"
    Me.jdLogs.Size = New System.Drawing.Size(284, 325)
    Me.jdLogs.TabIndex = 1
    '
    'cMenu
    '
    Me.cMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmClearLog, Me.cmSaveLog, Me.cmFind})
    Me.cMenu.Name = "cMenu"
    Me.cMenu.Size = New System.Drawing.Size(174, 70)
    '
    'cmClearLog
    '
    Me.cmClearLog.Name = "cmClearLog"
    Me.cmClearLog.Size = New System.Drawing.Size(173, 22)
    Me.cmClearLog.Text = "Clear Log"
    '
    'cmSaveLog
    '
    Me.cmSaveLog.Name = "cmSaveLog"
    Me.cmSaveLog.Size = New System.Drawing.Size(173, 22)
    Me.cmSaveLog.Text = "Save Log"
    '
    'cmFind
    '
    Me.cmFind.Name = "cmFind"
    Me.cmFind.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
    Me.cmFind.Size = New System.Drawing.Size(173, 22)
    Me.cmFind.Text = "Find In Log"
    '
    'spLogs
    '
    Me.spLogs.Dock = System.Windows.Forms.DockStyle.Fill
    Me.spLogs.Location = New System.Drawing.Point(0, 0)
    Me.spLogs.Name = "spLogs"
    '
    'spLogs.Panel1
    '
    Me.spLogs.Panel1.Controls.Add(Me.xpLogs)
    '
    'spLogs.Panel2
    '
    Me.spLogs.Panel2.Controls.Add(Me.luLogs)
    Me.spLogs.Size = New System.Drawing.Size(565, 325)
    Me.spLogs.SplitterDistance = 209
    Me.spLogs.TabIndex = 0
    '
    'xpLogs
    '
    Me.xpLogs.ContextMenuStrip = Me.cMenu
    Me.xpLogs.Dock = System.Windows.Forms.DockStyle.Fill
    Me.xpLogs.FormattingEnabled = True
    Me.xpLogs.Location = New System.Drawing.Point(0, 0)
    Me.xpLogs.Name = "xpLogs"
    Me.xpLogs.Size = New System.Drawing.Size(209, 325)
    Me.xpLogs.TabIndex = 1
    '
    'luLogs
    '
    Me.luLogs.ContextMenuStrip = Me.cMenu
    Me.luLogs.Dock = System.Windows.Forms.DockStyle.Fill
    Me.luLogs.FormattingEnabled = True
    Me.luLogs.Location = New System.Drawing.Point(0, 0)
    Me.luLogs.Name = "luLogs"
    Me.luLogs.Size = New System.Drawing.Size(352, 325)
    Me.luLogs.TabIndex = 0
    '
    'JDListBindingSource
    '
    Me.JDListBindingSource.DataSource = GetType(VaultToBaaN.jDList)
    '
    'JdFilesBindingSource
    '
    Me.JdFilesBindingSource.DataMember = "jdFiles"
    Me.JdFilesBindingSource.DataSource = Me.JDListBindingSource
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(291, 261)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(75, 23)
    Me.Button3.TabIndex = 12
    Me.Button3.Text = "Button3"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'frmMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(861, 397)
    Me.Controls.Add(Me.mTab)
    Me.Controls.Add(Me.sBar)
    Me.Controls.Add(Me.mBar)
    Me.MainMenuStrip = Me.mBar
    Me.Name = "frmMain"
    Me.Text = "Vault-BaaN EDI"
    Me.mBar.ResumeLayout(False)
    Me.mBar.PerformLayout()
    Me.mTab.ResumeLayout(False)
    Me.tabStartStop.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.grpBOM.ResumeLayout(False)
    Me.xpGrp.ResumeLayout(False)
    Me.jdGrp.ResumeLayout(False)
    Me.tabProgress.ResumeLayout(False)
    Me.pmSplit.Panel2.ResumeLayout(False)
    CType(Me.pmSplit, System.ComponentModel.ISupportInitialize).EndInit()
    Me.pmSplit.ResumeLayout(False)
    CType(Me.pmSplit1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.pmSplit1.ResumeLayout(False)
    Me.tabConfig.ResumeLayout(False)
    CType(Me.GrdConfig, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tabLogs.ResumeLayout(False)
    Me.sLogs.Panel1.ResumeLayout(False)
    Me.sLogs.Panel2.ResumeLayout(False)
    CType(Me.sLogs, System.ComponentModel.ISupportInitialize).EndInit()
    Me.sLogs.ResumeLayout(False)
    Me.cMenu.ResumeLayout(False)
    Me.spLogs.Panel1.ResumeLayout(False)
    Me.spLogs.Panel2.ResumeLayout(False)
    CType(Me.spLogs, System.ComponentModel.ISupportInitialize).EndInit()
    Me.spLogs.ResumeLayout(False)
    CType(Me.JDListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.JdFilesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents mBar As System.Windows.Forms.MenuStrip
  Friend WithEvents sBar As System.Windows.Forms.StatusStrip
  Friend WithEvents mTab As System.Windows.Forms.TabControl
  Friend WithEvents tabConfig As System.Windows.Forms.TabPage
  Friend WithEvents tabStartStop As System.Windows.Forms.TabPage
  Friend WithEvents mConfig As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mConfigLoad As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mConfigSave As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents GrdConfig As System.Windows.Forms.DataGridView
  Friend WithEvents jdGrp As System.Windows.Forms.GroupBox
  Friend WithEvents jdStart As System.Windows.Forms.Button
  Friend WithEvents jdStop As System.Windows.Forms.Button
  Friend WithEvents xpGrp As System.Windows.Forms.GroupBox
  Friend WithEvents xpStop As System.Windows.Forms.Button
  Friend WithEvents xpStart As System.Windows.Forms.Button
  Friend WithEvents tabProgress As System.Windows.Forms.TabPage
  Friend WithEvents pmSplit As System.Windows.Forms.SplitContainer
  Friend WithEvents jdmStop As System.Windows.Forms.Button
  Friend WithEvents jdmStart As System.Windows.Forms.Button
  Friend WithEvents xpmStop As System.Windows.Forms.Button
  Friend WithEvents xpmStart As System.Windows.Forms.Button
  Friend WithEvents cmdBom2 As System.Windows.Forms.Button
  Friend WithEvents cmdBom1 As System.Windows.Forms.Button
  Friend WithEvents cmdBom0 As System.Windows.Forms.Button
  Friend WithEvents grpBOM As System.Windows.Forms.GroupBox
  Friend WithEvents cmdBom3 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents lumStop As System.Windows.Forms.Button
  Friend WithEvents lumStart As System.Windows.Forms.Button
  Friend WithEvents luStop As System.Windows.Forms.Button
  Friend WithEvents luStart As System.Windows.Forms.Button
  Friend WithEvents MigratedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents StatusFromBaaNToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents RELEASEFromTextFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents UpdateAttributesInVaultToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents UpdateVaultDBInBaaNToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents pmSplit1 As System.Windows.Forms.SplitContainer
  Friend WithEvents tabLogs As System.Windows.Forms.TabPage
  Friend WithEvents sLogs As System.Windows.Forms.SplitContainer
  Friend WithEvents jdLogs As System.Windows.Forms.ListBox
  Friend WithEvents spLogs As System.Windows.Forms.SplitContainer
  Friend WithEvents xpLogs As System.Windows.Forms.ListBox
  Friend WithEvents luLogs As System.Windows.Forms.ListBox
  Friend WithEvents cMenu As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents cmClearLog As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents cmSaveLog As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
  Friend WithEvents cmFind As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents UpdateAttributeInVaultFromBOMXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents JDListBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents JdFilesBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents cmdDirect As System.Windows.Forms.Button
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents bnmStop As System.Windows.Forms.Button
  Friend WithEvents bnmStart As System.Windows.Forms.Button
  Friend WithEvents bnStop As System.Windows.Forms.Button
  Friend WithEvents bnStart As System.Windows.Forms.Button
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents qStop As Button
  Friend WithEvents qStart As Button
  Friend WithEvents Button3 As Button
End Class
