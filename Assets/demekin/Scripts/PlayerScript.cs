using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] AudioClip Sound1;
    private AudioSource audioSource;
    [SerializeField] private GameObject HPUI;
    [SerializeField]
    private Slider slider;
    private float maxLife;
    [SerializeField]
    private float Movespeed;
    [SerializeField]
    private GameObject EnemyObject;
    [SerializeField]
    private GameObject RotateObject;
    [SerializeField, Range(0f, 1f)]
    private float RotateSpeed;
    [SerializeField]
    private float maxSpeed;
    private Rigidbody rb;
    public static float PlayerLife;
    private bool IsDeath = false;
    [SerializeField]
    private PlayerManager playerManager;

    private float PlusSpeed;
    private float PlayerSpeed;
    private SceneController sceneController;
    public float playerSpeed
    {
        get { return PlayerSpeed; }
    }
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
        audioSource = GetComponent<AudioSource>();
        PlayerLife = playerManager.GetPlayer(this.gameObject.name).GetPlayerLife();
        maxLife = PlayerLife;
        if(slider != null){
            slider.value = 1;
        }
        sceneController = this.gameObject.GetComponent<SceneController>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        PlusSpeed = -Movespeed;
        Debug.Log(playerManager.GetPlayer(this.gameObject.name).GetPlayerName() + ": " + playerManager.GetPlayer(this.gameObject.name).GetPlayerInformation());
    }
    void Update()
    {
        PlusSpeed += Input.GetAxis("Mouse ScrollWheel") * 10;
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
            PlayerSpeed = Movespeed + PlusSpeed;
            transform.position += transform.forward * (PlayerSpeed * playerManager.GetPlayer(this.gameObject.name).GetPlayerSpeed()) * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, RotateObject.transform.rotation, RotateSpeed * playerManager.GetPlayer(this.gameObject.name).GetPlayerTurnSpeed());
        }
        if (Input.GetKey(KeyCode.I) && !IsDeath)
        {
            var obj = Instantiate(EnemyObject, transform.forward * 15f + transform.position, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y + 180, 0));
            obj.name = EnemyObject.name;
        }
        if (Input.GetKey(KeyCode.P) && !IsDeath)
        {
            PlayerLife = 0;
            Debug.Log("Ž€ˆö:Ž©”š");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(PlayerSpeed);
        }
        if (PlayerLife <= 0 && !IsDeath)
        {
            IsDeath = true;
            audioSource.PlayOneShot(Sound1);
            BreakPlayer();
            if (HPUI != null)
            {
                HPUI.SetActive(false);
            }
        }
        if (slider != null)
        {
            slider.value = PlayerLife / maxLife;
        }
        if (Input.GetKey(KeyCode.Escape))
        {

            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("EnemyBullet"))
        {
            PlayerLife = 0;
            Debug.Log("Ž€ˆö:Õ“ËŽ€(" + collision.gameObject.name + ")",collision.gameObject);
        }
    }
    void BreakPlayer()
    {
        PlayerD.col.enabled = false;
        Invoke("DestroyPlayer", PlayerD.DeathTime);
        SceneEnd();
        for (int i = 0; i < PlayerD.Children.Length; i++)
        {
            PlayerD.Children[i].transform.DetachChildren();
        }
        Destroy(PlayerD.Children[0]);
        for (int i = 0; i < PlayerD.DObject.Length; i++)
        {
            PlayerD.Childcol = PlayerD.DObject[i].GetComponent<BoxCollider>();
            PlayerD.Childcol.enabled = true;
            rb = PlayerD.DObject[i].GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddForce(Random.insideUnitSphere * PlayerD.Dpower, ForceMode.VelocityChange);
        }
        
    }
    
    
    void DestroyPlayer()
    {
        for (int i = 1; i < PlayerD.Children.Length; i++)
        {
            Destroy(PlayerD.Children[i]);
        }
        for (int i = 1; i < PlayerD.DObject.Length; i++)
        {
            Destroy(PlayerD.DObject[i]);
        }
    }
    void SceneEnd()
    {
        sceneController.SceneEnd();
    }
    
}
