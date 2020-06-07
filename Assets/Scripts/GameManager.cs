using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioSource music;
   
    public static GameManager instance;

    Song song;
    SongData songData;
    public string songTitle;
    public string songArtist;
    public TMPro.TMP_Text titleText;

    public int currentPoints;
    public int pointsPerNote = 10;
    public TMPro.TMP_Text pointsText;

    public int streak;
    public int highStreak;
    public TMPro.TMP_Text streakText;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public float totalNotes;
    public float missedNotes;

    public GameObject resultsScreen;
    public TMPro.TMP_Text finalSongName, finalPointsText, missedText, rankText, highScoreText, highStreakText;
    void Start()
    {
        instance = this;

        song = new Song();

        pointsText.text = "POINTS: " + 0;
        streakText.text = "STREAK: " + 0;
        titleText.text = songTitle + " - " + songArtist;

        currentMultiplier = 1;

        music.Play();

        totalNotes = FindObjectsOfType<NoteObject>().Length;

        resultsScreen.SetActive(false);

        LoadSong();

    }

    void Update()
    {
        if (!music.isPlaying && !resultsScreen.activeInHierarchy && !PauseMenu.Paused )
        {
            resultsScreen.SetActive(true);

            finalPointsText.text = "POINTS: " + currentPoints;
            missedText.text = "MISSED NOTES: " + missedNotes;

            float percent = ((totalNotes - missedNotes) / totalNotes) * 100f;
            var rankVal = "F";

            if(percent > 40)
            {
                rankVal = "D";
                if (percent > 55)
                {
                    rankVal = "C";
                    if (percent > 70)
                    {
                        rankVal = "B";
                        if (percent > 85)
                        {
                            rankVal = "A";
                            if (percent > 90)
                            {
                                rankVal = "S";
                                if (percent > 95)
                                {
                                    rankVal = "S+";
                                }
                            }
                        }
                    }
                }
            }

            rankText.text = "RANK: " + rankVal;


            SaveSong(songData);

            highScoreText.text = "HIGH SCORE: " + song.highScore;
            highStreakText.text = "HIGH STREAK: " + song.highStreak;

            finalSongName.text = songData.title + " - " + songData.artist;
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit");

        if (highStreak == streak)
        {
            highStreak++;
        }

        streak ++;
        if(currentMultiplier-1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        currentPoints += pointsPerNote * currentMultiplier;
        streakText.text = "STREAK: " + streak;
        pointsText.text = "POINTS: " + currentPoints;

        
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");
        streak = 0;
        streakText.text = "STREAK: " + streak;
        missedNotes++;
        
        
    }


    public void SaveSong(SongData songData)
    {

        if(songData.highScore < currentPoints)
        {
            song.highScore = currentPoints;
        }
        else
        {
            song.highScore = songData.highScore;
        }

        if(songData.highStreak < highStreak)
        {
            song.highStreak = highStreak;
        }
        else
        {
            song.highStreak = songData.highStreak;
        }

        SaveSystem.SaveSong(song);
    }

    public void LoadSong()
    {
        songData = SaveSystem.LoadSong(songTitle, songArtist);

        song.artist = songData.artist;
        song.title = songData.title;
        song.highScore = songData.highScore;
        song.highStreak = songData.highStreak;
    }
}
