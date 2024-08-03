using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotate : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private float Xangle;
    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(playerObject.transform.position, Vector3.right, Xangle);
    }
}
