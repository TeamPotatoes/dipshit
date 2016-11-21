using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
   
    public Texture Health;
    private float BarWidth;
    private float TextureWidth;
    public GameObject Player;
    
    void Start ()
    {
        BarWidth = Screen.width / 4;
        TextureWidth = BarWidth;
 
    }

    void OnGUI()
    {
        float RealHealth_check = Player.GetComponent<Player_stats>().RealHealth;
        float MaxHealth_check = Player.GetComponent<Player_stats>().MaxHealth;
        if (Health != null && TextureWidth > 0)
        {
            GUI.DrawTexture(new Rect(10, 12, TextureWidth, 15), Health, ScaleMode.ScaleAndCrop, true, 10.0f);
        }
        GUI.Box(new Rect(10, 10, BarWidth, 20), RealHealth_check.ToString("F0") + " of " + MaxHealth_check);
        TextureWidth = RealHealth_check / MaxHealth_check * BarWidth;
    }
       
}
