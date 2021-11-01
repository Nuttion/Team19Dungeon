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
        pHealth = player.GetComponent<PlayerAvatar>().health;
    }

    public virtual void OnTriggerEnter(Collider other) {

        Debug.Log(pHealth);

        if (gameObject.name == "Health")
        {
            if (player.GetComponent<PlayerAvatar>().health < 50)
            {
                player.GetComponent<PlayerAvatar>().health += 100 - player.GetComponent<PlayerAvatar>().health;
            }

            else
                player.GetComponent<PlayerAvatar>().health += 50;
            

            //gameObject.SetActive(false);
        }


    }
}
