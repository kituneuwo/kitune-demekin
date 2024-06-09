using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
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
    void Start()
    {
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
        rb.AddTorque(0, 0, Random.value - 0.5f * torque, ForceMode.Acceleration);
        rb.AddForce(-Vector3.right * speed * power * Random.value, ForceMode.Acceleration);
        rb.AddForce(Vector3.up * speed * power * plus * Random.value, ForceMode.Acceleration);
        Invoke("DestroyBullet", DeathTime);
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
