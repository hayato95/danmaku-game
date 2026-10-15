# danmaku-game(弾幕STG)

Unity 6 で作っている、2D 縦スクロールの弾幕シューティングです。趣味で作る 1 本目で、Unity WebGL で公開することを目指しています(目標は 2026 年内)。

> 開発中です。まだ公開していないので、遊べる URL はありません。公開したら、ここに載せます。

## 遊び方(今の状態)

| 操作 | 内容 |
|---|---|
| マウスの移動 | 自機がカーソルに追従する |
| 左クリック | 自機の弾を撃つ(今は押すたびに 1 発) |
| P キー | ポーズ |

敵の弾に 1 発当たるとゲームオーバーです。ステージは 1 つで、ウェーブを抜けるとボスが出ます。

ボム(右クリック)、残機、スコア、音、難易度は、これから入れます。

## これから入れるもの

決めた仕様は [docs/requirements.md](docs/requirements.md) に、番号(R-01 など)を付けて書いています。

- 被弾ルール: 残機 3、被弾後 2 秒の無敵、ボム 3 つ(右クリック)
- 自動連射、スコア、ハイスコア(ブラウザ内に保存)
- BGM と効果音、音量の設定画面
- 3 ステージ、難易度 3 段階(「ふつう」「とってもむずかしい」「極」)

## 開発の進み方

マイルストーンと issue で管理しています。

| マイルストーン | 期限 | 内容 |
|---|---|---|
| [M1 被弾ルールと基盤](https://github.com/hayato95/danmaku-game/milestone/1) | 2026-10-31 | 残機・無敵・ボム・HUD、ボス撃破からの遷移、WebGL の初回確認 |
| [M2 スコアと連射](https://github.com/hayato95/danmaku-game/milestone/2) | 2026-11-10 | 自動連射、スコア、ハイスコア |
| [M3 音と設定](https://github.com/hayato95/danmaku-game/milestone/3) | 2026-11-20 | BGM・効果音、設定画面 |
| [M4 ステージ2・3と難易度](https://github.com/hayato95/danmaku-game/milestone/4) | 2026-12-10 | ステージ 2・3、難易度 |
| [M5 WebGL調整と公開](https://github.com/hayato95/danmaku-game/milestone/5) | 2026-12-31 | WebGL の最終調整と公開 |

issue のラベルは 4 種類です。

- `優先度:` 必須 / 推奨 / 余裕があれば
- `担当:` スクリプト / Unityエディタ / 両方 / ドキュメント
- `難易度:` Lv1(目玉焼き級)から Lv5(ABC-D級)まで
- `状態:要詳細化`: ざっくり案の issue。着手前に、完了条件と数値を詰める

M1 の issue は、「誰がやっても同じ挙動になる」粒度まで書いています。M2 以降は、仕様が決まった順に詰めます。

## 環境

- Unity 6(6000.3.11f1)
- URP 17.3 / Input System 1.19 / Test Framework 1.6
- 対象: PC のブラウザ(WebGL)

## フォルダ構成

```
Assets/
  Scenes/    TitleScene / GameScene / GameOverScene / StageClearScene
  Scripts/   C# スクリプト(平置き)
docs/
  requirements.md   要件定義書(決めた仕様と、未決事項)
CLAUDE.md           Claude Code 向けのプロジェクト指示
```

## 開発の注意

- `Assets/Scripts/*.cs` は UTF-8(BOM なし)で保存します。
- 作業ツリーの改行は CRLF、Git のオブジェクトは LF です。差分が全行に出たときは、`git diff --ignore-space-at-eol` で確認します。
- シーンと Prefab(`.unity` `.prefab`)は YAML です。手で編集せず、Unity エディタ上で変更します。
- Unity と Claude Code の連携には、公式の Unity MCP(`com.unity.ai.assistant`)を使っています(R-22)。

## ライセンス

未定です。公開するときに決めます。
