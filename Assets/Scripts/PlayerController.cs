using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        Input.GetAxis("Horizontal");
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 5.0f;
        facingRight = true;
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        Move();
    }

    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;
    }

    // void onAnimatorMove(){
    //     animator.SetFloat("Horizontal", movement.x);
    //     animator.SetFloat("Vertical", movement.y);
    //     animator.SetFloat("Speed", movement.sqrMagnitude);
    // }

    void Move(){
        // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        // transform.position = transform.position + movement * Time.deltaTime * movementSpeed;
        // rb.position = rb.position + movement * Time.deltaTime * movementSpeed;
        rb.velocity = movement * movementSpeed;
        if (Input.GetAxisRaw ("Horizontal") > 0.0f && !facingRight) 
        {
            //If we're moving right but not facing right, flip the sprite and set     facingRight to true.
            Flip ();
            facingRight = true;
        } else if (Input.GetAxisRaw("Horizontal") < 0.0f && facingRight) 
        {
            //If we're moving left but not facing left, flip the sprite and set facingRight to false.
            Flip ();
            facingRight = false;
        }
    }

    void Flip() {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
