using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    // Use this for initialization
    public float dx;
    public float dy;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float posX = Hero.instance.transform.position.x - dx;
        float posY = Hero.instance.transform.position.y - dy;
        transform.position = new Vector3(posX, posY, transform.position.z);
	}
}
