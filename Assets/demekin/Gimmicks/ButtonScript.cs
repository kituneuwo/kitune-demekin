using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using DG.Tweening;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gimmickObject;
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
            transform.DOMove(PushPosition, Speed).SetEase(Ease.Linear);
            IsActivation = true;
            for (int i = 0; i < gimmickObject.Length; i++)
            {
                if (gimmickObject[i].tag == "Door")
                {
                    gimmickObject[i].GetComponent<DoorScript>().Open();
                }
                if (gimmickObject[i].tag == "Hinge")
                {
                    gimmickObject[i].GetComponent<TurnScript>().Turn();
                }
            }
        }
    }
}
