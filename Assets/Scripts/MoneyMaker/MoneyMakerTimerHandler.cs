using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMakerTimerHandler : MonoBehaviour
{
	[SerializeField] Image AutoTimerImage;
	[SerializeField] Image ManualTimerImage;
	MoneyMakerScript moneyScript;

	private void Start()
	{
		moneyScript = GetComponent<MoneyMakerScript>();
	}
	// Update is called once per frame
	void Update()
    {
		AutoTimerImage.fillAmount = moneyScript.getPrintSpeed() / moneyScript.getMaxPrintSpeed();
		ManualTimerImage.fillAmount = moneyScript.getManualPrintSpeed() / moneyScript.getMaxManualPrintSpeed() ;
    }
}
