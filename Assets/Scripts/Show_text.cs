using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//СКРИПТ ОТОБРАЖАЕТ ВСПЛЫВАЮЩИЕ ТЕКСТЫ ЕСЛИ К НИМ БЛИЗКО ПОДОЙТИ
public class Show_text : MonoBehaviour {
       
    public GameObject[] ShowMe;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        ShowMe = GameObject.FindGameObjectsWithTag("PopUp"); 
        
            GameObject[] signs; 
            signs = GameObject.FindGameObjectsWithTag("PopUp"); 
            GameObject closest = null; 
            float distance = Mathf.Infinity; 
            foreach (GameObject sign in signs) 
            {
                Vector3 diff = sign.transform.position - transform.position; 
                float curdistance = diff.sqrMagnitude;
                if (curdistance < distance) 
                {
                    closest = sign; 
                    distance = curdistance; 
                }
            }

                  
         if ((closest.transform.position - transform.position).sqrMagnitude < 60)
        {
            closest.GetComponent<Canvas>().enabled = true;
            
        } else 
        {
            closest.GetComponent<Canvas>().enabled = false;
               
         }
       
    }
    
            
}
