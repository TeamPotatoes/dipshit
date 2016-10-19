using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private float moveHorizontal;
    private Rigidbody rb;
    private int speed = 25;
    private Transform tr;
    private bool FacingForward = true;
    private bool FacingUp = true;
    private GameObject Player;

    void Start()

    {
        Player = (GameObject)this.gameObject;
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Player.transform.position += Player.transform.forward * speed * Time.deltaTime;
        }

    }


    void FixedUpdate()
    {  
        if (Input.GetKey(KeyCode.RightArrow)&& FacingForward == false)
          {
              tr.Rotate(0, 180, 0);
            FacingForward = true;
          }
        else
        {
            tr.Rotate(0, 0, 0);
        }
          if (Input.GetKey(KeyCode.LeftArrow) && FacingForward == true)
          {
              tr.Rotate(0, -180, 0);
              FacingForward = false;

          }
          
          else
        {
            tr.Rotate(0, 0, 0);
        }
      

    }
}

