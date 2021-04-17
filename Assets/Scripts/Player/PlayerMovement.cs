using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    CameraChange cameraChange;
    Rigidbody rb;

    Vector3 movement;
    public float speed = 5;

    [Header("Jump")]
    public float jumpForce = 2.0f;
    public bool canJumpTwice = false;
    public int extraJumps = 1;
    public bool isGrounded;
    private Vector3 jump;

    [Header("Dash")]
    public float dashSpeed;
    [SerializeField] private int direction;



    void Awake()
    {
        cameraChange = FindObjectOfType<CameraChange>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        jump = new Vector3(0.0f, jumpForce, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
 
        if(Input.GetKey(KeyCode.Q))
        {
            Dash();
            WaitForSeconds();
        }
        else
        {
            MoveX();
            if (cameraChange.gameProjection == eGameProjection.pers)
            {
                MoveZ();
            }
        }
    }

    void MoveX()
    {
        //Move
        float inputX = Input.GetAxis("Horizontal");
        movement = new Vector3(inputX * speed, 0,0);
        movement *= Time.deltaTime;

        //Translate
        transform.Translate(movement);
    }

    void MoveZ()
    {
        //Move
        float inputZ = Input.GetAxis("Vertical");
        movement = new Vector3(0, 0, inputZ * speed);
        movement *= Time.deltaTime;

        //Translate
        transform.Translate(movement);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Floor")
        {
            isGrounded = true;
            if(canJumpTwice)
            {
                extraJumps = 1;
            }
        }

        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        else if (Input.GetButtonDown("Jump") && !isGrounded && extraJumps > 0)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            extraJumps--;
        }
    }

    void Dash()
    {
        if(direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direction = 2;
            }
            else if(Input.GetKeyDown(KeyCode.W))
            {
                direction = 3;
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                direction = 4;
            }
        }

        if (direction == 1)
        {
            rb.AddForce(transform.right * dashSpeed, ForceMode.Impulse);
            direction = 5;
        }
        else if (direction == 2)
        {
            rb.AddForce(transform.right * -dashSpeed, ForceMode.Impulse);
            direction = 5;
        }
        else if (direction == 3 && cameraChange.gameProjection == eGameProjection.pers)
        {
            rb.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
            direction = 5;
        }
        else if (direction == 4 && cameraChange.gameProjection == eGameProjection.pers)
        {
            rb.AddForce(transform.forward * -dashSpeed, ForceMode.Impulse);
            direction = 5;
        }
    }

    void WaitForSeconds()
    {
        direction = 0;
    }


}
