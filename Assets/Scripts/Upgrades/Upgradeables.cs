using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgradeables : MonoBehaviour
{
	/* // Dictionary Approach to stats
	   // Do not delete, might be used later in the future
	[System.Serializable]
	public class _statint {
		[SerializeField] public string statName;
		[SerializeField] public int statVal;
	}

	[SerializeField] public _statint[] statsInt;
	public Dictionary<string,int> statIntDict = new Dictionary<string,int>();

	[System.Serializable]
	public class _statfloat {
		[SerializeField] public string statName;
		[SerializeField] public int statVal;
	}

	[SerializeField] public _statfloat[] statsFloat;
	public Dictionary<string,float> statFloatDict = new Dictionary<string,float>();
	*/

	[System.Serializable]
	public class _upgrade {
		[SerializeField] public string upgName;
		[SerializeField] public int upgPrice;
		[SerializeField] public string upgStatVar;
	}

	[SerializeField] public _upgrade[] upgrades;

	/* // Initializes dictionary
	 * Do not delete, will be used as reference for the future if an implementation
	 * like this is needed.
	public void initDict() {
		if(statsInt.Length > 0){
			foreach(Upgradeables._statint stat in statsInt){
				statIntDict.Add(stat.statName, stat.statVal);
			}
			Debug.Log("Before Dict: " + statIntDict.Count);
		}
		if(statsFloat.Length > 0) {
			foreach(Upgradeables._statfloat stat in statsFloat){
				statFloatDict.Add(stat.statName, stat.statVal);
			}
		}

	}
	*/

	public void test() {
		Debug.Log("Test worked");
	}

	public virtual void applyUpgrades(Upgradeables._upgrade upg, TMP_Text priceText) {
		Debug.Log("upgVar is: " + upg.upgStatVar);
		Debug.Log("upgPrice is: " + upg.upgPrice);
	}
}
