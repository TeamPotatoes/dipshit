using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//СКРИПТ ОТОБРАЖАЕТ ВСПЛЫВАЮЩИЕ ТЕКСТЫ ЕСЛИ К НИМ БЛИЗКО ПОДОЙТИ
public class Show_text : MonoBehaviour {
       
    public GameObject[] ShowMe; // Инфа для себя, чтобы видеть в инспекторе сколько существует объектов с определенным тегом на сцене [УДАЛИТЬ ПОТОМ]

    void Start()
    {
        
    }

    void LateUpdate()
    {
        ShowMe = GameObject.FindGameObjectsWithTag("PopUp"); // постоянно обновляем информацию о том сколько объектов на сцене [УДАЛИТЬ ПОТОМ]

        GameObject[] signs; //создаем переменную со списком объектов 
            signs = GameObject.FindGameObjectsWithTag("PopUp"); //все объекты с тегом PopUp чтобы попадали в этот список
            GameObject closest = null; // создаем переменную с объектом который будет ближайшим к персонажу
            float distance = Mathf.Infinity; // создаем переменную которая будет рассчитывать расстояние и задаем чтобы она охватывала все возможное пространство
            foreach (GameObject sign in signs)  // для каждого объекта sign в списке signs делаем следующее..
            {
                Vector3 diff = sign.transform.position - transform.position; // создаем переменную "Разница" которая выссчитывает расстояние от позиции sign до игрока
                float curdistance = diff.sqrMagnitude; // создаем переменную "текущее расстояние" которое равно квадрату переменной "разница" (создает нивидимое пространство вокруг персонажа)
                if (curdistance < distance) // если текущее расстояние меньше общего расстояния
                {
                    closest = sign; // близайший объект присвается переменной sign
                    distance = curdistance; // дистанция приравнивается к текущей дистанции
                }
            }

          // код для включения - выключения всплывающей таблички в зависимости от расстояния        
         if ((closest.transform.position - transform.position).sqrMagnitude < 60)
        {
            closest.GetComponent<Canvas>().enabled = true;
            
        } else 
        {
            closest.GetComponent<Canvas>().enabled = false;
               
         }
       
    }
    
            
}
