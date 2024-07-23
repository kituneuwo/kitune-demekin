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
    private float BulletSize;
    [SerializeField]
    private float BulletDeathTime;
    [SerializeField]
    private int maxUpAngle;
    [SerializeField]
    private int maxDownAngle;
    [SerializeField]
    private int ShotVolume;
    [SerializeField]
    private float BulletAccuracy;
    [SerializeField]
    private int ShootDistance;

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
    public float GetBulletSize()
    {
        return BulletSize;
    }
    public float GetShotVolume()
    {
        return ShotVolume;
    }
    public float GetBulletAccuracy()
    {
        return BulletAccuracy;
    }
    public int GetShootDistance()
    {
        return ShootDistance;
    }
}
