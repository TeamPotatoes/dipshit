using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


    private int speed = 15; //Скорость движения вперед/назад
  // private Transform tr;
  //  private bool FacingForward = true;
    private GameObject Player;
    private int speed2 = 5; //Скорость движения вбок

    void Start()

    {
        Player = (GameObject)this.gameObject;
      //  tr = GetComponent<Transform>();
    }



    void Update()
    {
        // Суицид:)
        if (Input.GetKey(KeyCode.R))
        {
            Destroy(Player);
        }
        //движения вперед и назад
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
            Player.transform.position += Player.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Player.transform.position -= Player.transform.forward * speed * Time.deltaTime;
        }
        //поворотна право и на лево
          if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            Player.transform.Rotate(0, -5, 0);
        }
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.RightArrow))
        {
            Player.transform.Rotate(0, 5, 0);
        }

        //Движения в бок
         if (Input.GetKey(KeyCode.D))
         {
            Player.transform.position += Player.transform.right * speed2 * Time.deltaTime;
         }
        if (Input.GetKey(KeyCode.A))
        {
            Player.transform.position -= Player.transform.right * speed2 * Time.deltaTime;
        }

    }


    void FixedUpdate()
    {  
       /* if (Input.GetKey(KeyCode.W)&& FacingForward == false)
          {
              tr.Rotate(0, 180, 0);
            FacingForward = true;
          }
        else
        {
            tr.Rotate(0, 0, 0);
        }
          if (Input.GetKey(KeyCode.S) && FacingForward == true)
          {
              tr.Rotate(0, -180, 0);
              FacingForward = false;

          }
          
          else
        {
            tr.Rotate(0, 0, 0);
        }*/
      

    }
}

