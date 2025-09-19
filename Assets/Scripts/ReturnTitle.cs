using UnityEngine;
using UnityEngine.SceneManagement;

//クリア画面からタイトルに戻ります
public class ClearManager : MonoBehaviour
{
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
