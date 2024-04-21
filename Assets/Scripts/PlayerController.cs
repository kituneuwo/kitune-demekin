using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private GameObject tPlayer;
    void Start()
    {
        tPlayer = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        this.transform.position += new Vector3(0, 0, speed);
    }
}
