using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    Ray _ray;
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float pointControl;
    private RaycastHit _hit;
    private int _layerMask;
    [SerializeField]
    private float _size;
    void Start()
    {
        _ray = new Ray(playerObject.transform.position,playerObject.transform.eulerAngles);
        _layerMask = LayerMask.GetMask(new string[] { "Default", "Water", "Enemy" });
    }

    void Update()
    {
        if(playerObject != null)
        {
            if (Physics.Raycast(playerObject.transform.position, playerObject.transform.forward, out _hit, maxDistance, _layerMask))
            {
                transform.position = _hit.point + (_hit.normal * 0.02f);
                transform.rotation = Quaternion.LookRotation(_hit.normal);
                transform.localScale = new Vector3(10 + (_hit.distance / _size), 10 + (_hit.distance / _size), 10 + (_hit.distance / _size));
            }
            else
            {
                transform.localPosition = new Vector3(0, 0, 10);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                transform.localScale = new Vector3(10,10,10);
            }
            Debug.DrawRay(playerObject.transform.position, playerObject.transform.forward * maxDistance, Color.red);
        }
    }
}
