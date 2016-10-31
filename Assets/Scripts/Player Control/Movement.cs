using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


    private int speed = 15; //Скорость движения вперед/назад
    private GameObject Player;
    private int speed2 = 8; //Скорость движения вбок
    public bool run; //быстрый бег, переменная задействована в аниматоре
    private bool sprintState;

   //Переменные для стамины
    public float MaxStamina = 100;
    public int tired = 1; //это когда заебался
    public float realStamina;// а про это я вообще молчу
    public int fatigue = 1; // это когда еще не заебался
 

    void Start()

    {

  
        realStamina = MaxStamina;
        Player = (GameObject)this.gameObject;
        sprintState = true;
        run = false;
            


    }






void LateUpdate()
    {
        //Если спринт, стамина уменьшается
        if (run == true && realStamina > 0  && Input.GetKey(KeyCode.W))
        {
            realStamina = realStamina - fatigue;
           
        }

        //если НЕ спринт, стамину увеличивается
        if (run == false && realStamina < 100)
        {
            realStamina = realStamina + tired;
        

        }
        

        if(realStamina <= 0)
      {
            sprintState = false;
      }
        if (realStamina >= 70)
       {
            sprintState = true;
       }
   
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

