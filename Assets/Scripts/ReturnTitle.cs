using UnityEngine;
using UnityEngine.SceneManagement;

//�N���A��ʂ���^�C�g���ɖ߂�܂�
public class ClearManager : MonoBehaviour
{
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
