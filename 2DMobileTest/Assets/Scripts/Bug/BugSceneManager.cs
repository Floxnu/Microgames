using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSceneManager: MonoBehaviour {

	public static BugSceneManager instance = null;
	public GameObject bugobject;
	public Vector3 range; 


	private static bool winningstate = false;

	public List<GameObject> bug;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>

	public virtual void customStart()
	{
		bug = new List<GameObject>();
		range = new Vector3(Random.Range(2,6),Random.Range(-2.6f,2.6f),-5f);


		Invoke("instantiateobject", 1.0f);
		
		Invoke("checkifwin", 6);
		GameManager.OnGameStart -= customStart;	

	}
	void Start () {
	
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

	public virtual void instantiateobject()
	{
		GameObject current = Instantiate(bugobject,range,Quaternion.identity);
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
