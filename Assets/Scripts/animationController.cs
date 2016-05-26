using UnityEngine;
using System.Collections;

public class animationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        GetComponent<Animator>().Play("explo");
    }
}
