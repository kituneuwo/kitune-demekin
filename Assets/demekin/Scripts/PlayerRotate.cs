using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerRotate : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;
    private Vector3 RotateNum;
    private Rigidbody rb;
    [SerializeField]
    private float torque;
    [SerializeField]
    private int limitup;
    [SerializeField]
    private int limitdown;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateNum.z = -30;
            RotateNum.y = transform.localEulerAngles.y + torque * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateNum.z = 30;
            RotateNum.y = transform.localEulerAngles.y - torque * Time.deltaTime;
        }
        else
        {
            RotateNum.z = 0;
        }
        if (Input.GetKey(KeyCode.W) && (transform.localEulerAngles.x >= limitup || transform.localEulerAngles.x == 0 || transform.localEulerAngles.x <= limitdown))
        {
            RotateNum.x = transform.localEulerAngles.x - torque * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && (transform.localEulerAngles.x <= limitdown || transform.localEulerAngles.x >= limitup))
        {
            RotateNum.x = transform.localEulerAngles.x + torque * Time.deltaTime;
        }
        if(transform.localEulerAngles.x <= limitup && transform.localEulerAngles.x > limitup - 10)
        {
            RotateNum.x = limitup + 0.01f;
        }
        if(transform.localEulerAngles.x >= limitdown && transform.localEulerAngles.x <= limitdown + 10)
        {
            RotateNum.x = limitdown - 0.01f;
        }
        transform.rotation = Quaternion.Euler(RotateNum);
        transform.position = PlayerObject.transform.position;
    }
}
