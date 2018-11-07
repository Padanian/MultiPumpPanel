﻿Public Class MultiPumpPanel
    Const Pi As Double = Math.PI
    Dim x1, y1, x2, y2, x3, y3 As Integer
    Dim xp1, yp1, xp2, yp2 As Int32
    Private m_lbltext As String = "Text"
    Private m_lblPumptext As String = "Text"
    Private m_semaphortext As String = "Text"
    Private m_selectedPositionOnOffSwitch As Integer
    Private m_selectedPositionPumpSwitch As Integer
    Private m_positionsOnOffSwitch As Integer = 2
    Private m_positionsPumpSwitch As Integer = 3
    Private m_WarningThreshold As Integer = 80
    Private m_semaphorColor As Color = Color.Yellow
    Private m_isSemaphorVisible As Boolean
    Private m_isSemaphorBlinking As Boolean
    Dim centreX As Double = 32
    Dim centreY As Double = 44
    Dim apen As New Pen(Color.LightGray, 1)
    Dim lpen As New Pen(Color.Black, 2)
    Dim angleSwitchOnOff As Double = -3 / 4 * Pi
    Dim angleSwitchPump As Double = -3 / 4 * Pi
    Dim blinkingSemaphorTimer As New Timer
    Dim pbSemaphor As New PictureBox
    Dim lblSemaphorText As New Label
    Dim clickAreaOnOffSwitch As Rectangle = New Rectangle(0, 0, 64, 100)
    Dim clickAreaPumpSwitch As Rectangle = New Rectangle(101, 0, 64, 100)



    Private Sub Me_click(sender As Object, e As EventArgs) Handles Me.Click
        If clickAreaOnOffSwitch.Contains(Me.PointToClient(MousePosition)) Then
            m_selectedPositionOnOffSwitch += 1
            If m_selectedPositionOnOffSwitch > m_positionsOnOffSwitch - 1 Then
                m_selectedPositionOnOffSwitch = 0
                angleSwitchOnOff = -3 / 4 * Pi
                Me.Refresh()
                Exit Sub
            End If
            If m_positionsOnOffSwitch = 2 Then
                angleSwitchOnOff += Pi / 2
            Else
                angleSwitchOnOff += Pi / 4
            End If
        ElseIf clickAreaPumpSwitch.Contains(Me.PointToClient(MousePosition)) Then
            m_selectedPositionPumpSwitch += 1
            If m_selectedPositionPumpSwitch > m_positionsPumpSwitch - 1 Then
                m_selectedPositionPumpSwitch = 0
                angleSwitchPump = -3 / 4 * Pi
                Me.Refresh()
                Exit Sub
            End If
            If m_positionsPumpSwitch = 2 Then
                angleSwitchPump += Pi / 2
            Else
                angleSwitchPump += Pi / 4
            End If
        End If

        Me.Refresh()
    End Sub
    Public Property isSemaphorVisible As Boolean
        Get
            isSemaphorVisible = m_isSemaphorVisible
        End Get
        Set(isSemaphorVisible As Boolean)
            m_isSemaphorVisible = isSemaphorVisible
            If isSemaphorVisible Then
                Me.Height = 200
                pbSemaphor.Visible = True
            Else
                Me.Height = 100
                pbSemaphor.Visible = False
            End If


        End Set
    End Property
    Public Property isSemaphorBlinking As Boolean
        Get
            isSemaphorBlinking = m_isSemaphorBlinking
        End Get
        Set(isSemaphorBlinking As Boolean)
            m_isSemaphorBlinking = isSemaphorBlinking
            Me.Refresh()
        End Set
    End Property
    Public Property semaphorColor As Color
        Get
            semaphorColor = m_semaphorColor
        End Get
        Set(semaphorColor As Color)
            Select Case semaphorColor
                Case Color.Yellow
                    pbSemaphor.Image = My.Resources.led_amber_black
                Case Color.Blue
                    pbSemaphor.Image = My.Resources.led_blue_black
                Case Color.Green
                    pbSemaphor.Image = My.Resources.led_green_black
                Case Color.Red
                    pbSemaphor.Image = My.Resources.led_red_black
                Case Color.Black
                    pbSemaphor.Image = My.Resources.led_off_black
                Case Else
                    pbSemaphor.Image = My.Resources.led_off_black
                    semaphorColor = Color.Yellow
                    m_semaphorColor = Color.Yellow
                    Exit Property
            End Select
            m_semaphorColor = semaphorColor

        End Set
    End Property
    Public ReadOnly Property positions As Integer
        Get
            positions = m_positionsOnOffSwitch
        End Get
    End Property
    Public Property lblPumptext As String
        Get
            lblPumptext = m_lblPumptext
        End Get
        Set(lblPumptext As String)
            If lblPumptext.Length < 10 Then
                m_lblPumptext = lblPumptext
                lblPumpTag.Text = lblPumptext
            End If
            Me.Refresh()
        End Set
    End Property

    Private Sub MultiPumpPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Pump1CalendarStrip As New MultiGenPointCalendarStrip.MultiGenPointCalendarStrip
        With Pump1CalendarStrip
            .Location = New Point(175, 20)
            .Settings(72, 144, 160, 180, 0, 0)
        End With
        Me.Controls.Add(Pump1CalendarStrip)
    End Sub

    Public Property lbltext As String
        Get
            lbltext = m_lbltext
        End Get
        Set(lbltext As String)
            If lbltext.Length < 10 Then
                m_lbltext = lbltext
                lblSwitchTag.Text = lbltext
            End If
            Me.Refresh()
        End Set
    End Property
    Public Property semaphortext As String
        Get
            semaphortext = m_semaphortext
        End Get
        Set(semaphortext As String)
            If semaphortext.Length < 10 Then
                m_semaphortext = semaphortext
                lblSemaphorText.Text = semaphortext
            End If
            Me.Refresh()
        End Set
    End Property
    Public ReadOnly Property selectedPositionOnOffSwitch As Integer
        Get
            selectedPositionOnOffSwitch = m_selectedPositionOnOffSwitch
        End Get
    End Property
    Public ReadOnly Property selectedPositionPumpSwitch As Integer
        Get
            selectedPositionPumpSwitch = m_selectedPositionPumpSwitch
        End Get
    End Property

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        AddHandler blinkingSemaphorTimer.Tick, AddressOf blinkingSemaphor
        With pbSemaphor
            .Location = New Point(6, 142)
            .Size = New Size(52, 52)
            .Name = "pbSemaphor"
            .Visible = False
            .Image = My.Resources.led_amber_black
            .SizeMode = PictureBoxSizeMode.Zoom
        End With
        Me.Controls.Add(pbSemaphor)

        With lblSemaphorText
            .Size = New Size(58, 18)
            .Font = New Font("SegoeUI", 8.25, FontStyle.Regular)
            .Name = "lblSemaphorText"
            .Location = New Point(3, 118)
            .Text = m_semaphortext
            .Visible = False
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        Me.Controls.Add(lblSemaphorText)

    End Sub
    Private Sub GaugePaint(sender As Object, e As PaintEventArgs) Handles Me.Paint

#Region "Switch ON OFF"
        e.Graphics.DrawEllipse(apen, 1, 13, 62, 62)
        e.Graphics.DrawEllipse(lpen, 4, 16, 56, 56)

        Dim m_step As Double
        If m_positionsOnOffSwitch = 2 Then
            m_step = Pi / 2
        Else
            m_step = Pi / 4
        End If

        Dim i As Integer
        For num As Double = -3 / 4 * Pi To -1 / 4 * Pi Step m_step
            x1 = Convert.ToInt32(30 * Math.Cos(num) + centreX)
            y1 = Convert.ToInt32(30 * Math.Sin(num) + centreY)
            x2 = Convert.ToInt32(36 * Math.Cos(num) + centreX)
            y2 = Convert.ToInt32(36 * Math.Sin(num) + centreY)
            x3 = Convert.ToInt32(42 * Math.Cos(num) + centreX)
            y3 = Convert.ToInt32(42 * Math.Sin(num) + centreY)

            e.Graphics.DrawLine(lpen, x1, y1, x2, y2)

            Dim ca As Control() = Me.Controls.Find("tag" & i.ToString, True)
            If ca.Length = 0 Then
                Dim tag As New Label
                With tag
                    .Size = New Size(16, 8)
                    .Font = New Font("SegoeUI", 5, FontStyle.Regular)
                    .Name = "tag" & i.ToString
                End With
                If i = 0 Then
                    tag.Text = "Off"
                ElseIf i = 1 And m_positionsOnOffSwitch = 2 Then
                    tag.Text = "On"
                ElseIf i = 1 And m_positionsOnOffSwitch = 3 Then
                    tag.Text = "Aut"
                ElseIf i = 2 Then
                    tag.Text = "On"
                End If

                If i = 0 Then
                    tag.Location = New Point(x3, y3 - 4)
                ElseIf i = 1 And m_positionsOnOffSwitch = 2 Then
                    tag.Location = New Point(x3 - 8, y3 - 4)
                ElseIf i = 2 And m_positionsOnOffSwitch = 3 Then
                    tag.Location = New Point(x3 - 8, y3 - 4)
                ElseIf i = 1 And m_positionsOnOffSwitch = 3 Then
                    tag.Location = New Point(x3 - 6, y3 - 1)
                End If

                Me.Controls.Add(tag)

            End If

            i += 1
        Next

        e.Graphics.DrawRectangle(apen, 1, 78, 62, 21)

        drawswitch(e, angleSwitchOnOff, 0)
        lblSwitchTag.Text = lbltext


        If isSemaphorVisible And Not isSemaphorBlinking Then
            With blinkingSemaphorTimer
                .Enabled = False
                .Stop()
            End With
            pbSemaphor.Visible = True
            e.Graphics.DrawRectangle(apen, 1, 115, 62, 21)
            lblSemaphorText.Visible = True
            Select Case m_semaphorColor
                Case Color.Yellow
                    pbSemaphor.Image = My.Resources.led_amber_black
                Case Color.Blue
                    pbSemaphor.Image = My.Resources.led_blue_black
                Case Color.Green
                    pbSemaphor.Image = My.Resources.led_green_black
                Case Color.Red
                    pbSemaphor.Image = My.Resources.led_red_black
            End Select

        ElseIf isSemaphorVisible And isSemaphorBlinking Then
            If blinkingSemaphorTimer.Enabled = False Then
                With blinkingSemaphorTimer
                    .Interval = 1000
                    .Enabled = True
                    .Start()
                End With
            End If
            e.Graphics.DrawRectangle(apen, 1, 115, 62, 21)
            lblSemaphorText.Visible = True
        ElseIf Not isSemaphorVisible Then
            With blinkingSemaphorTimer
                .Enabled = False
                .Stop()
            End With
            pbSemaphor.Visible = False
            lblSemaphorText.Visible = False
        End If
#End Region

#Region "Switch 1 auto 2"

        Dim offset As Integer = 86

        e.Graphics.DrawEllipse(apen, 1 + offset, 13, 62, 62)
        e.Graphics.DrawEllipse(lpen, 4 + offset, 16, 56, 56)

        m_step = Pi / 4


        Dim f As Integer
        For num As Double = -3 / 4 * Pi To -1 / 4 * Pi Step m_step
            x1 = Convert.ToInt32(30 * Math.Cos(num) + centreX + offset)
            y1 = Convert.ToInt32(30 * Math.Sin(num) + centreY)
            x2 = Convert.ToInt32(36 * Math.Cos(num) + centreX + offset)
            y2 = Convert.ToInt32(36 * Math.Sin(num) + centreY)
            x3 = Convert.ToInt32(42 * Math.Cos(num) + centreX + offset)
            y3 = Convert.ToInt32(42 * Math.Sin(num) + centreY)

            e.Graphics.DrawLine(lpen, x1, y1, x2, y2)

            Dim ca As Control() = Me.Controls.Find("tbg" & f.ToString, True)
            If ca.Length = 0 Then
                Dim tbg As New Label
                With tbg
                    .Size = New Size(16, 8)
                    .Font = New Font("SegoeUI", 5, FontStyle.Regular)
                    .Name = "tbg" & f.ToString
                End With
                If f = 0 Then
                    tbg.Text = "1"
                ElseIf f = 1 Then
                    tbg.Text = "Aut"
                ElseIf f = 2 Then
                    tbg.Text = "2"
                End If

                If f = 0 Then
                    tbg.Location = New Point(x3, y3 - 4)
                ElseIf f = 1 Then
                    tbg.Location = New Point(x3 - 6, y3 - 1)
                ElseIf f = 2 Then
                    tbg.Location = New Point(x3 - 8, y3 - 4)
                End If

                Me.Controls.Add(tbg)

            End If

            f += 1
        Next

        e.Graphics.DrawRectangle(apen, 1 + offset, 78, 62, 21)

        drawswitch(e, angleSwitchPump, offset)
        lblPumpTag.Text = lblPumptext


#End Region

    End Sub
    Private Sub blinkingSemaphor()

        pbSemaphor.Visible = True
        If m_semaphorColor <> Color.Black Then
            If DateTime.Now.Second Mod 2 = 0 Then
                Select Case m_semaphorColor
                    Case Color.Yellow
                        pbSemaphor.Image = My.Resources.led_amber_black
                    Case Color.Blue
                        pbSemaphor.Image = My.Resources.led_blue_black
                    Case Color.Green
                        pbSemaphor.Image = My.Resources.led_green_black
                    Case Color.Red
                        pbSemaphor.Image = My.Resources.led_red_black
                End Select
            Else
                pbSemaphor.Image = My.Resources.led_off_black
            End If
        End If

    End Sub

    Public Sub drawswitch(e, angle, offset)
        'prima linea
        Dim num As Double = angle - 0.075
        x1 = Convert.ToInt32(22 * Math.Cos(num) + centreX + offset)
        y1 = Convert.ToInt32(22 * Math.Sin(num) + centreY)

        num = angle + 0.075
        x2 = Convert.ToInt32(22 * Math.Cos(num) + centreX + offset)
        y2 = Convert.ToInt32(22 * Math.Sin(num) + centreY)

        Dim startNotchX As Int32 = (x1 + x2) / 2
        Dim startNotchY As Int32 = (y1 + y2) / 2

        num = angle
        Dim endNotchX = Convert.ToInt32(12 * Math.Cos(num) + centreX + offset)
        Dim endNotchY = Convert.ToInt32(12 * Math.Sin(num) + centreY)


        e.Graphics.DrawLine(lpen, x1, y1, x2, y2)
        e.Graphics.DrawLine(lpen, startNotchX, startNotchY, endNotchX, endNotchY)

        'seconda linea
        x1 = x2
        y1 = y2

        num = angle + Pi - 0.075
        x2 = Convert.ToInt32(22 * Math.Cos(num) + centreX + offset)
        y2 = Convert.ToInt32(22 * Math.Sin(num) + centreY)

        e.Graphics.DrawLine(lpen, x1, y1, x2, y2)

        'terza linea
        x1 = x2
        y1 = y2

        num = angle + Pi + 0.075
        x2 = Convert.ToInt32(22 * Math.Cos(num) + centreX + offset)
        y2 = Convert.ToInt32(22 * Math.Sin(num) + centreY)

        e.Graphics.DrawLine(lpen, x1, y1, x2, y2)

        'quarta linea
        x1 = x2
        y1 = y2

        num = angle - 0.075

        x2 = Convert.ToInt32(22 * Math.Cos(num) + centreX + offset)
        y2 = Convert.ToInt32(22 * Math.Sin(num) + centreY)

        e.Graphics.DrawLine(lpen, x1, y1, x2, y2)

    End Sub
End Class
