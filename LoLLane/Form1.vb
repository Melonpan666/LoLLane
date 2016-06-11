Public Class Form1

    ' -- 定数
    ' -- レーン
    Private Const LANE_TOP As Integer = 1
    Private Const LANE_JUNGLE As Integer = 2
    Private Const LANE_MID As Integer = 3
    Private Const LANE_ADC As Integer = 4
    Private Const LANE_SUP As Integer = 5
    ' -- ロール
    Private Const ROLE_ASSASSIN As Integer = 1
    Private Const ROLE_SUPPORT As Integer = 2
    Private Const ROLE_TANK As Integer = 3
    Private Const ROLE_FIGHTER As Integer = 4
    Private Const ROLE_MARKSMAN As Integer = 5
    Private Const ROLE_MAGE As Integer = 6
    ' Web 検索文字列
    Private Const SEARCH_BUILD As String = "Most Frequent Core Build"
    Private Const SEARCH_COUNTER As String = "Weak Against"
    Private Const SEARCH_MASTERY As String = "Most Frequent Masteries"
    Private Const SEARCH_SKILL As String = "Most Frequent Skill Order"
    Private Const SEARCH_RUNE As String = "Most Frequent Runes"
    ' ボタン色
    Private BT_BACK_COL_DEF As Color = Color.FromArgb(24, 28, 29)
    Private BT_BACK_COL_ENT As Color = Color.DodgerBlue
    Private BT_STR_COL_DEF As Color = Color.FromArgb(137, 245, 162)
    Private BT_STR_COL_ENT As Color = Color.Gold
    ' URL
    Private Const URL_LEFT_WEB As String = "https://champion.gg/champion/"
    Private Const URL_RIGHT_WEB As String = "http://www.championcounter.com/"
    Private Const URL_BACKIMAGE As String = "https://lolstatic-a.akamaihd.net/game-info/1.1.9/images/champion/backdrop/bg-"

    Private Structure Champ
        Public Name As String      ' チャンプ名
        Public Lane() As Integer     ' レーン
        Public Role() As Integer     ' ロール
        Sub New(ByVal n As String,
                ByVal l1 As Integer, ByVal l2 As Integer, ByVal l3 As Integer, ByVal l4 As Integer, ByVal l5 As Integer,
                ByVal r1 As Integer, ByVal r2 As Integer
            )
            Me.Name = n
            ReDim Me.Lane(4)
            Me.Lane(0) = l1
            Me.Lane(1) = l2
            Me.Lane(2) = l3
            Me.Lane(3) = l4
            Me.Lane(4) = l5
            ReDim Me.Role(1)
            Me.Role(0) = r1
            Me.Role(1) = r2
        End Sub
    End Structure

    Private ChampList As New ArrayList

    '-- 変数宣言
    Private Lanes() As String = {"", "Top", "Jungle", "Middle", "ADC", "Support"}
    Private Champions As New ArrayList

    ' URL
    Private URI_lolcounter As Uri
    Private URI_champgg As Uri

    ' 検索中文字列
    Private strSearchLeft As String = ""

    ' 直前の表示URL
    Private Bef_URI1 As Uri
    Private Bef_URI2 As Uri

    ' チャンプコンボボックス更新中フラグ
    Private flgChampCombo As Integer

    '-- 乱数
    Dim cRandom As New System.Random()

    ' **********************************************
    ' **  関数名 : チャンピオンデータ初期化       **
    ' **                                          **
    ' **  引数1  : なし                           **
    ' **********************************************
    Private Sub InitChamp()
        ' -- 構造体初期化
        ChampList.Add(New Champ("Aatrox", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Ahri", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Akali", LANE_MID, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Alistar", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Amumu", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Anivia", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Annie", LANE_MID, LANE_SUP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Ashe", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Aurelion Sol", LANE_MID, LANE_JUNGLE, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Azir", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Bard", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Blitzcrank", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Brand", LANE_MID, LANE_SUP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Braum", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Caitlyn", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Cassiopeia", LANE_MID, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Cho'Gath", LANE_TOP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Corki", LANE_ADC, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Darius", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Diana", LANE_MID, LANE_JUNGLE, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Dr. Mundo", LANE_TOP, LANE_JUNGLE, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Draven", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Ekko", LANE_TOP, LANE_MID, LANE_JUNGLE, 0, 0, 0, 0))
        ChampList.Add(New Champ("Elise", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Evelynn", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Ezreal", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Fiddlesticks", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Fiora", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Fizz", LANE_MID, LANE_TOP, LANE_JUNGLE, 0, 0, 0, 0))
        ChampList.Add(New Champ("Galio", LANE_MID, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Gangplank", LANE_TOP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Garen", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Gnar", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Gragas", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Graves", LANE_JUNGLE, LANE_ADC, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Hecarim", LANE_JUNGLE, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Heimerdinger", LANE_TOP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Illaoi", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Irelia", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Janna", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Jarvan IV", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Jax", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Jayce", LANE_MID, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Jhin", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Jinx", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Kalista", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Karma", LANE_SUP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Karthus", LANE_MID, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Kassadin", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Katarina", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Kayle", LANE_TOP, LANE_MID, LANE_JUNGLE, 0, 0, 0, 0))
        ChampList.Add(New Champ("Kennen", LANE_TOP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Kha'Zix", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Kindred", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Kog'Maw", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("LeBlanc", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Lee Sin", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Leona", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Lissandra", LANE_MID, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Lucian", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Lulu", LANE_SUP, LANE_MID, LANE_TOP, 0, 0, 0, 0))
        ChampList.Add(New Champ("Lux", LANE_MID, LANE_SUP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Malphite", LANE_TOP, LANE_SUP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Malzahar", LANE_MID, LANE_JUNGLE, LANE_TOP, 0, 0, 0, 0))
        ChampList.Add(New Champ("Maokai", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Master Yi", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Miss Fortune", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Mordekaiser", LANE_TOP, LANE_MID, LANE_JUNGLE, 0, 0, 0, 0))
        ChampList.Add(New Champ("Morgana", LANE_SUP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Nami", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Nasus", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Nautilus", LANE_SUP, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Nidalee", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Nocturne", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Nunu", LANE_JUNGLE, LANE_SUP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Olaf", LANE_TOP, LANE_JUNGLE, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Orianna", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Pantheon", LANE_TOP, LANE_JUNGLE, LANE_MID, 0, 0, 0, 0))
        ChampList.Add(New Champ("Poppy", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Quinn", LANE_TOP, LANE_ADC, LANE_JUNGLE, LANE_MID, 0, 0, 0))
        ChampList.Add(New Champ("Rammus", LANE_JUNGLE, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Rek'Sai", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Renekton", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Rengar", LANE_JUNGLE, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Riven", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Rumble", LANE_TOP, LANE_JUNGLE, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Ryze", LANE_TOP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Sejuani", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Shaco", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Shen", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Shyvana", LANE_JUNGLE, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Singed", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Sion", LANE_TOP, LANE_JUNGLE, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Sivir", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Skarner", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Sona", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Soraka", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Swain", LANE_TOP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Syndra", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Tahm Kench", LANE_SUP, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Taliyah", LANE_MID, LANE_TOP, LANE_SUP, LANE_JUNGLE, 0, 0, 0))
        ChampList.Add(New Champ("Talon", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Taric", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Teemo", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Thresh", LANE_SUP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Tristana", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Trundle", LANE_TOP, LANE_SUP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Tryndamere", LANE_TOP, LANE_JUNGLE, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Twisted Fate", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Twitch", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Udyr", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Urgot", LANE_TOP, LANE_ADC, LANE_MID, 0, 0, 0, 0))
        ChampList.Add(New Champ("Varus", LANE_ADC, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Vayne", LANE_ADC, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Veigar", LANE_MID, LANE_SUP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Vel'Koz", LANE_MID, LANE_SUP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Vi", LANE_JUNGLE, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Viktor", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Vladimir", LANE_TOP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Volibear", LANE_JUNGLE, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Warwick", LANE_JUNGLE, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Wukong", LANE_TOP, LANE_JUNGLE, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Xerath", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Xin Zhao", LANE_JUNGLE, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Yasuo", LANE_TOP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Yorick", LANE_TOP, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Zac", LANE_JUNGLE, LANE_TOP, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Zed", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Ziggs", LANE_MID, 0, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Zilean", LANE_SUP, LANE_MID, 0, 0, 0, 0, 0))
        ChampList.Add(New Champ("Zyra", LANE_SUP, LANE_MID, 0, 0, 0, 0, 0))

        ' -- コンボボックス
        SearchChamp()
    End Sub

    ' **********************************************
    ' **  関数名 : チャンプ名絞込                 **
    ' **                                          **
    ' **  引数1  : レーン (省略可)                **
    ' **  引数2  : ロール (省略可)                **
    ' **********************************************
    Private Sub SearchChamp(Optional ByVal l As Integer = 0, Optional ByVal r As Integer = 0)
        Dim i As Integer
        Dim j As Integer
        Dim flg As Integer

        ' 初期化
        Champions.Clear()

        For i = 0 To ChampList.Count - 1
            ' レーン検索
            If l <> 0 Then
                flg = 0
                For j = 0 To 4
                    If ChampList(i).Lane(j) = l Then
                        flg = 1
                        Exit For
                    End If
                Next
                ' ヒット無し
                If flg = 0 Then
                    Continue For
                End If
            End If

            ' ロール検索
            If r <> 0 Then
                flg = 0
                For j = 0 To 1
                    If ChampList(i).Role(j) = r Then
                        flg = 1
                        Exit For
                    End If
                Next
                ' ヒット無し
                If flg = 0 Then
                    Continue For
                End If
            End If

            ' 検索ヒット
            Champions.Add(ChampList(i).Name)
        Next
        Debug.Print("Count = " & Champions.Count & " Lane = " & ComboBox1.SelectedIndex)
    End Sub

    '-- フォーム初期化
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-- 初期化
        InitChamp()
        ComboBox1.DataSource = Lanes
        ComboBox2.DataSource = Champions
        flgChampCombo = 0

        ' 背景描画
        DrawBackPicture(SetBackURL(CType(Champions(0), String)))

        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub

    ' **********************************************
    ' **  関数名 : 背景画像表示                   **
    ' **                                          **
    ' **  引数1  : 画像URI                        **
    ' **********************************************
    Private Sub DrawBackPicture(ByVal s As String)
        'X座標
        Dim pos_x As Integer
        'Y座標
        Dim pos_y As Integer

        If ComboBox2.Text = "Ekko" Then
            pos_x = 300
        Else
            pos_x = -50
        End If
        pos_y = -100

        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        Dim request As System.Net.WebRequest =
            System.Net.WebRequest.Create(s)
        Dim response As System.Net.WebResponse = request.GetResponse()
        Dim responseStream As System.IO.Stream = response.GetResponseStream()
        Dim image = New Bitmap(responseStream)

        '補間方法として高品質双三次補間を指定する
        g.InterpolationMode =
            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        '画像を縮小して描画する
        g.DrawImage(image, pos_x, pos_y, CType(image.Width * 0.5, Integer), CType(image.Height * 0.5, Integer))

        'BitmapとGraphicsオブジェクトを破棄
        image.Dispose()
        g.Dispose()

        'PictureBox1に表示する
        PictureBox1.Image = canvas

        response = Nothing
        request = Nothing
        responseStream = Nothing
    End Sub


    '-- Lane シャッフル
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ComboBox1.Text = ComboBox1.Items(cRandom.Next(1, ComboBox1.Items.Count))
    End Sub

    '-- チャンプシャッフル
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox2.Text = ComboBox2.Items(cRandom.Next(0, ComboBox2.Items.Count))
    End Sub


    ' **********************************************
    ' **  関数名 : Webページ表示位置検索          **
    ' **                                          **
    ' **  引数1  : 検索文字列                     **
    ' **  引数2  : 検索対象WebBrowser             **
    ' **********************************************
    Private Sub Search(ByVal s As String, ByRef w As WebBrowser)
        Dim objRange As mshtml.IHTMLTxtRange = Nothing 'MSHTML.IHTMLTxtRange
        Dim Doc As mshtml.HTMLDocument  'MSHTML.HTMLDocument
        Dim Body As mshtml.HTMLBody 'MSHTML.HTMLBody
        Doc = w.Document.DomDocument
        Body = Doc.body

        If objRange Is Nothing Then
            objRange = Body.createTextRange
        End If

        If objRange.findText(s) Then
            '検索した語句を黄色く反転させる。
            'objRange.execCommand("BackColor", False, "YELLOW")

            '論理カーソル位置を、検索した語句の末尾に移動させスクロールする
            w.Document.Window.ScrollTo(0, Doc.documentElement.offsetHeight)
            objRange.scrollIntoView(True)
            objRange.collapse(False)
        End If

        objRange = Nothing
        Body = Nothing
        Doc = Nothing
    End Sub

    ' **********************************************
    ' **  関数名 : 右側Webページ表示              **
    ' **                                          **
    ' **  引数1  : 検索文字列                     **
    ' **********************************************
    Private Sub OpenWebRight(ByVal s As String)
        ' URI_lolcounter = New Uri("http://www.lolcounter.com/champions/" & ComboBox2.Text.Replace(" "c, "-"c).Replace("'"c, "").Replace("."c, "").ToLower)
        URI_lolcounter = New Uri(URL_RIGHT_WEB & ComboBox2.Text.Replace(" "c, "").Replace("'"c, "").Replace("."c, "").ToLower)
        ' 直前にロードしたページと同じなら再表示せず検索のみ
        If URI_lolcounter = Bef_URI1 Then
            Search(s, WebBrowser1)
            Return
        End If
        Bef_URI1 = URI_lolcounter
        WebBrowser1.Visible = False
        Try
            WebBrowser1.Navigate(URI_lolcounter)
        Catch ex As System.UriFormatException
            Return
        End Try
    End Sub

    '-- Web LoLCounter表示
    Private Sub Counter_Click(sender As Object, e As EventArgs) Handles Button_Counter.Click
        OpenWebRight(SEARCH_COUNTER)
    End Sub

    '-- Counter Web
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        TimerWeb1.Interval = 1000
        ' タイマ起動
        TimerWeb1.Enabled = True
    End Sub

    ' **********************************************
    ' **  関数名 : 左側Webページ表示              **
    ' **                                          **
    ' **  引数1  : 検索文字列                     **
    ' **********************************************
    Private Sub OpenWebLeft(ByVal s As String)
        URI_champgg = New Uri(URL_LEFT_WEB & ComboBox2.Text.Replace(" "c, "").Replace("'"c, "").Replace("."c, "") & "/" & ComboBox1.Text)
        ' 直前にロードしたページと同じなら再表示せず検索のみ
        If URI_champgg = Bef_URI2 Then
            Search(s, WebBrowser2)
            Return
        End If
        WebBrowser2.Visible = False
        strSearchLeft = s
        Bef_URI2 = URI_champgg
        Try
            WebBrowser2.Navigate(URI_champgg)
        Catch ex As System.UriFormatException
            Return
        End Try
    End Sub

    ' -- Build ボタン
    Private Sub Build_Click(sender As Object, e As EventArgs) Handles Build.Click
        OpenWebLeft(SEARCH_BUILD)
    End Sub

    ' -- Champion GG
    Private Sub WebBrowser2_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted
        TimerWeb2.Interval = 1000
        ' タイマ起動
        TimerWeb2.Enabled = True

    End Sub

    ' -- 背景画像URL作成
    Private Function SetBackURL(ByVal strchamp As String) As String
        Dim Ret As String
        Ret = URL_BACKIMAGE & strchamp.Replace(" "c, "").Replace("'G", "g"c).Replace("'Z", "z"c).Replace("'K", "k"c).Replace("'"c, "").Replace("."c, "").ToLower & ".jpg"
        Return Ret
    End Function

    ' -- チャンプコンボボックス
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' コンボボックス更新中は何もしない
        If flgChampCombo = 1 Then
            Return
        End If

        Try
            DrawBackPicture(SetBackURL(ComboBox2.Text))
        Catch ex As System.UriFormatException
            Return
        End Try

        If ComboBox2.Text = "Teemo" Then
            Dim mediaPlayer As New WMPLib.WindowsMediaPlayer()
            'オーディオファイルを指定する（自動的に再生される）
            mediaPlayer.URL = "http://vignette2.wikia.nocookie.net/leagueoflegends/images/5/53/Teemo.ogg/revision/latest?cb=20120619062518K"
            '再生する
            mediaPlayer.controls.play()
        End If

    End Sub

    ' Web Counter更新タイマ
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerWeb2.Tick
        WebBrowser2.ActiveXInstance.ExecWB(63, 1, 70, 0)
        Search(strSearchLeft, WebBrowser2)
        WebBrowser2.Visible = True
        ' タイマキャンセル
        TimerWeb2.Enabled = False
    End Sub

    ' Web Build更新タイマ
    Private Sub TimerWeb1_Tick(sender As Object, e As EventArgs) Handles TimerWeb1.Tick
        WebBrowser1.ActiveXInstance.ExecWB(63, 1, 50, 0)
        Search(SEARCH_COUNTER, WebBrowser1)
        WebBrowser1.Visible = True
        ' タイマキャンセル
        TimerWeb1.Enabled = False
    End Sub

    ' **********************************************
    ' **  関数名 : ボタン色変更                   **
    ' **                                          **
    ' **  引数1  : 対象Button                     **
    ' **  引数2  : フラグ(0:デフォ, 1:オン)       **
    ' **********************************************
    Private Sub ChangeBtColor(ByRef b As Button, ByVal flg As Integer)
        If flg = 1 Then     ' オン マウス
            b.BackColor = BT_BACK_COL_ENT
            b.ForeColor = BT_STR_COL_ENT
        Else                ' デフォルト
            b.BackColor = BT_BACK_COL_DEF
            b.ForeColor = BT_STR_COL_DEF
        End If

    End Sub

    ' Build ボタン
    Private Sub Build_MouseEnter(sender As Object, e As EventArgs) Handles Build.MouseEnter
        ChangeBtColor(Build, 1)
    End Sub

    Private Sub Build_MouseLeave(sender As Object, e As EventArgs) Handles Build.MouseLeave
        ChangeBtColor(Build, 0)
    End Sub

    ' Counter ボタン
    Private Sub Button_Counter_MouseEnter(sender As Object, e As EventArgs) Handles Button_Counter.MouseEnter
        ChangeBtColor(Button_Counter, 1)
    End Sub

    Private Sub Button_Counter_MouseLeave(sender As Object, e As EventArgs) Handles Button_Counter.MouseLeave
        ChangeBtColor(Button_Counter, 0)
    End Sub

    ' Lane ボタン
    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        ChangeBtColor(Button1, 1)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        ChangeBtColor(Button1, 0)
    End Sub

    ' Champ ボタン
    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        ChangeBtColor(Button2, 1)
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        ChangeBtColor(Button2, 0)
    End Sub

    ' Mastery ボタン
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button_Mastery.Click
        OpenWebLeft(SEARCH_MASTERY)
    End Sub

    Private Sub Button_Mastery_MouseEnter(sender As Object, e As EventArgs) Handles Button_Mastery.MouseEnter
        ChangeBtColor(Button_Mastery, 1)
    End Sub

    Private Sub Button_Mastery_MouseLeave(sender As Object, e As EventArgs) Handles Button_Mastery.MouseLeave
        ChangeBtColor(Button_Mastery, 0)
    End Sub

    ' Skill Order ボタン
    Private Sub Button_Skill_Click(sender As Object, e As EventArgs) Handles Button_Skill.Click
        OpenWebLeft(SEARCH_SKILL)
    End Sub

    Private Sub Button_Skill_MouseEnter(sender As Object, e As EventArgs) Handles Button_Skill.MouseEnter
        ChangeBtColor(Button_Skill, 1)
    End Sub

    Private Sub Button_Skill_MouseLeave(sender As Object, e As EventArgs) Handles Button_Skill.MouseLeave
        ChangeBtColor(Button_Skill, 0)
    End Sub

    ' Rune ボタン
    Private Sub Button_Rune_Click(sender As Object, e As EventArgs) Handles Button_Rune.Click
        OpenWebLeft(SEARCH_RUNE)
    End Sub

    Private Sub Button_Rune_MouseEnter(sender As Object, e As EventArgs) Handles Button_Rune.MouseEnter
        ChangeBtColor(Button_Rune, 1)
    End Sub

    Private Sub Button_Rune_MouseLeave(sender As Object, e As EventArgs) Handles Button_Rune.MouseLeave
        ChangeBtColor(Button_Rune, 0)
    End Sub

    ' -- レーンコンボボックス
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' 直前に選択されていたチャンプ名
        Dim Bef_champ As String = ComboBox2.Text
        Debug.Print("Bef = " & ComboBox2.Text)

        ' -- チャンプ検索
        SearchChamp(ComboBox1.SelectedIndex)

        ' コンボボックス更新開始
        flgChampCombo = 1
        ComboBox2.DataSource = Nothing
        ComboBox2.DataSource = Champions

        Debug.Print("Index = " & Champions.IndexOf(Bef_champ))

        flgChampCombo = 0
        ' コンボボックス更新終了
        If Champions.IndexOf(Bef_champ) < 0 Then
            ' 選択初期化
            ComboBox2.SelectedIndex = 0
            DrawBackPicture(SetBackURL(CType(Champions(0), String)))
        Else
            ' 直前に選択されていたチャンプ
            ComboBox2.SelectedIndex = Champions.IndexOf(Bef_champ)
        End If
    End Sub

End Class
