using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


    private int speed = 15; //Скорость движения вперед/назад
    private GameObject Player;
    private int speed2 = 8; //Скорость движения вбок
    public bool run; //быстрый бег, переменная задействована в аниматоре

//Переменные для стамины
    private float MaxStamina = 100;
    public Texture Stamina;// место для перетаскивания текстуры в инспекторе:)
    private int otdux = 1; //это когда заебался
    private float BarWidth; //ширина полотна
    private float textureWidth;// не за что не угадаешь
    private float realStamina;// а про это я вообще молчу
    private int ustalost = 1; // это когда еще не заебался


    void Start()

    {


        BarWidth = Screen.width / 5; //ширина полотна = ширене экрана поделённой на 5. При смене разрешения экрана должно сохранять пропорции
        realStamina = MaxStamina;
        textureWidth = BarWidth;
        



        Player = (GameObject)this.gameObject;
        run = true; //отображает возможность спринта в данный момент
      
    }


// Создает и размещает иконку стамины на экране
    void OnGUI()
    {
        GUI.Box(new Rect(750, 530, textureWidth, 40), realStamina + " of " + MaxStamina);// создает маленький "канвас" черного цвета на екране. 750 и 530 это кординанты экрана, остально размер
        if (Stamina != null && textureWidth > 0)// если текстура стамины НЕ нулл и ее ширина больше 0
        {
            GUI.DrawTexture(new Rect(750, 550, textureWidth, 15), Stamina, ScaleMode.ScaleAndCrop, true, 10.0F);// размещает текстуру на екране. 750 и 550 это кординанты экрана, остально размер и далее выбор самой текстуры способ заполнения пространства.
        }
    }



void LateUpdate()
    {
        //Если спринт, стамина уменьшается
        if (speed == 30 && realStamina > 0)
        {
            realStamina = realStamina - ustalost;
        }

        //если НЕ спринт, стамину увеличивается
        if (speed == 15 && realStamina < 100 || speed == 0 && realStamina < 100)
        {
            realStamina = realStamina + otdux;
        }
        
        if(realStamina == 0)
        {
            run = false;
        }
        if(realStamina >= 30)
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
            Debug.Log("Sprint");
        }
        else
        {
           
            speed = 15;
            Debug.Log("Nixyia ne Sprint");
        }
        
    }
}

