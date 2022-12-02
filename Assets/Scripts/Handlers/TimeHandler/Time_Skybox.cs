using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Skybox : Time_Base
{
	[SerializeField] float sunriseTime = 6f;
	[SerializeField] float sunsetTime = 18f;

	[SerializeField] Gradient skyTint_Day;
	[SerializeField] Gradient skyTint_Night;
	[SerializeField] AnimationCurve exposure_Day;
	[SerializeField] AnimationCurve exposure_Night;

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
		

		RenderSettings.skybox.SetFloat("_Exposure", isNight ? exposure_Night.Evaluate(progress) : exposure_Day.Evaluate(progress));
		RenderSettings.skybox.SetColor("_SkyTint", isNight ? skyTint_Night.Evaluate(progress) : skyTint_Day.Evaluate(progress));
	}
}
