using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PoPupmessages : MonoBehaviour
{
    public Texture hpPotion;
    public Texture staminaPotion;
    private float BarWidth;
    private Rect windowRect1 = new Rect(0, 380, 40, 60);
    private Rect windowRect2 = new Rect(45, 380, 40, 60);
    public GameObject Player;
    private Rect PopHealth = new Rect(0, 0, 0, 0);
    private Player_stats PS;
    private Movement MV;
    private int countCheck;




    void SetHpPointCountText()
    {
        MV.HpPotionCount.text = countCheck.ToString();

    }



    void Start()
    {
        
        MV.count = 0;
        SetHpPointCountText();
        MV = Player.GetComponent<Movement>();
        
        PS  = Player.GetComponent<Player_stats>();
        countCheck = MV.count;
    

    }


    void OnGUI()
    {
     
        GUI.Box(windowRect1, countCheck);
        GUI.Box(windowRect2, "2");
        GUI.DrawTexture(new Rect(0, 400, 40, 40), hpPotion);
        GUI.DrawTexture(new Rect(45, 400, 40, 40), staminaPotion);




    }




    // Update is called once per frame
    void Update()
    {
        if (PS.RealHealth <= 4999 && Input.GetKey(KeyCode.Keypad1))
        {
            PS.RealHealth = PS.RealHealth + 100;
        }
    }
 

}
