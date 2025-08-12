using UnityEngine;
using UnityEngine.Tilemaps;

public class ClueTilemap : MonoBehaviour
{
    public Tilemap tilemapToDisable;
    [SerializeField] private AudioManager audioManager; // 🎵 Referencia al AudioManager

    [Header("Movimiento del Tilemap")]
    public float moveSpeed = 2f;        // Velocidad de subida
    public float targetY = 16.23f;      // Altura final

    private bool movingUp = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioManager != null)
                audioManager.EffectReproduction(4); // 🔊 Sonido effect(4)

            movingUp = true; // Activar el movimiento
        }
    }

    void Update()
    {
        if (movingUp && tilemapToDisable != null)
        {
            Vector3 pos = tilemapToDisable.transform.position;

            // Mover hacia arriba
            pos.y = Mathf.MoveTowards(pos.y, targetY, moveSpeed * Time.deltaTime);
            tilemapToDisable.transform.position = pos;

            // Si ya llegó a la altura deseada → destruir
            if (Mathf.Approximately(pos.y, targetY))
            {
                Destroy(tilemapToDisable.gameObject);
                Destroy(gameObject); // Destruir el trigger también
            }
        }
    }
}
