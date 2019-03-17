using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D mRigidbody2d;
	private Animator mAnimator;
	private Vector3 dir;
	public float Speed;

	private void Awake () {
		this.mRigidbody2d = GetComponent<Rigidbody2D> ();
		this.mAnimator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		dir = Vector3.zero;
		dir.x = Input.GetAxisRaw ("Horizontal");
		dir.y = Input.GetAxisRaw ("Vertical");
		this.UpdateAnimationMove();
	}

	private void UpdateAnimationMove(){
		if (dir != Vector3.zero) {
			this.mAnimator.SetFloat("moveX",dir.x);
			this.mAnimator.SetFloat("moveY",dir.y);
			this.mAnimator.SetBool("moving",true);			
			Move ();
		}
		else{
			this.mAnimator.SetBool("moving",false);
		}
	}

	private void Move () {
		this.mRigidbody2d.MovePosition (transform.position + dir * this.Speed * Time.deltaTime);
	}
}