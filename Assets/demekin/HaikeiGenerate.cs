using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaikeiGenerate : MonoBehaviour
{
    [SerializeField]
    private GameObject haikeiObject;
    [SerializeField]
    private float gap;
    void Start()
    {
        Instantiate(haikeiObject, new Vector3(-7.4f, 2, -5), Quaternion.identity);
        InvokeRepeating("GenerateHaikei", 0.0f, gap);
    }
    void GenerateHaikei()
    {
        Instantiate(haikeiObject, new Vector3(-42.4f, 2, -5), Quaternion.identity);
    }
}
