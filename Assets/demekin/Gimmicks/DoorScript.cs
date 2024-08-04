using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 doorOpenPosition;
    [SerializeField]
    private float doorOpenSpeed;
    public void Open()
    {
        transform.DOMove(new Vector3(doorOpenPosition.x, doorOpenPosition.y, doorOpenPosition.z),doorOpenSpeed);
    }
}
