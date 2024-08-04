using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScene : MonoBehaviour
{
    private SceneController sceneController;
    private void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneController>();
    }
    public void RestartScene()
    {
        if(PlayerScript.PlayerLife <= 0)
        {
            sceneController.SceneRestart();
        }
    }
    public void BackScene()
    {
        if (PlayerScript.PlayerLife <= 0)
        {
            sceneController.SceneBack();
        }
    }
}
