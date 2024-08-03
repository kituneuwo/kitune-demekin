using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 doorOpenPosition;
    private Vector3 doorClosePosition;
    [SerializeField]
    private float doorOpenSpeed;
    void Start()
    {
        doorClosePosition = transform.position;
    }
    public void Open()
    {
        transform.position = Vector3.MoveTowards(doorClosePosition, doorOpenPosition, doorOpenSpeed * Time.deltaTime);
    }
}
