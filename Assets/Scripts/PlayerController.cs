using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight;
    public int health;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private GameObject button;
    private GameObject key;
    private GameObject ticket;
    private GameObject wallet;
    private GameObject phone;
    private GameObject money;

    // Start is called before the first frame update
    void Start()
    {
        Input.GetAxis("Horizontal");
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 5.0f;
        facingRight = true;
        health = 5;
        spriteRenderer = GetComponent<SpriteRenderer>();
        newSprite = Resources.Load<Sprite>("Sprites/Kid");
        button = GameObject.FindGameObjectWithTag("Button");
        button.SetActive(false);

        key = GameObject.FindGameObjectWithTag("Key");
        ticket = GameObject.FindGameObjectWithTag("Ticket");
        wallet = GameObject.FindGameObjectWithTag("Wallet");
        phone = GameObject.FindGameObjectWithTag("Phone");
        money = GameObject.FindGameObjectWithTag("Money");
        key.SetActive(false);
        ticket.SetActive(false);
        wallet.SetActive(false);
        phone.SetActive(false);
        money.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        if (GameManager.HasKey && GameManager.HasTicket && GameManager.HasWallet && GameManager.HasPhone && GameManager.HasMoney) {
            SceneManager.LoadScene("Win");
        }
    }

    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        Move();
        if (this.health == 0) {
            ChangeSprite();
            button.SetActive(true);
        }
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

    void ChangeSprite() {
        spriteRenderer.sprite = newSprite; 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (spriteRenderer.sprite == newSprite && !other.gameObject.CompareTag("Wall")) { 
            Physics2D.IgnoreLayerCollision(0, 2, true);
        }
        if (other.gameObject.CompareTag("Searchable")) {
            print("search");
            SearchableAttributes attributes = other.gameObject.GetComponent<SearchableAttributes>();
            switch (attributes.item) {
                case Constants.ItemType.Key:
                    GameManager.HasKey = true;
                    print("Picked up key");
                    key.SetActive(true);
                    break;
                case Constants.ItemType.Ticket:
                    GameManager.HasTicket = true;
                    print("Picked up ticket");
                    ticket.SetActive(true);
                    break;
                case Constants.ItemType.Wallet:
                    GameManager.HasWallet = true;
                    print("Picked up wallet");
                    wallet.SetActive(true);
                    break;
                case Constants.ItemType.Phone:
                    GameManager.HasPhone = true;
                    print("Picked up phone");
                    phone.SetActive(true);
                    break;
                case Constants.ItemType.Money:
                    GameManager.HasMoney = true;
                    print("Picked up money");
                    money.SetActive(true);
                    break;
                default:
                    print("Picked up nothing");
                    break;
            }
        }
    }
}
