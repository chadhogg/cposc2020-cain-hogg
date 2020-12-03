using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScriptV2 : MonoBehaviour
{

    private Rigidbody2D rb;
    public float horizontalForce = 7.0F;

    // <NEW
    public float verticalForce = 18.0F;
    // NEW>

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * horizontalForce);
        // <NEW
        rb.AddForce(transform.up * Input.GetAxis("Jump") * verticalForce);
        // NEW>
    }
}
