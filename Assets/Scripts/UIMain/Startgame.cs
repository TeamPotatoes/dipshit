using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;


public class Startgame : MonoBehaviour
{


    public Button StartGame;
    private GameObject UIMain;
    private Events Ev;

    void Start()
    {
        Ev = GetComponent<Events>();
        UIMain = (GameObject)this.gameObject;
        Button SG = StartGame.GetComponent<Button>();
        SG.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        UIMain.SetActive(false);
        Ev.UImainActive = false;
    }
   
}
       
