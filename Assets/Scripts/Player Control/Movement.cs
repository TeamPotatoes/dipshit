using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


    public int speed = 15; //Скорость движения вперед/назад
    private GameObject Player;
    private int speed2 = 8; //Скорость движения вбок
    public bool run; //быстрый бег, переменная задействована в аниматоре

   //Переменные для стамины
    public float MaxStamina = 100;
    public int tired = 1; //это когда заебался
    public float realStamina;// а про это я вообще молчу
    public int fatigue = 1; // это когда еще не заебался


    void Start()

    {

  
        realStamina = MaxStamina;
        Player = (GameObject)this.gameObject;
        run = false; //отображает возможность спринта в данный момент
      
    }






void LateUpdate()
    {
        //Если спринт, стамина уменьшается
        if (speed == 30 && realStamina > 0)
        {
            realStamina = realStamina - fatigue;
        }

        //если НЕ спринт, стамину увеличивается
        if (speed == 15 && realStamina < 100 || speed == 0 && realStamina < 100)
        {
            realStamina = realStamina + tired;
        }
        

    //!!!!!!!!!!!!!!!!! ЭТОТ КОД ХЕРИТ СМЫСЛ ПАРАМЕТРА RUN. ПОЛУЧАЕТСЯ ЧТО ОН ВСЕГДА ВРУБЛЕН И ПЕРСОНАЖ ВСЕГДА БЕЖИТ. САМ ЗАМЕТИЛ ТОЛЬКО КОГДА ВРУБИЛ УСКОРЕНИЕ АНИМАЦИИ
        if(realStamina <= 0)
      {
          run = false;
      }
        if (realStamina >= 30)
       {
            run = true;
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
        if(Input.GetKey(KeyCode.LeftShift) && run == true)
        {
          
            speed = 30;
            
        }
        else
        {
           
            speed = 15;
            
        }
        
    }
}

