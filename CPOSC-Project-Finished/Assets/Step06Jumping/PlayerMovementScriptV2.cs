using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScriptV2 : MonoBehaviour
{

    private Rigidbody2D rb;
    public float horizontalForce = 7.0F;
    public float verticalForce = 18.0F;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * horizontalForce);
        rb.AddForce(transform.up * Input.GetAxis("Jump") * verticalForce);
    }
}
