using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movimiento
    float horizontal;
    public float speed = 5f;

    //Animacion
    private Animator animator;

    //Audio
    [SerializeField] private AudioManager audioManager;

    //Posicion
    private Vector2 initialPosition;

    private Vector3 originalScale;

    //RigidBody
    private Rigidbody2D rb;

    //Marcas
    private bool miss = false;
    private bool isLookingUp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Posicion 
        initialPosition = transform.position;

        //Extra
        //originalScale = transform.localScale;
    }

    void Update()
    {
        //Direccion
        horizontal = Input.GetAxisRaw("Horizontal");

        //Movimiento
        if (horizontal < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (horizontal > 0) transform.localScale = new Vector2(1, 1);

        animator.SetBool("isRun", horizontal != 0);

        //Mirar hacia arriba
        isLookingUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        animator.SetBool("isLookUp", isLookingUp);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        if (miss == true)
        {
            ResetPosition();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }
}