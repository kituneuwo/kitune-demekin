using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mottaineeyatu : MonoBehaviour

{
    [SerializeField] private GameObject mottainee;
    // Start is called before the first frame update
    public void OnClick()
    {
        mottainee.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
