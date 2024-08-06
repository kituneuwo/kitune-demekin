using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public AudioClip[] audios;
    private AudioSource audioSource;
    private int i;
    private bool IsDeath;
    [SerializeField]
    private GameObject BulletObject;
    private GameObject obj;
    void Start()
    {
        
        IsDeath = false;

        audioSource = this.GetComponent<AudioSource>();
        if (audios != null)
        {
            i = Random.Range(0, audios.Length);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsDeath)
        {
            obj = Instantiate(BulletObject, transform.forward * 2.5f + transform.position, Quaternion.Euler(transform.eulerAngles));
            obj.name = transform.parent.name;
            audioSource.PlayOneShot(audios[i]);
        }
        if (!IsDeath && PlayerScript.PlayerLife <= 0)
        {
            IsDeath = true;
        }
    }
}
