using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private int livesRemaining;

	public int currentScore;

	public int gameDificulty;

	private bool gameResult = false;

	public enum GameType{
		TOUCH,
		TILT
	}

	public GameType currentGameType;

	public delegate void StartAction();
	public static event StartAction OnGameStart;
	public delegate void EndAction();
	public static event EndAction OnTimerEnd;



	public string[] gameNames;

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
		CanvasManager.instance.ScoreFadeIn();
		StartCoroutine(StartNextGame());

		
	}

	IEnumerator StartNextGame(){

		int randomGame = Random.Range(0, gameNames.Length);
		string gameId = gameNames[randomGame] + gameDificulty;

		yield return new WaitForSeconds(2);

		CanvasManager.instance.ScoreFadeOut();
		CanvasManager.instance.ShowTouch();

		SceneManager.LoadScene(2, LoadSceneMode.Additive);
		SceneManager.LoadScene(3, LoadSceneMode.Additive);

		yield return new WaitForSeconds(2);

		TimerManager.instance.StartTimer();

		if(OnGameStart != null){
			OnGameStart();
		}

	}

	public void SetGameResult(bool gameEndResult){

		gameResult = gameEndResult;

	}

	
}
