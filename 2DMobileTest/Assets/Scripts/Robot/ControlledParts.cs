using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledParts : MonoBehaviour
{

    public Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        Vector3 tiltinput = Input.acceleration;
        tiltinput = Quaternion.Euler(90, 0, -90) * tiltinput;
        transform.Translate(-tiltinput.z,tiltinput.x, 0);
    }
}
