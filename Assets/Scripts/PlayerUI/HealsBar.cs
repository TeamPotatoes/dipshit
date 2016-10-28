using UnityEngine;
using System.Collections;

public class HealsBar : MonoBehaviour {
    public float MaxHeals = 1000;
    public Texture Heals;
    private float BarWidth;
    private float realHeals;
    private float TextureWidth;


    // Use this for initialization
    void Start ()
    {
        BarWidth = Screen.width / 4;
        realHeals = MaxHeals;
        TextureWidth = BarWidth;

       

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
    void FixedUpdate () {
     

    }
}
