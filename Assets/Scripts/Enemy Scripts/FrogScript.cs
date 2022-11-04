using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : Mob
{

    private bool animation_started;
    private bool animation_Finished;
    private GameObject player;
    private int jumpedTimes;
    private bool jumpLeft = true;

    private string corotuine_Name = "FrogJump";

    
    
    void Start()
    {
        StartCoroutine(corotuine_Name);
        player = GameObject.FindGameObjectWithTag(myTags.PLAYER_TAG);
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position,0.5f,playerLayer))
        {
            player.GetComponent<PlayerDamage>().DealDamage();
        }
    }
    void LateUpdate()
    {
        if (animation_Finished && animation_started)
        {
            animation_started = false;

            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        animation_started = true;
        animation_Finished = false;

        jumpedTimes++;
        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");

        }
        else
        {
            anim.Play("FrogJumpRýght");
        }
        StartCoroutine(corotuine_Name);
    }

    void AnimationFinished()
    {
        animation_Finished = true;

        if (jumpLeft)
        {
            anim.Play("FrogIdleLeft");
        }
        else
        {
            anim.Play("FrogIdleRýght");
        }




        if (jumpedTimes ==3)
        {
            jumpedTimes = 0;

            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;

            jumpLeft = !jumpLeft;
        }
    }
}
