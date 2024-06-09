using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaikeiDestroy : MonoBehaviour
{
    void Start()
    {
        Invoke("Death",36);
    }
    void Death()
    {
        Destroy(this.gameObject);
    }
}
