#Region "Copyright"
'-----------------
'GUI4CBM4WIN
'
' Copyright (C) 2004-2005 Leif Bloomquist
' Copyright (C) 2006      Wolfgang 0.4.0
' Copyright (C) 2006      Spiro Trikaliotis
' Copyright (C) 2006-2007 Payton Byrd
'
' This software Is provided 'as-is', without any express or implied
' warranty. In no event will the authors be held liable for any damages
' arising from the use of this software.
'
' Permission is granted to anyone to use this software for any purpose,
' including commercial applications, and to alter it and redistribute it
' freely, subject to the following restrictions:
'
'     1. The origin of this software must not be misrepresented; you must
'        not claim that you wrote the original software. If you use this
'        software in a product, an acknowledgment in the product
'        documentation would be appreciated but is not required.
'
'     2. Altered source versions must be plainly marked as such, and must
'        not be misrepresented as being the original software.
'
'     3. This notice may not be removed or altered from any source
'        distribution.
'
#End Region

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Waiting
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents LEDTimer As System.Windows.Forms.Timer
    Public WithEvents LED As System.Windows.Forms.Label
    Public WithEvents Label As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Waiting))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LEDTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LED = New System.Windows.Forms.Label
        Me.Label = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LEDTimer
        '
        Me.LEDTimer.Enabled = True
        Me.LEDTimer.Interval = 300
        '
        'LED
        '
        Me.LED.BackColor = System.Drawing.Color.Black
        Me.LED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.LED, "LED")
        Me.LED.Name = "LED"
        '
        'Label
        '
        Me.Label.BackColor = System.Drawing.Color.Transparent
        Me.Label.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label, "Label")
        Me.Label.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label.Name = "Label"
        '
        'Waiting
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ControlBox = False
        Me.Controls.Add(Me.LED)
        Me.Controls.Add(Me.Label)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Waiting"
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class