using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GoalChecker : MonoBehaviour
{
    public GameObject clearText;
    private bool isCleared = false;
    public float nextSceneDelay = 2f; // 秒数（UIを見せてから遷移）

    void Update()
    {
        if (isCleared) return;

        GameObject[] goals = GameObject.FindGameObjectsWithTag("Goal");
        int correctBoxes = 0;

        foreach (GameObject goal in goals)
        {
            Collider2D hit = Physics2D.OverlapPoint(goal.transform.position);
            if (hit != null && hit.CompareTag("Box"))
            {
                correctBoxes++;
            }
        }

        if (correctBoxes == goals.Length)
        {
            Debug.Log("クリア！");
            isCleared = true;

            if (clearText != null)
                clearText.SetActive(true);

            // 指定時間後に次のシーンへ
            Invoke("LoadNextScene", nextSceneDelay);
        }
    }

    void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("最終ステージをクリアしました！");
            // 最後のシーンだった場合 → 最初に戻す
            SceneManager.LoadScene(0); 
        }
    }
}

