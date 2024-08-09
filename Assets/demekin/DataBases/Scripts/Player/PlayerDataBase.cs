using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataBases", menuName = "CreatePlayerDataBase")]
public class PlayerDataBase : ScriptableObject
{
    [SerializeField]
    private List<PlayerData> playerLists = new List<PlayerData>();

    public List<PlayerData> GetPlayerLists()
    {
        return playerLists;
    }
}
