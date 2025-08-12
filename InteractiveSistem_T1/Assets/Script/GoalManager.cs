using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;    // AudioManager asignado en Inspector
    [SerializeField] private Transform objetoAMover;       // Objeto que se moverá
    [SerializeField] private float velocidad = 2f;         // Velocidad del movimiento
    [SerializeField] private GameObject objetoAActivar;    // Objeto que se activará cuando cheeseCount sea 5

    private bool movimientoIniciado = false;
    private float tiempoMovimiento = 0f;

    private void Start()
    {
        StartCoroutine(EsperarYEmpezarMovimiento(8f));
    }

    private System.Collections.IEnumerator EsperarYEmpezarMovimiento(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        movimientoIniciado = true;
        tiempoMovimiento = 0f;

        if (audioManager != null)
        {
            audioManager.EffectReproduction(5);
        }
    }

    private void Update()
    {
        if (movimientoIniciado && objetoAMover != null)
        {
            if (tiempoMovimiento < 10f)
            {
                objetoAMover.Translate(Vector2.right * velocidad * Time.deltaTime);
                tiempoMovimiento += Time.deltaTime;
            }
            else
            {
                Destroy(objetoAMover.gameObject);
                movimientoIniciado = false;
            }
        }
    }
}
