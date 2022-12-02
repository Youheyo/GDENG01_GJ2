using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
	private GameObject raycastedObj;
	[SerializeField] private int rayLength = 10;
	private GameObject interactedObj;
	[SerializeField] private PlayerUIScript ui;

	[Header("Upgrade Stuff")]
	[SerializeField] private GameObject upgradePanel;
	[SerializeField] private TMP_Text noUpgrades;
	[SerializeField] private GameObject upgradeItem;
	// Very quick fix, not really good coding standards but we'll have to make do.
	private bool raycastOff = false;
	//[SerializeField] private LayerMask layerMaskInteract;
	
	void Awake() {
		ui = gameObject.transform.parent.GetComponent<PlayerUIScript>();

	}

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if(Physics.Raycast(transform.position, fwd, out hit, rayLength) && raycastOff == false)
		{
			if (hit.collider.CompareTag("Interactable"))
			{
				raycastedObj = hit.collider.gameObject;

				if (Input.GetKeyDown(KeyCode.E))
				{
					Debug.Log("Interacted with " + raycastedObj.name);
					//raycastedObj.SetActive(false);
					if(raycastedObj != null)
					raycastedObj.GetComponent<ObjectInteracted>().onInteract();
				}

				if(Input.GetMouseButtonDown(0)) {
					interactedObj = hit.transform.gameObject;
					Debug.Log("Upgrading: " + interactedObj.name);
					if(interactedObj != null) {
						raycastOff = true;
						//ui.upgradeScreen();
						upgradeScreen();
						Upgradeables upgrades = interactedObj.GetComponent<Upgradeables>();
						fillUpgrades(upgrades);
					}
				} 
			}
		}
    }

	void OnDrawGizmosSelected()
	{
		// Draws a 5 unit long red line in front of the object
		Gizmos.color = Color.red;
		Vector3 direction = transform.TransformDirection(Vector3.forward) * rayLength;
		Gizmos.DrawRay(transform.position, direction);
	}

	public void upgradeScreen() {
		upgradePanel.SetActive(!upgradePanel.activeSelf);
		if (upgradePanel.activeSelf)
		{
			Time.timeScale = 0.0f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Time.timeScale = 1.0f;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

		}
	}

	public void closeUpgrade() {
		foreach(Transform child in upgradePanel.transform.Find("upgContainer").transform) {
			Destroy(child.gameObject);
		}
		Time.timeScale = 1.0f;
		upgradePanel.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		raycastOff = false;
	}

	public void fillUpgrades(Upgradeables upg) {
		if(upg.upgrades.Length > 0) {
			//noUpgrades.GetComponent<MeshRenderer>().enabled = false;
			noUpgrades.text = string.Empty;
			foreach(Upgradeables._upgrade _upg in upg.upgrades) {
				var upgItem = Instantiate(upgradeItem, upgradePanel.transform.Find("upgContainer").transform);
				upgItem.transform.Find("upgradeName").GetComponent<TMP_Text>().text = _upg.upgName;
				var upgPriceText = upgItem.transform.Find("upgradePrice").GetComponent<TMP_Text>(); 
				upgPriceText.text = " - " + _upg.upgPrice;
				var button = upgItem.transform.Find("upgradeButton").GetComponent<Button>();
				button.onClick.AddListener(delegate {interactedObj.GetComponent<Upgradeables>().applyUpgrades(_upg, upgPriceText);});
			}
		} else {
			//noUpgrades.GetComponent<MeshRenderer>().enabled = true;
			noUpgrades.text = "No Further Upgrades Available";
		}
	}

	public void applyButton() {
		//Debug.Log("Working");
		//interactedObj.GetComponent<Upgradeables>().applyUpgrades(upgStatVar);
	}

}
