using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnAlien : MonoBehaviour
{

    public GameObject human;
    public GameObject Alien;
    private SpriteRenderer spriteR;
    private int pointlocation;
    private Quaternion rPoint1 = Quaternion.Euler(0,-38.68f,0);
    
    public GameObject target;

    private int layer = 0;

    void Awake()
    {
        string[] thisname = gameObject.name.Split(',');
        pointlocation = int.Parse(thisname[1]);
        
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    void instantiate()
    {   
       switch (pointlocation)
       {
           case 1:
            GameObject current = Instantiate(human,transform.position,rPoint1);
            
            spriteR = current.GetComponent<SpriteRenderer>();
            spriteR.sortingOrder = layer;
            break;
       }
        layer --;
    }

}
