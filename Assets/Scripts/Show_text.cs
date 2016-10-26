using UnityEngine;
using System.Collections;

//СКРИПТ ОТОБРАЖАЕТ ВСПЛЫВАЮЩИЕ ТЕКСТЫ ЕСЛИ К НИМ БЛИЗКО ПОДОЙТИ
public class Show_text : MonoBehaviour {
    public GameObject message;
    void Start()
    {
        if (message == null)
        {
            message = GameObject.FindWithTag("PopUp");
        }
        
    }
        
    void Update()
    {
        if ((message.transform.position - this.transform.position).sqrMagnitude < 5 * 5)
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
