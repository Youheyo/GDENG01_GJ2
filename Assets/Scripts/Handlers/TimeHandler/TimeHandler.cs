using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeHandler : MonoBehaviour
{
	public int day = 1;

	[SerializeField] private bool gameStarted = false;

	[SerializeField] float _dayLength = 24f;
	[SerializeField] float _startingTime = 0f;

	// 60 = 1 irl second = 1 game minute
	[SerializeField] float _timeFactor = 60f;

	[SerializeField] List<Time_Base> _time;

	public float dayLength => _dayLength;

	public float deltaTime => Time.deltaTime * _timeFactor / 3600f;

	public float currentTime = 0f;

	public void startTime() {
		currentTime = _startingTime;
		gameStarted = true;
	}

	public void addTime(Time_Base time) {
		_time.Add(time);
	}

	public void stopTime() {
		gameStarted = false;
		day = 1;
	}

	void Update() {
		if(gameStarted == true) {
			currentTime = (dayLength + currentTime + (Time.deltaTime * _timeFactor / 3600f)) % dayLength;
			if(currentTime >= 23.99f) {
				day++;
				currentTime = 0f;
			}
		}

		foreach(var times in _time) {
			times.OnTick(currentTime);
		}
	}

	public float getDayLength() {
		return _dayLength;
	}
}
