using UnityEngine;

public class CheeseCollector : MonoBehaviour
{
    public Transform locationA;
    public Transform locationB;
    public Transform spawnPoint;
    public GameObject objectToActivateAtFive;
    public GameObject Rat;

    [SerializeField] private AudioManager audioManager;

    private int cheeseCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cheese"))
        {
            cheeseCount++;

            // 🔹 Sonido al recoger queso
            if (audioManager != null)
            {
                audioManager.EffectReproduction(2);

                // Cambios de música
                if (cheeseCount == 3)
                {
                    audioManager.MusicReproduction(1);
                }
                else if (cheeseCount == 4)
                {
                    audioManager.MusicReproduction(0);
                }
            }

            Destroy(other.gameObject);

            if (cheeseCount == 3 && locationA != null)
            {
                transform.position = locationA.position;
            }
            else if (cheeseCount == 4 && locationB != null)
            {
                transform.position = locationB.position;
            }
            else if (cheeseCount == 5)
            {
                if (spawnPoint != null)
                    transform.position = spawnPoint.position;

                if (objectToActivateAtFive != null)
                    objectToActivateAtFive.SetActive(true);
                if (audioManager != null)
                {
                    audioManager.MusicReproduction(2);
                }

                if (Rat != null)
                {
                    Rat.SetActive(true);
                }
            }
        }
    }
    public int GetCheeseCount()
    {
        return cheeseCount;
    }

}
