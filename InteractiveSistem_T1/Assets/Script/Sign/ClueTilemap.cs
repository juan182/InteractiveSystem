using UnityEngine;
using UnityEngine.Tilemaps;

public class ClueTilemap : MonoBehaviour
{
    public Tilemap tilemapToDisable;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tilemapToDisable.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
