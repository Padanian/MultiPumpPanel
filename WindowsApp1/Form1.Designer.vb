<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MultiPumpPanel1 = New MultiPumpPanel.MultiPumpPanel()
        Me.SuspendLayout()
        '
        'MultiPumpPanel1
        '
        Me.MultiPumpPanel1.hourCounterPump1 = 0
        Me.MultiPumpPanel1.hourCounterPump2 = 0
        Me.MultiPumpPanel1.isSemaphorBlinking = False
        Me.MultiPumpPanel1.isSemaphorVisible = True
        Me.MultiPumpPanel1.lblPumptext = "Mode"
        Me.MultiPumpPanel1.lbltext = "Switch"
        Me.MultiPumpPanel1.Location = New System.Drawing.Point(131, 151)
        Me.MultiPumpPanel1.Name = "MultiPumpPanel1"
        Me.MultiPumpPanel1.pump1Alarm = False
        Me.MultiPumpPanel1.pump1Running = False
        Me.MultiPumpPanel1.pump2Alarm = False
        Me.MultiPumpPanel1.pump2Running = False
        Me.MultiPumpPanel1.semaphorColor = System.Drawing.Color.Black
        Me.MultiPumpPanel1.semaphortext = "Signals"
        Me.MultiPumpPanel1.Size = New System.Drawing.Size(348, 198)
        Me.MultiPumpPanel1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MultiPumpPanel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MultiPumpPanel1 As MultiPumpPanel.MultiPumpPanel
End Class
