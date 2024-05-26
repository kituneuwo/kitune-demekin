using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript_3D : MonoBehaviour
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
    [SerializeField]
    private float plus;
    private float RandomNumber;
    void Start()
    {
        RandomNumber = Random.value - 0.5f;
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
        Invoke("DestroyBullet", 1f);
    }

    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = true;
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddTorque(Random.value * torque, RandomNumber * torque, RandomNumber * torque, ForceMode.Acceleration);
        rb.AddForce(Vector3.forward * speed * power * RandomNumber, ForceMode.Acceleration);
        rb.AddForce(Vector3.right * speed * power * RandomNumber, ForceMode.Acceleration);
        Invoke("DestroyBullet", DeathTime);
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
