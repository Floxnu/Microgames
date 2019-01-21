using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKMovement : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rbRef;

	void Start () {
		rbRef = GetComponent<Rigidbody2D>();
		rbRef.velocity = new Vector2(5,0);

		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
