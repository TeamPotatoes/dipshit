using UnityEngine;
using System.Collections;

public class EnemyAnim : MonoBehaviour {
    public Animator anim;
    public GameObject Skeleton;
    public float speed = 20;
    public Transform target;
    public GameObject Player_stats;
    private bool patrol;
    private Player_stats RH;
    private Rigidbody rb;
    

    
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
     
        RH = Player_stats.GetComponent<Player_stats>();
        patrol = true;
        anim = GetComponent<Animator>();
    }
	


	void Update ()
    {
        anim.SetFloat("RunAttack", 0);
        anim.SetFloat("PlayerClose", 0);
       
        GameObject[] signs;
        signs = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach (GameObject sign in signs)
        {
            Vector3 diff = sign.transform.position - transform.position;
            float curdistance = diff.sqrMagnitude;
            if (curdistance < distance)
            {
                closest = sign;
                distance = curdistance;
            }
            if ((closest.transform.position - Skeleton.transform.position).sqrMagnitude < 60 && RH.RealHealth > 0)
            {
               
                RH.RealHealth = RH.RealHealth - RH.dmg;
                
            }

        }

        if ((closest.transform.position - Skeleton.transform.position).sqrMagnitude < 200 && (closest.transform.position - Skeleton.transform.position).sqrMagnitude >= 10)
        {
           // anim.SetFloat("RunAttack", 1);
            anim.Play("Run");
            rb.AddForce(rb.transform.forward * 300);
            //Skeleton.transform.position += Skeleton.transform.forward * speed * Time.deltaTime;
            transform.LookAt(target);
            patrol = false;
        }
        else
        {
            rb.AddForce(rb.transform.forward * 0);
        }
        
        if(patrol == true)
        {
            anim.Play("Idle");
           // anim.SetFloat("RunAttack", -1);
        }
        if ((closest.transform.position - Skeleton.transform.position).sqrMagnitude < 20)
        {
            anim.Play("Attack");
            transform.LookAt(target);
          //  anim.SetFloat("PlayerClose", 1);
        }
        
        
    }
    void LateUpdate()
    {
        
    } 
    
}
