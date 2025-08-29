using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stage1"); // 最初のステージ名
    }

    public void QuitGame()
    {
        Debug.Log("ゲームを終了します");
        Application.Quit();
    }
}
