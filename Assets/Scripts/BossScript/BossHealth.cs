using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Animator anim;
    private int health = 5;
    private bool canDamage;
   
    void Awake()
    {
        anim = GetComponent<Animator>();
        canDamage = true;
        
    }
    IEnumerator BossDead()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<BossScript>().BossDead();

    }
    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }
    

    void OnTriggerEnter2D(Collider2D target)
    {
        if (canDamage)
        {
            if (target.tag == myTags.BULLET_TAG)
            {

            health--;
            canDamage = false;
            if (health == 0)
            {
                GetComponent<BossScript>().DeactivateBossScript();
                anim.Play("BossDead");
                BossDead();


            }

            StartCoroutine(WaitForDamage());

            }
        }
    }
}
