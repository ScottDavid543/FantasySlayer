using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NinjaController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Animator animator;

    private float deathDelay;
    private float waitDelay;
    private float jumpDelay;
    public bool canMove;
    private bool dead;
    private Transform groundChecked;
    private bool grounded = false;
    private Transform playerChecked;
    public bool playerInRange = false;
    private Transform playerCheckedB;
    private bool playerBehind = false;
    private Transform playerCheckedClose;
    public bool playerClose = false;
    private Transform playerChecked2;
    private bool playerInRange2;
    private Transform kunaiChecked;
    private bool kunaiInRange;
    public float jumpForce = 2000f;
    private bool jump = false;

    public bool facingRight = true;

    private PlayerController playerController;
   
    public GameObject loadMenu;

    public RestartController restartController;

    private float lastY;
    

    /*public Text nCounterText;
    public int ninjaValue = 1;
    public static int nCounter;*/

    void Start()
    {
        canMove = true;
        dead = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        groundChecked = transform.Find("GroundCheckPointN");
        playerChecked = transform.Find("PlayerCheckPoint");
        playerCheckedB = transform.Find("PlayerCheckPointBack");
        playerCheckedClose = transform.Find("PlayerCheckPointClose");
        playerChecked2 = transform.Find("PlayerInRange2");
        kunaiChecked = transform.Find("KunaiCheckPoint");

        /*nCounter = GameObject.FindGameObjectsWithTag("enemyNinja").Length;
        nCounterText = GameObject.FindGameObjectWithTag("ninjaCounter").GetComponentInChildren<Text>();
        nCounterText.text = "Ninjas Remaining : " + nCounter.ToString();*/

    }

    // Update is called once per frame
    void Update()
    {
        LayerMask groundMask = 1 << LayerMask.NameToLayer("Ground");
        grounded = Physics2D.Linecast(transform.position, groundChecked.position, groundMask);
        LayerMask playerMask = 1 << LayerMask.NameToLayer("Player");
        playerInRange = Physics2D.Linecast(transform.position, playerChecked.position, playerMask);
        
        playerBehind = Physics2D.Linecast(transform.position, playerCheckedB.position, playerMask);
       
        playerClose = Physics2D.Linecast(transform.position, playerCheckedClose.position, playerMask);
        
        playerInRange2 = Physics2D.Linecast(transform.position, groundChecked.position, groundMask);

        LayerMask KunaiMask = 1 << LayerMask.NameToLayer("Kunai");
        kunaiInRange = Physics2D.Linecast(transform.position, kunaiChecked.position, KunaiMask);
    }
    void FixedUpdate()
    {
        if (canMove == true)
        {
            rb.velocity = new Vector2(transform.localScale.x * moveSpeed, rb.velocity.y);
            animator.SetFloat("Speed", rb.velocity.x);

            if (playerBehind == true)
            {
                Flip();

            }
            if (playerInRange == true)
            {
                //animator.SetBool("Throw", true);
                animator.SetTrigger("X");
                
                StartCoroutine(throwWait(waitDelay));
            }

            if (playerClose == true)
            {
                GetComponent<EnemyKunaiController>().canThrow = false;
                animator.SetTrigger("Close");
            }

            if (kunaiInRange && grounded)
            {
                jump = true;
            }
        }

        if (grounded == false)
        {
            Flip();
        }
        if (jump)
        {
            animator.SetBool("Jump", true);
            rb.AddForce(new Vector2(0f, jumpForce));
            StartCoroutine(jumpWait(jumpDelay));
            jump = false;
        }
        float fallrate = lastY - this.transform.position.y;
        animator.SetFloat("ySpeed", fallrate);
        {
            lastY = this.transform.position.y;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            canMove = false;
            animator.SetBool("isDead", true);
            StartCoroutine(ninDeath(deathDelay));
            //Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {

            //restartController.Restart();

        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            Flip();
        }
        /*if (col.gameObject.CompareTag("Attack"))
        {
            nCounter--;
            nCounterText.text = "Ninjas Remaining : " + nCounter.ToString();
        }*/
       /* if (playerInRange2 && Input.GetButton("Fire1"))
        {
            canMove = false;
            animator.SetBool("isDead", true);
            StartCoroutine(ninDeath(deathDelay));
        }*/
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayerK") && Input.GetButton("Fire1"))
        {          
            canMove = false;
            animator.SetBool("isDead", true);
            StartCoroutine(ninDeath(deathDelay));
            // counter--;
        }

    }
    IEnumerator ninDeath(float delay)
    {
        if (canMove == false)
        {
            yield return new WaitForSeconds(0.6f);
            //this.GetComponent<SpriteRenderer>().enabled = false;
            //this.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    IEnumerator throwWait(float delay)
    {
        yield return new WaitForSeconds(2f);
    }
    IEnumerator jumpWait(float delay)
    {
        yield return new WaitForSeconds(1f);
    }
}
