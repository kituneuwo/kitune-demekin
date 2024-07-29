using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private bool IsDeath;
    [SerializeField]
    private GameObject BulletObject;
    [SerializeField]
    private GameObject TargetObject;
    void Start()
    {
        
        IsDeath = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsDeath)
        {
            transform.LookAt(TargetObject.transform.position);
            Instantiate(BulletObject, transform.forward * 2.5f + transform.position, Quaternion.Euler(transform.eulerAngles));
        }
        if (!IsDeath && PlayerC_3D.PlayerLife <= 0)
        {
            IsDeath = true;
        }
    }
}
