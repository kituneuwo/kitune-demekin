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
        Instantiate(haikeiObject, new Vector3(-2.4f, 2, -5), Quaternion.Euler(0, 180, 0));
        InvokeRepeating("GenerateHaikei", 0.0f, gap);
    }
    void GenerateHaikei()
    {
        Instantiate(haikeiObject, new Vector3(32.6f, 2, -5), Quaternion.Euler(0, 180, 0));
    }
}
