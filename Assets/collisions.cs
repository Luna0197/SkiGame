using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class collisions : movement
{

    
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    public GameObject player;
    
    // OnTriggerEnter is called when the Collider other enters the trigger
     void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Obstacle"
        if (other.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}

