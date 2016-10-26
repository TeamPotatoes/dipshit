using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//СКРИПТ ОТОБРАЖАЕТ ВСПЛЫВАЮЩИЕ ТЕКСТЫ ЕСЛИ К НИМ БЛИЗКО ПОДОЙТИ
public class Show_text : MonoBehaviour {
       
    public GameObject[] ShowMe; //Эта штука в инспекторе (в скрипте) при старте игры, отобразит все объекты с тэгом PopUp. Кусочек кода для работы есть в Update.
    
    void Start()
    {
                     
    }

    void Update()
    {
        ShowMe = GameObject.FindGameObjectsWithTag("PopUp"); // тот самый кусочек кода
        
            GameObject[] signs; // оказывается можно создавать переменные и сразу придавать им значение непосредственно в скрипте. Эта переменная - список
            signs = GameObject.FindGameObjectsWithTag("PopUp"); // оказывается есть FindGameObjectWithTag и FindGameObjectsWithTag - первое переменная, второе список
            GameObject closest = null; //объявляем пустую переменную - ближайший объект 
            float distance = Mathf.Infinity; //объявляем расстояние - математическая бесконечность (т.е. все)
            foreach (GameObject sign in signs) // создаем объект sign. для каждого (foreach) sign в списке signs - делаем следующее ... 
            {
                Vector3 diff = sign.transform.position - transform.position; // вычисляем расстояние
                float curdistance = diff.sqrMagnitude; //делаем переменную с текущим расстоянием и приравниваем его к вычесленному квадрату расстояния...ипаная математика 
                if (curdistance < distance) // тут понятно
                {
                    closest = sign; 
                    distance = curdistance; 
                }
            }
           
        
         if ((closest.transform.position - transform.position).sqrMagnitude < 60)
        {
            print("You're close!"); // эта штука отображает в консоли инфу - далеко ты или близко от объекта с тэгом popup. Значит скрипт работает
            //closest.SetActive(true); - это не пойдет, т.к. оно выключает объекты и весь смысл кода выше летит к херам. Надо найти альтернативу включению
        } else 
        {
            print("You're far!");
             //closest.SetActive(false);     
         }
       
    }
    
            
}
