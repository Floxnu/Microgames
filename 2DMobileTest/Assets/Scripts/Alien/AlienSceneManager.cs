using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSceneManager : MonoBehaviour
{
	public static AlienSceneManager instance = null;
    public int spawnAlien;
    public bool isWin = false;

    public bool killer = false;    

    public List<GameObject> peoples = new List<GameObject>();

    public delegate void StartAction();
    public static event StartAction StartThis;

    void Awake()
    {
         if(instance != null){
			Destroy(this);
		}
		instance = this;
        spawnAlien = Random.Range(5, 16);
        GameManager.OnGameStart += customStart;
        InvokeRepeating("killerStare",2,2);
        Invoke("setGameResult",10);
    }
    void Start()
    {
        
    }

    void customStart()
    {
        StartThis();
        GameManager.OnGameStart -= customStart;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void killerStare()
    {
        if(killer)
        {
            foreach (GameObject item in peoples)
            {
               Walking walking = item.GetComponent<Walking>();
                walking.speed = 0;
            }
        }
    }

    void setGameResult()
    {
        GameManager.instance.SetGameResult(isWin);
    }
}
