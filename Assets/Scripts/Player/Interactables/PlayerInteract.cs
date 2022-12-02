using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
	private GameObject raycastedObj;
	[SerializeField] private int rayLength = 10;
	public Texture dirtTexture;
	GameManager gameManager;
	[SerializeField] ParticleSystem cleanParticleEffect;
	[SerializeField] GameObject HammerObject;
	//[SerializeField] private LayerMask layerMaskInteract;

	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update()
    {
        RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if(Physics.Raycast(transform.position, fwd, out hit, rayLength))
		{
				raycastedObj = hit.collider.gameObject;

				if (Input.GetKeyDown(KeyCode.E))
				{
					Debug.Log("Interacted with " + raycastedObj.name);
					//raycastedObj.SetActive(false);
					if(raycastedObj != null)
					raycastedObj.GetComponent<ObjectInteracted>().onInteract();
				}

			//Clean Button
			if (Input.GetKeyDown(KeyCode.F))
			{
				//raycastedObj.SetActive(false);
				
				if (raycastedObj != null)
					raycastedObj.GetComponent<ObjectInteracted>().onClean();

					cleanParticleEffect.transform.position = hit.transform.position;
					cleanParticleEffect.Play();

					HammerObject.GetComponent<Animator>().SetTrigger("isCleaning");
					HammerObject.transform.position = hit.transform.position + new Vector3(0.0f,2.0f,0.0f);
				 
				/*
				if(raycastedObj.GetComponent<Renderer>().material.GetTexture("_DetailAlbedoMap") != null)
				{
					Debug.Log("Cleaning " + raycastedObj.name);
					raycastedObj.GetComponent<Renderer>().material.SetTexture("_DetailAlbedoMap", null);
					gameManager.cleanAdd(1);

				}
				else 
					Debug.Log($"{raycastedObj.name} is already clean!");
				 */
			}

			//Put Dirt on object
			if (Input.GetKeyDown(KeyCode.V))
			{
				Debug.Log("Applying Dirt on " + raycastedObj.name);
				//raycastedObj.GetComponent<Renderer>().material.SetTexture("_DetailAlbedoMap", dirtTexture);
				raycastedObj.GetComponent<ObjectInteracted>().applyDirt();
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
}
