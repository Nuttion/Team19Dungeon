using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    GameObject player;
    float pHealth;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public virtual void OnTriggerEnter(Collider other) {



        if (gameObject.name == "Health")
        {
            if (player.GetComponent<PlayerAvatar>().health > 50)
            {
                player.GetComponent<PlayerAvatar>().health += 100 - player.GetComponent<PlayerAvatar>().health;
            }

            else
                player.GetComponent<PlayerAvatar>().health += 50;
            

            gameObject.SetActive(false);
        }

        Debug.Log(player.GetComponent<PlayerAvatar>().fuel);

        if (gameObject.name == "Fire")
        {
            if (player.GetComponent<PlayerAvatar>().fuel > 20)
            {
                player.GetComponent<PlayerAvatar>().fuel += 50 - player.GetComponent<PlayerAvatar>().fuel;
            }

            else
                player.GetComponent<PlayerAvatar>().fuel += 30;


            gameObject.SetActive(false);
        }

        if (gameObject.name == "Electric")
        {
            if (player.GetComponent<PlayerAvatar>().ammo > 80)
            {
                player.GetComponent<PlayerAvatar>().ammo += 200 - player.GetComponent<PlayerAvatar>().ammo;
            }

            else
                player.GetComponent<PlayerAvatar>().ammo += 120;


            gameObject.SetActive(false);
        }
    }
}
