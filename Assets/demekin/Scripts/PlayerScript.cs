using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public static float PlayerLife = 0;
    public static int Score = 0;
    public static bool IsClear = false;
    public static bool IsDeath = false;
    public static int DeathCount = 0;
    public static float _time = 0;
    public static int Coin = 0;
    [SerializeField] AudioClip Sound1;
    private AudioSource audioSource;
    [SerializeField] private GameObject HPUI;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TMP_Text _speedtext;
    [SerializeField]
    private TMP_Text _scoretext;
    [SerializeField]
    private GameObject _speedmeter;
    private Image _speedmeterImage;
    private float PlayerSpeedValue;
    private float maxLife;
    [SerializeField]
    private float Movespeed;
    [SerializeField]
    private GameObject EnemyObject;
    [SerializeField]
    private GameObject RotateObject;
    [SerializeField, Range(0f, 1f)]
    private float RotateSpeed;
    private float maxPlusSpeed;
    private float maxSpeed;
    private Rigidbody rb;
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
        maxPlusSpeed = Movespeed;
        _time = 0;
        Score = 0;
        IsClear = false;
        IsDeath = false;
        maxSpeed = Movespeed + maxPlusSpeed;
        audioSource = GetComponent<AudioSource>();
        _speedmeterImage = _speedmeter.GetComponent<Image>();
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
        if(!IsDeath && !IsClear)
        {
            PlusSpeed += Input.GetAxis("Mouse ScrollWheel") * 10;
            if (PlusSpeed > maxPlusSpeed)
            {
                PlusSpeed = maxPlusSpeed;
            }
            else if (PlusSpeed < -Movespeed)
            {
                PlusSpeed = -Movespeed;
            }
            if (Input.GetKey(KeyCode.I) && !IsDeath)
            {
                var obj = Instantiate(EnemyObject, transform.forward * 15f + transform.position, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y + 180, 0));
                obj.name = EnemyObject.name;
            }
            if (Input.GetKey(KeyCode.P) && !IsDeath)
            {
                PlayerLife = 0;
                Debug.Log("éÄàˆ:é©îö");
            }
            if (slider != null)
            {
                slider.value = PlayerLife / maxLife;
            }
            PlayerSpeed = Movespeed + PlusSpeed;
            PlayerSpeedValue = PlayerSpeed * playerManager.GetPlayer(this.gameObject.name).GetPlayerSpeed() * 1.8f;
            _scoretext.SetText("Score:" + Score.ToString());
            _time += Time.deltaTime;
        }
        if (PlayerLife <= 0 && !IsDeath)
        {
            IsDeath = true;
            DeathCount++;
            Debug.Log(DeathCount);
            audioSource.PlayOneShot(Sound1);
            BreakPlayer();
            if (HPUI != null)
            {
                HPUI.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(DeathCount);
        }
        transform.position += transform.forward * (PlayerSpeed * playerManager.GetPlayer(this.gameObject.name).GetPlayerSpeed()) * Time.deltaTime;
        _speedtext.SetText(PlayerSpeedValue.ToString("F1") + "km/h");
        _speedmeterImage.fillAmount = (PlayerSpeed / maxSpeed) / 4;
        transform.rotation = Quaternion.Lerp(transform.rotation, RotateObject.transform.rotation, RotateSpeed * playerManager.GetPlayer(this.gameObject.name).GetPlayerTurnSpeed());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal" && !IsClear)
        {
            IsClear = true;
            DOVirtual.Float(PlayerSpeed, 0, 5, onVirtualUpdate: (tweenValue) => { PlayerSpeed = tweenValue; }).SetEase(Ease.OutSine);
            sceneController.SceneEnd();
            if (HPUI != null)
            {
                HPUI.SetActive(false);
            }
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("EnemyBullet") && !IsClear)
        {
            PlayerLife = 0;
            Debug.Log("éÄàˆ:è’ìÀéÄ(" + collision.gameObject.name + ")",collision.gameObject);
        }
    }
    void BreakPlayer()
    {
        PlayerD.col.enabled = false;
        Invoke("DestroyPlayer", PlayerD.DeathTime);
        sceneController.SceneEnd();
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
    
}
