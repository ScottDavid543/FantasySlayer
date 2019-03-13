using UnityEngine;
using System.Collections;

public class RestartController : MonoBehaviour {
    public GameObject GameOver;
    public GameObject RestartButton;
    public GameObject loadMenu;
    public bool gameActive;



  
    void Start () {
        GameOver.SetActive(false);
        RestartButton.SetActive(false);
        loadMenu.SetActive(false);

    }
	void Awake()
    {
        gameActive = false;
        StartCoroutine(startDelay());
    }
	// Update is called once per frame
	void Update () {
        
        if(gameActive)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject playerK = GameObject.FindGameObjectWithTag("PlayerK");

            if (player)
            {
               // Debug.Log("PLAYER: " + player.activeSelf);               
            }
            if (!playerK)
            {
                if (!player)
                {
                    
                    //Debug.Log("DEAD");
                    GameOver.SetActive(true);
                    RestartButton.SetActive(true);
                    loadMenu.SetActive(true);
                }
            }           
            if (playerK)
             {
                Debug.Log("PLAYER: " + player.activeSelf);               
             }
            if (!player)
            {
                if (!playerK)
                {
                   
                    // Debug.Log("DEAD");
                    GameOver.SetActive(true);
                    RestartButton.SetActive(true);
                    loadMenu.SetActive(true);
                }
            }
            
        }

        
    }
    public void Restart()
    {
        GameOver.SetActive(true);
        RestartButton.SetActive(true);
        loadMenu.SetActive(true);
       
    }

    IEnumerator startDelay()
    {
        yield return new WaitForSeconds(1);
        gameActive = true;
    }
}
