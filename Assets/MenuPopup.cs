using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopup : MonoBehaviour
{

    public GameObject popupUI;
    public TMPro.TMP_Text artist;
    public TMPro.TMP_Text title;
    public TMPro.TMP_Text highScore;
    public TMPro.TMP_Text highStreak;

    string test = "lol";

    public void LoadSong()
    {
        popupUI.SetActive(true);
        artist.text = "ARTIST: " + test;
        title.text = "TITLE: " + test;
        highScore.text = "HIGH SCORE: " + test;
        highStreak.text = "HIGH STREAK: " + test;

    }
}
