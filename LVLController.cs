using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVLController : MonoBehaviour
{

    /*public GameObject MZombieSign;
    public GameObject FZombieSign;
    public GameObject FNinjaSign;
    public GameObject MNinjaSign;*/
    public GameObject enemySign;
    public int sign = 1;
    


     public void OnTriggerEnter2D(Collider2D col)
     {
         if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag(("PlayerK")))
         {
            enemySign.SetActive(true);
         }
     }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag(("PlayerK")))
        {
            enemySign.SetActive(false);
        }
    }

    /* public void OnTriggerEnter2D(Collider2D col)
     {
         if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag(("PlayerK")))
         {                     
             MZombieSign.SetActive(true);
             FZombieSign.SetActive(true);
             MNinjaSign.SetActive(true);
             FNinjaSign.SetActive(true);
         }
     }

    public void OnTriggerExit2D(Collider2D col)
     {
         if(col.gameObject.CompareTag("Player")|| col.gameObject.CompareTag(("PlayerK")))
         {
             MZombieSign.SetActive(false);
             FZombieSign.SetActive(false);
             MNinjaSign.SetActive(false);
             FNinjaSign.SetActive(false);
         }
     }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag(("PlayerK")))
        {
            if (sign == 1)
            {
                MZombieSign.SetActive(true);
            }
            if (sign == 2)
            {
                FZombieSign.SetActive(true);
            }
            if (sign == 3)
            {
                MNinjaSign.SetActive(true);
            }
            if (sign == 4)
            {
                FNinjaSign.SetActive(true);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag(("PlayerK")))
        {
            
            if (sign == 1)
            {
                MZombieSign.SetActive(false);
                sign = 2;
            }
            if (sign == 2)
            {
                FZombieSign.SetActive(false);
                sign = 3;
            }
            if (sign == 3)
            {
                MNinjaSign.SetActive(false);
                sign = 4;
            }
            if (sign == 4)
            {
                FNinjaSign.SetActive(false);
                sign = 5;
            }
        }

    }*/
    private void Update()
    {
        //Debug.Log(sign);
    } 
}