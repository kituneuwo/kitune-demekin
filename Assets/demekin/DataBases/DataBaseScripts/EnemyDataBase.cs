using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataBases", menuName = "CreateEnemyDataBase")]
public class EnemyDataBase : ScriptableObject
{
    [SerializeField]
    private List<EnemyData> enemyLists = new List<EnemyData>();

    public List<EnemyData> GetEnemyLists()
    {
        return enemyLists;
    }
}
