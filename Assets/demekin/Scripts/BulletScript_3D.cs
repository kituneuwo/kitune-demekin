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
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * speed, ForceMode.VelocityChange);
        this.gameObject.transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 90, transform.localEulerAngles.z);
        Invoke("DestroyBullet", 1f);
    }
    void OnCollisionEnter(Collision collision)
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
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
