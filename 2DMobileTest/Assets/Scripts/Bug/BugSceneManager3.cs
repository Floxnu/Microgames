using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSceneManager3: MonoBehaviour {

	 public static BugSceneManager3 instance = null;
	public GameObject bugobject;
	private Vector3 range; 
	private Vector3 range1; 
	private Vector3 range2; 

	private static bool winningstate = false;

	public List<GameObject> bug = new List<GameObject>();


void customStart()
	{
		range = new Vector3(Random.Range(2,6),Random.Range(-2.6f,2.6f),-5f);
		range1 = new Vector3(Random.Range(2,6),Random.Range(-2.6f,2.6f),-5f);
		range2 = new Vector3(Random.Range(2,6),Random.Range(-2.6f,2.6f),-5f);


		Invoke("instantiateobject", 1.0f);
		
		Invoke("checkifwin", 6);
		GameManager.OnGameStart -= customStart;		

	}
	
	void Update () {
		
	}

	void Awake()
	{
        if(instance != null){
			Destroy(this);
		}
		instance = this;
		GameManager.OnGameStart += customStart;

	}

	void instantiateobject()
	{
		GameObject current = Instantiate(bugobject,range,Quaternion.identity);
  		bug.Add(current);
		current = Instantiate(bugobject,range1,Quaternion.identity);
  		bug.Add(current);
		current = Instantiate(bugobject,range2,Quaternion.identity);
  		bug.Add(current);

	}

	public bool checkifwin()
	{
		if (bug.Count == 0)
		{
			winningstate = true;
			GameManager.instance.SetGameResult(true);
		}else
		{
			print(bug.Count);
			winningstate = false;
			GameManager.instance.SetGameResult(false);
		}
			instance = null;
			return winningstate;
	}

	public static bool getwinningstate()
	{
		return winningstate;
	}
}
