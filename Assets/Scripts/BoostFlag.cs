using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostFlag : MonoBehaviour
{
    public float boostAmount = 5f;
    public float boostDuration = 2f;

    private movement playerMovement;

    void Start()
    {

        playerMovement = FindObjectOfType<movement>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(boostPlayer());
        }
    }

    IEnumerator boostPlayer()
    {

        if (playerMovement != null)
        {
            playerMovement.moveSpeed += boostAmount;
            yield return new WaitForSeconds(boostDuration);
            playerMovement.moveSpeed += boostAmount;
        }
    }
}
