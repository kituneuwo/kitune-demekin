using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(PlayerObject.transform.localEulerAngles.x, 0, PlayerObject.transform.localEulerAngles.z - 30);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(PlayerObject.transform.localEulerAngles.x, 0, PlayerObject.transform.localEulerAngles.z + 30);
        }
        else
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(-20, 0, PlayerObject.transform.localEulerAngles.z);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(20, 0, PlayerObject.transform.localEulerAngles.z);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }
}
