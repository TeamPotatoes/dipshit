using UnityEngine;
using System.Collections;


public class Events : MonoBehaviour
{
    public GameObject UIMain;
    public bool UImainActive = true;


    // Use this for initialization
    void Start()
    {
        UIMain = (GameObject)this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && UImainActive == true)
        {
            UIMain.SetActive(false);
            UImainActive = false;
        }
        if (Input.GetButtonDown("Cancel") && UImainActive == false)
        {
            UIMain.SetActive(true);
            UImainActive = true;
        }
    }
}
