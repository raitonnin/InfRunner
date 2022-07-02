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
    private bool isGrounded = false;
    [SerializeField]private float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;
    public BoxCollider playerBoxCollider;
    [SerializeField]private float jumpPressedRememberTime = 0.2f;
    private float jumpPressedRemember = 0f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerBoxCollider = GetComponent<BoxCollider>();
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
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && rb.velocity.y < 0)
        {
            //set velocity to zero somehow
        }
        jumpPressedRemember -= Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space"))//&& isGrounded)
        {
            jumpPressedRemember = jumpPressedRememberTime;
            //_jump = true;
        }
        if((jumpPressedRemember > 0) && isGrounded)
        {
            jumpPressedRemember = 0;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
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
        /* 
        if you spam the jump button you will jump extra times
        if you hit the jump on the way down and it activates while you aren't on the ground yet you will not get upward momentum but the forces will collide and settle you somewhere inbetween
        i need to stop the mashing capability from allowing multiple jumps and make it so that the jumps are constrained and serve a less physics momentum purpose but a deliberate purpose where they
        are extremely replicatable. meaning i may need entirely to ditch the rigidbody no matter how much i really wanted to keep it.
        */
        if(_jump)
        {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Jump occurred");
        _jump = false;
        }
    }
}
