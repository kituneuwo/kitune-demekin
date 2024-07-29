using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class mottainee2 : MonoBehaviour
{
    [SerializeField] private GameObject mottainee1;
    // Start is called before the first frame update
    public void OnClick()
    {
        StartCoroutine(DelayCoroutine());
        
        
    }
    private IEnumerator DelayCoroutine()
    {
        transform.position = Vector3.one;

        // 3•bŠÔ‘Ò‚Â
        yield return new WaitForSeconds(3);

        this.transform.DOMove(new Vector3(357.5f, 201f, 0f), 2f);
    }

    
}
