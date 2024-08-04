using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] AudioClip Sound1;
    [SerializeField] AudioClip Sound2;
    AudioSource audioSource;

    [SerializeField] private GameObject HPUI;
    public Slider slider;

    private Rigidbody rb;
    private float Life;
    float maxLife;
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
        if(slider != null)
        {
            slider.value = 1;
        }
        Life = maxLife;
        audioSource = GetComponent<AudioSource>();
        IsDeath = false;
        Life = enemyManager.GetEnemy(this.gameObject.name).GetEnemyLife();
        maxLife = Life;
        Debug.Log(enemyManager.GetEnemy(this.gameObject.name).GetEnemyName() + ": " + enemyManager.GetEnemy(this.gameObject.name).GetEnemyInformation());
    }

    void BreakChara()
    {
        EnemyD.col.enabled = false;
        EnemyD.Triggercol.enabled = false;
        for (int i = 0; i < EnemyD.DObject.Length; i++)
        {
            Destroy(EnemyD.DObject[i],EnemyD.DeathTime);
        }
        for (int i = 0; i < EnemyD.Children.Length; i++)
        {
            EnemyD.Children[i].transform.DetachChildren();
            Destroy(EnemyD.Children[i]);
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Life--;
            audioSource.PlayOneShot(Sound2);
            Debug.Log(Life);
            if(slider != null)
            {
                slider.value = (float)Life / (float)maxLife;
            }
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            Life -= enemyManager.GetWeapon(other.gameObject.name).GetWeaponDamage() / 10;
            Debug.Log(Life);
        }
        if (Life <= 0 && !IsDeath)
        {
            HPUI.SetActive(false);
            audioSource.PlayOneShot(Sound1);
            IsDeath = true;
            BreakChara();
        }
    }
}
