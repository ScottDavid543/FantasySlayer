using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour {
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    public Animator animator;

    private float deathDelay;
    private float waitDelay;
    private bool canMove;
    private bool dead;
    private Transform groundChecked;
    private bool grounded = false;
    private Transform playerChecked;
    public bool playerInRange = false;
    private Transform playerCheckedB;
    private bool playerBehind = false;
    

    private bool facingRight = true;

    public GameObject youWin;
    public GameObject loadMenu;
    

  //  public  Text counterText;
   // public int zombieValue = 1;
   // public static int counter;

    public RestartController restartController;

    // Use this for initialization
    void Start()
    {
        canMove= true;
        dead = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundChecked = transform.Find("GroundCheckPointZ");
        playerChecked = transform.Find("PlayerCheckPoint");
        playerCheckedB = transform.Find("PlayerCheckPointBack");

       // counter = GameObject.FindGameObjectsWithTag("Enemy").Length;
       // counterText = GameObject.FindGameObjectWithTag("zombieCounter").GetComponentInChildren<Text>();
       // counterText.text = "Zombies Remaining : " + counter.ToString();

        

    }
    void Update()
    {
        LayerMask groundMask = 1 << LayerMask.NameToLayer("Ground");
        grounded = Physics2D.Linecast(transform.position, groundChecked.position, groundMask);
        LayerMask playerMask = 1 << LayerMask.NameToLayer("Player");
        playerInRange = Physics2D.Linecast(transform.position, playerChecked.position, playerMask);
        LayerMask playerMaskB = 1 << LayerMask.NameToLayer("Player");
        playerBehind = Physics2D.Linecast(transform.position, playerCheckedB.position, playerMask);

       

        //Debug.Log(canMove);
    }
	void FixedUpdate()
    {
        if (canMove == true)
        {
            rb.velocity = new Vector2(transform.localScale.x * moveSpeed, rb.velocity.y);
            animator.SetFloat("Speed", rb.velocity.x);

            if (playerInRange == true)
            {               
                animator.SetBool("playerInRange", true);               
            }
            if (playerInRange == false)
            {
                animator.SetBool("playerInRange", false);
            }
            if (playerBehind == true) 
            {
                Flip();            
            }
        }
        if (grounded == false)
        {
            Flip();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            canMove = false;
            animator.SetBool("dead", true);
            StartCoroutine(zomDeath(deathDelay));
            //Destroy(this.gameObject);
        }
       /* if (col.gameObject.CompareTag("Attack"))
        {
            counter--;
            counterText.text = "Zombies Remaining : " + counter.ToString();
        }*/
        if (col.gameObject.CompareTag("Player") ) 
        {
            //restartController.Restart();
            //GameOver.SetActive(true);
            //RestartButton.SetActive(true);
            //loadMenu.SetActive(true);
        }
        if(col.gameObject.CompareTag("Enemy"))
        {
            Flip();
        }
        if (col.gameObject.CompareTag("enemyNinja"))
        {
            Flip();
        }
                   
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayerK") && Input.GetButton("Fire1"))
        {
            canMove = false;
            animator.SetBool("dead", true);
            StartCoroutine(zomDeath(deathDelay));
            // counter--;
        }

    }
    IEnumerator zomDeath(float delay)
    {
        if (canMove == false)
        {
            yield return new WaitForSeconds(0.92f);
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    

    
}
