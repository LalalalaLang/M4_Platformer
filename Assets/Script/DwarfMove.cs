using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfMove : MonoBehaviour
{
    //to move
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Vector2 direction;

    //to detect ground
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    //to check jumps
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    //to jump
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    //
    [Header("Related GameObjects")]
    [SerializeField]
    private GameObject graphics;

    [SerializeField]
    private Animator animator;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = graphics.GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }

        isGrounded = Physics2D.OverlapCircle(rb.position, checkRadius, whatIsGround);

        if(moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        SpriteOrientation();

        animator.SetFloat("MoveX", Mathf.Abs(direction.x));
        animator.SetFloat("MoveY", rb.velocity.y);

    }

    private void SpriteOrientation()
    {
        if (direction.x < 0f)
        {
            graphics.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x > 0f)
        {
            graphics.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}


