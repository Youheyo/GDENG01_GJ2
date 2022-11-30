using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
	private GameObject raycastedObj;
	[SerializeField] private int rayLength = 10;
	//[SerializeField] private LayerMask layerMaskInteract;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if(Physics.Raycast(transform.position, fwd, out hit, rayLength))
		{
			//if (hit.collider.CompareTag("Interactable"))
			//{
				raycastedObj = hit.collider.gameObject;

				if (Input.GetKeyDown(KeyCode.E))
				{
					Debug.Log("Interacted with " + raycastedObj.name);
					//raycastedObj.SetActive(false);
					if(raycastedObj != null)
					raycastedObj.GetComponent<ObjectInteracted>().onInteract();
				}
			if (Input.GetKeyDown(KeyCode.F))
			{
				Debug.Log("Cleaning " + raycastedObj.name);
				//raycastedObj.SetActive(false);
				/*
				if (raycastedObj != null)
					raycastedObj.GetComponent<ObjectInteracted>().onClean();
				 */
				raycastedObj.GetComponent<Renderer>().material.SetTexture("_DetailAlbedoMap", null);
			}
			//}
		}
    }

	void OnDrawGizmosSelected()
	{
		// Draws a 5 unit long red line in front of the object
		Gizmos.color = Color.red;
		Vector3 direction = transform.TransformDirection(Vector3.forward) * rayLength;
		Gizmos.DrawRay(transform.position, direction);
	}
}
