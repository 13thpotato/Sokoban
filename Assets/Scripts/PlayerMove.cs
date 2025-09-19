using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveSpeed = 5f;

    public bool isMoving = false;
    public bool canWarp = false;
    private Coroutine moveCoroutine;

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
                    if (block == null || block.CompareTag("WarpTile"))
                    {
                        // SE���Ȃ炵�Ĕ�������
                        hit.GetComponent<BoxSE>()?.PlayPushSE();
                        hit.transform.position = boxTarget;
                        moveCoroutine = StartCoroutine(MoveToTarget(target));
                    }
                    // else: �����Ȃ��̂ŉ������Ȃ�
                }
                //�����Ȃ����^�C���ł���ꍇ
                else if (hit == null || hit.CompareTag("WarpTile") || hit.CompareTag("FallTile"))
                {
                    // �v���C���[�����ړ�
                    moveCoroutine = StartCoroutine(MoveToTarget(target));
                    //���[�v�t���O�I��
                    canWarp = true;
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

    public void WarpTo(Vector3 destination)
    {
        // �ړ��R���[�`�����~�߂�
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }

        // �����ړ�
        transform.position = destination;
        isMoving = false;
    }
}


