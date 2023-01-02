Public Class Inequalities
    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point
    Dim m, f
    Public Sub Perf(ByRef f As Size)

    End Sub
    Public Sub New()
        InitializeComponent()

        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.ResizeRedraw, True)

    End Sub

    Private Const cGrip As Integer = 16
    Private Const cCaption As Integer = 32

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = &H84 Then
            Dim pos As Point = New Point(m.LParam.ToInt32())
            pos = Me.PointToClient(pos)

            If pos.Y < cCaption Then
                m.Result = CType(2, IntPtr)
                Return
            End If

            If pos.X >= Me.ClientSize.Width - cGrip AndAlso pos.Y >= Me.ClientSize.Height - cGrip Then
                m.Result = CType(17, IntPtr)
                Return
            End If
        End If



        MyBase.WndProc(m)
    End Sub


    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseDown ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseMove ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseUp ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If

    End Sub
    Private Sub Inequalities_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label6.Text = "Δ = " & (b.Text ^ 2) & "-" & "(" & 4 * (a.Text * c.Text) & ") = "


        delta.Text = (b.Text ^ 2) - 4 * (a.Text * c.Text)
        'ex: a>0 (concordant)
        If (a.Text > 0) Then If (sign.Text = ">") Then info.Text = "x < " & r1.Text & " v x > " & r2.Text
        'ex: +a<0 (discordant)
        If (a.Text > 0) Then If (sign.Text = "<") Then info.Text = r1.Text & "< x <" & r2.Text Else If (delta.Text < 0) Then info.Text = "∀x∈R"
        'ex: -a<0 (concordant)
        If (a.Text < 0) Then If (sign.Text = "<") Then info.Text = "x < " & r1.Text & " v x > " & r2.Text
        'ex: -a>0 (discordant)
        If (a.Text < 0) Then If (sign.Text = ">") Then info.Text = r1.Text & " < x < " & r2.Text Else If (delta.Text < 0) Then info.Text = "∀x∈R"
        If (delta.Text = 0) Then info.Text = "x≠" & r1.Text
        If (info.Text = "NaN< x <NaN") Then
            info.Text = "∄x∈R"
        End If

        n1.Text = b.Text * -1

        dt.Text = delta.Text

        dn.Text = 2 * a.Text

        r1.Text = ((b.Text * -1) - Math.Sqrt(b.Text ^ 2 - 4 * (a.Text * c.Text))) / (2 * a.Text)

        r2.Text = ((b.Text * -1) + Math.Sqrt(b.Text ^ 2 - 4 * (a.Text * c.Text))) / (2 * a.Text)
    End Sub

    Private Sub Closea_Click(sender As Object, e As EventArgs) Handles Closea.Click
        Application.Exit()
    End Sub

    Private Sub Minimizea_Click(sender As Object, e As EventArgs) Handles Minimizea.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub NormalActualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalActualToolStripMenuItem.Click
        Me.Close()
        Normal.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        a.Text = ""
        b.Text = ""
        c.Text = ""
        delta.Text = ""
        n1.Text = "-b"
        dt.Text = "b^2 - 4ac"
        dn.Text = "2a"
        r1.Text = ""
        r2.Text = ""
        Label6.Text = "Δ = b^2 - 4ac = "
        info.Text = ""
        retta.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sign.Text = "<"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        sign.Text = ">"
    End Sub

    Private Sub ScientificToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScientificToolStripMenuItem.Click
        Me.Close()
        Scientific.Show()
    End Sub
End Class