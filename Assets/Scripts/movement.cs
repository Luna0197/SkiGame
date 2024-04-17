using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveVector;
    public float rotationSpeed;
    public float speedIncrease;
    
   
      
    
    
    void Update()

    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        movePlayer();
        moveSpeed = moveSpeed += speedIncrease * 0.5f;
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
