using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{

    public bool isPaused = false;
    public static PauseManager Instance { get; private set; }


    private void Awake()
    {
        Instance = this;  
    }

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
