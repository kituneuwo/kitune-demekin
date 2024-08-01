using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private bool IsDeath;
    [SerializeField]
    private GameObject BulletObject;
    void Start()
    {
        
        IsDeath = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !IsDeath)
        {
            Instantiate(BulletObject, transform.forward * 2.5f + transform.position, Quaternion.Euler(transform.eulerAngles));
        }
        if (!IsDeath && PlayerScript.PlayerLife <= 0)
        {
            IsDeath = true;
        }
    }
}
