using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.UI;

public class BonusScript : MonoBehaviour
{
    [SerializeField]
    private GameObject BonusImage;
    [SerializeField]
    private GameObject ScoreImage;
    private TMP_Text ScoreText;
    private TMP_Text BonusText;
    private RectTransform rect;
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
        ScoreText = ScoreImage.GetComponent<TMP_Text>();
        BonusText = ScoreImage.GetComponent<TMP_Text>();
        ScoreText.color = new Color(1, 1, 1, 0);
        BonusText.color = new Color(1, 1, 1, 0);
        ScoreImage.GetComponent<RectTransform>().transform.localPosition = new Vector3Int(200, 135, 0);
    }
    public async void Prepare()
    {
        ScoreText.SetText(PlayerScript.Score.ToString());
        rect.DOMoveX(rect.position.x - 350, 1).SetEase(Ease.Linear);
        await Task.Delay(1000);
        ScoreText.DOColor(Color.white, 1);
    }
    void AddBonus()
    {
        
        BonusImage.GetComponent<RectTransform>().transform.localPosition = new Vector3Int(200, 30, 0);
        BonusText.color = Color.white;
        BonusText.DOColor(new Color(1, 1, 1, 0), 1);
        BonusImage.GetComponent<RectTransform>().DOMoveY(BonusImage.GetComponent<RectTransform>().position.y + 100,1).SetEase(Ease.Linear);
    }
}
