﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {


	public static TimerManager instance;
	public Slider timeSlider;
	public Text timerText;
	public float timeLeft;
	private float timeSpeed = 1;

	private void Awake() {
		if(instance!=null){
			instance = this;
		}
		instance = this;
	}

	public void SetGameTimer(int gameLength){

		timeLeft = gameLength;
		timerText.text = timeLeft.ToString();

	}

	public void StartTimer(){
		GameManager.instance.SetGameResult(false);

		StartCoroutine(DecreaseTimer());

	}

	IEnumerator DecreaseTimer(){

		float i = 100/timeLeft;
		timeSlider.value = 100;

		while(timeLeft > 0){
			if(!GameManager.instance.GetGameResult()){
				timeSpeed = 2;
			} else{
				timeSpeed = 1;
			}
			timeLeft -= Time.deltaTime * timeSpeed;
			timeSlider.value -= i  * Time.deltaTime * timeSpeed;
			timerText.text = Mathf.Round(timeLeft + .5f).ToString();
			yield return null;
		}

		GameManager.instance.TimerEnd();
		
	}

	private void OnDestroy() {
		instance = null;
	}
	
}
