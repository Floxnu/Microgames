﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {


	public static TimerManager instance;
	public Slider timeSlider;
	public Text timerText;
	public float timeLeft;

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

		StartCoroutine(DecreaseTimer());

	}

	IEnumerator DecreaseTimer(){

		float i = 100/timeLeft;
		timeSlider.value = 100;

		while(timeLeft > 0){
			timeLeft -= Time.deltaTime;
			timeSlider.value -= i  * Time.deltaTime;
			timerText.text = Mathf.Round(timeLeft + .5f).ToString();
			yield return null;
		}
		
	}

	private void OnDestroy() {
		instance = null;
	}
	
}
