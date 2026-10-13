# danmaku-game

Unity 2D 縦スクロール弾幕STG(東方Project inspired / SF・宇宙・メカ)。個人開発。公開先は itch.io (WebGL)。

## 環境

- Unity `6000.3.11f1` / URP 2D / New Input System(`UnityEngine.Input` は使えない。`Mouse.current` / `Keyboard.current` 経由)
- 解像度 9:16 縦画面。TextMeshPro 使用
- シーン: `TitleScene`(0) → `GameScene`(1) → `GameOverScene`(2) / `StageClearScene`(3)
- Unity Editor が無い環境では、コンパイル確認・実行・シーン編集はできない。スクリプトの読み書きまで

## ディレクトリ

- `Assets/Scripts/` — C# 全般(`Enemy` 抽象基底 → `EnemyStraight` / `EnemyHoming` / `EnemyFloat` / `EnemyCircleOrbit` / `Boss`)
- `Assets/Scripts/BulletPatternManager.cs` — 弾幕パターン(Aimed / Spread / Straight / AllDirections / Spiral)
- `Assets/Scripts/WaveManager.cs`, `WaveData.cs` — Wave進行。`WaveData[] waves` をInspectorで設定
- `Assets/Prefabs/`, `Assets/Scenes/`
- `Assets/_Recovery/` は Unity の自動復旧ファイル。編集対象外

## コーディング規約

- 文字コード UTF-8 / 改行 LF(`.editorconfig` 参照)。Shift-JIS で保存しない
- private フィールド: camelCase。Inspector公開は `[SerializeField] private`
- public メソッド: XMLドキュメントコメント(`///`)。private メソッド: `//` コメント
- 死亡処理は `OnDied()` に一元化(`Die()` ではなく)
- 境界・残数チェックは `== 0` でなく `<= 0`
- コメントは日本語、設計判断は「なぜ」を書く

## Git

- コミットメッセージ: conventional commits + 日本語説明(`feat:` / `fix:` / `refactor:` / `chore:`)
- **コミット・PRに Co-Authored-By 等のAI署名は付けない**
- シーン・Prefab は YAML で差分が大きい。変更前にコミットして戻れる状態にする

## Unity の既知の地雷

- `transform.position.y -= v` はコンパイルエラー。`transform.position = new Vector3(x, y - v, z)` と全体代入する
- `[SerializeField]` のデフォルト値は Prefab / シーンの保存値で上書きされる。変更後は Inspector を確認
- `Rigidbody2D` の速度は `linearVelocity`(`velocity` は旧API)
- `Time.timeScale = 0` でも `Update()` は呼ばれ続ける(`deltaTime` が 0 になるだけ)
- UnityEvent(OnClick)に登録するメソッドは `public` にする
- スクリプトの改名・移動は `.meta` の GUID を保ったまま行う(シーン / Prefab の参照が切れる)

## 現状(2026-10 時点の実測)

- 実装済み: 移動(マウス追尾)・射撃、雑魚4種、ボス3フェーズ、Wave進行、ポーズ(Pキー)、リトライ、各シーン遷移UI
- **未実装 / 要確認**
  - ボス撃破 → `StageClearScene` への遷移コードが無い(`Boss.OnDied()` は `Destroy` のみ)
  - コミット済み `GameScene.unity` は旧 `WaveManager` フィールドのまま。`waves` 配列が未設定で、Wave を飛ばして即ボスが出る状態
  - スコア、SE/BGM、エフェクト、スプライト(`Assets/Sprites` は `.meta` のみで実体が無い)
  - 自動テスト(Test Framework は導入済みだがテスト無し)
- `Boss.Start()` が `bulletSpeed` / `fireInterval` を直書きし、Inspector値を上書きしている
- `EnemySpawner.cs` は未使用(WaveManager に置換済み)

## MCP for Unity

`Packages/manifest.json` に `com.coplaydev.unity-mcp`(`v10.0.0` 固定)を追加済み。ローカルの Claude Code から Unity Editor を起動した状態で接続して使う。クラウドセッションからは接続できない。
