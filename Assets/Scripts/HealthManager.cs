using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int health = 100;
    public Text healthText;
    public Slider healthSlider; 
    private int hurtDamage = 50;
    private float damageCooldown = 1.0f; 
    private float lastDamageTime = -1.0f;
    public float knockbackForce = 10.0f;

    private Rigidbody rb;

    public AudioSource hit;





   

   

    void Update()
    {
        restart();


       
    }

    void Start()
    {
        
        UpdateHealthText();
        UpdateHealthSlider();

        
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from the player GameObject.");
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }

    void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            
            healthSlider.value = health;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Obstacle") && Time.time > lastDamageTime + damageCooldown)
        {
           
            health -= hurtDamage;
            lastDamageTime = Time.time;
            hit.Play();


            UpdateHealthText();
            UpdateHealthSlider();

            
            ApplyKnockback(other);
        }
    }

    void ApplyKnockback(Collider other)
    {
        if (rb != null)
        {
           
            Vector3 knockbackDirection = -transform.forward;

           
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }

    void restart()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
