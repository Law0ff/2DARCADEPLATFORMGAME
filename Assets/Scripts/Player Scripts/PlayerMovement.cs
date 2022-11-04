using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpPower = 12f;

    private Rigidbody2D myBody;
    private Animator anim;

    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool jumped;


    public static Transform mT;
     void Awake()
    {
        mT = transform;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    
    void Update()
    {
        CheckIfGrounded();
        PlayerJump();
        anim.SetBool("Jump", jumped);
    }

    void FixedUpdate()
    {
        PlayerWalk();
        
    }
    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");    

        if (h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            ChangeDirection(1);
        }
        else if ( h < 0 )
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            ChangeDirection(-1);
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }

        anim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x));    
    }
    

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down,0.1f,groundLayer);

        if (!isGrounded)
            return;
       
            // and we jumped before
            if (jumped)
                jumped = false;
        
    }
  void PlayerJump()
    {
        if (!isGrounded)
            return;
        
            if (Input.GetKey(KeyCode.Space))
            {
                jumped = true;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
            }
        
    }

} // Class




















