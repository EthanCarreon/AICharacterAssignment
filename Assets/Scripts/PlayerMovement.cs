using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        

    }

    void FixedUpdate()
    {
        // move x and z positions only get reference
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // set move direction to add itself forward (Z) right and left (X)
        Vector3 moveDirection = transform.forward * moveZ + transform.right * moveX;

        // normalize movement vector
        moveDirection.Normalize();

        // set rigidbody velocity to x and z values with move direction, dont move y value (remain same)
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
    }
}