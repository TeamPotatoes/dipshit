using UnityEngine;
using System.Collections;

public class Player_stats : MonoBehaviour {
    public GameObject Player;

    public float MaxHealth = 5000;
    [HideInInspector] public float RealHealth;
    public int dmg = 1;
    public int regen = 1;
    public bool playerInjured;
    public float MaxStamina = 100;
    [HideInInspector] public float realStamina;
    public int fatigue = 1; // это когда еще не заебался
    public int tired = 1; //это когда заебался
    
    

    void Start()
    {
        RealHealth = MaxHealth;
        playerInjured = false;
        realStamina = MaxStamina;

    }

    void LateUpdate()
    {
        //СТРОКИ СТАМИНЫ
        bool run_check = Player.GetComponent<Movement>().run;
        bool sprintState_check = Player.GetComponent<Movement>().sprintState;
        if (run_check == true && realStamina > 0 && Input.GetKey(KeyCode.W))
        {
            realStamina = realStamina - fatigue;
        }

        //если НЕ спринт, стамина увеличивается
        if (run_check == false && realStamina < MaxStamina)
        {
            realStamina = realStamina + tired;
        }
        if (realStamina <= 0)
        {
            sprintState_check = false;
        }
        if (realStamina >= 70)
        {
            sprintState_check = true;
        }
        //КОНЕЦ СТРОК СТАМИНЫ

        //УРОН ПЕРОСНАЖУ ОТ ИСТОЧНИКА ОГНЯ
        GameObject[] signs;
        signs = GameObject.FindGameObjectsWithTag("StaticFire");
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
        if ((closest.transform.position - transform.position).sqrMagnitude < 10 && RealHealth <= MaxHealth)
        {
            RealHealth = RealHealth - dmg;
            playerInjured = true;
        }
        if (RealHealth >= 1)
        {
            playerInjured = true;
        }

        if (RealHealth >= 1 && playerInjured == true)
        {
            RealHealth = RealHealth + regen;

        }
        if (RealHealth >= MaxHealth)
        {
            playerInjured = false;
            RealHealth = MaxHealth;
        }
        if (RealHealth <= 0)
        {
            Destroy(Player);
        }

        
    }

}
