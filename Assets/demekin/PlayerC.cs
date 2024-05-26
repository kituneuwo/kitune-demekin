using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float MinX;
    [SerializeField]
    private float MaxX;
    [SerializeField]
    private float MaxY;
    [SerializeField]
    private float MinY;
    [SerializeField]
    private GameObject EnemyObject;
    [SerializeField]
    private GameObject BulletObject;
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < MaxY)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > MinY)
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < MaxX)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > MinX)
        {
            transform.position += new Vector3(-speed * Time.deltaTime,0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletObject, new Vector3(transform.position.x + 2.6f, transform.position.y + 0.075f, transform.position.z), Quaternion.Euler(0,0,-90));
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(EnemyObject, new Vector3(transform.position.x + 15, transform.position.y, transform.position.z), Quaternion.Euler(0, 90, 0));
        }
    }
}
