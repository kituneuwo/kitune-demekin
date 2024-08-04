using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//’Ç‰Á

public class FadeManager : MonoBehaviour
{
    public static bool isFadeInstance = false;

    private bool isFadeIn = false;
    private bool isFadeOut = false;
    private bool isSceneEnd = false;
    [SerializeField]
    private GameObject Button1;
    [SerializeField]
    private GameObject Button2;

    private float alpha = 0.0f;
    private float fadeSpeed = 0.2f;
    void Start()
    {
        Button1.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        Button2.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        if (!isFadeInstance)
        {
            DontDestroyOnLoad(this);
            isFadeInstance = true;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (isFadeIn)
        {
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
        }
        else if (isSceneEnd)
        {
            alpha += Time.deltaTime / fadeSpeed;
            if (alpha >= 0.3f)
            {
                isSceneEnd = false;
                alpha = 0.3f;
                Button1.GetComponent<Image>().color = new Color(255, 255, 255, 1);
                Button2.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    public void fadeIn()
    {
        isFadeIn = true;
        isFadeOut = false;
        Button1.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        Button2.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void fadeOut()
    {
        isFadeOut = true;
        isFadeIn = false;
    }
    public void HalfFadeOut()
    {
        isSceneEnd = true;
    }
}
