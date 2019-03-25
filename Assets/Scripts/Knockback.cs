using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * 击退
 */
public class Knockback : MonoBehaviour
{

    //推的距离
    public float Thrust;

    //持续时间
    public float KnockTime;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void Force(Rigidbody2D hitRigidbody, Collider2D other){

         Vector2 diff = other.transform.position - gameObject.transform.position;
                        diff = diff.normalized * Thrust;
                        hitRigidbody.AddForce(diff, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("breakable"))
        {
            other.GetComponent<Pot>().Smash();
        }

        if (other.isTrigger && (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player")))
        {
              
           

            Rigidbody2D hitRigidbody = other.GetComponent<Rigidbody2D>();
            if (hitRigidbody != null)
            {                

                //是触发器
                if (other.CompareTag("enemy") && other.GetComponent<Enemy>().currentState != EnemyState.stagger)
                {                   
                     Debug.Log("knock 发生碰撞.." + other.gameObject.tag);
                    this.Force(hitRigidbody,other);
                    other.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hitRigidbody, this.KnockTime, damage);
                }
                else if(other.CompareTag("Player") && other.GetComponent<PlayerMovement>().currentState != PlayerStatus.stagger)
                {
                     Debug.Log("knock 发生碰撞.." + other.gameObject.tag);
                     this.Force(hitRigidbody,other);
                    other.GetComponent<PlayerMovement>().currentState = PlayerStatus.stagger;
                    other.GetComponent<PlayerMovement>().Knock(this.KnockTime, damage);
                }

               


            }

        }
    }




}
