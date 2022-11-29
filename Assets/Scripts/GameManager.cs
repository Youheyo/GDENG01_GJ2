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
	[Header("Player Resources")]
	[SerializeField] private int moneyCountAmt = 0;
	[SerializeField] private int cleanCountAmt = 0;
	
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

	private void moneyAdd(int amt) {
		moneyCountAmt += amt;
	}

	public int getMoneyAmt() {
		return moneyCountAmt;
	}

	private void cleanAdd(int amt) {
		cleanCountAmt += amt;
	}

	public int getCleanAmt() {
		return cleanCountAmt;
	}
}
