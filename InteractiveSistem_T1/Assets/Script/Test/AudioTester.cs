using UnityEngine;

public class AudioTester : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        // Probar primer efecto
        audioManager.EffectReproduction(0);

        // Esperar 2 segundos y luego reproducir música
        Invoke(nameof(TestMusic), 2f);
    }

    void TestMusic()
    {
        audioManager.MusicReproduction(0);
    }
}
