using UnityEngine;
using System.Collections;

public class door_animation : MonoBehaviour {
    public Animator anim;
    private bool door_opened;
    private bool player_near;
    public GameObject Player;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        door_opened = false;
        player_near = false;
       
    }
	
	// Update is called once per frame
	void Update () {
        if ((Player.transform.position - this.transform.position).sqrMagnitude < 5 * 5)
        {
            player_near = true;
        } else
        {
            player_near = false;
        }


        if (Input.GetKeyDown(KeyCode.F) && door_opened == false && player_near == true)
        {
            anim.Play("door_open", -1, 0f);
            door_opened = true;
        } else if (Input.GetKeyDown(KeyCode.F) && door_opened == true && player_near == true)
        {
            anim.Play("door_close", -1, 0f);
            door_opened = false;
        }
    }
}
