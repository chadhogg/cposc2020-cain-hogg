using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float horizontalForce = 7.0F;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update whenever physics engine runs
    void FixedUpdate()
    {
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * horizontalForce);
    }
}
