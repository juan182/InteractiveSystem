using UnityEngine;

public class SignInteraction : MonoBehaviour
{
    public GameObject messagePanel;         // Panel con el mensaje del letrero
    public GameObject interactionIndicator; // Elemento visual que se activa al acercarse

    private bool playerInRange = false;

    void Start()
    {
        // Asegurarse que los elementos estén desactivados al iniciar
        if (messagePanel != null)
            messagePanel.SetActive(false);

        if (interactionIndicator != null)
            interactionIndicator.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.R))
        {
            if (messagePanel != null)
                messagePanel.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (interactionIndicator != null)
                interactionIndicator.SetActive(true); // Mostrar "Presiona R" al acercarse
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (messagePanel != null)
                messagePanel.SetActive(false); // Ocultar el mensaje al alejarse

            if (interactionIndicator != null)
                interactionIndicator.SetActive(false); // Ocultar el indicador también
        }
    }
}
