using UnityEngine;
using UnityEngine.SceneManagement; 

//�L�[�{�[�h��R�ŃX�e�[�W�̏�Ԃ����Z�b�g���܂�
public class RestartManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
