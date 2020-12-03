using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScriptV3 : MonoBehaviour
{
    private Rigidbody2D rb;
    // <NEW
    private GameObject ground;
    // NEW>
    public float horizontalForce = 7.0F;
    public float verticalForce = 250.0F;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // <NEW
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Tilemap"))
        {
            if(collision.GetContact(0).normal == Vector2.up)
            {
                ground = collision.gameObject;
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
    // NEW>

    void FixedUpdate()
    {
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * horizontalForce);
        // <NEW
        if(ground != null)
        // NEW>
        {
            rb.AddForce(transform.up * Input.GetAxis("Jump") * verticalForce);
        }
    }
}
