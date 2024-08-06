using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerDataBase playerDataBase;

    private Dictionary<PlayerData, int> numOfPlayer = new Dictionary<PlayerData, int>();
    public PlayerData GetPlayer(string searchPlayerName)
    {
        return playerDataBase.GetPlayerLists().Find(playerName => playerName.GetPlayerName() == searchPlayerName);
    }
}
