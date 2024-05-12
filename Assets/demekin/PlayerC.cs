using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float MaxY;
    [SerializeField]
    private float MinY;
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < MaxY)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > MinY)
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
    }
}
