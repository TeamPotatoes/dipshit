using UnityEngine;
using System.Collections;

public class Player_animation : MonoBehaviour {
    public Animator anim;
    public AudioClip jump;
    private AudioSource source;
    private float inputSides;
    private float inputFronts;
    private float inputTurns;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        anim.speed = 1.0f;
    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Movement>().grounded == true)
        {
            anim.Play("jump_stay", -1, 0f);
            source.PlayOneShot(jump, 1.0f);
        }
       if (Input.GetKey(KeyCode.Space) && Input.GetAxis("Vertical")!=0 &&  GetComponent<Movement>().grounded == true)
        {
            anim.Play("running_jump", -1, 0f);
            source.PlayOneShot(jump, 1.0f);
        }

        inputSides = Input.GetAxis("Horizontal");
        inputFronts = Input.GetAxis("Vertical");
        //inputTurns = transform.rotation.y; 
        anim.SetFloat("inputSides", inputSides);
        anim.SetFloat("inputFronts", inputFronts);
        anim.SetFloat("inputTurns", GetComponent<Movement>().inputTurns);
        anim.SetBool("run", GetComponent<Movement>().run);
        anim.SetBool("stay", GetComponent<Movement>().stay);
        anim.SetBool("jump", GetComponent<Movement>().hasJump);
        // временный костыль ускоряющий анимацию если игрок бежит
        if (GetComponent<Movement>().run == true)
        {
            anim.speed = 1.5f;
        }
        if (GetComponent<Movement>().run == false)
        {
            anim.speed = 1.0f;
        }
    }
}
