using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager sharedInstance = null;
	public static GameManager instance {
		get {
			if(sharedInstance == null) {
				sharedInstance = new GameManager();
			}
			return sharedInstance;
		}
		set {
			sharedInstance = new GameManager();
		}
	}

	// Declare variables here
	[Header("Statistics/Resources")]

	[Header("Player Resources")]
	[SerializeField] private int moneyCountAmt = 0;
	[SerializeField] private int cleanCountAmt = 0;

	[Header("Money Maker Stats")]
	[SerializeField] private float maxPrintSpeed = 60.0f;
	[SerializeField] private int maxPrintAmt = 1;
	[SerializeField] private float maxManualPrintSpeed = 30.0f;
	[SerializeField] private int maxManualPrintAmt = 1;

	[Header("Cleaning Stat")]
	[SerializeField] private float maxCleanLevel = 5.0f;

	[Header("Upgrade Levels")]

	[Header("Money Maker Upgrade Levels")]
	[SerializeField] private int printSpeedLvl = 1;
	[SerializeField] private int printAmtLvl = 1;
	[SerializeField] private int manualPrintSpeedLvl = 1;
	[SerializeField] private int manualPrintAmtLvl = 1;
	
	[Header("Money Maker Upgrade Levels")]
	[SerializeField] private float cleanScoreMultiplier = 1;
	// Declare functions here
	private void Awake() {
		if(GameManager.instance != null) {
			Debug.Log("Game Manager Detected! Deleting new copy");
			Destroy(gameObject);
			return;
		}

		sharedInstance = this;
		DontDestroyOnLoad(gameObject);
	}

	// Only use for debugging purposes or somehow anything that needs to be actively checked
	void Update(){
		if(Input.GetKeyDown(KeyCode.O)) {
			Debug.Log("[DEBUG] - Increase Money");
			moneyCountAmt++;
		}
		if(Input.GetKeyDown(KeyCode.P)) {
			Debug.Log("[DEBUG] - Increase Cleanliness");
			cleanCountAmt++;
		}
	}

	public void startGame() {
		gameObject.GetComponent<TimeHandler>().startTime();
	}

	// Functions related to time
	public void addTime(Time_Base time) {
		gameObject.GetComponent<TimeHandler>().addTime(time);
	}

	public float getDayLength() {
		return gameObject.GetComponent<TimeHandler>().getDayLength();
	}

	// Functions relating to player resources

	public void moneyAdd(int amt) {
		moneyCountAmt += amt;
	}

	public int getMoneyAmt() {
		return moneyCountAmt;
	}

	public void cleanAdd(int amt) {
		cleanCountAmt += (int)(amt * cleanScoreMultiplier);
	}

	public int getCleanAmt() {
		return cleanCountAmt;
	}

	// A bunch of getter functions for money maker

	public float getMaxPSpeed() {
		return maxPrintSpeed;
	}

	public int getMaxPAmt() {
		return maxPrintAmt;
	}

	public float getMaxMPSpeed() {
		return maxManualPrintSpeed;
	}

	public int getMaxMPAmt() {
		return maxManualPrintAmt;
	}

	// A bunch of setter functions for money maker

	public void setMaxPSpeed(float val) {
		maxPrintSpeed = val;
	}

	public void setMaxPAmt(int val) {
		maxPrintAmt = val;
	}

	public void setMaxMPSpeed(float val) {
		maxManualPrintSpeed = val;
	}

	public void setMaxMPAmt(int val) {
		maxManualPrintAmt = val;
	}

	// A bunch of getter functions for money maker

	public int getPSpeedLvl() {
		return printSpeedLvl;
	}

	public int getPAmtLvl() {
		return printAmtLvl;
	}

	public int getMPSpeedLvl() {
		return manualPrintSpeedLvl;
	}

	public int getMPAmtLvl() {
		return manualPrintAmtLvl;
	}

	// A bunch of upgrade functions for money maker

	public bool upgMaxPSpeed() {
		if(printSpeedLvl < 4) {
			printSpeedLvl++;
			return true;
		}
		return false;
	}

	public bool upgMaxPAmt() {
		if(printAmtLvl < 4) {
			printAmtLvl++;
			return true;
		}
		return false;
	}

	public bool upgMaxMPSpeed() {
		if(manualPrintSpeedLvl < 4){
			manualPrintSpeedLvl++;
			return true;
		}
		return false;
	}

	public bool upgMaxMPAmt() {
		if(manualPrintAmtLvl < 4) {
			manualPrintAmtLvl++;
			return true;
		}
		return false;
	}


	public void setMaxCleanLevel(int val)
	{
		maxCleanLevel = val;
	}

	public float getMaxCleanLevel() { 
		return maxCleanLevel;
	}	
	public float getCleanLevel() { 
		return cleanScoreMultiplier;
	}

	public bool upgMaxCleanLevel()
	{
		if(cleanScoreMultiplier < 4)
		{
			cleanScoreMultiplier++;
			return true;
		}
		return false;
	}
}
