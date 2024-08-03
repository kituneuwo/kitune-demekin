using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetScript1 : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;
    //[SerializeField,Range(0f,10f)]
    private float maxMove;
    [SerializeField, Range(0f, 1f)]
    private float RotateSpeed;
    private PlayerScript playerScript;
    //[SerializeField]
    private float XAngleControl;
    private float maxMoveValue;
    private float XAngleControlValue;
    private float Angle;
    [SerializeField]
    private float maxMoveMultiplier;
    [SerializeField]
    private float maxMoveMValue;
    [SerializeField]
    private float XAngleMultiplier;
    [SerializeField]
    private float SpeedMultiplier;
    void Start()
    {
       playerScript = PlayerObject.GetComponent<PlayerScript>();
    }

    void Update()
    {
        if(PlayerObject != null)
        {
            Angle = -360 + PlayerObject.transform.eulerAngles.x;
            maxMoveValue = -Angle * maxMoveMultiplier / 60 + maxMoveMValue;
            if (Angle <= 0 && Angle >= -180)
            {
                XAngleControl = transform.eulerAngles.x * XAngleMultiplier / 60 - 1.2f ;
                maxMove = playerScript.playerSpeed * 0.05f + maxMoveValue;
            }
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log(maxMove);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(maxMove, XAngleControl, 10), RotateSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(-maxMove,XAngleControl, 10), RotateSpeed);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 10), RotateSpeed);
            }
            transform.LookAt(PlayerObject.transform.position);
        }
    }
}
