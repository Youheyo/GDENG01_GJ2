using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyMakerScript : Upgradeables
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

	[Header("Effects")]
	[SerializeField] ParticleSystem particle;
	[SerializeField] private Animator mmAnimator;
	
	// Start is called before the first frame update
	void Start()
	{
		initStats();
		/* // Dictionary approach to stats
		initDict();

		maxPrintAmt = statIntDict["maxPrintAmt"];
		maxManualPrintAmt = statIntDict["maxManualPrintAmt"];
		maxPrintSpeed = statFloatDict["maxPrintSpeed"];
		maxManualPrintSpeed = statFloatDict["maxManualPrintSpeed"];
		*/

		// Initialize Counters
		printSpeed = maxPrintSpeed;
		manualPrintSpeed = maxManualPrintSpeed;
		mmAnimator = GetComponent<Animator>();
	}

	public float getPrintSpeed()
	{
		return printSpeed;
	}
	public float getManualPrintSpeed()
	{
		return manualPrintSpeed;
	}
	public float getMaxPrintSpeed()
	{
		return maxPrintSpeed;
	}
	public float getMaxManualPrintSpeed()
	{
		return maxManualPrintSpeed;
	}

	public void initStats() {
		maxPrintSpeed = GameManager.instance.getMaxPSpeed();
		maxPrintAmt = GameManager.instance.getMaxPAmt();
		maxManualPrintSpeed = GameManager.instance.getMaxMPSpeed();
		maxManualPrintAmt = GameManager.instance.getMaxMPAmt();
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
			particle.Play();
			mmAnimator.SetTrigger("manual");
		}
		
		printSpeed -= Time.deltaTime;
		if(isManual == true){
			manualPrintSpeed -= Time.deltaTime;
		}
	}

	public void manualEnable(){
		isManual = true;
	}

 	public override void applyUpgrades(Upgradeables._upgrade upg, TMP_Text priceText) {
		if(GameManager.instance.getMoneyAmt() >= upg.upgPrice) {
			bool upgStatus = false;
			switch(upg.upgStatVar) {
			case "maxPrintSpeed":
				upgStatus = GameManager.instance.upgMaxPSpeed();
				break;
			case "maxPrintAmt":
				upgStatus = GameManager.instance.upgMaxPAmt();
				break;
			case "maxManualPrintSpeed":
				upgStatus = GameManager.instance.upgMaxMPSpeed();
				break;
			case "maxManualPrintAmt":
				upgStatus = GameManager.instance.upgMaxMPAmt();
				break;
			default:
				Debug.Log("Upgrade failed");
				break;
			}

			if(upgStatus != false) {
				GameManager.instance.moneyAdd(-upg.upgPrice);
				updateStats();

				upg.upgPrice = (int)(upg.upgPrice * 1.5f);
				priceText.text = " - " + upg.upgPrice;
			} else {
				Debug.Log("No more upgrades");
			}
		} else {
			Debug.Log("Not enough money");
		}
	}

	// This could probably be done on GameManager instead, but probably be an example for other object upgrades instead
	public void updateStats() {
		int upgLvl = 0;
	
		upgLvl = GameManager.instance.getPSpeedLvl();
		switch(upgLvl) {
			case 1:
				GameManager.instance.setMaxPSpeed(60.0f);
				break;
			case 2:
				GameManager.instance.setMaxPSpeed(50.0f);
				break;
			case 3:
				GameManager.instance.setMaxPSpeed(40.0f);
				break;
			case 4:
				GameManager.instance.setMaxPSpeed(30.0f);
				break;
			default:
				Debug.Log("Stat Update Failed");
				break;
		}
	
		upgLvl = GameManager.instance.getPAmtLvl();
		switch(upgLvl) {
			case 1:
				GameManager.instance.setMaxPAmt(1);
				break;
			case 2:
				GameManager.instance.setMaxPAmt(2);
				break;
			case 3:
				GameManager.instance.setMaxPAmt(4);
				break;
			case 4:
				GameManager.instance.setMaxPAmt(6);
				break;
			default:
				Debug.Log("Stat Update Failed");
				break;
		}
	
		upgLvl = GameManager.instance.getMPSpeedLvl();
		switch(upgLvl) {
			case 1:
				GameManager.instance.setMaxMPSpeed(30.0f);
				break;
			case 2:
				GameManager.instance.setMaxMPSpeed(25.0f);
				break;
			case 3:
				GameManager.instance.setMaxMPSpeed(20.0f);
				break;
			case 4:
				GameManager.instance.setMaxMPSpeed(15.0f);
				break;
			default:
				Debug.Log("Stat Update Failed");
				break;
		}
	
		upgLvl = GameManager.instance.getMPAmtLvl();
		switch(upgLvl) {
			case 1:
				GameManager.instance.setMaxMPAmt(1);
				break;
			case 2:
				GameManager.instance.setMaxMPAmt(3);
				break;
			case 3:
				GameManager.instance.setMaxMPAmt(6);
				break;
			case 4:
				GameManager.instance.setMaxMPAmt(10);
				break;
			default:
				Debug.Log("Stat Update Failed");
				break;
		}
		initStats();
	}
}
