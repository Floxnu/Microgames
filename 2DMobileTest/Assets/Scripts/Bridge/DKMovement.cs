using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKMovement : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rbRef;
	float startFall;
	Animator animRef;
	bool isFlipped;
	bool gameStart;


	private void Awake() {
		GameManager.OnGameStart += CustomStart;
	}
	void Start () {
		rbRef = GetComponent<Rigidbody2D>();
		animRef = GetComponent<Animator>();
		
	}

	public void CustomStart(){
		gameStart = true;
		
		GameManager.OnGameStart -= CustomStart;
	}



	private void Update() {

		if(gameStart){

			rbRef.velocity = !isFlipped?new Vector2(4,rbRef.velocity.y):new Vector2(-4, rbRef.velocity.y);
		}
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

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.collider.tag == "Rock"){
			GetComponent<SpriteRenderer>().flipX = true;
			isFlipped = !isFlipped;
		}
	}
	
}
