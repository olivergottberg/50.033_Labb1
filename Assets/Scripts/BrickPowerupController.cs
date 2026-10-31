using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPowerupController : MonoBehaviour, IPowerupController
{
    public Animator powerupAnimator;
    public BasePowerup powerup; // reference to this brick's powerup
    public bool isBreakable = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!powerup.hasSpawned)
            {
                //enable sprite
                this.GetComponent<SpriteRenderer>().enabled = true;
                //bounce
                this.GetComponent<Animator>().SetTrigger("bounce");
                //spawn the powerup
                powerupAnimator.SetTrigger("spawned");

                if (isBreakable)
                {
                    //show disabled sprite if it's not breakable type of brick
                    this.GetComponent<Animator>().SetTrigger("spawned");
                }
            }
            else
            {
                if (isBreakable)
                {
                    //else if it's breakable, can still bounce although powerup has spawned
                    this.GetComponent<Animator>().SetTrigger("bounce");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    //the brick bouncing is not due to spring but to animator
    //theres no need to set this
    //just implemented to follow interface
    public void Disable()
    {
        //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //transform.localPosition = new Vector3(0, 0, 0);
    }
}