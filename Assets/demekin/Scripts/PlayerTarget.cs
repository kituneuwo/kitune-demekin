using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(targetObject.transform.position);
    }
}
