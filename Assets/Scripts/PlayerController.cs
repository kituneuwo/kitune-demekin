using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    void Update()
    {
        this.transform.position += new Vector3(speed, 0, 0);
    }
}
