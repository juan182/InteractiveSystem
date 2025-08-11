using UnityEngine;

public class ClueInteraction : MonoBehaviour
{
    public GameObject cheesePrefab;
    public GameObject interactionIndicator;
    public bool action = false; // Indica si el jugador puede interactuar

    private bool isPlayerNearby = false;

    [SerializeField] private AudioManager audioManager; // Referencia al AudioManager

    void Start()
    {
        if (interactionIndicator != null)
        {
            interactionIndicator.SetActive(false); // Inicia desactivado
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // 🔹 Reproducir audio effect(1) al presionar E estando cerca
            if (audioManager != null)
            {
                audioManager.EffectReproduction(1);
            }

            // Instanciar queso
            if (cheesePrefab != null)
            {
                Instantiate(cheesePrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            action = true; // Jugador cerca → puede interactuar

            // 🔹 Mantener sonido al entrar (Effect 0)
            if (audioManager != null)
            {
                audioManager.EffectReproduction(0);
            }

            if (interactionIndicator != null)
            {
                interactionIndicator.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            action = false; // Jugador lejos → no puede interactuar

            if (interactionIndicator != null)
            {
                interactionIndicator.SetActive(false);
            }
        }
    }
}
