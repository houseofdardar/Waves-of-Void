using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float speed;
    public float acceleration = .5f;
    public float decelaration = .5f;
    public float topSpeed = 5.0f;
    public float minimumSpeed = 1.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = -transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime * acceleration;
        // if velocity < topspeed

        rb.velocity = transform.forward * speed;
        //if speed > topspeed 
        //slow down

    }
}
    
