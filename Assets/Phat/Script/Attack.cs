using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [System.NonSerialized]public Animator anim;
    private float lastShootTime;
    private float nextShootTime;
    public float interval;
    public GameObject bullet;
    public GameObject bulletLV1;
    public GameObject bulletLV2;
    public GameObject buster;
    public GameObject busterDash;
    public GameObject busterJump;
    public GameObject busterWall;
    public Movement move;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //interval -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.C))
        {

            //anim.SetTrigger("Shoot 0");
            StartCoroutine(Shoot());           
        }
        //Shooting();

    }

    public void Shooting()
    {       
        if (Input.GetKeyDown(KeyCode.C) && Time.time > nextShootTime )
        {
            anim.SetBool("Shoot", true);
            nextShootTime = Time.time + interval;          
        }
        Invoke(nameof(AnimationCheck),interval);
    }

    public IEnumerator Shoot()
    {
        if (Time.time - lastShootTime >= interval)
        {          
            anim.SetBool("Shoot", true);
            lastShootTime = Time.time;           
        }
        
        yield return new WaitForSeconds(interval);
        anim.SetBool("Shoot", false);
    }
    private void AnimationCheck()
    {
        anim.SetBool("Shoot", false);
    }

    
}
