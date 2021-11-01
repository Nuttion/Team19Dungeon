﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    Animator skeletonAnimator;

    public bool melee;
    NavMeshAgent agent;

    public GameObject player;

    public float health = 10.0f;

    public float agroRange = 10.0f;
    public float damage = 5.0f;
    public bool playerSeen;
    public bool playerHit;

    //Rotation vars
    public float rotationSpeed;
    private float adjRotSpeed;
    public Quaternion targetRotation;

    //Laser Damage
    public GameObject laser;
    public GameObject laserMuzzle;
    private float laserTimer;
    private float laserTime = 1.0f;

    //Collision Damage
    private float damageTimer;
    private float damageTime = 0.5f;

    public GameObject burning;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        skeletonAnimator = gameObject.GetComponent<Animator>();
        playerSeen = false;
        playerHit = false;
}

    // Update is called once per frame
    void Update() {

        Debug.Log(playerSeen);

        Behaviour();

        //Kill check - moved from takeDamage due to bug
        if (health <= 0) {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    void Behaviour() {

        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
        else if (player && !GameManager.instance.playerDead) {

            //Raycast in direction of Player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -(transform.position - player.transform.position).normalized, out hit, agroRange)) {

                //If Raycast hits player
                if (hit.transform.tag == "Player")
                {

                    playerSeen = true;

                    if (playerSeen == true)
                    {
                        skeletonAnimator.SetBool("playerSeen", true);
                    }

                    Debug.DrawLine(transform.position, player.transform.position, Color.red);

                    //Rotate slowly towards player
                    targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                    adjRotSpeed = Mathf.Min(rotationSpeed * Time.deltaTime, 1);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, adjRotSpeed);

                    //Move towards player
                    if (Vector3.Distance(player.transform.position, transform.position) >= 1)
                    {
                        agent.SetDestination(player.transform.position);
                    }

                    //Stop if close to player
                    else if (!melee)
                    {
                        if (Vector3.Distance(player.transform.position, transform.position) < 5)
                        {
                            agent.SetDestination(transform.position);
                        }
                    }


                    //Fire Laser
                    if (Time.time > laserTimer)
                    {
                        if (!melee)
                        {
                            Instantiate(laser, laserMuzzle.transform.position, laserMuzzle.transform.rotation);
                        }
                        laserTimer = Time.time + laserTime;
                    }
                }

                else
                {
                    playerSeen = false;

                    if (playerSeen == false)
                    {
                        skeletonAnimator.SetBool("playerSeen", false);
                    }
                }
                    
                    
            }
        }
    }


    private void OnCollisionStay(Collision collision) {

        skeletonAnimator.SetBool("playerHit", true);

        if (collision.transform.tag == "Player" && Time.time > damageTimer) {
            collision.transform.GetComponent<PlayerAvatar>().takeDamage(damage);
            damageTimer = Time.time + damageTime;
        }
    }

    public void takeDamage(float thisDamage) {

        health -= thisDamage;
    }

}
