using UnityEngine;
using System.Collections;

public class HealsBar : MonoBehaviour {
    public float MaxHeals = 1000;
    public Texture Heals;
    private float BarWidth;
    private float realHeals;
    private float TextureWidth;
    public GameObject[] Fire;
    private int dmg = 7;
    private int heal = 3;
    public GameObject Player;
    private bool playerInjured;

    // Use this for initialization
    void Start ()
    {
        BarWidth = Screen.width / 4;
        realHeals = MaxHeals;
        TextureWidth = BarWidth;
        playerInjured = false;
       

    }

    void OnGUI()
    {
      
        GUI.Box(new Rect(10, 10, BarWidth, 40), MaxHeals + " of " + realHeals);

        if (Heals != null && TextureWidth > 0)
        {
            GUI.DrawTexture(new Rect(10, 30, TextureWidth, 15), Heals, ScaleMode.ScaleAndCrop, true, 10.0f);
        }
    }


    
    // Update is called once per frame
    void LateUpdate ()
    {
        Fire = GameObject.FindGameObjectsWithTag("StaticFire");

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

      
        if ((closest.transform.position - Player.transform.position).sqrMagnitude < 60 && realHeals <= 1000)
        {
            realHeals = realHeals - dmg;
            playerInjured = true;
        }
       
        if(realHeals >= 1 && playerInjured == true)
        {
            realHeals = realHeals + heal;

        }
        if (realHeals >= 1000)
        {
            playerInjured = false;
            realHeals = 1000;
        }
        if (realHeals <= 0)
        {
            Destroy(Player);
        }
    }
}
