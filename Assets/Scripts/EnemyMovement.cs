using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    // Use this for initialization
    public LayerMask whatIsGround;
    public float radius;
    bool isInGround;
    Transform groundPos;
    public bool movingLeft;
    float speed = 2f;
    Rigidbody2D body;
	void Start () {
        groundPos = transform.GetChild(0);
        if (movingLeft)
        {
            transform.localScale = new Vector3(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f);
        }
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        isInGround = Physics2D.OverlapCircle(groundPos.position, radius, whatIsGround);
        if(transform.localScale.x == 1)
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
        if (!isInGround)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
	}
}
