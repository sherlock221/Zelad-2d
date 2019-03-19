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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("发生碰撞..");
        if(other.CompareTag("enemy")){
            Rigidbody2D enemyRigidbody = other.GetComponent<Rigidbody2D>();
            enemyRigidbody.isKinematic = false;   
            Vector2 diff = gameObject.transform.position - other.transform.position;
            diff = diff.normalized  * Thrust; 
            Debug.Log(diff);           
            enemyRigidbody.AddForce(diff,ForceMode2D.Force);  
            StartCoroutine(KnockCo(enemyRigidbody));   
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemyRigidbody){
        if(enemyRigidbody != null){
            yield return new WaitForSeconds(KnockTime);           
            enemyRigidbody.velocity = Vector3.zero;
             enemyRigidbody.isKinematic = true;
        }
    }
}
