using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public int points;
    public int streak;

    public PlayerData(Player player)
    {
        points = player.points;
        streak = player.streak;

    }
}
