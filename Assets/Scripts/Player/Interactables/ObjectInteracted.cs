using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteracted : MonoBehaviour
{

	[SerializeField] private string objName;

	public void onInteract() {
		if(objName == "MoneyMaker") {
			gameObject.GetComponent<MoneyMakerScript>().interacted();
		}
	}

	void Awake()
	{
		if(objName.Length <= 0) {
			objName = this.name;
		}
	}

	private void OnDestroy()
	{
	}
}
