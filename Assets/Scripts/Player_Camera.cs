using UnityEngine;
using System.Collections;


public class Player_Camera : MonoBehaviour
{

    public GameObject Player;
    private float turn_speed = 4.0f;
    private Vector3 offsetX;
    private Vector3 offsetY;
    public Transform target;

     // Use this for initialization
     void Start()
     {
     offsetX = new Vector3(target.position.x, target.position.y + 10.0f, target.position.z);
     offsetY = new Vector3(target.position.x, target.position.y, target.position.z);
    }
    void Update()
    {
  
    }

    // Update is called once per frame
    void LateUpdate ()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turn_speed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turn_speed, Vector3.right) * offsetY;
        transform.position = target.position - offsetX; //- offsetY;
        transform.LookAt(target);
       // transform.RotateAround(offset, Vector3.up, 20 * Time.deltaTime);

       //  transform.position = Player.transform.position + offsetX + offsetY; 
    }

}


