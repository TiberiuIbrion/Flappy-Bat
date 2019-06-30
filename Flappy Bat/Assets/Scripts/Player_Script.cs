using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Rigidbody2D player_rb;
    public float speed;
    public bool onGround;
    public float riseForce;
    float player_speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        onGround = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(onGround == false)
        {
            player_rb.AddForce(Vector2.right * speed);
            player_speed += speed;
        }
        else
        {
            player_rb.velocity = Vector2.zero;
        }
        if(player_speed > speed)
        {
            player_speed = player_speed - (player_speed - speed);
        }
        if(Input.GetMouseButtonDown(0))
        {
            player_rb.velocity = new Vector2(speed, riseForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
            Score_Script.scoreValue = 0;
        }
            if (collision.gameObject.tag == "Score Point")
        {
            Score_Script.scoreValue += 1;
        }
    }
}
