using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    private RaycastHit hit;

    private GameObject grabbedObject;

    [Tooltip("(Player)")]
    [SerializeField] private Transform player;

    [Tooltip("(Camera)")]
    [SerializeField] private new Transform camera;

    [Tooltip("(Camera > GrabPos)")]
    [SerializeField] private Transform grabPos;

    [Tooltip("Must be same as: ReticleScript")]
    [SerializeField] private float maxReach = 20f;

    [Tooltip("Speed of object towards grabPos")]
    [SerializeField] private float followSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            Physics.Raycast(camera.position, camera.forward, out hit, maxReach) &&
            hit.transform.GetComponent<Rigidbody>() &&
            hit.transform.gameObject.CompareTag("Clutchable"))
        {
            grabbedObject = hit.transform.gameObject;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            grabbedObject = null;
        }

        if (grabbedObject)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity =
                (20 / grabbedObject.GetComponent<Rigidbody>().mass) * (grabPos.position - grabbedObject.transform.position);
            grabbedObject.GetComponent<Rigidbody>().freezeRotation = true;
        }

        //Throw Grabbed Object
        if (grabbedObject && Input.GetMouseButtonDown(1))
        {
            grabbedObject.GetComponent<Rigidbody>().AddForce(camera.forward * 600);
            grabbedObject.GetComponent<Rigidbody>().freezeRotation = false;
            grabbedObject = null;
        }

        //Push object
        if (grabbedObject == null && Input.GetMouseButtonDown(1) &&
            Physics.Raycast(camera.position, camera.forward, out hit, maxReach) &&
            hit.transform.GetComponent<Rigidbody>() &&
            hit.transform.gameObject.CompareTag("Clutchable"))
        {
            hit.transform.GetComponent<Rigidbody>().AddForce(camera.forward * 10, ForceMode.Impulse);
        }
    }
}