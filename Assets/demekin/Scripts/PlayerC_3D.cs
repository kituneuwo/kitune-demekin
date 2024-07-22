using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC_3D : MonoBehaviour
{
    [SerializeField]
    private float Movespeed;
    [SerializeField]
    private GameObject EnemyObject;
    [SerializeField]
    private GameObject BulletObject;
    [SerializeField]
    private GameObject RotateObject;
    [SerializeField, Range(0f, 1f)]
    private float RotateSpeed;
    [SerializeField]
    private float maxSpeed;
    private Rigidbody rb;
    public static int PlayerLife;
    private bool IsDeath;
    private float Wheel;
    private float PlusSpeed;
    [System.Serializable]
    private struct PlayerDeathP
    {
        public float Dpower;
        public GameObject[] Children;
        public GameObject[] DObject;
        public float DeathTime;
        public BoxCollider col;
        [System.NonSerialized]
        public BoxCollider Childcol;
    }
    [SerializeField]
    private PlayerDeathP PlayerD;
    void Start()
    {
        IsDeath = false;
        PlayerLife = 200;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        Wheel = Input.GetAxis("Mouse ScrollWheel") * 10;
        PlusSpeed += Wheel;
        if(PlusSpeed > maxSpeed)
        {
            PlusSpeed = maxSpeed;
        }
        else if(PlusSpeed < -Movespeed)
        {
            PlusSpeed = -Movespeed;
        }
        if (PlayerLife > 0 && !IsDeath)
        {
            transform.position += transform.forward * (Movespeed + PlusSpeed) * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, RotateObject.transform.rotation, RotateSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !IsDeath)
        {
            Instantiate(BulletObject, transform.forward * 2.5f + transform.position, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, -90));
        }
        if (Input.GetKey(KeyCode.I) && !IsDeath)
        {
            var obj = Instantiate(EnemyObject, transform.forward * 15f + transform.position, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y + 180, 0));
            obj.name = EnemyObject.name;
        }
        if (Input.GetKey(KeyCode.P) && !IsDeath)
        {
            PlayerLife = 0;
        }
        if (PlayerLife <= 0 && !IsDeath)
        {
            IsDeath = true;
            BreakPlayer();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != 9)
        {
            PlayerLife = 0;
        }
    }
    void BreakPlayer()
    {
        PlayerD.col.enabled = false;
        Invoke("DestroyPlayer", PlayerD.DeathTime);
        for (int i = 0; i < PlayerD.Children.Length; i++)
        {
            PlayerD.Children[i].transform.DetachChildren();
        }
        for (int i = 0; i < PlayerD.DObject.Length; i++)
        {
            PlayerD.Childcol = PlayerD.DObject[i].GetComponent<BoxCollider>();
            PlayerD.Childcol.enabled = true;
            rb = PlayerD.DObject[i].GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddForce(Random.insideUnitSphere * PlayerD.Dpower, ForceMode.VelocityChange);
        }
        Invoke("Stop", PlayerD.DeathTime - 0.05f);
    }
    void DestroyPlayer()
    {
        for (int i = 0; i < PlayerD.Children.Length; i++)
        {
            Destroy(PlayerD.Children[i]);
        }
        for (int i = 0; i < PlayerD.DObject.Length; i++)
        {
            Destroy(PlayerD.DObject[i]);
        }
    }
    private void Stop()
    {
        Time.timeScale = 0;
    }
}
