using UnityEngine;
using UnityEngine.SceneManagement;

//�^�C�g���ɖ߂�
public class ClearManager : MonoBehaviour
{
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
