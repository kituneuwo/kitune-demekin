using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class aaaa : MonoBehaviour
{
    public void OnClick()
    {
        this.transform.DOMove(new Vector3(755f, 1000f, 0f), 3f);
    }

    void FixedUpdate()
    {
       
    }
}
