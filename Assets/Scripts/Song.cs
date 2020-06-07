using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : LevelSelector
{
    public GameObject popupUI;
    public GameObject levelSelector;

    public TMPro.TMP_Text artistText;
    public TMPro.TMP_Text titleText;
    public TMPro.TMP_Text highScoreText;
    public TMPro.TMP_Text highStreakText;
    

    public string title = null;
    public string artist = null;
    public int highScore = 0;
    public int highStreak = 0;

    public void updatePopup()
    {
        popupUI.SetActive(true);
        artistText.text = "ARTIST: " + artist;
        titleText.text = "TITLE: " + title;
        highScoreText.text = "HIGH SCORE: " + highScore;
        highStreakText.text = "HIGH STREAK: " + highStreak;

        levelSelector.GetComponent<LevelSelector>().levelName = (title + artist).Replace(" ", "");
    }

}
