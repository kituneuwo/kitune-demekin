using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScene : MonoBehaviour
{
    private SceneController sceneController;
    private FadeManager fadeManager;
    private GameObject fadeObject;
    private void Start()
    {
        fadeObject = transform.parent.gameObject;
        fadeManager = fadeObject.GetComponent<FadeManager>();
        sceneController = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneController>();
    }
    public void RestartScene()
    {
        if(PlayerScript.PlayerLife <= 0 && fadeManager.AlphaValue == 0.8f)
        {
            sceneController.SceneRestart();
        }
    }
    public void GoNextScene()
    {
        if (fadeManager.AlphaValue == 0.8f)
        {
            sceneController.SceneNext();
        }
    }
    public void BackScene()
    {
        if (PlayerScript.PlayerLife <= 0 && fadeManager.AlphaValue == 0.8f)
        {
            sceneController.SceneBack();
        }
    }
}
