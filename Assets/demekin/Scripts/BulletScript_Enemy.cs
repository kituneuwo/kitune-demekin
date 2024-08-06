using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript_Enemy : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float power;
    [SerializeField]
    private float torque;
    [SerializeField]
    private float DeathTime;
    private float LengthTime;
    [SerializeField]
    private float plus;
    private float RandomNumber;
    [SerializeField]
    private EnemyManager enemyManager;
    private float AnglePlusX;
    private float AnglePlusY;
    private EnemyScript enemyScript;
    private bool IsCreate;
    void Start()
    {
        IsCreate = false;
        AnglePlusX = Random.Range(-enemyManager.GetWeapon(this.gameObject.name).GetBulletAccuracy() / 10, enemyManager.GetWeapon(this.gameObject.name).GetBulletAccuracy() / 10);
        AnglePlusY = Random.Range(-enemyManager.GetWeapon(this.gameObject.name).GetBulletAccuracy() / 10, enemyManager.GetWeapon(this.gameObject.name).GetBulletAccuracy() / 10);
        transform.rotation = Quaternion.Euler(transform.localEulerAngles.x + AnglePlusX, transform.localEulerAngles.y + AnglePlusY, transform.localEulerAngles.z);
        LengthTime = enemyManager.GetWeapon(this.gameObject.name).GetBulletDeathTime();
        speed = enemyManager.GetWeapon(this.gameObject.name).GetBulletSpeed();
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        this.gameObject.transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 90, transform.localEulerAngles.z);
        Invoke("DestroyBullet", LengthTime);
        IsCreate = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Default") && IsCreate && rb != null)
        {
            rb.useGravity = true;
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddTorque(Random.value - 0.5f * torque, Random.value - 0.5f * torque, Random.value - 0.5f * torque, ForceMode.Acceleration);
            RandomNumber = Random.value - 0.5f;
            rb.AddForce(Vector3.forward * speed * power * RandomNumber, ForceMode.Acceleration);
            RandomNumber = Random.value - 0.5f;
            rb.AddForce(Vector3.right * speed * power * RandomNumber, ForceMode.Acceleration);
            RandomNumber = Random.value - 0.5f;
            rb.AddForce(Vector3.up * speed * power * RandomNumber, ForceMode.Acceleration);
            Invoke("DestroyBullet", DeathTime);
            if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                PlayerScript.PlayerLife -= enemyManager.GetWeapon(this.gameObject.name).GetWeaponDamage();
                if(PlayerScript.PlayerLife > 0)
                {
                    Debug.Log(PlayerScript.PlayerLife);
                }
                else
                {

                }
            }
        }
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
