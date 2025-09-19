using UnityEngine;

public class WarpTile : MonoBehaviour
{
    public Transform warpDestination; // ワープ先

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove playerMove = other.GetComponent<PlayerMove>();

        // プレイヤーがワープタイルに触れた場合
        if (other.CompareTag("Player") && playerMove.canWarp)
        {
            WarpPlayer(other);
            // ワープ後フラグオフ（往復防止）
            playerMove.canWarp = false;
        }
       
    }

    public void WarpPlayer(Collider2D player)
    {

        // ワープ効果音を再生する場合
        // AudioManager.PlayWarpSound();

        // ワープ先にプレイヤーを移動
        PlayerMove move = player.GetComponent<PlayerMove>();
        move.WarpTo(warpDestination.position);
    }
}


