using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI; // Asignar el panel desde el Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Tecla para pausar
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true;
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true); // Muestra el panel
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        isPaused = false;
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false); // Oculta el panel
    }

    // Función para salir del juego
    public void QuitGame()
    {
        Debug.Log("Salio del juego...");
        Application.Quit();
    }

    // Función para reiniciar el juego
    public void RestartGame()
    {
        Time.timeScale = 1f; // Asegura que el tiempo se reanude antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
