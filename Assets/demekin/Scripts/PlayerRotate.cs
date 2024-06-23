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
            transform.eulerAngles = new Vector3(0, 0, PlayerObject.transform.localEulerAngles.z - 30);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, PlayerObject.transform.localEulerAngles.z + 30);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(PlayerObject.transform.eulerAngles.x - 10, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(PlayerObject.transform.eulerAngles.x + 10, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
