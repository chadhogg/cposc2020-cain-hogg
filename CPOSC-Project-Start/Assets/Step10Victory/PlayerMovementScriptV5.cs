﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementScriptV5 : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject ground;
    private GameObject restartText;
    // <NEW
    private GameObject victoryText;
    // NEW>
    public float horizontalForce = 7.0F;
    public float verticalForce = 250.0F;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        restartText = GameObject.Find("RestartText");
        // <NEW
        victoryText = GameObject.Find("VictoryText");
        // NEW>
    }

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

    // <NEW
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name.Equals("VictoryObject"))
        {
            victoryText.GetComponent<Text>().enabled = true;
            restart();
        }
    }
    // NEW>

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Tilemap"))
        {
            if(collision.GetContact(0).normal == Vector2.up)
            {
                ground = collision.gameObject;
                restartText.GetComponent<Text>().enabled = false;
                victoryText.GetComponent<Text>().enabled = false;
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
                restartText.GetComponent<Text>().enabled = false;
                victoryText.GetComponent<Text>().enabled = false;
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
        if(transform.position.y < -15)
        {
            restartText.GetComponent<Text>().enabled = true;
            restart();
        }


    }
}
