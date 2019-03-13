using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KunaiBehaviour : MonoBehaviour {
  
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
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag == "Killbox")
        {
            Destroy(this.gameObject);
        }
       
    }
}
