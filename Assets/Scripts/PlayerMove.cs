using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveSpeed = 5f;

    private bool isMoving = false;
    private Vector3 targetPos;

    void Update()
    {
        if (!isMoving)
        {
            Vector3 dir = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.UpArrow)) dir = Vector3.up;
            else if (Input.GetKeyDown(KeyCode.DownArrow)) dir = Vector3.down;
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) dir = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow)) dir = Vector3.right;

            if (dir != Vector3.zero)
            {
                Vector3 target = transform.position + dir;

                // Box�����邩���ׂ�
                Collider2D hit = Physics2D.OverlapPoint(target);
                if (hit != null && hit.CompareTag("Box"))
                {
                    Vector3 boxTarget = target + dir;
                    // ���̐�ɉ������邩�H�i�ǂ�ʂ̔��Ȃǁj
                    Collider2D block = Physics2D.OverlapPoint(boxTarget);
                    if (block == null)
                    {
                        // SE���Ȃ炵�Ĕ�������
                        hit.GetComponent<BoxSE>()?.PlayPushSE();
                        hit.transform.position = boxTarget;
                        StartCoroutine(MoveToTarget(target));
                    }
                    // else: �����Ȃ��̂ŉ������Ȃ�
                }
                else if (hit == null)
                {
                    // �v���C���[�����ړ�
                    StartCoroutine(MoveToTarget(target));
                }
            }
        }
    }

    System.Collections.IEnumerator MoveToTarget(Vector3 target)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
        isMoving = false;
    }
}
