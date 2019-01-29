using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    float rotateSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            print(true);
        transform.Rotate(0, 0,rotateSpeed);

        }   

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            print(true);
        transform.Rotate(0, 0,-rotateSpeed);

        }   
        if(Input.GetKey(KeyCode.UpArrow))
        {
            print(true);
        transform.Rotate(rotateSpeed, 0,0);

        }   

        if(Input.GetKey(KeyCode.DownArrow))
        {
            print(true);
        transform.Rotate(-rotateSpeed, 0,0);

        }   
    }

    
}
