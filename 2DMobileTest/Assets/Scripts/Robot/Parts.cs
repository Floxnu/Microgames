using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{

    private Rigidbody2D rigidibody2D;
    private Vector3 currentPosition;

    private Vector3 targetPosition;

    private bool attached;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rigidibody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!attached)
        {

        currentPosition = this.transform.position;
        rigidibody2D.MovePosition(Vector3.MoveTowards(currentPosition,new Vector3(0.2f, -10, 1),10 * Time.deltaTime));
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        print("a");
        this.transform.parent = other.gameObject.transform;
        attached = true;
    }
}
