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

                // Boxがあるか調べる
                Collider2D hit = Physics2D.OverlapPoint(target);
                if (hit != null && hit.CompareTag("Box"))
                {
                    Vector3 boxTarget = target + dir;
                    // 箱の先に何かあるか？（壁や別の箱など）
                    Collider2D block = Physics2D.OverlapPoint(boxTarget);
                    if (block == null || block.CompareTag("WarpTile"))
                    {
                        // SEをならして箱を押す
                        hit.GetComponent<BoxSE>()?.PlayPushSE();
                        hit.transform.position = boxTarget;
                        moveCoroutine = StartCoroutine(MoveToTarget(target));
                    }
                    // else: 押せないので何もしない
                }
                //何もないかタイルである場合
                else if (hit == null || hit.CompareTag("WarpTile") || hit.CompareTag("FallTile"))
                {
                    // プレイヤーだけ移動
                    moveCoroutine = StartCoroutine(MoveToTarget(target));
                    //ワープフラグオン
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
        // 移動コルーチンを止める
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }

        // 強制移動
        transform.position = destination;
        isMoving = false;
    }
}


