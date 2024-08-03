using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SISIODOSI : MonoBehaviour
{
    [SerializeField] AudioClip Sound1;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(Sound1);
        }
    }
}
