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
    void Start()
    {
        
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
            Instantiate(BulletObject, new Vector3(transform.position.x + 2.6f, transform.position.y + 0.075f, transform.position.z), Quaternion.Euler(0, 0, -90));
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(EnemyObject, new Vector3(transform.position.x + 15, transform.position.y, transform.position.z), Quaternion.Euler(0, 90, 0));
        }
    }
}
