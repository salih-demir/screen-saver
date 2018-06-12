Imports System.Windows.Ink
Class MainWindow
    Private konum As Point
    Dim a As Integer
    Dim salla As Integer
    Dim x As Integer = 1000
    Private kontrol As Boolean = False
    Sub Tik()
        Randomize()
        salla = (Rnd() * 200) + 1
        Dim pts As New StylusPointCollection()
        pts.Add(New StylusPoint(Rnd() * Me.Width - 1, Rnd() * Me.Height - 1))
        Dim NewStroke As New Stroke(pts)
        Ink.Strokes.Add(NewStroke)
        Ink.Strokes(Ink.Strokes.Count - 1).DrawingAttributes.Height = salla
        Ink.Strokes(Ink.Strokes.Count - 1).DrawingAttributes.Width = salla
        Ink.Strokes(Ink.Strokes.Count - 1).DrawingAttributes.Color = Color.FromArgb(130, Rnd() * 255, Rnd() * 255, Rnd() * 255)
        If Ink.Strokes.Count = 1000 Then
            Sayac1.IsEnabled = False
            Sayac2.IsEnabled = True
        End If
    End Sub
    Sub Tik2()
        x -= 1
        If Ink.Strokes.Count = 1 Then
            Ink.Strokes.Clear()
            Sayac1.IsEnabled = True
            Sayac2.IsEnabled = False
            x = 1000
            Exit Sub
        End If
        Ink.Strokes.RemoveAt(x)
    End Sub
    Private Sub MainWindow_KeyDown(sender As Object, e As System.Windows.Input.KeyEventArgs) Handles Me.KeyDown
        Me.Close()
    End Sub
    Sub mousekontrol()
        If kontrol = False Then
            konum = New Point(Mouse.GetPosition(Me).X, Mouse.GetPosition(Me).Y)
            kontrol = True
        Else
            If Math.Abs(Mouse.GetPosition(Me).X - konum.X) > 5 OrElse Math.Abs(Mouse.GetPosition(Me).Y - konum.Y) > 5 Then
                Me.Close()
            End If
        End If
    End Sub
    Private Sub MainWindow_MouseMove(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles Me.MouseMove
        mousekontrol()
    End Sub
End Class