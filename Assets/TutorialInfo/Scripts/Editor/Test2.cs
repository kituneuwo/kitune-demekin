using UnityEngine;
using UnityEditor;

public class Test2 : MonoBehaviour
{
    void Update()
    {
        EndGame();
    }

    //�Q�[���I��
    private void EndGame()
    {
        //Esc�������ꂽ��
        if (Input.GetKey(KeyCode.Escape))
        {

            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
            Application.Quit();//�Q�[���v���C�I��
        }

    }
}