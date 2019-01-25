using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
	Vector3 currentposition;
    public GameObject target;

    public bool killer = false;

    public bool isAlien = false;

	Vector3 targetposition1;
    public Animator animator ;
    public float speed;

   void Awake()
   {
       speed = Random.Range(2f,5f);
        animator = GetComponent<Animator>();
   }

    void Start()
    {
        Rigidbody2D rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.gravityScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {   
        animator.SetFloat("Speed",speed);

        currentposition = this.transform.position;
        if(target)
        {   
            targetposition1 = target.transform.position; 
		    this.transform.position = Vector3.MoveTowards(currentposition,targetposition1, speed * Time.deltaTime);	           
        }else
        {
            
        }
        			
    }


    void OnMouseDown()
    {
         if(!isAlien)
        {
            AlienSceneManager.instance.killer = true;
        }else
        {
            AlienSceneManager.instance.isWin = true;
        }
        AlienSceneManager.instance.peoples.Remove(gameObject);
        if(!AlienSceneManager.instance.killer || !AlienSceneManager.instance.isWin)
        {
        Destroy(gameObject);
        }
    }
}
