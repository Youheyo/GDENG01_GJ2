using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMakerInteract : ObjectInteracted
{
	public override void onInteract(){
		gameObject.GetComponent<MoneyMakerScript>().manualEnable();
	}
}
