using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Time_Clock : Time_Base
{
	[SerializeField] TMP_Text timeDisplay;
	[SerializeField] TMP_Text dayDisplay;

	public override void OnTick(float currentTime) {
		int hours = Mathf.FloorToInt(currentTime);

		float remainder = (currentTime - hours) * 60f; // remainder in minutes
		int minutes = Mathf.FloorToInt(remainder);

		remainder = (remainder - minutes) * 60f; // remainder in seconds

		timeDisplay.text = hours.ToString() + ":" + minutes.ToString("00") + ":" + remainder.ToString("00.0");
		dayDisplay.text = "Day : " + GameManager.instance.getDay().ToString();
	}
}
