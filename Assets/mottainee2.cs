using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mottainee2 : MonoBehaviour
{
    [SerializeField] private GameObject mottainee1;
    // Start is called before the first frame update
    public void OnClick()
    {

        mottainee1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
