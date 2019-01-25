using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKMovement : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rbRef;
	float startFall;
	Animator animRef;


	private void Awake() {
		GameManager.OnGameStart += CustomStart;
	}
	void Start () {
		rbRef = GetComponent<Rigidbody2D>();
		animRef = GetComponent<Animator>();
		
	}

	public void CustomStart(){
		rbRef.velocity = new Vector2(4,0);
		GameManager.OnGameStart -= CustomStart;
	}



	private void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

		 if (hit.collider == null)
        {
			if(startFall > 0 ){
				startFall -= Time.deltaTime;
			}else{
            	animRef.SetBool("IsFalling", true);

			}
        } else{
			startFall = 0.1f;
			animRef.SetBool("IsFalling", false);
		}

	}
	
}
