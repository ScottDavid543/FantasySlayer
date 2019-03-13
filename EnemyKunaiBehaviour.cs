using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyKunaiBehaviour : MonoBehaviour {
  
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
       
    }
}
