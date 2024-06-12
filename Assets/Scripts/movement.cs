using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveVector;
    public float rotationSpeed;
    public float speedIncrease;
    public float boostDuration = 1.0f; // Adjust the boost duration as needed
    public float boostCooldown = 3.0f; // Adjust the boost cooldown as needed
    private bool isBoosting = false;
    private float boostTimer = 0.0f;
    private float cooldownTimer = 0.0f;

    public AudioSource Whoosh;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        movePlayer();
        moveSpeed += speedIncrease * Time.deltaTime; // Adjust speed gradually
        notGoingBack();

        // Check if boost button is pressed and not already boosting
        if (Input.GetKeyDown(KeyCode.Space) && !isBoosting && cooldownTimer <= 0.0f)
        {
            StartCoroutine(ActivateBoost());
            Whoosh.Play();
        }

        // Update cooldown timer
        if (cooldownTimer > 0.0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private IEnumerator ActivateBoost()
    {
        isBoosting = true;
        moveSpeed *= 2; // Double the move speed
        yield return new WaitForSeconds(boostDuration);
        moveSpeed /= 2; // Restore original move speed
        isBoosting = false;
        cooldownTimer = boostCooldown; // Start cooldown
       
    }

    private void movePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            transform.Rotate(Vector3.up * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            transform.Rotate(Vector3.down * rotationSpeed);
        }

        if (transform.eulerAngles.y < 80)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    private void notGoingBack()
    {
        if (moveSpeed <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
