using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}


public class Enemy : MonoBehaviour
{   

    public EnemyState currentState;

    public float health;
    public string enemyName;
    public int baseAttack;

    public float moveSpeed;


    void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {       
        this.currentState = EnemyState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void TakeDamage(float damage){
        Debug.Log("受伤..");
        health -= damage;
        if(this.health <= 0){
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D enemyRigidbody,float knockTime,float damage){
        this.TakeDamage(damage);
        if(this.health > 0)
            StartCoroutine(KnockCo(enemyRigidbody,knockTime));
    }

        private IEnumerator KnockCo(Rigidbody2D enemyRigidbody,float knockTime)
    {
        if (enemyRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);                                  
            enemyRigidbody.velocity = Vector3.zero;
            // enemyRigidbody.isKinematic = true;     
            this.currentState = EnemyState.idle;         
           
        }
    }

    


}
