using UnityEngine;

public class MoveCOntroller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float JumpForce;
    private float XInput;


    [Header("Collision Check")]
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        AnimationControllers();
        CollisionChecks();

        XInput = Input.GetAxisRaw("Horizontal");

        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        FlipController();

    }

    private void AnimationControllers()
    {
        anim.SetFloat("xVelocity", rb.velocity.x);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }


    private void Jump()//make player jump
    {
        if (isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }

    private void Movement()//move player side to side
    {
        rb.velocity = new Vector2(XInput * moveSpeed, rb.velocity.y);
    }
    private void FlipController()//flip player to mouse
    {
        Vector3 mousePos  = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < transform.position.x && facingRight == true)
            Flip();
        else if (mousePos.x > transform.position.x && facingRight == false)
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void CollisionChecks()//check if player stands on the ground
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
