using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D body;
    public LayerMask whatIsGround;
    public Transform groundPos;
    public float radius;
    public float jumpPower;
    bool doubleJump;
    bool onGround;

    public static Hero instance;

    void Awake()
    {
        instance = this;
        
    }

    void Start () {
        body = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(PlayerPrefs.GetFloat("PosX", transform.position.x), PlayerPrefs.GetFloat("PosY", transform.position.y), transform.position.z);
	}

    // Update is called once per frame
    void Update() {
        onGround = Physics2D.OverlapCircle(groundPos.position, radius, whatIsGround);
        print(onGround);
        float forceX = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                doubleJump = false;
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            }
            else
            {
                if (!doubleJump)
                {
                    doubleJump = true;
                    new Vector2(body.velocity.x, jumpPower);
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //body.velocity = new Vector2(-2f, body.velocity.y);
            forceX = -2f;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // body.velocity = new Vector2(2f, body.velocity.y);
            forceX = 2f;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        body.velocity = new Vector2(forceX, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "check")
        {
            SavePos(col.gameObject.transform.position.x, col.gameObject.transform.position.y);
            
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "dead")
        {
            SceneManager.LoadScene("main");
        }
    }
    void SavePos(float x, float y)
    {
        PlayerPrefs.SetFloat("PosX", x);
        PlayerPrefs.SetFloat("PosY", y);
    }
}
