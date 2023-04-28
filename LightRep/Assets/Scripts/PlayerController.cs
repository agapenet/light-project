using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float horizontal;
    public int freeze;

    private float hangCounter;
    private float hangTime = .14f;
    private bool isGrounded;

    public Transform groundCheck;
    public LayerMask ground;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        freeze = 1;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, ground);
        HangTime();

        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * freeze, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && hangCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .7f);
        }
    }

    //Jump is in here too, but im too lazy to bring it out
    private void HangTime()
    {
        if (isGrounded)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
    }
}
