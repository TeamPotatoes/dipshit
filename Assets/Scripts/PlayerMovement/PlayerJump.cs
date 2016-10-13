using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

    private bool grounded = true;
    public float JumpPower = 200;
    private bool hasJump = false;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!grounded && rb.velocity.y == 0)
        {
            grounded = true;
        }
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            hasJump = true;
        }

    }
    void FixedUpdate()
    {
        if (hasJump)
        {
            rb.AddForce(transform.up * JumpPower);
            grounded = false;
            hasJump = false;
        }
    }
}
