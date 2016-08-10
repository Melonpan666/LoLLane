Imports System.Drawing.Drawing2D
'Test
Public Class Form1

    ' -- 定数
    ' -- レーン
    Private Const LANE_TOP As Integer = 1
    Private Const LANE_JUNGLE As Integer = 2
    Private Const LANE_MID As Integer = 3
    Private Const LANE_ADC As Integer = 4
    Private Const LANE_SUP As Integer = 5
    ' -- ロール
    Private Const ROLE_ASSASSIN As Byte = &H1
    Private Const ROLE_FIGHTER As Byte = &H2
    Private Const ROLE_MAGE As Byte = &H4
    Private Const ROLE_SUPPORT As Byte = &H8
    Private Const ROLE_TANK As Byte = &H10
    Private Const ROLE_MARKSMAN As Byte = &H20
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
    ' コンボボックス色
    Private COMB_BK_COL() As Color = {BT_BACK_COL_DEF, Color.DeepSkyBlue, Color.Purple, Color.Orange, Color.Crimson, Color.LimeGreen}
    ' URL
    Private Const URL_LEFT_WEB As String = "https://champion.gg/champion/"
    Private Const URL_RIGHT_WEB As String = "http://www.championcounter.com/"
    Private Const URL_BACKIMAGE As String = "https://lolstatic-a.akamaihd.net/game-info/1.1.9/images/champion/backdrop/bg-"

    Private Structure Champ
        Public Name As String      ' チャンプ名
        Public JpName As String      ' チャンプ日本語名
        Public Lane() As Integer     ' レーン
        Public Role() As Byte     ' ロール
        Sub New(ByVal n As String, ByVal jn As String,
                ByVal l1 As Integer, ByVal l2 As Integer, ByVal l3 As Integer, ByVal l4 As Integer, ByVal l5 As Integer,
                ByVal r1 As Byte, ByVal r2 As Byte
            )
            Me.Name = n
            Me.JpName = jn
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

    ' スクロールロックフラグ
    Private flgScrollL As Integer
    Private flgScrollR As Integer

    ' 表示倍率
    Private dRate As Decimal

    ' フォームサイズ初期値
    Private Const iniFormWidth As Integer = 816
    Private Const iniFormHeight As Integer = 517
    ' フォームサイズ倍率
    Private rateForm As Decimal

    ' ブラウザサイズ初期値
    Private Const iniLBrowserWidth As Integer = 390
    Private Const iniLBrowserHeight As Integer = 401
    Private Const iniRBrowserWidth As Integer = 390
    Private Const iniRBrowserHeight As Integer = 401

    '-- 乱数
    Dim cRandom As New System.Random()

    ' ツールチップ設定
    Dim ToolTip1 As ToolTip

    ' **********************************************
    ' **  関数名 : チャンピオンデータ初期化       **
    ' **                                          **
    ' **  引数1  : なし                           **
    ' **********************************************
    Private Sub InitChamp()
        ' -- 構造体初期化
        ChampList.Add(New Champ("Aatrox", "エイトロックス", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Ahri", "アーリ", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Akali", "アカリ", LANE_MID, LANE_TOP, 0, 0, 0, ROLE_ASSASSIN, 0))
        ChampList.Add(New Champ("Alistar", "アリスター", LANE_SUP, 0, 0, 0, 0, ROLE_TANK, 0))
        ChampList.Add(New Champ("Amumu", "アムム", LANE_JUNGLE, 0, 0, 0, 0, ROLE_TANK, ROLE_MAGE))
        ChampList.Add(New Champ("Anivia", "アニビア", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, ROLE_SUPPORT))
        ChampList.Add(New Champ("Annie", "アニー", LANE_MID, LANE_SUP, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Ashe", "アッシュ", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, ROLE_SUPPORT))
        ChampList.Add(New Champ("Aurelion Sol", "オレリオン・ソル", LANE_MID, LANE_JUNGLE, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Azir", "アジール", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, ROLE_MARKSMAN))
        ChampList.Add(New Champ("Bard", "バード", LANE_SUP, 0, 0, 0, 0, ROLE_SUPPORT, ROLE_MAGE))
        ChampList.Add(New Champ("Blitzcrank", "ブリッツ", LANE_SUP, 0, 0, 0, 0, ROLE_TANK, ROLE_FIGHTER))
        ChampList.Add(New Champ("Brand", "ブランド", LANE_MID, LANE_SUP, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Braum", "ブラウム", LANE_SUP, 0, 0, 0, 0, ROLE_SUPPORT, ROLE_TANK))
        ChampList.Add(New Champ("Caitlyn", "ケイトリン", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Cassiopeia", "カシオペア", LANE_MID, LANE_TOP, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Cho'Gath", "チョ＝ガス", LANE_TOP, LANE_MID, 0, 0, 0, ROLE_TANK, ROLE_MAGE))
        ChampList.Add(New Champ("Corki", "コーキ", LANE_ADC, LANE_MID, 0, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Darius", "ダリウス", LANE_TOP, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Diana", "ダイアナ", LANE_MID, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_MAGE))
        ChampList.Add(New Champ("Dr. Mundo", "ドクター・ムンド", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Draven", "ドレイヴン", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Ekko", "エコー", LANE_TOP, LANE_MID, LANE_JUNGLE, 0, 0, ROLE_ASSASSIN, ROLE_FIGHTER))
        ChampList.Add(New Champ("Elise", "エリス", LANE_JUNGLE, 0, 0, 0, 0, ROLE_MAGE, ROLE_FIGHTER))
        ChampList.Add(New Champ("Evelynn", "イブリン", LANE_JUNGLE, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_MAGE))
        ChampList.Add(New Champ("Ezreal", "エズリアル", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, ROLE_MAGE))
        ChampList.Add(New Champ("Fiddlesticks", "フィドル", LANE_JUNGLE, 0, 0, 0, 0, ROLE_MAGE, ROLE_SUPPORT))
        ChampList.Add(New Champ("Fiora", "フィオラ", LANE_TOP, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Fizz", "フィズ", LANE_MID, LANE_TOP, LANE_JUNGLE, 0, 0, ROLE_ASSASSIN, ROLE_FIGHTER))
        ChampList.Add(New Champ("Galio", "ガリオ", LANE_MID, LANE_TOP, 0, 0, 0, ROLE_TANK, ROLE_MAGE))
        ChampList.Add(New Champ("Gangplank", "ガングプランク", LANE_TOP, LANE_MID, 0, 0, 0, ROLE_FIGHTER, ROLE_SUPPORT))
        ChampList.Add(New Champ("Garen", "ガレン", LANE_TOP, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Gnar", "ナー", LANE_TOP, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_MARKSMAN))
        ChampList.Add(New Champ("Gragas", "グラガス", LANE_JUNGLE, 0, 0, 0, 0, ROLE_MAGE, ROLE_FIGHTER))
        ChampList.Add(New Champ("Graves", "グレイブス", LANE_JUNGLE, LANE_ADC, LANE_TOP, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Hecarim", "ヘカリム", LANE_JUNGLE, LANE_TOP, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Heimerdinger", "ハイマー", LANE_TOP, LANE_MID, 0, 0, 0, ROLE_MAGE, ROLE_SUPPORT))
        ChampList.Add(New Champ("Illaoi", "イラオイ", LANE_TOP, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Irelia", "イレリア", LANE_TOP, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Janna", "ジャンナ", LANE_SUP, 0, 0, 0, 0, ROLE_SUPPORT, ROLE_MAGE))
        ChampList.Add(New Champ("Jarvan IV", "ジャーヴァンIV", LANE_JUNGLE, LANE_TOP, 0, 0, 0, ROLE_TANK, ROLE_FIGHTER))
        ChampList.Add(New Champ("Jax", "ジャックス", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Jayce", "ジェイス", LANE_MID, LANE_TOP, 0, 0, 0, ROLE_FIGHTER, ROLE_MARKSMAN))
        ChampList.Add(New Champ("Jhin", "ジン", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Jinx", "ジンクス", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Kalista", "カリスタ", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Karma", "カルマ", LANE_SUP, LANE_MID, 0, 0, 0, ROLE_MAGE, ROLE_SUPPORT))
        ChampList.Add(New Champ("Karthus", "カーサス", LANE_MID, LANE_TOP, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Kassadin", "カサディン", LANE_MID, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_MAGE))
        ChampList.Add(New Champ("Katarina", "カタリナ", LANE_MID, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_MAGE))
        ChampList.Add(New Champ("Kayle", "ケイル", LANE_TOP, LANE_MID, LANE_JUNGLE, 0, 0, ROLE_FIGHTER, ROLE_SUPPORT))
        ChampList.Add(New Champ("Kennen", "ケネン", LANE_TOP, LANE_MID, 0, 0, 0, ROLE_MAGE, ROLE_MARKSMAN))
        ChampList.Add(New Champ("Kha'Zix", "カ＝ジックス", LANE_JUNGLE, 0, 0, 0, 0, ROLE_ASSASSIN, 0))
        ChampList.Add(New Champ("Kindred", "キンドレッド", LANE_JUNGLE, 0, 0, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Kog'Maw", "コグ＝マウ", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, ROLE_MAGE))
        ChampList.Add(New Champ("LeBlanc", "ルブラン", LANE_MID, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_MAGE))
        ChampList.Add(New Champ("Lee Sin", "リー・シン", LANE_JUNGLE, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Leona", "レオナ", LANE_SUP, 0, 0, 0, 0, ROLE_TANK, ROLE_SUPPORT))
        ChampList.Add(New Champ("Lissandra", "リサンドラ", LANE_MID, LANE_TOP, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Lucian", "ルシアン", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Lulu", "ルル", LANE_SUP, LANE_MID, LANE_TOP, 0, 0, ROLE_SUPPORT, ROLE_MAGE))
        ChampList.Add(New Champ("Lux", "ラックス", LANE_MID, LANE_SUP, 0, 0, 0, ROLE_MAGE, ROLE_SUPPORT))
        ChampList.Add(New Champ("Malphite", "マルファイト", LANE_TOP, LANE_SUP, 0, 0, 0, ROLE_TANK, ROLE_FIGHTER))
        ChampList.Add(New Champ("Malzahar", "マルザハール", LANE_MID, LANE_JUNGLE, LANE_TOP, 0, 0, ROLE_MAGE, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Maokai", "マオカイ", LANE_TOP, 0, 0, 0, 0, ROLE_TANK, ROLE_MAGE))
        ChampList.Add(New Champ("Master Yi", "マスター・イー", LANE_JUNGLE, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_FIGHTER))
        ChampList.Add(New Champ("Miss Fortune", "フォーチュン", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Mordekaiser", "モルデカイザー", LANE_TOP, LANE_MID, 0, 0, 0, ROLE_FIGHTER, ROLE_MAGE))
        ChampList.Add(New Champ("Morgana", "モルガナ", LANE_SUP, LANE_MID, 0, 0, 0, ROLE_MAGE, ROLE_SUPPORT))
        ChampList.Add(New Champ("Nami", "ナミ", LANE_SUP, 0, 0, 0, 0, ROLE_SUPPORT, ROLE_MAGE))
        ChampList.Add(New Champ("Nasus", "ナサス", LANE_TOP, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Nautilus", "ノーチラス", LANE_SUP, LANE_TOP, LANE_JUNGLE, 0, 0, ROLE_TANK, ROLE_FIGHTER))
        ChampList.Add(New Champ("Nidalee", "ニダリー", LANE_JUNGLE, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_SUPPORT))
        ChampList.Add(New Champ("Nocturne", "ノクターン", LANE_JUNGLE, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_FIGHTER))
        ChampList.Add(New Champ("Nunu", "ヌヌ", LANE_JUNGLE, LANE_SUP, LANE_TOP, 0, 0, ROLE_SUPPORT, ROLE_FIGHTER))
        ChampList.Add(New Champ("Olaf", "オラフ", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Orianna", "オリアナ", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, ROLE_SUPPORT))
        ChampList.Add(New Champ("Pantheon", "パンテオン", LANE_TOP, LANE_JUNGLE, LANE_MID, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Poppy", "ポッピー", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Quinn", "クイン", LANE_TOP, LANE_ADC, LANE_JUNGLE, LANE_MID, 0, ROLE_MARKSMAN, ROLE_FIGHTER))
        ChampList.Add(New Champ("Rammus", "ラムス", LANE_JUNGLE, LANE_TOP, 0, 0, 0, ROLE_TANK, ROLE_FIGHTER))
        ChampList.Add(New Champ("Rek'Sai", "レク＝サイ", LANE_JUNGLE, 0, 0, 0, 0, ROLE_FIGHTER, 0))
        ChampList.Add(New Champ("Renekton", "レネクトン", LANE_TOP, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Rengar", "レンガー", LANE_JUNGLE, LANE_TOP, 0, 0, 0, ROLE_ASSASSIN, ROLE_FIGHTER))
        ChampList.Add(New Champ("Riven", "リヴェン", LANE_TOP, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_FIGHTER))
        ChampList.Add(New Champ("Rumble", "ランブル", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_MAGE))
        ChampList.Add(New Champ("Ryze", "ライズ", LANE_TOP, LANE_MID, 0, 0, 0, ROLE_MAGE, ROLE_FIGHTER))
        ChampList.Add(New Champ("Sejuani", "セジュアニ", LANE_JUNGLE, 0, 0, 0, 0, ROLE_TANK, ROLE_FIGHTER))
        ChampList.Add(New Champ("Shaco", "シャコ", LANE_JUNGLE, 0, 0, 0, 0, ROLE_ASSASSIN, 0))
        ChampList.Add(New Champ("Shen", "シェン", LANE_TOP, 0, 0, 0, 0, ROLE_TANK, ROLE_FIGHTER))
        ChampList.Add(New Champ("Shyvana", "シヴァーナ", LANE_JUNGLE, LANE_TOP, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Singed", "シンジド", LANE_TOP, 0, 0, 0, 0, ROLE_TANK, ROLE_FIGHTER))
        ChampList.Add(New Champ("Sion", "サイオン", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_MAGE))
        ChampList.Add(New Champ("Sivir", "シヴィア", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, 0))
        ChampList.Add(New Champ("Skarner", "スカーナー", LANE_JUNGLE, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Sona", "ソナ", LANE_SUP, 0, 0, 0, 0, ROLE_SUPPORT, ROLE_MAGE))
        ChampList.Add(New Champ("Soraka", "ソラカ", LANE_SUP, 0, 0, 0, 0, ROLE_SUPPORT, ROLE_MAGE))
        ChampList.Add(New Champ("Swain", "スウェイン", LANE_TOP, LANE_MID, 0, 0, 0, ROLE_MAGE, ROLE_FIGHTER))
        ChampList.Add(New Champ("Syndra", "シンドラ", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, ROLE_SUPPORT))
        ChampList.Add(New Champ("Tahm Kench", "タム・ケンチ", LANE_SUP, LANE_TOP, 0, 0, 0, ROLE_TANK, ROLE_SUPPORT))
        ChampList.Add(New Champ("Taliyah", "タリヤ", LANE_MID, LANE_TOP, LANE_SUP, 0, 0, ROLE_MAGE, ROLE_SUPPORT))
        ChampList.Add(New Champ("Talon", "タロン", LANE_MID, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_FIGHTER))
        ChampList.Add(New Champ("Taric", "タリック", LANE_SUP, 0, 0, 0, 0, ROLE_SUPPORT, ROLE_FIGHTER))
        ChampList.Add(New Champ("Teemo", "ティーモ", LANE_TOP, 0, 0, 0, 0, ROLE_MARKSMAN, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Thresh", "スレッシュ", LANE_SUP, 0, 0, 0, 0, ROLE_SUPPORT, ROLE_FIGHTER))
        ChampList.Add(New Champ("Tristana", "トリスターナ", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Trundle", "トランドル", LANE_TOP, LANE_SUP, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Tryndamere", "トリンダメア", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Twisted Fate", "フェイト", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Twitch", "トゥイッチ", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Udyr", "ウディア", LANE_JUNGLE, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Urgot", "アーゴット", LANE_TOP, LANE_ADC, 0, 0, 0, ROLE_MARKSMAN, ROLE_TANK))
        ChampList.Add(New Champ("Varus", "ヴァルス", LANE_ADC, LANE_MID, 0, 0, 0, ROLE_MARKSMAN, ROLE_MAGE))
        ChampList.Add(New Champ("Vayne", "ヴェイン", LANE_ADC, 0, 0, 0, 0, ROLE_MARKSMAN, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Veigar", "ベイガー", LANE_MID, LANE_SUP, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Vel'Koz", "ヴェル＝コズ", LANE_MID, LANE_SUP, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Vi", "ヴァイ", LANE_JUNGLE, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Viktor", "ビクター", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Vladimir", "ブラッドミア", LANE_TOP, LANE_MID, 0, 0, 0, ROLE_MAGE, ROLE_TANK))
        ChampList.Add(New Champ("Volibear", "ボリベア", LANE_JUNGLE, LANE_TOP, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Warwick", "ワーウィック", LANE_JUNGLE, LANE_TOP, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Wukong", "ウーコン", LANE_TOP, LANE_JUNGLE, 0, 0, 0, ROLE_FIGHTER, ROLE_TANK))
        ChampList.Add(New Champ("Xerath", "ゼラス", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Xin Zhao", "シン・ジャオ", LANE_JUNGLE, LANE_TOP, 0, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Yasuo", "ヤスオ", LANE_TOP, LANE_MID, 0, 0, 0, ROLE_FIGHTER, ROLE_ASSASSIN))
        ChampList.Add(New Champ("Yorick", "ヨリック", LANE_TOP, 0, 0, 0, 0, ROLE_FIGHTER, ROLE_MAGE))
        ChampList.Add(New Champ("Zac", "ザック", LANE_JUNGLE, LANE_TOP, 0, 0, 0, ROLE_TANK, ROLE_FIGHTER))
        ChampList.Add(New Champ("Zed", "ゼド", LANE_MID, 0, 0, 0, 0, ROLE_ASSASSIN, ROLE_FIGHTER))
        ChampList.Add(New Champ("Ziggs", "ジグス", LANE_MID, 0, 0, 0, 0, ROLE_MAGE, 0))
        ChampList.Add(New Champ("Zilean", "ジリアン", LANE_SUP, LANE_MID, 0, 0, 0, ROLE_SUPPORT, ROLE_MAGE))
        ChampList.Add(New Champ("Zyra", "ザイラ", LANE_SUP, 0, 0, 0, 0, ROLE_MAGE, ROLE_SUPPORT))


        ' -- コンボボックス
        SearchChamp()
    End Sub

    ' **********************************************
    ' **  関数名 : ツールチップ初期化             **
    ' **                                          **
    ' **  引数1  : なし                           **
    ' **********************************************
    Private Sub InitToolTip()
        'ToolTipを作成する
        ToolTip1 = New ToolTip(Me.components)
        ' -- ToolTipの設定を行う
        'ToolTipが表示されるまでの時間
        ToolTip1.InitialDelay = 1300
        'ToolTipが表示されている時に、別のToolTipを表示するまでの時間
        ToolTip1.ReshowDelay = 1000
        'ToolTipを表示する時間
        ToolTip1.AutoPopDelay = 10000
        'フォームがアクティブでない時でもToolTipを表示する
        ToolTip1.ShowAlways = True

        'ToolTip設定
        ToolTip1.SetToolTip(CheckBox_Topmost, "Display this window as top most")
        ToolTip1.SetToolTip(PictureBox1, "Click the champion image, and copy the champion jp-name to the clipboard")
        ToolTip1.SetToolTip(Role_ListBox, "Choose any roles, and narrow the search")
    End Sub

    ' **********************************************
    ' **  関数名 : ロール状態取得                 **
    ' **                                          **
    ' **  引数1  : リストボックス                 **
    ' **********************************************
    Private Function GetRoleState(ByVal c As CheckedListBox) As Byte
        Dim b As Byte = &H1  ' 00000001
        Dim ret As Byte = 0
        Dim i As Integer

        For i = 0 To c.Items.Count - 1
            If c.GetItemChecked(i) Then
                ret += b << i
            End If
        Next

        Return ret
    End Function

    ' **********************************************
    ' **  関数名 : チャンプ名絞込                 **
    ' **                                          **
    ' **  引数1  : レーン (省略可)                **
    ' **  引数2  : ロール (省略可)                **
    ' **********************************************
    Private Sub SearchChamp(Optional ByVal l As Integer = 0, Optional ByVal r As Byte = 0)
        Dim i As Integer
        Dim j As Integer
        Dim flg As Integer
        Dim chkRole As Byte = 0

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
                chkRole = ChampList(i).Role(0) Or ChampList(i).Role(1)

                If (r And chkRole) = 0 Then
                    ' ヒットなし
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
        flgScrollL = 0
        flgScrollR = 0
        dRate = 0.5
        rateForm = 1.0

        InitToolTip()

        ' チェックボックス初期化
        Role_ListBox.Items.Add("Assassin")
        Role_ListBox.Items.Add("Fighter")
        Role_ListBox.Items.Add("Mage")
        Role_ListBox.Items.Add("Support")
        Role_ListBox.Items.Add("Tank")
        Role_ListBox.Items.Add("Marksman")
        Role_ListBox.CheckOnClick = True

        ' 背景描画
        DrawBackPicture(SetBackURL(CType(Champions(0), String)))

        ' サイズ固定
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
            pos_x = 300 + (Me.Width - iniFormWidth) / 2
        Else
            pos_x = -50 + (Me.Width - iniFormWidth) / 2
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
        g.DrawImage(image, pos_x, pos_y, CType(image.Width * dRate, Integer), CType(image.Height * dRate, Integer))

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
        ' スクロールロック中
        If flgScrollR = 0 Then
            Return
        End If

        ' URI_lolcounter = New Uri("http://www.lolcounter.com/champions/" & ComboBox2.Text.Replace(" "c, "-"c).Replace("'"c, "").Replace("."c, "").ToLower)
        URI_lolcounter = New Uri(URL_RIGHT_WEB & ComboBox2.Text.Replace(" "c, "").Replace("'"c, "").Replace("."c, "").ToLower)
        ' 直前にロードしたページと同じなら再表示せず検索のみ
        If URI_lolcounter = Bef_URI1 Then
            Search(s, WebBrowser1)
            flgScrollR = 1
            Return
        End If
        Bef_URI1 = URI_lolcounter
        WebBrowser1.Visible = False
        Try
            WebBrowser1.Navigate(URI_lolcounter)
        Catch ex As System.UriFormatException
            flgScrollR = 1
            Return
        End Try
        flgScrollR = 1
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
        ' スクロールロック中
        If flgScrollL = 0 Then
            Return
        End If

        ' URI作成
        If ComboBox2.Text = "Wukong" Then
            URI_champgg = New Uri(URL_LEFT_WEB & "MonkeyKing/" & ComboBox1.Text)
        Else
            URI_champgg = New Uri(URL_LEFT_WEB & ComboBox2.Text.Replace(" "c, "").Replace("'"c, "").Replace("."c, "") & "/" & ComboBox1.Text)
        End If

        ' 直前にロードしたページと同じなら再表示せず検索のみ
        If URI_champgg = Bef_URI2 Then
            Search(s, WebBrowser2)
            flgScrollL = 0
            Return
        End If
        WebBrowser2.Visible = False
        strSearchLeft = s
        Bef_URI2 = URI_champgg
        Try
            WebBrowser2.Navigate(URI_champgg)
        Catch ex As System.UriFormatException
            flgScrollL = 0
            Return
        End Try
        flgScrollL = 0
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

    ' Counter ボタン
    Private Sub Button_Counter_MouseEnter(sender As Object, e As EventArgs) Handles Button_Counter.MouseEnter
        flgScrollR = 1
        ChangeBtColor(CType(sender, Button), 1)
    End Sub

    Private Sub Button_Counter_MouseLeave(sender As Object, e As EventArgs) Handles Button_Counter.MouseLeave
        ChangeBtColor(CType(sender, Button), 0)
    End Sub

    ' Lane ボタン
    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        ChangeBtColor(CType(sender, Button), 1)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        ChangeBtColor(CType(sender, Button), 0)
    End Sub

    ' Champ ボタン
    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        ChangeBtColor(CType(sender, Button), 1)
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        ChangeBtColor(CType(sender, Button), 0)
    End Sub

    ' Mastery ボタン
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button_Mastery.Click
        flgScrollL = 1
        OpenWebLeft(SEARCH_MASTERY)
    End Sub

    Private Sub Button_Mastery_MouseEnter(sender As Object, e As EventArgs) Handles Button_Mastery.MouseEnter
        ChangeBtColor(CType(sender, Button), 1)
    End Sub

    Private Sub Button_Mastery_MouseLeave(sender As Object, e As EventArgs) Handles Button_Mastery.MouseLeave
        ChangeBtColor(CType(sender, Button), 0)
    End Sub

    ' Skill Order ボタン
    Private Sub Button_Skill_Click(sender As Object, e As EventArgs) Handles Button_Skill.Click
        flgScrollL = 1
        OpenWebLeft(SEARCH_SKILL)
    End Sub

    Private Sub Button_Skill_MouseEnter(sender As Object, e As EventArgs) Handles Button_Skill.MouseEnter
        ChangeBtColor(CType(sender, Button), 1)
    End Sub

    Private Sub Button_Skill_MouseLeave(sender As Object, e As EventArgs) Handles Button_Skill.MouseLeave
        ChangeBtColor(CType(sender, Button), 0)
    End Sub

    ' Rune ボタン
    Private Sub Button_Rune_Click(sender As Object, e As EventArgs) Handles Button_Rune.Click
        flgScrollL = 1
        OpenWebLeft(SEARCH_RUNE)
    End Sub

    Private Sub Button_Rune_MouseEnter(sender As Object, e As EventArgs) Handles Button_Rune.MouseEnter
        ChangeBtColor(CType(sender, Button), 1)
    End Sub

    Private Sub Button_Rune_MouseLeave(sender As Object, e As EventArgs) Handles Button_Rune.MouseLeave
        ChangeBtColor(CType(sender, Button), 0)
    End Sub

    ' Build ボタン
    Private Sub Build_Click(sender As Object, e As EventArgs) Handles Build.Click
        flgScrollL = 1
        OpenWebLeft(SEARCH_BUILD)
    End Sub

    Private Sub Build_MouseEnter(sender As Object, e As EventArgs) Handles Build.MouseEnter
        ChangeBtColor(CType(sender, Button), 1)
    End Sub

    Private Sub Build_MouseLeave(sender As Object, e As EventArgs) Handles Build.MouseLeave
        ChangeBtColor(CType(sender, Button), 0)
    End Sub

    ' **********************************************
    ' **  関数名 : チャンプコンボボックス更新     **
    ' **                                          **
    ' **  引数1  : レーン（省略可）               **
    ' **  引数2  : ロール（省略可）               **
    ' **********************************************
    Private Sub updateChampCombo(Optional ByVal l As Integer = 0, Optional ByVal r As Byte = 0)
        ' 直前に選択されていたチャンプ名
        Dim Bef_champ As String = ComboBox2.Text
        Dim i As Integer
        Debug.Print("Bef = " & ComboBox2.Text)

        ' -- チャンプ検索
        SearchChamp(l, r)

        If Champions.Count = 0 Then
            ' -- チャンプなしの場合
            MessageBox.Show("no match champion", "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            ' レーン初期化
            ComboBox1.SelectedIndex = 0
            ' ロール初期化
            For i = 0 To Role_ListBox.Items.Count - 1
                Role_ListBox.SetItemChecked(i, False)
            Next
            ' チャンプコンボボックス初期化
            SearchChamp()
        End If

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

    ' -- レーンコンボボックス
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' 色変更
        Dim Combo As ComboBox = sender
        Combo.BackColor = COMB_BK_COL(Combo.SelectedIndex)
        updateChampCombo(Combo.SelectedIndex, GetRoleState(Role_ListBox))

    End Sub

    ' **********************************************
    ' **  関数名 : フォーム再描画                 **
    ' **                                          **
    ' **  引数1  : フォーム倍率                   **
    ' **********************************************
    Private Sub displayForm(ByVal r As Decimal)
        PictureBox1.Width = Me.Width - 20
        PictureBox1.Height = Me.Height - 40
        WebBrowser1.Left = Me.Width / 2
        WebBrowser1.Width = iniRBrowserWidth * r
        WebBrowser1.Height = iniRBrowserHeight * r
        WebBrowser2.Width = iniLBrowserWidth * r
        WebBrowser2.Height = iniLBrowserHeight * r
        Label1.Left = Me.Width - Label1.Width - 30
        Label2.Left = Me.Width - Label2.Width - 30
        CheckBox_Topmost.Left = Me.Width - CheckBox_Topmost.Width - 30
        Button_Counter.Left = Me.Width - Button_Counter.Width - 30
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Normal Then
            ' 通常サイズ
            dRate = 0.5
            displayForm(1.0)

            ' 再描画
            DrawBackPicture(SetBackURL(ComboBox2.Text))
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            ' 最大化
            ' 倍率取得
            rateForm = Me.Width / iniFormWidth

            dRate = 0.5
            displayForm(rateForm)

            ' 再描画
            DrawBackPicture(SetBackURL(ComboBox2.Text))
        End If
    End Sub

    ' レーンコンボボックス描画
    Private Sub ComboBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox1.DrawItem
        If e.Index = -1 Then Exit Sub

        Dim Combo As ComboBox = sender
        Dim TextBrush As Brush = Brushes.White
        Dim TextString As String = Combo.Items(e.Index).ToString
        Dim sf As SizeF = e.Graphics.MeasureString(TextString, e.Font)

        Combo.BackColor = COMB_BK_COL(0)

        Dim TextRect As RectangleF  '文字領域の設定
        With TextRect
            '.X = (e.Bounds.Width - CInt(sf.Width)) \ 2
            .X = e.Bounds.X
            .Y = e.Bounds.Y
            .Width = e.Bounds.Width
            .Height = e.Bounds.Height
        End With

        Dim BackRect As RectangleF  '背景領域の設定
        With BackRect
            .X = e.Bounds.X
            .Y = e.Bounds.Y + e.Bounds.Height * 0.8
            .Width = e.Bounds.Width
            .Height = e.Bounds.Height / 5
        End With

        e.DrawBackground()      'フォーカス背景色描画用

        '文字の描画
        e.Graphics.FillRectangle(New SolidBrush(COMB_BK_COL(e.Index)), BackRect)
        e.Graphics.DrawString(TextString, e.Font, TextBrush, TextRect)

        e.DrawFocusRectangle()  'フォーカス背景色描画用
    End Sub

    ' **********************************************
    ' **  関数名 : チャンプ名変換（英→日）       **
    ' **                                          **
    ' **  引数1  : チャンプ名（英語）             **
    ' **********************************************
    Private Function TransEnToJp(e As String)
        Dim i As Integer
        Dim ret As String = ""

        For i = 0 To ChampList.Count - 1
            If ChampList(i).Name = e Then
                ret = ChampList(i).JpName
                Exit For
            End If
        Next

        Return ret
    End Function

    Private Sub CheckBox_Topmost_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Topmost.CheckedChanged
        Me.TopMost = Not Me.TopMost
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Clipboard.SetText(TransEnToJp(ComboBox2.Text))
    End Sub

    Private Sub Role_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Role_ListBox.SelectedIndexChanged
        updateChampCombo(ComboBox1.SelectedIndex, GetRoleState(CType(sender, CheckedListBox)))
    End Sub
End Class
