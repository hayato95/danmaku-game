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
        // İ’è‰æ–Ê‚Ö‚Ì‘JˆÚˆ—‚ğ‚±‚±‚É’Ç‰Á
    }
}