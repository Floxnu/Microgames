using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : MonoBehaviour {

	public int plugID;
	private bool isMovable = true;
	Rigidbody2D rbRef;

	private void Start() {
		rbRef = GetComponent<Rigidbody2D>();
	}


	private void OnMouseDrag() {
	
		if(isMovable){
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			pos.z = 0;

			rbRef.MovePosition(Vector2.Lerp(transform.position,pos + (Vector3.up*2), .5f ));
				
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {

		print("Collision Detected");
		Socket socketRef = other.GetComponent<Socket>();

		if(socketRef != null){
			if(socketRef.socketID == plugID){
				print("Success");
				isMovable = false;
			} else{
				print("Failure");
				isMovable = false;
			}
		}
		
	}
}
