using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start1 : MonoBehaviour
{
    [SerializeField]
    private string SceneA;

    public void SwitchScene()
    {

        SceneManager.LoadScene(SceneA, LoadSceneMode.Single);
        Time.timeScale = 1;

    }
    
}