using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveVector;
    private float speed = 2.0f;
    public GameObject character;
    public Rigidbody rb;
    public float rotationSpeed;
   
   
      
    float horizontalInput = Input.GetAxis("Horizontal"); 
    
    void Update()
    {
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);

        movePlayer();
        

    }

    private void movePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
           transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
           transform.Rotate(Vector3.up * rotationSpeed);
           
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            transform.Rotate(Vector3.down * rotationSpeed);
        }

        if (transform.eulerAngles.y < 80)
            
        {
            transform.Rotate(eulers:new Vector3(x:0,y:rotationSpeed,z:0)*Time.deltaTime);
        }
    }

   

    private void restrict()
    {
        if (transform.eulerAngles.y < 269)
        {
            transform.Rotate(eulers:new Vector3(x:0,y:rotationSpeed,z:0)*Time.deltaTime);
        }
    }
    
   
   



}
