using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScene : MonoBehaviour
{
    private SceneController sceneController;
    private FadeManager fadeManager;
    private void Start()
    {
        fadeManager = transform.parent.gameObject.GetComponent<FadeManager>();
        sceneController = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneController>();
    }
    public void GoNextScene()
    {
        if (fadeManager.AlphaValue == 0.8f)
        {
            if (PlayerScript.IsClear)
            {
                sceneController.SceneNext();
            }
            else
            {
                sceneController.SceneRestart();
            }
        }
    }
    public void BackScene()
    {
        if (fadeManager.AlphaValue == 0.8f && (PlayerScript.IsDeath || PlayerScript.IsClear))
        {
            sceneController.SceneBack();
        }
    }
}
