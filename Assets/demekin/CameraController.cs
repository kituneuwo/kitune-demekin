using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject tPlayer;

    void Update()
    {
        transform.position = new Vector3(tPlayer.transform.position.x - 7.5f, tPlayer.transform.position.y + 2, tPlayer.transform.position.z + 7);
    }
}
