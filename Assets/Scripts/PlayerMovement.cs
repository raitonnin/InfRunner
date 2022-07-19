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
    private bool _jump = false;
    private bool isGrounded = false;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;
    public BoxCollider playerBoxCollider;
    private float jumpPressedRememberTime = 0.2f;
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
        jumpPressedRemember -= Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space"))//&& isGrounded) "removed checked for later"
        {
            jumpPressedRemember = jumpPressedRememberTime;
            //_jump = true; checked instead in new if statement where we look to see if the jump has recently been pressed
        }
        if((jumpPressedRemember > 0) && isGrounded)
        {
            jumpPressedRemember = 0;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
            _jump = true;
            
        }
        
        movementForce = new Vector3( x: horizontal, y: 0f, z: 0);
        /*The way my jump works currently is at the height of the parabola gravity kicks up to drop you faster. It isnt intelligent enough to know you arent holding the jump key down but it works half decent
        There is a key press timer that recalls for a certain amount of time the last time you pressed the button to jump and will auto jump for you when near the ground though. the time is short. this code is checked 
        before the isgrounded variables and then if it remembers the press or is being pressed now and is on the ground at the moment you will jump. applying the rigid bodys velocity a new v3.*/
        if (rb.position.y <= -1)
        {
            FindObjectOfType<GameManager>().EndGame();
            rb.velocity = Vector3.zero;
        }    
        if (rb.velocity.y < 4 && !isGrounded)
        {
            Physics.gravity = new Vector3(0, -16f, 0);
            Debug.Log(Physics.gravity);
        }
        else
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
            Debug.Log(Physics.gravity);
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
        Debug.Log(Physics.gravity);
        }
    }
}
