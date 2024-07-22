using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private EnemyDataBase enemyDataBase;

    private Dictionary<EnemyData, int> numOfEnemy = new Dictionary<EnemyData, int>();
    public EnemyData GetEnemy(string searchEnemyName)
    {
        return enemyDataBase.GetEnemyLists().Find(enemyName => enemyName.GetEnemyName() == searchEnemyName);
    }

    private Dictionary<WeaponData, int> numOfWeapon = new Dictionary<WeaponData, int>();
    public WeaponData GetWeapon(string searchWeaponName)
    {
        return enemyDataBase.GetWeaponLists().Find(weaponName => weaponName.GetWeaponName() == searchWeaponName);
    }
}
