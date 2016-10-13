using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private float moveHorizontal;
    private Rigidbody rb;
    public float speed;

    void Start()

    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.AddForce(movement * speed);
    }
}
