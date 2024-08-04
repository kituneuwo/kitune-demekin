using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurnScript : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float turnDistance;
    public void Turn()
    {
        transform.DORotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + turnDistance, transform.eulerAngles.z), turnSpeed); 
    }
}
