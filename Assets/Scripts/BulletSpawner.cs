using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

    // Use this for initialization
    public GameObject bullet;
    public Transform startPos;

    private float elapsed;
	void Start () {
        elapsed = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) && elapsed>=0.5f)
        {
            Instantiate(bullet, startPos.position, Quaternion.identity);
            elapsed = 0f;
        }
	}
}
