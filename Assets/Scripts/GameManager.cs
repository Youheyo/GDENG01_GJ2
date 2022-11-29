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

	[Header("Upgrade Levels")]

	[Header("Money Maker Upgrade Levels")]
	[SerializeField] private int printSpeedLvl = 1;
	[SerializeField] private int printAmt = 1;
	[SerializeField] private int manualPrintDelay = 1;
	[SerializeField] private int manualPrintAmt = 1;
	
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

	// Functions relating to player resources

	public void moneyAdd(int amt) {
		moneyCountAmt += amt;
	}

	public int getMoneyAmt() {
		return moneyCountAmt;
	}

	public void cleanAdd(int amt) {
		cleanCountAmt += amt;
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


}
