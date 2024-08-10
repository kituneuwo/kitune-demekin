using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static bool isFadeInstance = false;
    private string _activeScenename;
    private bool isFadeIn = false;
    private bool isFadeOut = false;
    private bool isSceneEnd = false;
    [SerializeField]
    private GameObject ButtonBack;
    [SerializeField]
    private GameObject Restart;
    [SerializeField]
    private GameObject ButtonClear;
    [SerializeField]
    private GameObject GameOver;
    [SerializeField]
    private GameObject GameClear;
    private RectTransform Clearrect;
    [SerializeField]
    private BonusScript bonusScript;

    private float alpha = 0.0f;
    public float AlphaValue
    {
        get { return alpha; }
    }
    [SerializeField]
    private float fadeSpeed;
    void Start()
    {
        Clearrect = GameClear.GetComponent<RectTransform>();
        _activeScenename = SceneManager.GetActiveScene().name;
        Debug.Log(_activeScenename);
        ButtonBack.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        Restart.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        ButtonClear.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        GameOver.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        GameClear.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        if (!isFadeInstance)
        {
            DontDestroyOnLoad(this);
            isFadeInstance = true;
        }
        else
        {
            Destroy(this);
        }
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void Update()
    {
        if (isFadeIn)
        {
            _activeScenename = SceneManager.GetActiveScene().name;
            alpha -= Time.deltaTime / fadeSpeed;
            if (alpha <= 0.0f)
            {
                isFadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if (isFadeOut)
        {
            alpha += Time.deltaTime / fadeSpeed;
            if (alpha >= 1.0f)
            {
                isFadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
            if (PlayerScript.IsDeath)
            {
                GameOver.GetComponent<Image>().color = new Color(255, 255, 255, 5 - (5 * alpha));
            }
            else
            {
                GameClear.GetComponent<Image>().color = new Color(255, 255, 255, 5 - (5 * alpha));
                bonusScript.bonusText.color = new Color(255, 255, 255, 5 - (5 * alpha));
                bonusScript.scoreText.color = new Color(255, 255, 255, 5 - (5 * alpha));
            }
        }
        else if (isSceneEnd)
        {
            Clearrect.transform.localPosition = new Vector3(0, 64.5f, 0);
            alpha += Time.deltaTime / fadeSpeed;
            if (alpha >= 0.8f)
            {
                isSceneEnd = false;
                alpha = 0.8f;
                if (PlayerScript.IsDeath)
                {
                    Restart.GetComponent<Image>().color = new Color(255, 255, 255, 1);
                }
                else
                {
                    ButtonClear.GetComponent<Image>().color = new Color(255, 255, 255, 1);
                    bonusScript.Prepare();
                }
                ButtonBack.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
            if (PlayerScript.IsDeath)
            {
                GameOver.GetComponent<Image>().color = new Color(255, 255, 255, alpha * 1.25f);
            }
            else
            {
                GameClear.GetComponent<Image>().color = new Color(255, 255, 255, alpha * 1.25f);
            }
        }
    }

    public void fadeIn()
    {
        isFadeIn = true;
        isFadeOut = false;
        ButtonBack.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        Restart.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        ButtonClear.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void fadeOut()
    {
        isFadeOut = true;
        isFadeIn = false;
        ButtonBack.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        Restart.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        ButtonClear.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
    public void HalfFadeOut()
    {
        isSceneEnd = true;
    }
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if(nextScene.name != _activeScenename)
        {
            PlayerScript.DeathCount = 0;
        }
        Invoke("FadeIn", 0.5f);
    }
}
