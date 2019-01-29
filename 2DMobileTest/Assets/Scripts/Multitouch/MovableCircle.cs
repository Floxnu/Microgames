using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCircle : MonoBehaviour
{
    Vector2 targetPosition;
    Vector3 startingPosition;
    bool isTouchOver;

    private void Start() {
        startingPosition = transform.position;
    }


    void OnTouchDown(){
        isTouchOver = true;

    }
     void OnTouchStay(Vector2 position){
         isTouchOver = true;
         targetPosition = position;
        
    }
     void OnTouchExit(){
        isTouchOver = false;
    }
     void OnTouchUp(){
        isTouchOver = false;
        
    }

    private void Update() {
        transform.position = Vector2.Lerp(transform.position, targetPosition, 0.3f);

        if(!isTouchOver){
            targetPosition = startingPosition;
        }
    }
}
