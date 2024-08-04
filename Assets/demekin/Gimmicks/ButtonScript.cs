using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using DG.Tweening;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gimmickObject;
    [SerializeField]
    private Vector3 PushPosition;
    [SerializeField] private float Speed;
    private bool IsActivation;
    private void Start()
    {
        IsActivation = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet") && !IsActivation)
        {
            this.transform.DOMove(PushPosition, Speed);
            if (gimmickObject.tag == "Door")
            {
                gimmickObject.GetComponent<DoorScript>().Open();
                IsActivation = true;
            }
        }
    }
}
