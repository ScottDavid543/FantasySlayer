using UnityEngine;
using System.Collections;

public class KunaiController : MonoBehaviour {
    public Rigidbody2D rbKunai;
    public float speedR = 20f;
    public float speedL = -20f;
    private PlayerController playerController;
    [HideInInspector]
    public bool facingRight = true;
    public float throwDelay;
    public bool canThrow;
    public float throwCooldownTime;

    // Use this for initialization
    void Start () {
        canThrow = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<PlayerController>().canMove == true)
        {
            /*if (Input.GetButtonDown("Fire1") && canThrow == true)
            {
                StartCoroutine(ScheduleThrow(throwDelay));
                StartCoroutine(throwCooldown(throwCooldownTime));
            }*/
        }


    }
    void Awake()
    {
        playerController = transform.root.GetComponent<PlayerController>();
    }
    IEnumerator ScheduleThrow(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (playerController.facingRight)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 270f));
            Rigidbody2D KunaiInstance = Instantiate(rbKunai, transform.position + new Vector3(0.2f, 0, 0), rotation) as Rigidbody2D;
            KunaiInstance.velocity = new Vector2(speedR, 0);
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            Rigidbody2D KunaiInstance = Instantiate(rbKunai, transform.position + new Vector3(-0.2f, 0, 0), rotation) as Rigidbody2D;
            KunaiInstance.velocity = new Vector2(speedL, 0);
        }
    }
    IEnumerator throwCooldown(float delay)
    {
        canThrow = false;
        yield return new WaitForSeconds(delay);
        canThrow = true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    public void attackButton()
    {
        if (GetComponent<PlayerController>().canMove == true)
        {
                StartCoroutine(ScheduleThrow(throwDelay));
                StartCoroutine(throwCooldown(throwCooldownTime));
        }
    }

}
