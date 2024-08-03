using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gimmickObject;
    private bool IsActivation;
    private void Start()
    {
        IsActivation = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet") && !IsActivation)
        {
            if (gimmickObject.tag == "Door")
            {
                gimmickObject.GetComponent<DoorScript>().Open();
                IsActivation = true;
            }
        }
    }
}
