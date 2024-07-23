using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private float Bulletspeed;
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private float shootDistance;
    private float TargetDistance;
    private Vector3 MoveSpeedBefore;
    private Vector3 MoveSpeedNow;
    private Vector3 MoveSpeedAfter;
    [SerializeField]
    private float limitup;
    [SerializeField]
    private float limitdown;
    [SerializeField]
    private GameObject BulletObject;
    [SerializeField]
    private EnemyManager enemyManager;
    void Start()
    {
        Debug.Log(enemyManager.GetWeapon(this.gameObject.name).GetWeaponName() + ": " + enemyManager.GetWeapon(this.gameObject.name).GetWeaponInformation());
        InvokeRepeating("shoot", 1f, enemyManager.GetWeapon(this.gameObject.name).GetWeaponRapidFireRate());
    }
    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, playerObj.transform.position) < shootDistance)
        {
            MoveSpeedNow = playerObj.transform.position - MoveSpeedBefore;
            MoveSpeedBefore = playerObj.transform.position;
            TargetDistance = Vector3.Distance(this.transform.position, playerObj.transform.position);
            MoveSpeedAfter = MoveSpeedNow * TargetDistance / Bulletspeed / Time.deltaTime + playerObj.transform.position;
            transform.LookAt(MoveSpeedAfter);
        }
    }
    void shoot()
    {
        if(Vector3.Distance(this.transform.position, playerObj.transform.position) < shootDistance && PlayerC_3D.PlayerLife > 0)
        {
            Instantiate(BulletObject, transform.forward * 2.5f + transform.position, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, -90));
        }
    }
}
