using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject pauseMenuUI;
    public AudioSource song;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Pause();
            
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        song.Play();
        Paused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        song.Pause();
        Paused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("GameSelect");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
        
          
    }
}
