using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }


    public void OnSettingsButtonClicked()
    {
        // 設定画面への遷移処理をここに追加
    }
}