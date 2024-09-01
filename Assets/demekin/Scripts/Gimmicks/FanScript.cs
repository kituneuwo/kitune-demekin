using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float hitRadius;
    [SerializeField]
    private float torque;
    private RaycastHit _hit;
    private Rigidbody rb;
    private BoxCollider col;
    [SerializeField]
    private bool IsActive;

    void Start()
    {
        col = gameObject.GetComponent<BoxCollider>();
        rb = gameObject.GetComponent<Rigidbody>();
        col.center = new Vector3(0,0,-maxDistance / 2);
        col.size = new Vector3(1,1,maxDistance);
    }
    void Update()
    {
        if (IsActive)
        {
            rb.AddTorque(0, 0, 10 * torque);
            if (Physics.SphereCast(transform.position, hitRadius, -transform.forward, out _hit, maxDistance))
            {
                Debug.Log(_hit.collider.gameObject.name);
            }
            Debug.DrawRay(transform.position, -transform.forward * maxDistance, Color.red);
        }
    }
    public void ChangeFan()
    {
        if (IsActive)
        {
            IsActive = false;
            while(rb.velocity.z < 3)
            {
                rb.AddTorque(0, 0, -torque);
            }
        }
        else
        {
            IsActive = true;
        }
    }
}
