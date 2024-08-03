using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using DG.Tweening;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gimmickObject;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
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
            this.transform.DOMove(new Vector3(x, y, z), Speed);
            if (gimmickObject.tag == "Door")
            {
                gimmickObject.GetComponent<DoorScript>().Open();
                IsActivation = true;
            }
        }
    }
}
