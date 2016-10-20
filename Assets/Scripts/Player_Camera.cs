using UnityEngine;
using System.Collections;

public class Player_Camera : MonoBehaviour {

    public GameObject Player;
    private Vector3 offset;
    private Vector3  Position;
    //public Transform target;


	// Use this for initialization
	void Start ()
    {
       // Position = transform.TransformPoint(Vector3.right * 2);
       // Instantiate(Player, Position, Player.transform.rotation);
        offset = transform.position - Player.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        //transform.LookAt(target);
       transform.position = Player.transform.position + offset;
    }
}
