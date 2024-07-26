using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody rb;
    private float Life;
    public float EnemyLife { get; set; }
    [SerializeField]
    private EnemyManager enemyManager;
    private bool IsDeath;
    [System.Serializable]
    private struct EnemyDeathP
    {
        public float Dpower;
        public GameObject[] Children;
        public GameObject[] DObject;
        public float DeathTime;
        public BoxCollider col;
        public BoxCollider Triggercol;
        [System.NonSerialized]
        public BoxCollider Childcol;
    }
    [SerializeField]
    private EnemyDeathP EnemyD;
    void Start()
    {
        IsDeath = false;
        Life = enemyManager.GetEnemy(this.gameObject.name).GetEnemyLife();
        Debug.Log(enemyManager.GetEnemy(this.gameObject.name).GetEnemyName() + ": " + enemyManager.GetEnemy(this.gameObject.name).GetEnemyInformation());
    }

    void BreakChara()
    {
        EnemyD.col.enabled = false;
        EnemyD.Triggercol.enabled = false;
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Life--;
            Debug.Log(Life);
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            Life -= enemyManager.GetWeapon(other.gameObject.name).GetWeaponDamage() / 10;
            Debug.Log(Life);
        }
        if (Life <= 0 && !IsDeath)
        {
            IsDeath = true;
            BreakChara();
        }
    }
}
