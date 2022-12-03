using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUIScript : MonoBehaviour
{
    private RaycastHit hit;

    private GameObject lookedObject;

    [Tooltip("(Camera)")]
    [SerializeField] private new Transform camera;

    [Tooltip("Must be same as: ReticleScript")]
    [SerializeField] private float maxReach = 20f;

    [Space(10)]
    [Header("Action Panels")]
    [SerializeField] private GameObject cleanPanel;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject interactPanel;

    // Update is called once per frame
    void Update()
    {
        //Looked
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxReach)) //&&
            //hit.transform.GetComponent<Rigidbody>() &&
            //hit.transform.gameObject.CompareTag("Clutchable") || hit.transform.gameObject.CompareTag("Interactable"))
        {
            //lookedObject = null;
            lookedObject = hit.transform.gameObject;
        }
        //Away
        else
        {
            lookedObject = null;
        }

        //if looking at object
        if (lookedObject != null)
        {
			if (lookedObject.transform.CompareTag("Interactable") && lookedObject.name =="MoneyMaker")
            {
                cleanPanel.SetActive(false);
                upgradePanel.SetActive(true);
                interactPanel.SetActive(true);
            }
			else if (lookedObject.transform.CompareTag("Interactable") && lookedObject.name =="PlayerUpgrade")
            {
                cleanPanel.SetActive(false);
                upgradePanel.SetActive(true);
                interactPanel.SetActive(false);
            }
            else if (lookedObject.transform.CompareTag("Interactable"))
            {
                cleanPanel.SetActive(false);
                upgradePanel.SetActive(false);
                interactPanel.SetActive(true);
            }
			if (lookedObject.transform.CompareTag("Cleanable"))
            {
                cleanPanel.SetActive(true);
                upgradePanel.SetActive(false);
                interactPanel.SetActive(false);
            }


        }
        //if not looking at object
        if (lookedObject == null)
        {
            cleanPanel.SetActive(false);
            upgradePanel.SetActive(false);
            interactPanel.SetActive(false);
        }
    }
}
