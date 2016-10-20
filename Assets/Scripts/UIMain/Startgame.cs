using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class Startgame : MonoBehaviour {

    
    public Button StartGame;
    private GameObject UImain;



    void Start ()
    {
        UImain = (GameObject)this.gameObject;
       Button SG = StartGame.GetComponent<Button>();
        SG.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick()
    {
        UImain.SetActive(false);

    }
    

	
}
