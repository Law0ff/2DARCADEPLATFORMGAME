using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    
    public GameObject stone;
    public Transform attackInstantiate;
    private Animator anim;

    private string coroutine_Name = "StartAttack";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(coroutine_Name);

    }
    public void  BossDead()
    {
        
        gameObject.SetActive(false);

    }

    void ThrowStone()
    {
        GameObject obj = Instantiate(stone, attackInstantiate.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f, -700f), 0f));

    }
    void BackToIdle()
    {
        anim.Play("BossIdle");
    }
    public void DeactivateBossScript()
    {
        StopCoroutine(coroutine_Name);
        enabled = false;
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        anim.Play("BossAttack");
        StartCoroutine(coroutine_Name);
    }
}
