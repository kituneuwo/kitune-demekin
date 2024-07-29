using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start1 : MonoBehaviour
{

    public void SwitchScene()
    {

        SceneManager.LoadScene("Stage", LoadSceneMode.Single);
        Time.timeScale = 1;

    }
    
}