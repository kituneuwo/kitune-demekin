using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class start : MonoBehaviour
{
    public void OnClick()
    {
        this.transform.DOMove(new Vector3(0f, -15f, 8f), 3f);
    }

    void FixedUpdate()
    {
       
    }
}
