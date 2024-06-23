using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC_3D : MonoBehaviour
{
    [SerializeField]
    private float Movespeed;
    [SerializeField]
    private GameObject EnemyObject;
    [SerializeField]
    private GameObject BulletObject;
    [SerializeField]
    private float torque;
    private Rigidbody rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddForce(transform.forward * Movespeed * Time.deltaTime, ForceMode.VelocityChange);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(-torque, 0, 0));
            //rb.AddTorque(torque, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(torque, 0, 0));
            //rb.AddTorque(-torque, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -torque, 0), Space.World);
            //rb.AddTorque(0, -torque, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, torque, 0), Space.World);
            //rb.AddTorque(0, torque, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(BulletObject, transform.forward * -2.4f + transform.position, Quaternion.Euler(0, transform.localEulerAngles.y, -90));
        }
        if (Input.GetKey(KeyCode.I))
        {
            var obj = Instantiate(EnemyObject, transform.forward * -15f + transform.position, Quaternion.Euler(0, transform.localEulerAngles.y + 180, 0));
            obj.name = EnemyObject.name;
        }
    }
}
