using UnityEngine;
using System.Collections;


public class Player_Camera : MonoBehaviour
{



    public GameObject Player;
   // private float speedMod = 10.0f;
    private Vector3 offset;
    public Transform target;


     // Use this for initialization
     void Start()
     {

        transform.LookAt(target);
        offset = Player.transform.position ;// - Player.transform.position;

    }
    void Update()
    {
  
    }

    // Update is called once per frame
    void LateUpdate ()
    {

        transform.RotateAround(offset, Vector3.up, 20 * Time.deltaTime);

        // transform.position = Player.transform.position + offset; 
    }

}


