using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteracted : MonoBehaviour
{

	[SerializeField] private GameObject affectedObject;
	[SerializeField] private string objName;

	public void onInteract() {

	}

	void Awake()
	{
		if(objName.Length <= 0) {
			objName = this.name;
		}
	}

	private void OnDestroy()
	{
	// Either replace with RemoveAllObserver (or whatever that sounded familiar with it
	// or refactor so that observers could be removed properly.
	//EventBroadcaster.Instance.RemoveAllObservers();
	}
	
	private void disableAffectedObject()
	{
		affectedObject.SetActive(!affectedObject.activeSelf);
	}
}
