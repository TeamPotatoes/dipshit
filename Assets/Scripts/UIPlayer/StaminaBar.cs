using UnityEngine;
using System.Collections;

public class StaminaBar : MonoBehaviour {
    //Переменные для стамины
    public Texture Stamina;// место для перетаскивания текстуры в инспекторе:)
    private float BarWidth; //ширина полотна
    private float textureWidth;// не за что не угадаешь
    public GameObject Player;
   

    void Start () {
        BarWidth = Screen.width / 5; //ширина полотна = ширене экрана поделённой на 5. При смене разрешения экрана должно сохранять пропорции
        textureWidth = BarWidth;
    }

    void OnGUI()
    {
        float realStamina_check = Player.GetComponent<Player_stats>().realStamina;
        float MaxStamina_check = Player.GetComponent<Player_stats>().MaxStamina;
        // создает маленький "канвас" черного цвета на екране. 750 и 530 это кординанты экрана, остально размер
        if (Stamina != null && textureWidth > 0)// если текстура стамины НЕ нулл и ее ширина больше 0
        {
            GUI.DrawTexture(new Rect(10, 32, textureWidth, 15), Stamina, ScaleMode.ScaleAndCrop, true, 10.0F);// размещает текстуру на екране. 750 и 550 это кординанты экрана, остально размер и далее выбор самой текстуры способ заполнения пространства.
        }
        GUI.Box(new Rect(10, 30, BarWidth, 20), realStamina_check + " of " + MaxStamina_check);
        textureWidth = realStamina_check / MaxStamina_check * BarWidth;
    }
    
}
