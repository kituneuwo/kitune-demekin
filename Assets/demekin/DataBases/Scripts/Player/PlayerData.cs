using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "PlayerData", menuName = "CreatePlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private string PlayerName;
    [SerializeField,TextArea]
    private string PlayerInformation;
    [SerializeField]
    private float PlayerLife;
    [SerializeField]
    private float PlayerSpeed;
    [SerializeField]
    private float PlayerTurnSpeed;
    [SerializeField]
    private float PlayerDamage;
    [SerializeField]
    private float PlayerBulletSpeed;
    [SerializeField]
    private float PlayerBulletDTime;

    public string GetPlayerName()
    {
        return PlayerName;
    }
    public string GetPlayerInformation()
    {
        return PlayerInformation;
    }
    public float GetPlayerLife()
    {
        return PlayerLife;
    }
    public float GetPlayerSpeed()
    {
        return PlayerSpeed;
    }
    public float GetPlayerTurnSpeed()
    {
        return PlayerTurnSpeed;
    }
    public float GetPlayerDamage()
    {
        return PlayerDamage;
    }
    public float GetPlayerBulletSpeed()
    {
        return PlayerBulletSpeed;
    }
    public float GetPlayerBulletDTime()
    {
        return PlayerBulletDTime;
    }
}
