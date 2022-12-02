using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUpgradeScript : Upgradeables
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void applyUpgrades(_upgrade upg, TMP_Text priceText) {
		if(GameManager.instance.getMoneyAmt() >= upg.upgPrice) {
			bool upgStatus = false;
			switch(upg.upgStatVar) {
			case "maxCleanLevel":
				upgStatus = GameManager.instance.upgMaxCleanLvl();
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

	public void updateStats() {
		int upgLvl = 0;
	
		upgLvl = GameManager.instance.getMaxCleanLvl();
		switch(upgLvl) {
			case 1:
				GameManager.instance.setCleanLevel(1);
				break;
			case 2:
				GameManager.instance.setCleanLevel(2);
				break;
			case 3:
				GameManager.instance.setCleanLevel(4);
				break;
			case 4:
				GameManager.instance.setCleanLevel(6);
				break;
			default:
				Debug.Log("Stat Update Failed");
				break;
		}

	}
}
