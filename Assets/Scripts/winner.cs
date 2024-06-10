using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winner : MonoBehaviour
{

    [SerializeField] private GameObject winScreen;
    

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }
}
