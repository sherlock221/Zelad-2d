using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Log : Enemy
{

    public Transform Target;

    public float ChaseRadius;
    public float AttackRadius;
    public Transform HomePosition;
    private Rigidbody2D mRigidbody2d;

    private Animator mAni;

    private void Awake()
    {
        mRigidbody2d = GetComponent<Rigidbody2D>();
        mAni = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        this.CheckDistance();
    }

    private void CheckDistance()
    {

        float dis = Vector3.Distance(Target.position, transform.position);
        //追逐
        if (dis <= this.ChaseRadius && dis > AttackRadius)
        {

            if (this.currentState == EnemyState.walk ||
                this.currentState == EnemyState.idle &&
                this.currentState != EnemyState.stagger)
            {
                Vector3 position = Vector3.MoveTowards(transform.position, Target.position, moveSpeed * Time.fixedDeltaTime);
                mRigidbody2d.MovePosition(position);
                ChangeState(EnemyState.walk);
                mAni.SetBool("wakeUp", true);
                this.ChangeAnim(position - transform.position);

            }           
        }
        else if(dis > ChaseRadius){                            
            mAni.SetBool("wakeUp", false);
        }

    }


    private void setAniMove(Vector2 dir)
    {
        mAni.SetFloat("moveX", dir.x);
        mAni.SetFloat("moveY", dir.y);
    }

    public void ChangeAnim(Vector2 dir)
    {

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x < 0)
            {
               setAniMove(Vector2.left);
            }
            else
            {
                setAniMove(Vector2.right);
            }
        }

        else if( Mathf.Abs(dir.x) < Mathf.Abs(dir.y)){
             if (dir.y < 0)
            {
               setAniMove(Vector2.down);
            }
            else
            {
                setAniMove(Vector2.up);
            }
        }

       
    }


    public void ChangeState(EnemyState newState)
    {
        this.currentState = newState;
    }


}
