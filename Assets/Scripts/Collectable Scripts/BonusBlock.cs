using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Mob
{
    public Transform buttom_Collision;
    private Vector3 moveDirection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnim;
    private bool canAnimated = true;
    public GameObject Coin;



    private void Start()
    {
        originPosition = transform.position;
        animPosition = transform.position;
        animPosition.y += 0.15f;

    }

    void Update()
    {
        CheckForCollision();
        AnimateUpDown();
    }


    void CheckForCollision()
    {
        if (canAnimated)
        {
            RaycastHit2D hit = Physics2D.Raycast(buttom_Collision.position, Vector2.down, 0.1f, playerLayer);
            if (hit)
            {
                if (hit.collider.gameObject.tag == myTags.PLAYER_TAG)
                {
                    
                    anim.Play("Idle");
                    startAnim = true;
                    canAnimated = false;
                    
                }
            }
        }
        
    }
    void AnimateUpDown()
    {
        if (startAnim)
        {
            transform.Translate(moveDirection * Time.smoothDeltaTime);

            if (transform.position.y >= animPosition.y)
            {
                moveDirection = Vector3.down;
            }
            else if (transform.position.y <= originPosition.y)
            {
                startAnim = false;
            }
        }
    }
}
