using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 doorOpenPosition;
    [SerializeField]
    private Ease _ease;
    public void Open(float Time)
    {
        transform.DOMove(new Vector3(doorOpenPosition.x, doorOpenPosition.y, doorOpenPosition.z),Time).SetEase(_ease);
    }
}
