using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float moveX;
    public float maxSpeed;
    public Rigidbody2D rb2D;
    bool facingRight = true;
    Animator anim;
    public float jumpForce = 700f;
	public bool grounded, running;
    public Transform Groundcheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;


    //Flipping
    void Flip()

    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //Jumping
    void Jump()
    {			
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rb2D.AddForce(new Vector2(0, jumpForce));
        }
	}
    void Movement()
    {
		moveX = Input.GetAxisRaw ("Horizontal");
		rb2D.velocity = new Vector2 (moveX * maxSpeed, 0);

		anim.SetFloat ("SpeedX", Mathf.Abs (moveX));
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Movement ();
        if (moveX > 0 && !facingRight)
        
            Flip();
        
        else if (moveX < 0 && facingRight)
        
            Flip();

        grounded = Physics2D.OverlapCircle(Groundcheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rb2D.velocity.y);

    }

    void Update()
    {
        Jump();
        Debug.Log(rb2D.velocity.y);
    }

}
