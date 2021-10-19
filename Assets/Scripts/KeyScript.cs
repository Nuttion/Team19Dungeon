using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject Key;
    public GameObject Door;

    public bool keyCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            keyCollected = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EndDoor" && keyCollected == true)
        {
            Destroy(collision.gameObject);
        }
    }
}
