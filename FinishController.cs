using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinishController : MonoBehaviour {

    public GameObject NextLVLButton;
    public GameObject menuButton;
    public int level2 = 0;
    public PlayerController playerController;
    public AudioClip WinSound;

    public void Start()
    {
        NextLVLButton.SetActive(false);
        menuButton.SetActive(false);
    }
    public void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("PlayerK"))
        {
            AudioSource.PlayClipAtPoint(WinSound, transform.position);
            NextLVLButton.SetActive(true);
            menuButton.SetActive(true);
            //playerController.canMove = false;
        }
    }
}
