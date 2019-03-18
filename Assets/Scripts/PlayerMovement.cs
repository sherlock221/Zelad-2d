using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStatus
{
	walk,
	attack,
	interact
}

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D mRigidbody2d;
	private Animator mAnimator;
	private Vector3 dir;
	public float Speed;

	private PlayerStatus  mCurrentStatus;


	private void Awake () {
		this.mRigidbody2d = GetComponent<Rigidbody2D> ();
		this.mAnimator = GetComponent<Animator>();
		this.mCurrentStatus = PlayerStatus.walk;
	}

	// Use this for initialization
	void Start () {
		this.mAnimator.SetFloat("moveX",0);	
		this.mAnimator.SetFloat("moveY",-1);			
	} 
 
	// Update is called once per frame
	void Update () {
		dir = Vector3.zero;
		dir.x = Input.GetAxisRaw ("Horizontal");
		dir.y = Input.GetAxisRaw ("Vertical");



		 //判断不进行重复攻击
		if(Input.GetKeyDown(KeyCode.Space) && this.mCurrentStatus != PlayerStatus.attack){
			StartCoroutine(AttackCo());
		}
		else if(mCurrentStatus == PlayerStatus.walk){
			this.UpdateAnimationMove();
		}	


			
	}

	private IEnumerator  AttackCo(){		
		mAnimator.SetBool("attacking",true);
		mCurrentStatus = PlayerStatus.attack;	
		yield return null;	
		mAnimator.SetBool("attacking",false);	
		yield return new WaitForSeconds(0.3f);			
		mCurrentStatus = PlayerStatus.walk;
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
		//向量归一化 斜向走过快做归一化处理
		dir.Normalize();	
		this.mRigidbody2d.MovePosition (transform.position + dir * this.Speed * Time.deltaTime);
	}
}