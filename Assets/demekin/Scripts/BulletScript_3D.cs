using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript_3D : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    public float BulletSpeed { 
        get { return speed; }
    }
    [SerializeField]
    private float power;
    [SerializeField]
    private float torque;
    [SerializeField]
    private float DeathTime;
    [SerializeField]
    private float LengthTime;
    [SerializeField]
    private float plus;
    private float RandomNumber;
    private Vector3 PositionBefore;
    private Vector3 PositionNow;
    void Start()
    {
        PositionBefore = transform.position;
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        Invoke("Look",0.02f);
        Invoke("DestroyBullet", LengthTime);
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
    void Look()
    {
        PositionNow = transform.position - PositionBefore;
        transform.rotation = Quaternion.LookRotation(PositionNow);
        this.gameObject.transform.eulerAngles = new Vector3(transform.localEulerAngles.x + 90, transform.localEulerAngles.y, 0);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
