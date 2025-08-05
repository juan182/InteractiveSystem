using UnityEngine;

public class ClueInteraction : MonoBehaviour
{
    public GameObject cheesePrefab;
    public AudioClip soundEffect;
    public GameObject interactionIndicator; // Objeto que se activa cuando el jugador est� cerca

    private bool isPlayerNearby = false;

    void Start()
    {
        if (interactionIndicator != null)
        {
            interactionIndicator.SetActive(false); // Aseg�rate de que inicie desactivado
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (soundEffect != null)
            {
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            }

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

            if (interactionIndicator != null)
            {
                interactionIndicator.SetActive(true); // Mostrar se�al visual
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (interactionIndicator != null)
            {
                interactionIndicator.SetActive(false); // Ocultar se�al visual
            }
        }
    }
}
