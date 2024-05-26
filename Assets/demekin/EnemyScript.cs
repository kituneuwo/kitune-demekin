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
    [SerializeField]
    private BoxCollider col1;
    [SerializeField]
    private BoxCollider col2;
    private BoxCollider Childcol;
    [SerializeField]
    private int health;
    private enum StartP
    {
        ç∂è„,
        ç∂,
        ç∂â∫,
        íÜâõè„,
        íÜâõâ∫,
        âEè„,
        âE,
        âEâ∫
    }
    [SerializeField]
    StartP StartPosition;
    void BreakChara()
    {
        col1.enabled = false;
        col2.enabled = false;
        Invoke("DestroyChara", DeathTime);
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
