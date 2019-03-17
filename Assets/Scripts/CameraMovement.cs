using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform target;
    public float smoothing;

    public Vector2 MinPos;
    public Vector2 MaxPos;

    // Start is called before the first frame update
    void Start () {

    }

   
    // Update is called once per frame
    void Update () {

    }

     private void LateUpdate () {
         if(transform.position != this.target.position){
             Vector3 targetPosition = new Vector3(target.position.x,target.position.y,transform.position.z);
             
             targetPosition.x = Mathf.Clamp(targetPosition.x,MinPos.x,MaxPos.x);
             targetPosition.y = Mathf.Clamp(targetPosition.y,MinPos.y,MaxPos.y);

             transform.position = Vector3.Lerp(transform.position,targetPosition,smoothing);
         }
    }

}