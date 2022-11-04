using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{

    protected Rigidbody2D myBody;
    protected Animator anim;
    protected bool attacked = false;
    

    [SerializeField]
    protected float moveSpeed;

    [SerializeField]
    protected float HP;

    [SerializeField]
    protected bool canMove = true;

    public LayerMask playerLayer;
    protected bool stunned;
    public virtual void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }

    
    public virtual void Attack()
    {   
    }

    public virtual void GetDamage()
    {
    }
}
