using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class SongData
{
    public string title = null;
    public string artist = null;
    public int highScore;
    public int highStreak;

    public SongData(Song song)
    {
        title = song.title;
        artist = song.artist;
        highScore = song.highScore;
        highStreak = song.highStreak;

    }
}
