using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour {

	GameObject currentBall;

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Ball")){
			other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			currentBall = other.gameObject;
			StartCoroutine("moveToInside");
		}
	}

	IEnumerator moveToInside(){

		currentBall.GetComponent<Collider2D>().enabled = false;
		
		for(int i = 0; i<15; i++){
			Vector3 targetVector = new Vector3(transform.position.x, transform.position.y, 0);
			currentBall.transform.position = Vector3.Lerp(currentBall.transform.position, targetVector,0.2f);
			yield return null;
		}

		Destroy(currentBall);
		currentBall = null;
	}
}
