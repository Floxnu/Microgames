using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private int livesRemaining = 3;

	public int currentScore;

	public int gameDificulty;

	private bool gameResult = false;
	public string currentGameId;

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

		int randomGame = UnityEngine.Random.Range(0, gameNames.Length);

		string[] result = gameNames[randomGame].Split(',');

		int gameTimer = int.Parse(result[1]);
	
		currentGameId = result[0] + gameDificulty;

		yield return new WaitForSeconds(2);

		CanvasManager.instance.ScoreFadeOut();

		if(result[2].Equals("tilt")){

			CanvasManager.instance.ShowTilt();
		} else{
			CanvasManager.instance.ShowTouch();
		}

		SceneManager.LoadScene(2, LoadSceneMode.Additive);
		SceneManager.LoadScene(currentGameId, LoadSceneMode.Additive);

		yield return new WaitForSeconds(2);

		TimerManager.instance.SetGameTimer(gameTimer);
		TimerManager.instance.StartTimer();

		if(OnGameStart != null){
			OnGameStart();
		}

	}

	public void SetGameResult(bool gameEndResult){

		gameResult = gameEndResult;

	}

	public void TimerEnd(){

		StartCoroutine(GameEndTransition());
	
	}

	IEnumerator GameEndTransition(){

		CanvasManager.instance.FadeInBackground();
		yield return new WaitForSeconds(0.5f);
		
		if(OnTimerEnd != null){
			OnTimerEnd();

		}

		CanvasManager.instance.ScoreFadeIn();
		yield return new WaitForSeconds(0.5f);

		if(gameResult){
			currentScore++;
			CanvasManager.instance.SetScoreText(currentScore.ToString());
		} else {
			CanvasManager.instance.LooseHeart(livesRemaining);
			print(livesRemaining);
			livesRemaining--;
		}
		
		SceneManager.UnloadSceneAsync(currentGameId);
		SceneManager.UnloadSceneAsync(2);

		yield return null;

		StartCoroutine(StartNextGame());

	}

	
}
