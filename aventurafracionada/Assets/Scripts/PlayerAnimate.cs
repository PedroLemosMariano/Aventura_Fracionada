using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        // Atualizar o parâmetro "isMoving" no Animator
        bool isMoving = movement.magnitude > 0;
        animator.SetBool("isMoving", isMoving);

        // Pular
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }
    }
    
}
