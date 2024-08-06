using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurnScript : MonoBehaviour
{
    [SerializeField]
    private float turnDistance;
    [SerializeField]
    private Ease _ease;
    public void Turn(float Time)
    {
        transform.DORotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + turnDistance, transform.eulerAngles.z), Time).SetEase(_ease); 
    }
}
