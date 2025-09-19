using UnityEngine;

public class WarpTile : MonoBehaviour
{
    public Transform warpDestination; // ���[�v��

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove playerMove = other.GetComponent<PlayerMove>();

        // �v���C���[�����[�v�^�C���ɐG�ꂽ�ꍇ
        if (other.CompareTag("Player") && playerMove.canWarp)
        {
            WarpPlayer(other);
            // ���[�v��t���O�I�t�i�����h�~�j
            playerMove.canWarp = false;
        }
       
    }

    public void WarpPlayer(Collider2D player)
    {

        // ���[�v���ʉ����Đ�����ꍇ
        // AudioManager.PlayWarpSound();

        // ���[�v��Ƀv���C���[���ړ�
        PlayerMove move = player.GetComponent<PlayerMove>();
        move.WarpTo(warpDestination.position);
    }
}


