using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private float shootDistance;
    private float TargetDistance;
    private Vector3 MoveSpeedBefore;
    private Vector3 MoveSpeedNow;
    private Vector3 MoveSpeedAfter;
    [SerializeField]
    private GameObject BulletObject;
    [SerializeField]
    private EnemyManager enemyManager;
    private GameObject Child;
    private float maxUpAngle;
    private float maxDownAngle;
    void Start()
    {
        maxUpAngle = enemyManager.GetWeapon(this.gameObject.name).GetMaxUpAngle();
        maxDownAngle = enemyManager.GetWeapon(this.gameObject.name).GetMaxDownAngle();
        Debug.Log(enemyManager.GetWeapon(this.gameObject.name).GetWeaponName() + ": " + enemyManager.GetWeapon(this.gameObject.name).GetWeaponInformation());
        InvokeRepeating("shoot", Random.value, enemyManager.GetWeapon(this.gameObject.name).GetWeaponFireRate());
    }
    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, playerObj.transform.position) < shootDistance)
        {
            MoveSpeedNow = playerObj.transform.position - MoveSpeedBefore;
            MoveSpeedBefore = playerObj.transform.position;
            TargetDistance = Vector3.Distance(this.transform.position, playerObj.transform.position);
            MoveSpeedAfter = MoveSpeedNow * TargetDistance / enemyManager.GetWeapon(this.gameObject.name).GetBulletSpeed() / Time.deltaTime + playerObj.transform.position;
            transform.LookAt(MoveSpeedBefore);
            AngleControl();
        }
    }
    void shoot()
    {
        if(Vector3.Distance(this.transform.position, playerObj.transform.position) < shootDistance && PlayerC_3D.PlayerLife > 0)
        {
            transform.LookAt(MoveSpeedAfter);
            AngleControl();
            Child = Instantiate(BulletObject, transform.forward * 2.5f + transform.position, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, -90));
            Child.name = this.gameObject.name;
        }
    }
    void AngleControl()
    {
        if (transform.localEulerAngles.x <= maxUpAngle && transform.localEulerAngles.x > 190)
        {
            transform.localEulerAngles = new Vector3(maxUpAngle, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        else if (transform.localEulerAngles.x >= maxDownAngle && transform.localEulerAngles.x < 170)
        {
            transform.localEulerAngles = new Vector3(maxDownAngle, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }
}
