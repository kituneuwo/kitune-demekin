using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private int health;
    [System.Serializable]
    private struct EnemyDeathP
    {
        public float Dpower;
        public GameObject[] Children;
        public GameObject[] DObject;
        public float DeathTime;
        public BoxCollider col1;
        public BoxCollider col2;
        [System.NonSerialized]
        public BoxCollider Childcol;
    }
    [SerializeField]
    private EnemyDeathP EnemyD;
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
        EnemyD.col1.enabled = false;
        EnemyD.col2.enabled = false;
        Invoke("DestroyChara", EnemyD.DeathTime);
        for (int i = 0; i < EnemyD.Children.Length; i++)
        {
            EnemyD.Children[i].transform.DetachChildren();
        }
        for (int i = 0; i < EnemyD.DObject.Length; i++)
        {
            EnemyD.Childcol = EnemyD.DObject[i].GetComponent<BoxCollider>();
            EnemyD.Childcol.enabled = true;
            rb = EnemyD.DObject[i].GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddForce(Random.insideUnitSphere * EnemyD.Dpower, ForceMode.VelocityChange);
        }
    }
    void DestroyChara()
    {
        for (int i = 0; i < EnemyD.Children.Length; i++)
        {
            Destroy(EnemyD.Children[i]);
        }
        for (int i = 0; i < EnemyD.DObject.Length; i++)
        {
            Destroy(EnemyD.DObject[i]);
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
