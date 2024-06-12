using System.Collections;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public float slowDownAmount = 5f; 
    public float slowDownDuration = 2f;
    public AudioSource Wrong;
    private movement playerMovement; 

    void Start()
    {
       
        playerMovement = FindObjectOfType<movement>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SlowDownPlayer());
            Wrong = GetComponent<AudioSource>();
            Wrong.Play();
        }
    }

    IEnumerator SlowDownPlayer()
    {
     
        if (playerMovement != null)
        {
            playerMovement.moveSpeed -= slowDownAmount;
            yield return new WaitForSeconds(slowDownDuration);
            playerMovement.moveSpeed += slowDownAmount;
        }
    }
}
