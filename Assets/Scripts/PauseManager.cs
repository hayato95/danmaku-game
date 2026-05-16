using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{

    bool isPaused = false;

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }


    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
