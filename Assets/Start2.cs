using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class Start2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        this.transform.DOMove(new Vector3(0f, -15f, 7.84f), 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
