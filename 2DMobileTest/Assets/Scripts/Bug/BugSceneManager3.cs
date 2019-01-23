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


	void Start () {
		range = new Vector3(Random.Range(2,6),Random.Range(-2.6f,2.6f),-5f);
		range1 = new Vector3(Random.Range(2,6),Random.Range(-2.6f,2.6f),-5f);
		range2 = new Vector3(Random.Range(2,6),Random.Range(-2.6f,2.6f),-5f);

		Invoke("instantiateobject", 1.0f);
		
		Invoke("checkifwin", 6);
	}
	
	void Update () {
		
	}

	void Awake()
	{
            if (instance == null)
                {
                instance = this;
				}
            else if (instance != this)
                {
                Destroy(gameObject);    
				}
            DontDestroyOnLoad(gameObject);

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
			print(true);
			print(bug.Count);
			return true;
		}else
		{
			print(bug.Count);
			winningstate = false;
			print(false);
			return false;
		}
	}

	public static bool getwinningstate()
	{
		return winningstate;
	}
}
