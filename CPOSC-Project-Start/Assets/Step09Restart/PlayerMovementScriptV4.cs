using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementScriptV4 : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject ground;
    // <NEW
    private GameObject restartText;
    // NEW>
    public float horizontalForce = 7.0F;
    public float verticalForce = 250.0F;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // <NEW
        restartText = GameObject.Find("RestartText");
        // NEW>
    }

    // <NEW
    public void unFreeze()
    {
        Time.timeScale = 1;
    }

    public void restart()
    {
        transform.position = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
        Invoke("unFreeze", 0.05F);
        Time.timeScale = 0.01F;
    }
    // NEW>

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Tilemap"))
        {
            if(collision.GetContact(0).normal == Vector2.up)
            {
                ground = collision.gameObject;
                // <NEW
                restartText.GetComponent<Text>().enabled = false;
                // NEW>
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Tilemap"))
        {
            if(collision.GetContact(0).normal == Vector2.up)
            {
                ground = collision.gameObject;
                // <NEW
                restartText.GetComponent<Text>().enabled = false;
                // NEW>
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.Equals(ground))
        {
            ground = null;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * horizontalForce);
        if(ground != null)
        {
            rb.AddForce(transform.up * Input.GetAxis("Jump") * verticalForce);
        }
        // <NEW
        if(transform.position.y < -15)
        {
            restartText.GetComponent<Text>().enabled = true;
            restart();
        }
        // NEW>
    }
}
