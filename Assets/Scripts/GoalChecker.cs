using UnityEngine;
using TMPro;

public class GoalChecker : MonoBehaviour
{
    public GameObject clearText; // �N���A�e�L�X�g�iUI�j

    private bool isCleared = false;

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
            {
                clearText.SetActive(true); // UI�\���I
            }
        }
    }
}
