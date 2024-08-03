using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 doorOpenPosition;
    [SerializeField]
    private float doorOpenSpeed;
    private bool IsOpen;
    void Start()
    {
        IsOpen = false;
    }
    private void Update()
    {
        if (IsOpen)
        {
            transform.localPosition += Vector3.up * doorOpenSpeed;
            if(doorOpenPosition.y <= transform.localPosition.y)
            {
                IsOpen = false;
            }
        }
    }
    public void Open()
    {
        IsOpen = true;
    }
}
