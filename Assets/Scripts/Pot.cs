using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator mAni;

    private void Awake() {
        this.mAni = GetComponent<Animator>();
    }

    void Start()
    {
        
    }


    public void Smash(){
        this.mAni.SetBool("isDestory",true);
        StartCoroutine(DestoryPot());
    }

    private IEnumerator DestoryPot(){
        yield return new WaitForSeconds(.3f);
        // GameObject.Destroy(this.gameObject);
        this.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
