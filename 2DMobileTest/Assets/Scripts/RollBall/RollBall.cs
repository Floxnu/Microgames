using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBall : MonoBehaviour
{
   Rigidbody2D rbRef;
   bool canMove;

   private void Awake() {
       rbRef= GetComponent<Rigidbody2D>();
       GameManager.OnGameStart+= CustomStart;
   }

   void CustomStart(){
       canMove = true;

        GameManager.OnGameStart -= CustomStart;
   }

   private void Update() {

       if(canMove){
            Vector3 tiltInput = Input.acceleration;

            tiltInput = Quaternion.Euler(90,0, -90) * tiltInput;

            rbRef.AddForce(new Vector2(-tiltInput.z, tiltInput.x + .4f) * 10);
       }
   }
}
