using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButtonControllerK : MonoBehaviour {
    public Button jumpButton;
    public GameObject JumpButton;
    public Button attackButton;
    public GameObject AttackButton;

    public Button moveRightButton;
    public GameObject MoveRightButton;
    public Button moveLeftButton;
    public GameObject MoveLeftButton;

    public GameObject playerK;
    public MenuController menuController;

    public AudioSource footStep;
    public AudioClip jumpSound;
    public AudioClip attackSound;

    private bool MovingRight, MovingLeft;
    //public PlayerController playerController;
    // Use this for initialization
    void Start () {
        

        playerK = GameObject.FindGameObjectWithTag("PlayerK");
        
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
        if (playerK.GetComponent<PlayerControllerKnight>().facingRight)
        {
            playerK.GetComponent<PlayerControllerKnight>().Flip();

        }
    }
    public void stopLeft()
    {
        MovingLeft = false;
        footStep.enabled = false;
        footStep.loop = false;
        playerK.GetComponent<Animator>().SetBool("Speed1", false);
        Debug.Log("Speed1");
    }
    public void startRight()
    {
        MovingRight = true;
        footStep.enabled = true;
        footStep.loop = true;
        if (playerK.GetComponent<PlayerControllerKnight>().facingRight == false)
        {
            playerK.GetComponent<PlayerControllerKnight>().Flip();
        }
    }
    public void stopRight()
    {
        MovingRight = false;
        footStep.enabled = false;
        footStep.loop = false;
        playerK.GetComponent<Animator>().SetBool("Speed1", false);
        Debug.Log("Speed1");
    }
    // Update is called once per frame
    void Update () {
        if (MovingLeft)
        {
            playerK.GetComponent<Animator>().SetBool("Speed1", true);
            playerK.GetComponent<PlayerControllerKnight>().MoveLeft();
        }
        if (MovingRight)
        {
            playerK.GetComponent<Animator>().SetBool("Speed1", true);
            playerK.GetComponent<PlayerControllerKnight>().MoveRight();
        }
        if (playerK)
        {
            JumpButton.SetActive(true);
            AttackButton.SetActive(true);
            MoveLeftButton.SetActive(true);
            MoveRightButton.SetActive(true);
        }
        //Button btn = jumpButton.GetComponent<Button>();
        // btn.onClick.AddListener(TaskOnClick);
    }
    public void MoveRightOnClick()
    {

        playerK.GetComponent<PlayerControllerKnight>().MoveRight();
        //Debug.Log("moveRight");


    }
    public void MoveLeftOnClick()
    {

        playerK.GetComponent<PlayerControllerKnight>().MoveLeft();
        //Debug.Log("moveLeft");

    }
    void JumpOnClick()
    {
        //playerController.jump = true;
       // Debug.Log("You have clicked the button!");
        
        if(playerK.GetComponent<PlayerControllerKnight>().grounded)
        { 
                
            playerK.GetComponent<PlayerControllerKnight>().jump = true;
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }

    }
    void AttackOnClick()
    {             
            playerK.GetComponent<PlayerControllerKnight>().animator.SetTrigger("Throwing");
        Input.GetButtonDown("Fire1");
        AudioSource.PlayClipAtPoint(attackSound, transform.position);
    }
    
}
