using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public int nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (nextLevel == 2)
            {
                SceneManager.LoadScene("Level 2");
            }

            else if (nextLevel == 2)
            {
                SceneManager.LoadScene("Level 3");
            }
        }
    }
}
