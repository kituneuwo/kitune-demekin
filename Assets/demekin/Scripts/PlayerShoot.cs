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
        if (Input.GetKeyDown(KeyCode.Space) && !IsDeath)
        {
            GameObject obj = Instantiate(BulletObject, transform.forward * 2.5f + transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -90));

            
        }
        if (!IsDeath && PlayerC_3D.PlayerLife <= 0)
        {
            IsDeath = true;
        }
    }
}
