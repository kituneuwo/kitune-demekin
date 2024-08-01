using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Start2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        this.transform.DOMove(new Vector3(1f, -16.9f, 1f), 3f);
        StartCoroutine(DelayCoroutine());
    }
    private IEnumerator DelayCoroutine()
    {
        transform.position = Vector3.one;

       
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("StageScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

}
