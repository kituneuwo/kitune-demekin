using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Datas", menuName = "CreateWeaponData")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private string WeaponName;
    [SerializeField, TextArea]
    private string WeaponInformation;
    [SerializeField]
    private int WeaponDamage;
    [SerializeField]
    private float WeaponRapidFireRate;
    [SerializeField]
    private float BulletSpeed;
    public string GetWeaponName()
    {
        return WeaponName;
    }
    public string GetWeaponInformation()
    {
        return WeaponInformation;
    }
    public int GetWeaponDamage()
    {
        return WeaponDamage;
    }
    public float GetWeaponRapidFireRate()
    {
        return WeaponRapidFireRate;
    }
    public float GetBulletSpeed()
    {
        return BulletSpeed;
    }
}
