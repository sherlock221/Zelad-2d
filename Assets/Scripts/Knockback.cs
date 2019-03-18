using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * 击退
 */
public class Knockback : MonoBehaviour
{   

    //推的距离
    public float thrust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("breakable")){
            Debug.Log("attc");
            other.GetComponent<Pot>().Smash();
        }
    }
}
