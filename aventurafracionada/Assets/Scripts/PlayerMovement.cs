using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float jumpDelay = 0.2f; // Tempo de delay antes de pular
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;
    public Transform model;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = model.GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f, groundLayer);

        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical += 1f;
            moveHorizontal += -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVertical += -1f;
            moveHorizontal += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal += -1f;
            moveVertical += -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal += 1f;
            moveVertical += 1f;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Atualiza a animação com base na velocidade
        float movementSpeed = movement.magnitude;
        animator.SetFloat("speed", movementSpeed);

        // Pular com delay
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump"); // Inicia a animação primeiro
            animator.SetBool("isGrounded", false);
            Invoke("Jump", jumpDelay); // Aguarda um tempo antes de aplicar a força do pulo
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }
}
