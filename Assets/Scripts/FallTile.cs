using UnityEngine;

public class FallTile : MonoBehaviour
{
    public Rigidbody2D fallTilemap; // Inspector�ŁuFall�vTilemap���Z�b�g����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (fallTilemap != null)
            {
                // Static �� Dynamic �ɐ؂�ւ��ė����J�n
                fallTilemap.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}

