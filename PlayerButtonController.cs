using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButtonController : MonoBehaviour {
    public Button jumpButton;
    public GameObject JumpButton;
    public Button attackButton;
    public GameObject AttackButton;
    public GameObject player;
    public Button moveRightButton;
    public GameObject MoveRightButton;
    public Button moveLeftButton;
    public GameObject MoveLeftButton;
    public MenuController menuController;

    private bool  MovingRight, MovingLeft;

    public AudioSource footStep;
    public AudioClip jumpSound;
    public AudioClip attackSound;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
        Button Jumpbtn = jumpButton.GetComponent<Button>();
        Jumpbtn.onClick.AddListener(JumpOnClick);

        Button Attackbtn = attackButton.GetComponent<Button>();
        Attackbtn.onClick.AddListener(AttackOnClick);

        Button MoveRightbtn = moveRightButton.GetComponent<Button>();
        MoveRightbtn.onClick.AddListener(MoveRightOnClick);

        Button MoveLeftbtn = moveLeftButton.GetComponent<Button>();
        MoveLeftbtn.onClick.AddListener(MoveLeftOnClick);
       

        MovingLeft = false;
        MovingRight = false;

    }
	public void startLeft()
    {
        MovingLeft = true;
        footStep.enabled = true;
        footStep.loop = true;
        if (player.GetComponent<PlayerController>().facingRight)
        {
            player.GetComponent<PlayerController>().Flip();

        }
    }
    public void stopLeft()
    {
        MovingLeft = false;
        footStep.enabled = false;
        footStep.loop = false;
        player.GetComponent<Animator>().SetBool("Speed1", false);
        Debug.Log("Speed1");
    }
    public void startRight()
    {
        MovingRight = true;
        footStep.enabled = true;
        footStep.loop = true;
        if (player.GetComponent<PlayerController>().facingRight == false)
        {
            player.GetComponent<PlayerController>().Flip();
        }
    }
    public void stopRight()
    {
        MovingRight = false;
        footStep.enabled = false;
        footStep.loop = false;
        player.GetComponent<Animator>().SetBool("Speed1", false);
        Debug.Log("Speed1");
    }
	// Update is called once per frame
	void Update () { 
        if(MovingLeft)
        {
            player.GetComponent<Animator>().SetBool("Speed1", true);
            player.GetComponent<PlayerController>().MoveLeft();
        }     
        if(MovingRight)
        {
            player.GetComponent<Animator>().SetBool("Speed1", true);
            player.GetComponent<PlayerController>().MoveRight();
        }
        if(player)
        {
            JumpButton.SetActive(true);
            AttackButton.SetActive(true);
            MoveLeftButton.SetActive(true);
            MoveRightButton.SetActive(true);
        } 
    }
    public void MoveRightOnClick()
    {        
        player.GetComponent<PlayerController>().MoveRight();
        //Debug.Log("moveRight");       
    }
    public void MoveLeftOnClick()
    {       
        player.GetComponent<PlayerController>().MoveLeft();
        //Debug.Log("moveLeft");        
    }

    void JumpOnClick()
    {          
        if (player.GetComponent<PlayerController>().grounded)
        {
            player.GetComponent<PlayerController>().jump = true;
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }
    }
    void AttackOnClick()
    {
        Debug.Log("You have clicked the button!");
        if (player.GetComponent<KunaiController>().canThrow == true)
        {
            player.GetComponent<PlayerController>().animator.SetTrigger("Throwing");
            player.GetComponent<KunaiController>().attackButton();
            AudioSource.PlayClipAtPoint(attackSound, transform.position);
        }
    }    
}
