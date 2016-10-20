using UnityEngine;
using System.Collections;

public class Player_animation : MonoBehaviour {
    public Animator anim;
    public AudioClip jump;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && GetComponent<Jump>().grounded == true)
        {
            anim.Play("jump_stay", -1, 0f);
            source.PlayOneShot(jump, 1.0f);
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            anim.Play("running", -1, 0f);
        }
        if (Input.GetButtonDown("Horizontal") && Input.GetButtonDown("Jump") && GetComponent<Jump>().grounded == true)
        {
            anim.Play("running_jump", -1, 0f);
            source.PlayOneShot(jump, 1.0f);
        }

        //    inputH = Input.GetAxis("Horizontal");
        //   anim.SetFloat("inputH", inputH);


    }
}
