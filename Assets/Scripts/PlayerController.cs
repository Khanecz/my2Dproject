using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    public Rigidbody2D rb2D;
    bool facingRight = true;
    Animator anim;

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(moveX * maxSpeed, rb2D.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(moveX));

        float moveY = Input.GetAxis("Vertical");
        rb2D.velocity = new Vector2(rb2D.velocity.x, moveY * maxSpeed);
        anim.SetFloat("Speed", Mathf.Abs(moveY));


        if (moveX > 0 && !facingRight)
        
            Flip();
        
        else if (moveX < 0 && facingRight)
        
            Flip();
        

    }


}
