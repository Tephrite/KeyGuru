using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;
    public string levelName;
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

    public void Select()
    {
        fader.FadeTo(levelName);
    }

}
