using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region movementvariables
    //movement variables
    private Rigidbody2D rb;
    private float moveDirection;
    
    [SerializeField]
    float playerMoveSpeed;
    [SerializeField]
    bool isRunning;
    [SerializeField]
    float jumpForce;

    //walljump variables
    bool isOnWall;
    [SerializeField]
    Transform handPos;
    [SerializeField]
    float checkWallRadius;
    [SerializeField]
    LayerMask whatIsWall;

    //jump variables
    bool isGrounded;
    [SerializeField]
    Transform feetPos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask whatIsGround;

    float jumpTimeCounter;
    [SerializeField]
    float jumpTime;
    bool isJumping;
    #endregion

    public GameObject dustParticle;
    bool spawnDustParticle = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets move direction input
        moveDirection = Input.GetAxisRaw("Horizontal");

        //checks to see if the player is touching a wall or the ground
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        isOnWall = Physics2D.OverlapCircle(handPos.position, checkWallRadius, whatIsWall);

        Flip();
        HandleJump();
        HandleSprint();

        //this method spawns a dust particle when the player lands, I commented it out because I'll implement a good particle system later.
        //if (isGrounded)
        //{
        //    if (spawnDustParticle)
        //    {
        //        Instantiate(dustParticle, feetPos);
        //        spawnDustParticle = false;
        //    }
        //}
        //else
        //{
        //    spawnDustParticle = true;
        //}
        
    }

    void FixedUpdate()
    {
        //adds velocity, therefore moving the player depending on move direction input
        rb.velocity = new Vector2(moveDirection * playerMoveSpeed, rb.velocity.y);
        //calls the jump function
        
        
    }
    #region playermovement
    void HandleJump()
    {
        //if the player is on the ground, they can jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            //isJumping = true;
            //jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        //if the player is on a wall, they can jump
        if(isOnWall && Input.GetButtonDown("Jump"))
        {
            //isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        //if (Input.GetButton("Jump") && isJumping)
        //{
        //    if (jumpTimeCounter > 0)
        //    {
        //        rb.velocity = Vector2.up * jumpForce;
        //        jumpTimeCounter -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        isJumping = false;
        //    }
        //}

        //if (Input.GetButtonUp("Jump"))
        //{
        //    //isJumping = false;
        //}
    }

    void HandleSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            playerMoveSpeed /= 0.15f;
        }

        if (isRunning)
        {
            playerMoveSpeed *= 0.15f;
        }
    }

    //this function flips the player depending on which direction they are facing
    void Flip()
    {
        if (moveDirection > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveDirection < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    #endregion  

}
