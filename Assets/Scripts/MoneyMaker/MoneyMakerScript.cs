using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMakerScript : MonoBehaviour
{
	[Header("Money Maker Stats")]
	[SerializeField] private float maxPrintSpeed = 60.0f;
	[SerializeField] private int maxPrintAmt = 1;
	[SerializeField] private float maxManualPrintSpeed = 30.0f;
	[SerializeField] private int maxManualPrintAmt = 1;

	[Header("Money Maker Counters")]
	[SerializeField] private float printSpeed;
	[SerializeField] private float manualPrintSpeed;

	[Header("Money Maker Misc. Variables")]
	private bool isManual = false;
	
	// Start is called before the first frame update
	void Start()
	{
		maxPrintSpeed = GameManager.instance.getMaxPSpeed();
		maxPrintAmt = GameManager.instance.getMaxPAmt();
		maxManualPrintSpeed = GameManager.instance.getMaxMPSpeed();
		maxManualPrintAmt = GameManager.instance.getMaxMPAmt();

		// Initialize Counters
		printSpeed = maxPrintSpeed;
		manualPrintSpeed = maxManualPrintSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		if(printSpeed <= 0.0f) {
			GameManager.instance.moneyAdd(maxPrintAmt);
			printSpeed = maxPrintSpeed;
		}
		if(manualPrintSpeed <= 0.0f) {
			GameManager.instance.moneyAdd(maxManualPrintAmt);
			manualPrintSpeed = maxManualPrintSpeed;
			isManual = false;
		}
		
		printSpeed -= Time.deltaTime;
		if(isManual == true){
			manualPrintSpeed -= Time.deltaTime;
		}
	}

	public void manualEnable(){
		isManual = true;
	}
}
