﻿using UnityEngine;
using System.Collections;

public class PlayerControllerKnight : MonoBehaviour {

    public float maxSpeed = 5f;
    public float moveForce = 700f;
    private Rigidbody2D rb;
    public bool facingRight = true;
    public Animator animator;

    private Transform groundChecked;
    public bool grounded = false;
    public float jumpForce = 1000f;
    public bool jump = false;
    public bool canMove = true;
    private float deathDelay;

    public FinishController finishController;
    public RestartController other;

    public bool moveLeft, moveRight;

    public GameObject Background;
    public AudioClip deathSound;
    public GameObject Camera;

    private float lastY;
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Background = GameObject.FindGameObjectWithTag("Background");

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundChecked = transform.Find("GroundCheckPoint");
        lastY = 0;

        GameObject restart = GameObject.Find("RestartController");
        RestartController other = (RestartController)restart.GetComponent(typeof(RestartController));

       
    }
    void Update()
    {
        LayerMask groundMask = 1 << LayerMask.NameToLayer("Ground");
        grounded = Physics2D.Linecast(transform.position, groundChecked.position, groundMask);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
    void FixedUpdate()
    {
        

        if (canMove == true)
        {
            float h = Input.GetAxis("Horizontal");

            //if (h * rb.velocity.x < maxSpeed)
            //{
            //    rb.AddForce(Vector2.right * h * moveForce);
            //}
            //animator.SetFloat("Speed", Mathf.Abs(h));
            //Debug.Log(Mathf.Abs(rb.velocity.y));

            float fallrate = lastY - this.transform.position.y;
            animator.SetFloat("ySpeed", fallrate);
            float absoluteSpeed = Mathf.Abs(rb.velocity.x);
            if (absoluteSpeed > maxSpeed)
            {
                float sign = Mathf.Sign(rb.velocity.x);
                rb.velocity = new Vector2(sign * maxSpeed, rb.velocity.y);
            }
            if (h > 0 && !facingRight)
            {
                Flip();
            }
            else if (h < 0 && facingRight)
            {
                Flip();
            }
            if (jump)
            {
                animator.SetBool("Jump", true);               
                rb.AddForce(new Vector2(0f, jumpForce));
                jump = false;
            }
            /*if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Throwing");
            }*/
            lastY = this.transform.position.y;
        }
        if (canMove == false)
        {
            other.Restart();
        }
    }
    public void MoveLeft()
    {
        rb.AddForce(Vector2.left * moveForce);
    }
    public void MoveRight()
    {
        rb.AddForce(Vector2.right * moveForce);
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        Vector3 newScale = Background.transform.localScale;
        newScale.x *= -1;
        Background.transform.localScale = newScale;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "EnemyAttack")
        {

            canMove = false;
            //rb.mass = 20f;
            animator.SetTrigger("isDead");
            StartCoroutine(playerDeath(deathDelay));
        }

        if (col.gameObject.tag == "Killbox")
        {
            canMove = false;
            animator.SetTrigger("isDead");
            StartCoroutine(playerDeath(deathDelay));
        }

    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            canMove = false;
        }
    }
    IEnumerator playerDeath(float delay)
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        yield return new WaitForSeconds(0.6f);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        this.gameObject.SetActive(false);
        Camera.transform.parent = null;
        Background.transform.parent = null;
    }

}
