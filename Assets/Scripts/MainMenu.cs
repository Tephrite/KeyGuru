using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad;
    public SceneFader sceneFader;

    // Start is called before the first frame update
    public void PlayGame()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
