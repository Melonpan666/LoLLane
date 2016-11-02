<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Button_Counter = New System.Windows.Forms.Button()
        Me.Build = New System.Windows.Forms.Button()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TimerWeb2 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerWeb1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button_Mastery = New System.Windows.Forms.Button()
        Me.Button_Skill = New System.Windows.Forms.Button()
        Me.Button_Rune = New System.Windows.Forms.Button()
        Me.CheckBox_Topmost = New System.Windows.Forms.CheckBox()
        Me.Role_ListBox = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CallPick = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button_ShowPanel = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(12, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Lane Shuffle"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox1.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.SystemColors.Window
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(124, 10)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(145, 27)
        Me.ComboBox1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(12, 45)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 28)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Champ Shuffle"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ComboBox2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBox2.ForeColor = System.Drawing.SystemColors.Window
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(124, 45)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(144, 27)
        Me.ComboBox2.TabIndex = 3
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(417, 136)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(390, 401)
        Me.WebBrowser1.TabIndex = 4
        Me.WebBrowser1.Visible = False
        '
        'Button_Counter
        '
        Me.Button_Counter.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button_Counter.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Counter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Button_Counter.Location = New System.Drawing.Point(717, 107)
        Me.Button_Counter.Name = "Button_Counter"
        Me.Button_Counter.Size = New System.Drawing.Size(90, 28)
        Me.Button_Counter.TabIndex = 5
        Me.Button_Counter.Text = "Counter"
        Me.Button_Counter.UseVisualStyleBackColor = False
        '
        'Build
        '
        Me.Build.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Build.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Build.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Build.Location = New System.Drawing.Point(312, 107)
        Me.Build.Name = "Build"
        Me.Build.Size = New System.Drawing.Size(90, 28)
        Me.Build.TabIndex = 6
        Me.Build.Text = "Build"
        Me.Build.UseVisualStyleBackColor = False
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Location = New System.Drawing.Point(12, 136)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.ScriptErrorsSuppressed = True
        Me.WebBrowser2.Size = New System.Drawing.Size(390, 401)
        Me.WebBrowser2.TabIndex = 7
        Me.WebBrowser2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(2, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(816, 547)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(748, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Ver.β.07"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(739, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Patch 6.21"
        '
        'TimerWeb2
        '
        '
        'TimerWeb1
        '
        '
        'Button_Mastery
        '
        Me.Button_Mastery.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button_Mastery.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Mastery.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Button_Mastery.Location = New System.Drawing.Point(212, 107)
        Me.Button_Mastery.Name = "Button_Mastery"
        Me.Button_Mastery.Size = New System.Drawing.Size(90, 28)
        Me.Button_Mastery.TabIndex = 11
        Me.Button_Mastery.Text = "Mastery"
        Me.Button_Mastery.UseVisualStyleBackColor = False
        '
        'Button_Skill
        '
        Me.Button_Skill.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button_Skill.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Skill.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Button_Skill.Location = New System.Drawing.Point(12, 107)
        Me.Button_Skill.Name = "Button_Skill"
        Me.Button_Skill.Size = New System.Drawing.Size(90, 28)
        Me.Button_Skill.TabIndex = 12
        Me.Button_Skill.Text = "Skill Order"
        Me.Button_Skill.UseVisualStyleBackColor = False
        '
        'Button_Rune
        '
        Me.Button_Rune.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button_Rune.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Rune.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Button_Rune.Location = New System.Drawing.Point(112, 107)
        Me.Button_Rune.Name = "Button_Rune"
        Me.Button_Rune.Size = New System.Drawing.Size(90, 28)
        Me.Button_Rune.TabIndex = 13
        Me.Button_Rune.Text = "Rune"
        Me.Button_Rune.UseVisualStyleBackColor = False
        '
        'CheckBox_Topmost
        '
        Me.CheckBox_Topmost.AutoSize = True
        Me.CheckBox_Topmost.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox_Topmost.ForeColor = System.Drawing.SystemColors.Window
        Me.CheckBox_Topmost.Location = New System.Drawing.Point(732, 56)
        Me.CheckBox_Topmost.Name = "CheckBox_Topmost"
        Me.CheckBox_Topmost.Size = New System.Drawing.Size(75, 16)
        Me.CheckBox_Topmost.TabIndex = 15
        Me.CheckBox_Topmost.Text = "TopMost"
        Me.CheckBox_Topmost.UseVisualStyleBackColor = True
        '
        'Role_ListBox
        '
        Me.Role_ListBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.Role_ListBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Role_ListBox.ForeColor = System.Drawing.SystemColors.Window
        Me.Role_ListBox.FormattingEnabled = True
        Me.Role_ListBox.Location = New System.Drawing.Point(276, 9)
        Me.Role_ListBox.Name = "Role_ListBox"
        Me.Role_ListBox.Size = New System.Drawing.Size(103, 88)
        Me.Role_ListBox.TabIndex = 16
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CallPick)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gold
        Me.GroupBox1.Location = New System.Drawing.Point(388, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(151, 95)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Champion Select"
        '
        'CallPick
        '
        Me.CallPick.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.CallPick.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CallPick.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.CallPick.Location = New System.Drawing.Point(100, 20)
        Me.CallPick.Name = "CallPick"
        Me.CallPick.Size = New System.Drawing.Size(45, 61)
        Me.CallPick.TabIndex = 2
        Me.CallPick.Text = "Call + Pick"
        Me.CallPick.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(7, 53)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 28)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "Pick Champ"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(7, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 28)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Call Lane"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button_ShowPanel
        '
        Me.Button_ShowPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_ShowPanel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_ShowPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.Button_ShowPanel.Location = New System.Drawing.Point(124, 72)
        Me.Button_ShowPanel.Name = "Button_ShowPanel"
        Me.Button_ShowPanel.Size = New System.Drawing.Size(144, 24)
        Me.Button_ShowPanel.TabIndex = 18
        Me.Button_ShowPanel.Text = "Show Panel"
        Me.Button_ShowPanel.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(819, 549)
        Me.Controls.Add(Me.Button_ShowPanel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Role_ListBox)
        Me.Controls.Add(Me.CheckBox_Topmost)
        Me.Controls.Add(Me.Button_Rune)
        Me.Controls.Add(Me.Button_Skill)
        Me.Controls.Add(Me.Button_Mastery)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WebBrowser2)
        Me.Controls.Add(Me.Build)
        Me.Controls.Add(Me.Button_Counter)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "LoLLane"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Button_Counter As Button
    Friend WithEvents Build As Button
    Friend WithEvents WebBrowser2 As WebBrowser
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TimerWeb2 As Timer
    Friend WithEvents TimerWeb1 As Timer
    Friend WithEvents Button_Mastery As Button
    Friend WithEvents Button_Skill As Button
    Friend WithEvents Button_Rune As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents CheckBox_Topmost As CheckBox
    Friend WithEvents Role_ListBox As CheckedListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents CallPick As Button
    Friend WithEvents Button_ShowPanel As Button
End Class
