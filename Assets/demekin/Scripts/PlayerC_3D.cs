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
    private float StageSpeed;
    [SerializeField]
    private float torque;
    private Rigidbody rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, Movespeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, Movespeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, Movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, -Movespeed * Time.deltaTime);
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
        transform.position += new Vector3(StageSpeed * Time.deltaTime, 0, 0);
    }
}
