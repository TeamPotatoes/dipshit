using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PoPupmessages : MonoBehaviour
{
   
    public GameObject Player;
    private Player_stats PS;
    private int countCheck;
    public int HPcount;
    private GameObject HP;
    private GameObject HPText;
    private Text HPcountText;
    public int frame;

    public class WaitUntilExample : MonoBehaviour
    {



    }


    void OnMouseDown(Collider GUI)
    {



    }




        void Start()
    {
      
        PS = Player.GetComponent<Player_stats>();
        HP = GameObject.Find("hp1");
        HPText = GameObject.Find("hp1Text");
        HP.SetActive(false);
        HPcountText = HPText.GetComponent<Text>();
        HPcount = 0;

  
      /*  MV = Player.GetComponent<Movement>();
        
        PS  = Player.GetComponent<Player_stats>();
        countCheck = count;*/
    

    }
   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HpPotion"))
        {
            Destroy(other.gameObject);
            HPcount = HPcount + 1;
            HP.SetActive(true);
    
            HPcountText.text = HPcount.ToString();


        }
      
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && PS.RealHealth <= 4999 && HPcount >=1)
        {
            PS.RealHealth = PS.RealHealth + 1000;
            HPcount = HPcount - 1;
            HPcountText.text = HPcount.ToString();
        }
       if (HPcount == 0)
        {
            HP.SetActive(false);
        }
     

    }
 

}
