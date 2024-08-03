using UnityEngine;

public class Test : MonoBehaviour
{

   

    //ゲーム開始時に呼ばれる
    private void Start()
    {
        
    }

    


    //ゲーム終了
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}