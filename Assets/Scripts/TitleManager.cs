using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stage1"); // �ŏ��̃X�e�[�W��
    }

    public void QuitGame()
    {
        Debug.Log("�Q�[�����I�����܂�");
        Application.Quit();
    }
}
