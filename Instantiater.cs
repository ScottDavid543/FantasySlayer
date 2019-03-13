using UnityEngine;
using System.Collections;

public class Instantiater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Object InstantiatePlayer(GameObject x)
    {
        Object y;
        y = Instantiate(x);
        return y;
    }
}
