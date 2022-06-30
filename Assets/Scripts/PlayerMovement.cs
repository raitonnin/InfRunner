using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float turnSpeed = 50.0f;
    [SerializeField] private float jumpForce = 1.0f;
    private Vector3 movementForce;
    private float maxSpeed = 20;
    private float terminalVelocity = 10;
    private bool _jump = false;
    private bool IsGrounded = false;
    [SerializeField]private float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;
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
        Jump();
                
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(IsGrounded && rb.velocity.y < 0)
        {
            //set velocity to zero somehow
        }
        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space")&& IsGrounded)
        {
            _jump = true;
        }

        
        movementForce = new Vector3( x: horizontal, y: 0f, z: 0);
        
        if (rb.position.y <= -1)
        {
            FindObjectOfType<GameManager>().EndGame();
            rb.velocity = Vector3.zero;
        }     
    }
    void Move()
    {   
        if (rb.velocity.z < maxSpeed){
        rb.AddForce(Vector3.forward * speed);
        }
        rb.AddForce(movementForce * turnSpeed, ForceMode.VelocityChange);
    }
    void Jump()
    {
        if(_jump)
        {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _jump = false;
        }
    }
}
