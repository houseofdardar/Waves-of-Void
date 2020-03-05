using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public int deaths = 0;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistince = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public float respawnHight = -50;

    

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistince, groundMask);
           
            if(isGrounded && velocity.y < 0)
            {
            velocity.y = -2f;
            }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (gameObject.transform.position.y <= respawnHight)
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
           // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            controller.velocity.Set(0,0,0);
            deaths = deaths + 1;
            Debug.Log(deaths);
        }
        // put the score screen here
        if (deaths >= 3)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("you died, put death screen here");
            
              
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("GameOver");

            
        }

        

    }

    public void pauseDeath()
    {
        deaths = 3;
    }
}
