<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MultiPumpPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl1 esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSwitchTag = New System.Windows.Forms.Label()
        Me.lblPumpTag = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblSwitchTag
        '
        Me.lblSwitchTag.Location = New System.Drawing.Point(3, 81)
        Me.lblSwitchTag.Name = "lblSwitchTag"
        Me.lblSwitchTag.Size = New System.Drawing.Size(58, 18)
        Me.lblSwitchTag.TabIndex = 1
        Me.lblSwitchTag.Text = "Label1"
        Me.lblSwitchTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPumpTag
        '
        Me.lblPumpTag.Location = New System.Drawing.Point(89, 81)
        Me.lblPumpTag.Name = "lblPumpTag"
        Me.lblPumpTag.Size = New System.Drawing.Size(58, 18)
        Me.lblPumpTag.TabIndex = 2
        Me.lblPumpTag.Text = "Label1"
        Me.lblPumpTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MultiPumpPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblPumpTag)
        Me.Controls.Add(Me.lblSwitchTag)
        Me.Name = "MultiPumpPanel"
        Me.Size = New System.Drawing.Size(539, 226)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblSwitchTag As Label
    Friend WithEvents lblPumpTag As Label
End Class
