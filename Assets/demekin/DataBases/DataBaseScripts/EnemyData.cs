using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Datas", menuName = "CreateEnemyData")]
public class EnemyData : ScriptableObject
{
    public enum KindOfEnemy
    {
        Enemy,
        Boss,
        RareEnemy
    }
    [SerializeField]
    private KindOfEnemy kindOfEnemy;
    [SerializeField]
    private string EnemyName;
    [SerializeField]
    private string EnemyInformation;
    [SerializeField]
    private int EnemyLife;
    [SerializeField]
    private int EnemyDamage;
    [SerializeField]
    private float EnemySpeed;

    public KindOfEnemy GetKindOfEnemy()
    {
        return kindOfEnemy;
    }

    public string GetEnemyName()
    {
        return EnemyName;
    }
    public string GetEnemyInformation()
    {
        return EnemyInformation;
    }
    public int GetEnemyLife()
    {
        return EnemyLife;
    }
    public int GetEnemyDamage()
    {
        return EnemyDamage;
    }
    public float GetEnemySpeed()
    {
        return EnemySpeed;
    }
}
