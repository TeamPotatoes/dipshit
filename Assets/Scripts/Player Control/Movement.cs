using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


    private int speed = 15; //Скорость движения вперед/назад
    private GameObject Player;
    private int speed2 = 8; //Скорость движения вбок
    public bool run; //быстрый бег, переменная задействована в аниматоре
    public bool sprintState;

   //Переменные для стамины

    //Переменные для прыжка
    public bool grounded = true;
    public float JumpPower = 200;
    private bool hasJump = false;
    private Rigidbody rb;

    void Start()

    {

  
        Player = (GameObject)this.gameObject;
        sprintState = true;
        run = false;
        rb = GetComponent<Rigidbody>(); //пока используется только в прыжке


    }


void LateUpdate()
    {
        //ПРОВЕРКА СТАМИНЫ 
        float realStamina_check = Player.GetComponent<Player_stats>().realStamina;
        if (realStamina_check <= 0)
      {
            sprintState = false;
      }
        if (realStamina_check >= 70)
       {
            sprintState = true;
       }
    }

    void FixedUpdate()
    {
        //Проверка прыжка
        if (hasJump)
        {
            rb.AddForce(transform.up * JumpPower);
            grounded = false;
            hasJump = false;
        }
    }
    void Update()
    {
        //проверка прыжка
        if (!grounded && rb.velocity.y == 0)
        {
            grounded = true;
        }
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            hasJump = true;
        }



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
        //поворот направо и налево
          if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            Player.transform.Rotate(0, -5, 0);
        }
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.RightArrow))
        {
            Player.transform.Rotate(0, 5, 0);
        }

        //Движения вбок
         if (Input.GetKey(KeyCode.D))
         {
            Player.transform.position += Player.transform.right * speed2 * Time.deltaTime;
         }
        if (Input.GetKey(KeyCode.A))
        {
            Player.transform.position -= Player.transform.right * speed2 * Time.deltaTime;
        }
        //Быстрый бег (надо скорректировать)
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && sprintState == true)
        {
            run = true;
            speed = 30; // режим, больного туберкулезом, бомжа наркомана
           // speed = speed * 2; // Режим флеша
            
        }
        else
        {
            run = false;
            speed = 15;

        }
    }
}

