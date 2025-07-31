using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GoalChecker : MonoBehaviour
{
    public GameObject clearText;
    private bool isCleared = false;
    public float nextSceneDelay = 2f; // �b���iUI�������Ă���J�ځj

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
            Debug.Log("�N���A�I");
            isCleared = true;

            if (clearText != null)
                clearText.SetActive(true);

            // �w�莞�Ԍ�Ɏ��̃V�[����
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
            Debug.Log("�ŏI�X�e�[�W���N���A���܂����I");
            // �Ō�̃V�[���������ꍇ �� �ŏ��ɖ߂�
            SceneManager.LoadScene(0); 
        }
    }
}

