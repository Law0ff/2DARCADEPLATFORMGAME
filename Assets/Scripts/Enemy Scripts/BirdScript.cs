using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : Mob
{

    Vector2 dir;
    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 movePosition;
    public GameObject birdEgg;
    private float distance;


   
    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 6f;

        movePosition = transform.position;
        movePosition.x -= 6f;
     
    }

   
    void Update()
    {
        MoveTheBird();
        DropTheEgg();
    }


    public override void Attack()
    {
        base.Attack();
    }

    void MoveTheBird()
    {
        if (canMove)
        {
            transform.Translate(moveDirection *moveSpeed* Time.smoothDeltaTime);

            if (transform.position.x >= originPosition.x)
            {
                moveDirection = Vector3.left;

                changeDirection(0.8f);
            }
            else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;
                changeDirection(-0.8f);
            }
        }
    }

    void changeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void changeDirectionDive()
    {

        Vector2 playerPos = PlayerMovement.mT.position;
        //dir = playerPos - (Vector2)transform.position;
        //transform.up = dir;
 
        distance = Vector2.Distance(transform.position,playerPos);
        Vector2 direction = PlayerMovement.mT.position - transform.position;      
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position, PlayerMovement.mT.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
      

    }

    bool isDropTheEgg = false;
    void DropTheEgg()
    {
        if (!isDropTheEgg && !isBirdDive)
        {
            if (!isPlayerDown())
                return;

                Instantiate(birdEgg, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
                isDropTheEgg = true;
                anim.SetBool(AnimParameters.isDropEgg, isDropTheEgg);
                StartCoroutine(BirdDiveCR());
        }
    }




    private bool isPlayerDown()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, playerLayer);
    }


    bool isBirdDive = false;
    IEnumerator BirdDiveCR()
    {
        yield return new WaitForSeconds(Random.Range(3,5));
        GameManager.Instance.OnSlowTime(4f);
        changeDirectionDive();
        isBirdDive = true;
        moveSpeed = 7;
   
    }

    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
        
    //}

    IEnumerator BirdDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);

       
    }
    
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == myTags.BULLET_TAG )
        {
            anim.Play("BirdDead");

            GetComponent<BoxCollider2D>().isTrigger = true;
            myBody.bodyType = RigidbodyType2D.Dynamic;
            canMove = false;

            StartCoroutine(BirdDead());
        }
        else if (target.tag == myTags.PLAYER_TAG)
        {
            target.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
    }

}
