using UnityEngine;
using System.Collections;

public class Player_animation : MonoBehaviour {
    public Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && GetComponent<Jump>().grounded == true)
        {
            anim.Play("jump", -1, 0f);
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            anim.Play("walking", -1, 0f);
        }


        //    inputH = Input.GetAxis("Horizontal");
        //   anim.SetFloat("inputH", inputH);


    }
}
