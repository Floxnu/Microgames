using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private int livesRemaining;

	public int currentScore;

	public int gameDificulty;

	public enum GameType{
		TOUCH,
		TILT
	}

	public GameType currentGameType;

	public delegate void StartAction();
	public static event StartAction OnGameStart;

	private void Awake() {
		if(instance != null){
			Destroy(this);
		}
		instance = this;
		DontDestroyOnLoad(this);
		DontDestroyOnLoad(gameObject);
	}

	private void Start() {
		CanvasManager.instance.SetScoreText(currentScore.ToString());
		StartCoroutine(StartNextGame());
		
	}

	IEnumerator StartNextGame(){
		yield return new WaitForSeconds(2);

		SceneManager.LoadScene(2, LoadSceneMode.Additive);
		SceneManager.LoadScene(3, LoadSceneMode.Additive);

		yield return new WaitForSeconds(1);

	}
}
