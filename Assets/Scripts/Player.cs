using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int points = 0;
    public int streak = 0;

    public TMPro.TMP_Text pointsText = null;
    public TMPro.TMP_Text streakText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = ""+points;
        streakText.text = ""+streak;
    }
}
