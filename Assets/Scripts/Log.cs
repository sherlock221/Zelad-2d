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

    private void Awake() {
            mRigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckDistance();   
    }

    private void CheckDistance(){

        float dis = Vector3.Distance(Target.position,transform.position);      
       
        //追逐
        if(dis <= this.ChaseRadius && dis > AttackRadius){  
            Vector3 position = Vector3.MoveTowards(transform.position,Target.position,moveSpeed * Time.deltaTime);
            mRigidbody2d.MovePosition(position);
        }

    }


}
