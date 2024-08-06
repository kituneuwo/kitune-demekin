using UnityEngine;

public class Test2 : MonoBehaviour
{
    void Update()
    {
        EndGame();
    }

    //ゲーム終了
    private void EndGame()
    {
        //Escが押された時
        if (Input.GetKey(KeyCode.Escape))
        {

            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
            Application.Quit();//ゲームプレイ終了
        }

    }
}