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
        Object,
        Enemy,
        Boss,
        RareEnemy
    }
    [SerializeField]
    private KindOfEnemy kindOfEnemy;
    [SerializeField]
    private string EnemyName;
    [SerializeField,TextArea]
    private string EnemyInformation;
    [SerializeField]
    private int EnemyLife;
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
    public float GetEnemySpeed()
    {
        return EnemySpeed;
    }
}
