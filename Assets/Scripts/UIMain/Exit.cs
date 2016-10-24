using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{

    public Button ExitGame;


    void Start()
    {
        Button EX = ExitGame.GetComponent<Button>();
        EX.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.Quit();

    }
    
}
