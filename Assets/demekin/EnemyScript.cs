using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Children;
    [SerializeField]
    private GameObject[] DObject;
    [SerializeField]
    private float power;
    [SerializeField]
    private float DeathTime;
    private Rigidbody rb;
    private BoxCollider col;
    private BoxCollider Childcol;
    private int health;
    void Start()
    {
        health = 10;
        
    }
    void BreakChara()
    {
        col = this.gameObject.GetComponent<BoxCollider>();
        col.enabled = false;
        for (int i = 0; i < Children.Length; i++)
        {
            Children[i].transform.DetachChildren();
        }
        for (int i = 0; i < DObject.Length; i++)
        {
            Childcol = DObject[i].GetComponent<BoxCollider>();
            Childcol.enabled = true;
            rb = DObject[i].GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddForce(Random.insideUnitSphere * power, ForceMode.VelocityChange);
        }
        Invoke("DestroyChara", DeathTime);
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            health--;
            if(health <= 0)
            {
                BreakChara();
            }
        }
    }
}
