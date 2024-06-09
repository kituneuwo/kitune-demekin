using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private EnemyDataBase enemyDataBase;

    private Dictionary<EnemyData, int> numOfEnemy = new Dictionary<EnemyData, int>();
    public EnemyData GetEnemy(string searchName)
    {
        return enemyDataBase.GetEnemyLists().Find(enemyName => enemyName.GetEnemyName() == searchName);
    }
}
