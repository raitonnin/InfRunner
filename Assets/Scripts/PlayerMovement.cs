using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10.0f;
    public float turnSpeed = 50.0f;
    private Vector3 movementForce;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movementForce = new Vector3( x: horizontal, y: 0f, z: 0);
        
        if (rb.position.y <= -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
    void Move()
    {   
        rb.AddForce(Vector3.forward * speed);
        rb.AddForce(movementForce * turnSpeed, ForceMode.VelocityChange);
    }
}
