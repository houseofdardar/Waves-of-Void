using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToObjectStick : MonoBehaviour
{
    public Vector3 offset;
    CharacterController cc;
    public Vector3 currentPos;
    public Transform startPoint;
    public Transform endPoint;
    public float travleTime;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("A");
            other.gameObject.transform.SetParent(transform,true);
            offset = other.transform.position - transform.position;
            cc = other.gameObject.GetComponent<CharacterController>();
           //gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }*/
   /* private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // other.transform.position = transform.position + offset;
        }
    } */
        private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("b");
            other.gameObject.transform.parent = null;
            cc.Move(rb.velocity * Time.deltaTime);
        }
    }
    /* private void FixedUpdate()
     {
             currentPos = Vector3.Lerp(startPoint.position, endPoint.position, Mathf.Cos(Time.time / travleTime * Mathf.PI * 2) * -.05f + .5f);
         rb.MovePosition(currentPos);
     } */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        
            cc = other.GetComponent<CharacterController>();
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            cc.Move(rb.velocity * Time.deltaTime);
    }
    
}
