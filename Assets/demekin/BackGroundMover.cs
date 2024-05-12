using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
    void Update()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
