using UnityEngine;

public class Test : MonoBehaviour
{

   

    //�Q�[���J�n���ɌĂ΂��
    private void Start()
    {
        
    }

    


    //�Q�[���I��
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}