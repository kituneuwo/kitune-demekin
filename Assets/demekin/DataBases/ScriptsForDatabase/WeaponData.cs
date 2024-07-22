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
    private float WeaponFireRate;
    [SerializeField]
    private float BulletSpeed;
    [SerializeField]
    private float BulletDeathTime;
    [SerializeField]
    private int maxUpAngle;
    [SerializeField]
    private int maxDownAngle;
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
    public float GetWeaponFireRate()
    {
        return WeaponFireRate;
    }
    public float GetBulletSpeed()
    {
        return BulletSpeed;
    }
    public float GetBulletDeathTime()
    {
        return BulletDeathTime;
    }
    public int GetMaxUpAngle()
    {
        return maxUpAngle;
    }
    public int GetMaxDownAngle()
    {
        return maxDownAngle;
    }
}
