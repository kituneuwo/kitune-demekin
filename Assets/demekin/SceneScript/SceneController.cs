using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameObject fadeCanvas;
    [SerializeField]
    private GameObject fade;

    void Start()
    {
        if (!FadeManager.isFadeInstance)
        {
            Instantiate(fade);
        }
        Invoke("findFadeObject", 0.02f);
    }

    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        fadeCanvas.GetComponent<FadeManager>().fadeIn();
    }

    public async void SceneRestart()//É{É^ÉìëÄçÏÇ»Ç«Ç≈åƒÇ—èoÇ∑
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();
        await Task.Delay(200);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public async void SceneBack()
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();
        await Task.Delay(200);
        SceneManager.LoadScene("StageScene");
    }
    public void SceneEnd()
    {
        fadeCanvas.GetComponent<FadeManager>().HalfFadeOut();
    }
}