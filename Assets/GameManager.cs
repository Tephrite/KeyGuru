using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player player;
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }
    
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        player.points = data.points;
        player.streak = data.streak;
    }

}
