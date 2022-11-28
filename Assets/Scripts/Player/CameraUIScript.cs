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
    [SerializeField] private GameObject grabPanel;
    [SerializeField] private GameObject throwPanel;
    [SerializeField] private GameObject pushPanel;
    [SerializeField] private GameObject interactPanel;

	[SerializeField] private bool holdingObject = false;

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
            if (lookedObject.transform.CompareTag("Clutchable"))
            {
                grabPanel.SetActive(true);
                throwPanel.SetActive(false);
                pushPanel.SetActive(true);
                interactPanel.SetActive(false);
            }
            if (lookedObject.transform.CompareTag("Interactable"))
            {
                grabPanel.SetActive(false);
                throwPanel.SetActive(false);
                pushPanel.SetActive(false);
                interactPanel.SetActive(true);
            }

        }
        //if not looking at object
        if (lookedObject == null)
        {
            grabPanel.SetActive(false);
            throwPanel.SetActive(false);
            pushPanel.SetActive(false);
            interactPanel.SetActive(false);
        }

        //if grabbing the object
        if (lookedObject != null && Input.GetMouseButton(0))
        {
			holdingObject = true;
        }
		else holdingObject = false;
            if (lookedObject != null && lookedObject.transform.CompareTag("Clutchable") && holdingObject)
            {
                grabPanel.SetActive(false);
                throwPanel.SetActive(true);
                pushPanel.SetActive(false);
                interactPanel.SetActive(false);
            }
    }
}