using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeHandler : MonoBehaviour
{
	[SerializeField] TMP_Text dayText;
	public int day = 1;
	[SerializeField] TMP_Text timeText;
	public int hour;
	public float minute;

	private void Update()
	{
		minute += Time.deltaTime;
		if (minute >= 60)
		{
			if (hour >= 24)
			{
				hour = 0;
				day++;
			}
			else
			{
				hour++;
			}
		}
		dayText.text = $"Day : {day}";

		timeText.text = $"{hour}:{(int)minute}";
	}
}