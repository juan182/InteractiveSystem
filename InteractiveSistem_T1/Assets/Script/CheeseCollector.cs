using UnityEngine;

public class CheeseCollector : MonoBehaviour
{
    public Transform locationA;
    public Transform locationB;
    public Transform spawnPoint;
    public GameObject objectToActivateAtFive;

    private int cheeseCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cheese"))
        {
            cheeseCount++;
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
            }
        }
    }
}
