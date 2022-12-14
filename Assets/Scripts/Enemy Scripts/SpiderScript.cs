using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : Mob
{
    private Vector3 moveDirection = Vector3.down;
    private string coroutine_Name = "ChangeMovement";
    bool SpiderDead;
    void Start()
    {
        StartCoroutine(coroutine_Name);


    }


    void Update()
    {
        MoveSpider();
    }

    void MoveSpider()
    {
        transform.Translate(moveDirection * Time.smoothDeltaTime);

    }
    IEnumerator ChangeMovement()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        if (moveDirection == Vector3.down)
        {
            moveDirection = Vector3.up;

        }
        else
        {
            moveDirection = Vector3.down;
        }
        StartCoroutine(coroutine_Name);      
    }

     void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag==myTags.BULLET_TAG)
        {
            anim.Play("SpiderDead");
            myBody.bodyType = RigidbodyType2D.Dynamic;

            StartCoroutine(SpiderDeadd());
            StopCoroutine(coroutine_Name);

        }
        if (target.tag == myTags.PLAYER_TAG)
        {
            target.GetComponent<PlayerDamage>().DealDamage();
        }
    }

    IEnumerator SpiderDeadd()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);

        
    }
}
