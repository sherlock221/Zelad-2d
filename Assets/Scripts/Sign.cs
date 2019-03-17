using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    // Start is called before the first frame update

    public Text DialogText;
    public GameObject Dialog;

    private bool mIsPlayerInRange;

    public string SignText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space) && this.mIsPlayerInRange){
            if(this.Dialog.activeInHierarchy){
                this.Dialog.SetActive(false);
            }
            else{
                 this.Dialog.SetActive(true);
                this.DialogText.text = SignText;
            }           
        }
        
    }

     private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            this.mIsPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
          if(other.CompareTag("Player")){
              this.mIsPlayerInRange = false;
              Dialog.SetActive(false);
        }
      
    }
}
