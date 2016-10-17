using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private float moveHorizontal;
    private Rigidbody rb;
    public float speed;
    public Animator anim;
    private float inputH;
    private Transform tr;
    private bool FacingRight = true;
 
    void Start()

    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
        anim.Play("walking", -1, 0f);
        }
        
   //    inputH = Input.GetAxis("Horizontal");
   //   anim.SetFloat("inputH", inputH);

        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.AddForce(movement * speed);
        if (speed >= 20)
        {
            speed = 10;
        }  
    }
}
