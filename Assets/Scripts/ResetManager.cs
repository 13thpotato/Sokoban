using UnityEngine;
using UnityEngine.SceneManagement; 

//キーボードのRでステージの状態をリセットします
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
