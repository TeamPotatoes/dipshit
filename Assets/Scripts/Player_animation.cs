using UnityEngine;
using System.Collections;

public class Player_animation : MonoBehaviour {
    public Animator anim;
    public AudioClip jump;
    private AudioSource source;
    private float inputSides;
    private float inputFronts;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        //this.animation["running"].wrapMode = WrapMode.PingPong;
    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Jump>().grounded == true)
        {
            anim.Play("jump_stay", -1, 0f);
            source.PlayOneShot(jump, 1.0f);
        }
        //if (Input.GetKey(KeyCode.W))
        //{
        //    anim.Play("running", -1, 0f);
        //}
        if (Input.GetButtonDown("Horizontal") && Input.GetButtonDown("Jump") && GetComponent<Jump>().grounded == true)
        {
            anim.Play("running_jump", -1, 0f);
            source.PlayOneShot(jump, 1.0f);
        }

        inputSides = Input.GetAxis("Horizontal");
        inputFronts = Input.GetAxis("Vertical");
        anim.SetFloat("inputSides", inputSides);
        anim.SetFloat("inputFronts", inputFronts);
    }
}
