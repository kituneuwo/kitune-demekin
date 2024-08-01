using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;
    [SerializeField,Range(0f,10f)]
    private float maxMove;
    [SerializeField, Range(0f, 1f)]
    private float RotateSpeed;
    private PlayerScript playerScript;
    [SerializeField]
    private float SpeedControl;
    [SerializeField,Range(0f,0.5f)]
    private float YAngleControl;
    [SerializeField]
    private float YSpeedControl;
    void Start()
    {
       playerScript = PlayerObject.GetComponent<PlayerScript>();
    }

    void Update()
    {
        if(PlayerObject != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(playerScript.playerSpeed * SpeedControl + maxMove,transform.localEulerAngles.y * YAngleControl * playerScript.playerSpeed * YSpeedControl - maxMove, 10), RotateSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(-playerScript.playerSpeed * SpeedControl - maxMove, transform.localEulerAngles.y * YAngleControl * playerScript.playerSpeed * YSpeedControl - maxMove, 10), RotateSpeed);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 10), RotateSpeed);
            }
            transform.LookAt(PlayerObject.transform.position);
        }
    }
}
