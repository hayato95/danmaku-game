using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManager : MonoBehaviour
{
   public void RetryGameButtonClicked()
    {
        SceneManager.LoadScene("GameScene");

    }
}
