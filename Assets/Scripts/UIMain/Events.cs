using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Events : MonoBehaviour
{
    private GameObject UIMain;
    private bool UImainActive = true;
    private float UI;

    // Use this for initialization
    void Start()
    {

        UIMain = (GameObject)this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && UImainActive == true)
        {
            UIMain.SetActive(false);
            UImainActive = false;
        }
        else
        {
           UImainActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && UImainActive == false)
        {
            UIMain.SetActive(true);
             UImainActive = true; 
        }
        else
        {
            UImainActive = false;
        }
    }
}
