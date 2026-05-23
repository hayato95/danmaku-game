using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearManager : MonoBehaviour
{
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnTitleButtonClicked()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
