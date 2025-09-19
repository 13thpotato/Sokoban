using UnityEngine;

public class FallTile : MonoBehaviour
{
    public Rigidbody2D fallTilemap; // Inspectorで「Fall」Tilemapをセットする

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (fallTilemap != null)
            {
                // Static → Dynamic に切り替えて落下開始
                fallTilemap.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}

