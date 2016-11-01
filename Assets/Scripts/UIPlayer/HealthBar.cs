using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    public float MaxHealth = 5000;
    public Texture Health;
    private float BarWidth;
    public float RealHealth;
    private float TextureWidth;
    public int dmg = 1;
    public int regen = 3;
    public GameObject Player;
    public bool playerInjured;

    // Use this for initialization
    void Start ()
    {
        BarWidth = Screen.width / 4;
        RealHealth = MaxHealth;
        TextureWidth = BarWidth;
        playerInjured = false;
       

    }

    void OnGUI()
    {
        if (Health != null && TextureWidth > 0)
        {
            GUI.DrawTexture(new Rect(10, 12, TextureWidth, 15), Health, ScaleMode.ScaleAndCrop, true, 10.0f);
        }
        GUI.Box(new Rect(10, 10, BarWidth, 20), MaxHealth + " of " + RealHealth);
    }


    
    void LateUpdate ()
    {
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

      //УРОН ПЕРОСНАЖУ ОТ ИСТОЧНИКА ОГНЯ
       /* if ((closest.transform.position - Player.transform.position).sqrMagnitude < 10 && RealHealth <= 1000)
        {
            RealHealth = RealHealth - dmg;
            playerInjured = true;
        } */
        if(RealHealth >= 1)
        {
            playerInjured = true;
        }
       
        if(RealHealth >= 1 && playerInjured == true)
        {
            RealHealth = RealHealth + regen;

        }
        if (RealHealth >= 5000)
        {
            playerInjured = false;
            RealHealth = 5000;
        }
        if (RealHealth <= 0)
        {
            Destroy(Player);
        }
    }
}
