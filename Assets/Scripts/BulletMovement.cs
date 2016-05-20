using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    // Use this for initialization
    private float dir;
	void Start () {
        dir = Hero.instance.transform.localScale.x;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(5f * Time.deltaTime * dir, 0f, 0f);
	}
}
