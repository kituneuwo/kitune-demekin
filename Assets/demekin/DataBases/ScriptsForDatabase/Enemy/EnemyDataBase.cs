using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataBases", menuName = "CreateEnemyDataBase")]
public class EnemyDataBase : ScriptableObject
{
    [SerializeField]
    private List<EnemyData> enemyLists = new List<EnemyData>();
    [SerializeField]
    private List<WeaponData> weaponLists = new List<WeaponData>();

    public List<EnemyData> GetEnemyLists()
    {
        return enemyLists;
    }
    public List<WeaponData> GetWeaponLists()
    {
        return weaponLists;
    }
}
