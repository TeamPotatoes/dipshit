using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//СКРИПТ ОТОБРАЖАЕТ ВСПЛЫВАЮЩИЕ ТЕКСТЫ ЕСЛИ К НИМ БЛИЗКО ПОДОЙТИ
public class Show_text : MonoBehaviour {
    private GameObject message;
    private GameObject Player;
    void Start()
    {
       
        Player = (GameObject)this.gameObject;
        if (message == null)
        {
            message = GameObject.FindGameObjectWithTag("PopUp");
        }
        
    }

    void Update()
    {
        if ((message.transform.position - Player.transform.position).sqrMagnitude < 60)
        {
            message.SetActive(true);
        } else
        {
              message.SetActive(false);     
        }
        //foreach (GameObject.FindGameObjectWithTag("PopUp"))
         //   { }
    }
    
            
}
