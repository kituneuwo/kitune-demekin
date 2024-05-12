using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Children;
    [SerializeField]
    private GameObject[] DObject;
    [SerializeField]
    private float power;
    private Rigidbody rb;
    void Start()
    {
        for (int i = 0; i < Children.Length; i++)
        {
            Children[i].transform.DetachChildren();
        }
        for (int i = 0; i < DObject.Length; i++)
        {
            rb = DObject[i].GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddForce(Random.insideUnitSphere * power, ForceMode.VelocityChange);
        }
        Invoke("DestroyChara", 2.75f);
    }
    void DestroyChara()
    {
        for (int i = 0; i < Children.Length; i++)
        {
            Destroy(Children[i]);
        }
        for (int i = 0; i < DObject.Length; i++)
        {
            Destroy(DObject[i]);
        }
    }
}
