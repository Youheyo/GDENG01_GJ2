using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Light : Time_Base
{
	[SerializeField] Light LinkedLight;
	[SerializeField] float sunriseTime = 6f;
	[SerializeField] float sunsetTime = 18f;

	[SerializeField] Gradient lightColour_Day;
	[SerializeField] Gradient lightColour_Night;
	[SerializeField] AnimationCurve lightIntensity_Day;
	[SerializeField] AnimationCurve lightIntensity_Night;

	float daylightLength;
	float nightLength;

	void Awake() {
		daylightLength = sunsetTime - sunriseTime;
		nightLength = sunriseTime + (GameManager.instance.getDayLength() - sunsetTime);
	}

	public override void OnTick(float currentTime) {
		float progress = -1f;
		bool isNight = true;
		// pre-dawn
		if(currentTime < sunriseTime) {
			progress = (currentTime + (GameManager.instance.getDayLength() - sunsetTime)) / nightLength;
		} // during the day 
		else if (currentTime < sunsetTime) {
			progress = (currentTime - sunriseTime) / daylightLength;
			isNight = false;
		} // post-sunset
		else 
			progress = (currentTime - sunsetTime) / nightLength;
		

		LinkedLight.intensity = isNight ? lightIntensity_Night.Evaluate(progress) : lightIntensity_Day.Evaluate(progress);
		LinkedLight.color = isNight ? lightColour_Night.Evaluate(progress) : lightColour_Day.Evaluate(progress);

		LinkedLight.transform.rotation = Quaternion.Euler(progress * 180f, 0f, 0f);
	}
}
