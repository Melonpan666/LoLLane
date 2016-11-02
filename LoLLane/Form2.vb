Public Class Form2
    ' アイコンサイズ
    Protected Friend Const ICON_SIZE As Integer = 30

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        makeThumbnail()
        ' サイズ固定
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub

    ' ListBoxのDrawItemイベントのハンドラ
    Private Sub ListBox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox1.DrawItem
        If e.Index = -1 Then ' 項目がない場合にも呼び出される
            Return
        End If

        e.DrawBackground()

        ' チャンプ名
        Dim TextString As String = Form1.Champions(e.Index).ToString

        Dim thumbnail As Image = ListBox1.Items(e.Index)
        ' 画像を中央に表示
        e.Graphics.DrawImage(thumbnail,
            e.Bounds.X,
            e.Bounds.Y + (e.Bounds.Height - thumbnail.Height) \ 2)
        '文字を表示
        Dim TextBrush As Brush = Brushes.White
        Dim TextRect As RectangleF  '文字領域の設定
        With TextRect
            .X = e.Bounds.X + ICON_SIZE
            .Y = e.Bounds.Y + 4
            .Width = e.Bounds.Width - ICON_SIZE
            .Height = e.Bounds.Height
        End With
        e.Graphics.DrawString(TextString, e.Font, TextBrush, TextRect)

        thumbnail = Nothing

        e.DrawFocusRectangle()
    End Sub

    ' **********************************************
    ' **  関数名 : サムネイル作成                 **
    ' **                                          **
    ' **  引数1  : 元画像                         **
    ' **  引数2  : 元画像幅                       **
    ' **  引数3  : 元画像高さ                     **
    ' **********************************************
    Function createThumbnail(ByVal image As Image, ByVal w As Integer, ByVal h As Integer) As Image
        Dim fw As Double = CDbl(w) / CDbl(image.Width)
        Dim fh As Double = CDbl(h) / CDbl(image.Height)

        Dim scale As Double = Math.Min(fw, fh)
        Dim nw As Integer = CInt(image.Width * scale)
        Dim nh As Integer = CInt(image.Height * scale)

        Return New Bitmap(image, nw, nh)
    End Function

    ' **********************************************
    ' **  関数名 : サムネイルリスト作成           **
    ' **                                          **
    ' **  引数1  : なし                           **
    ' **********************************************
    Private Function makeThumbnail()
        ListBox1.ItemHeight = ICON_SIZE
        ListBox1.ScrollAlwaysVisible = True
        ListBox1.DrawMode = DrawMode.OwnerDrawFixed
        Dim imageDir As String = Form1.FolderName + "\Image\ChampionIcon" ' 画像ディレクトリ

        Try
            Dim i As Integer
            For i = 0 To Form1.Champions.Count - 1
                Dim s As String
                If Form1.Champions(i) = "Wukong" Then
                    s = imageDir + "\MonkeyKing.png"
                Else
                    s = imageDir + "\" + Form1.Champions(i).Replace(" "c, "").Replace("'"c, "").Replace("."c, "") + ".png"
                End If

                Debug.Print(s)
                Dim original As Image = Image.FromFile(s)
                Dim thumbnail = createThumbnail(original,
                    ListBox1.ClientSize.Width,
                    ListBox1.ItemHeight)

                ListBox1.Items.Add(thumbnail) ' 画像の追加

                original.Dispose()
                ' thumbnailオブジェクトは破棄できない
            Next
        Catch ex As System.IO.FileNotFoundException
            Return -1
        End Try

        Return 0
    End Function

    ' OKボタン
    Private Sub Button_OK_MouseEnter(sender As Object, e As EventArgs) Handles Button_OK.MouseEnter
        Form1.ChangeBtColor(CType(sender, Button), 1)
    End Sub

    Private Sub Button_OK_MouseLeave(sender As Object, e As EventArgs) Handles Button_OK.MouseLeave
        Form1.ChangeBtColor(CType(sender, Button), 0)
    End Sub

    Private Sub Button_OK_Click(sender As Object, e As EventArgs) Handles Button_OK.Click
        closePanel()
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        closePanel()
    End Sub

    Private Sub closePanel()
        If ListBox1.SelectedIndex <> -1 Then
            Form1.ComboBox2.SelectedIndex = ListBox1.SelectedIndex
            If Form1.WebBrowser2.Visible = True Then
                Form1.flgScrollL = 1
                Form1.OpenWebLeft(Form1.strSearchLeft)
            End If
            If Form1.WebBrowser1.Visible = True Then
                Form1.OpenWebRight(Form1.SEARCH_COUNTER)
            End If
        End If
        Close()
    End Sub
End Class