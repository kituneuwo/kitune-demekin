using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderSea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10)
        {
            Destroy(collision.gameObject);
        }
    }
}
