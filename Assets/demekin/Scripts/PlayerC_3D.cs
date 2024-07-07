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
    private GameObject RotateObject;
    [SerializeField, Range(0f, 1f)]
    private float RotateSpeed;
    private Rigidbody rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.position += transform.forward * Movespeed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, RotateObject.transform.rotation, RotateSpeed);
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(BulletObject, transform.forward * 2.5f + transform.position, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, -90));
        }
        if (Input.GetKey(KeyCode.I))
        {
            var obj = Instantiate(EnemyObject, transform.forward * -15f + transform.position, Quaternion.Euler(0, transform.localEulerAngles.y + 180, 0));
            obj.name = EnemyObject.name;
        }
    }
}
