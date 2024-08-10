using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.UI;
using System;

public class BonusScript : MonoBehaviour
{
    [SerializeField]
    private GameObject BonusImage;
    private RectTransform BonusRect;
    [SerializeField]
    private GameObject ScoreImage;
    private TMP_Text ScoreText;
    public TMP_Text scoreText
    {
        get {return ScoreText; }
        set { ScoreText = value; }
    }
    private TMP_Text BonusText;
    private RectTransform rect;
    [System.Serializable]
    public struct Bonus
    {
        public string name;
        public int amount;
        public string KindOfTerms;
        public string terms;
    }
    [SerializeField]
    private Bonus[] BonusList;
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
        ScoreText = ScoreImage.GetComponent<TMP_Text>();
        BonusText = BonusImage.GetComponent<TMP_Text>();
        BonusRect = BonusImage.GetComponent<RectTransform>();
        ScoreText.color = new Color(1, 1, 1, 0);
        BonusText.color = new Color(1, 1, 1, 0);
        ScoreImage.GetComponent<RectTransform>().transform.localPosition = new Vector3Int(200, 135, 0);
    }
    public async void Prepare()
    {
        ScoreText.SetText("Score:" + PlayerScript.Score.ToString());
        rect.DOMoveX(rect.position.x - 250, 1).SetEase(Ease.Linear);
        await Task.Delay(1000);
        ScoreText.DOColor(Color.white, 1);
        for(int i = 0; i < BonusList.Length; i++)
        {
            if (CheckBonus(i))
            {
                await Task.Delay(1000);
                ScoreText.SetText("Score:" + PlayerScript.Score.ToString());
            }
        }
    }
    private bool CheckBonus(int number)
    {
        BonusText.SetText(BonusList[number].name + ":" + BonusList[number].amount);
        BonusRect.transform.localPosition = new Vector3(BonusRect.transform.localPosition.x, 30, BonusRect.transform.localPosition.z);
        if(BonusList[number].KindOfTerms == "true")
        {
            AddBonus(number);
            return true;
        }
        if (BonusList[number].KindOfTerms == "Death")
        {
            if(PlayerScript.DeathCount == int.Parse(BonusList[number].terms))
            {
                AddBonus(number);
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (BonusList[number].KindOfTerms == "EnemyTag")
        {
            if (GameObject.FindWithTag(BonusList[number].terms) == null)
            {
                AddBonus(number);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    void AddBonus(int number)
    {
        BonusText.color = Color.white;
        BonusText.DOColor(new Color(1, 1, 1, 0), 1);
        BonusRect.DOMoveY(BonusRect.position.y + 100, 1).SetEase(Ease.Linear);
        PlayerScript.Score += BonusList[number].amount;
    }
}
