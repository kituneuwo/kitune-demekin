using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using DG.Tweening;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] AudioClip Sound1;
    private AudioSource audioSource;
    [SerializeField]
    private GameObject[] gimmickObject;
    [SerializeField]
    private Vector3 PushPosition;
    [SerializeField] private float _time;
    private bool IsActivation;
    [SerializeField]
    Renderer rendererComponent;
    [SerializeField]
    private Color Changecolor;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        IsActivation = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet") && !IsActivation)
        {
            audioSource.PlayOneShot(Sound1);
            this.rendererComponent.material.DOColor(Changecolor, _time).SetEase(Ease.OutCubic);
            transform.DOMove(PushPosition, _time).SetEase(Ease.Linear);
            IsActivation = true;
            for (int i = 0; i < gimmickObject.Length; i++)
            {
                if (gimmickObject[i].tag == "Door")
                {
                    gimmickObject[i].GetComponent<DoorScript>().Open(_time);
                }
                if (gimmickObject[i].tag == "Hinge")
                {
                    gimmickObject[i].GetComponent<TurnScript>().Turn();
                }
            }
        }
    }
}
