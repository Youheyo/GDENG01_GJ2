using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleScript : MonoBehaviour
{

    [Tooltip("Camera > CameraUI > Reticle")]
    [SerializeField] private new Transform camera;
    [SerializeField] private Image reticle;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    [SerializeField] private Color dirtyColor;

    [Tooltip("Must be same as: GrabScript")]
    [SerializeField] private float maxReach = 20f;

	[SerializeField] GameObject hitObj = null;

    private void Start()
    {

        reticle.color = new Color(96, 109, 96, 1f);
    }

    private void Update()
    {
        RaycastHit hit;
		if (Physics.Raycast(camera.position, camera.forward, out hit, maxReach) &&
			hit.transform.gameObject.CompareTag("Interactable"))
		{
			hitObj = hit.transform.gameObject;

			if (!hit.transform.gameObject.GetComponent<Outline>())
				hit.transform.gameObject.AddComponent<Outline>();
			else if (hit.transform.gameObject.GetComponent<Outline>().OutlineColor != inactiveColor && !Input.GetMouseButton(0))
				hit.transform.gameObject.GetComponent<Outline>().OutlineColor = inactiveColor;


			if (!hit.transform.gameObject.GetComponent<outlinescript>())
				hit.transform.gameObject.AddComponent<outlinescript>();

			if (!hit.transform.gameObject.GetComponent<Outline>().enabled)
				hit.transform.gameObject.GetComponent<Outline>().enabled = true;

			hit.transform.gameObject.GetComponent<Outline>().OutlineWidth = 11f;

			/*
			if (Input.GetMouseButton(0))
			{
				hit.transform.gameObject.GetComponent<Outline>().OutlineColor = activeColor;
			}
			else
			{
			 */
				hit.transform.gameObject.GetComponent<Outline>().OutlineColor = inactiveColor;
			//}
			hit.transform.gameObject.GetComponent<outlinescript>().AssureOutline();

		}
		else if (Physics.Raycast(camera.position, camera.forward, out hit, maxReach) &&
			hit.transform.gameObject.CompareTag("Cleanable"))
		{
			hitObj = hit.transform.gameObject;

			if (!hit.transform.gameObject.GetComponent<Outline>())
				hit.transform.gameObject.AddComponent<Outline>();

			if (!hit.transform.gameObject.GetComponent<outlinescript>())
				hit.transform.gameObject.AddComponent<outlinescript>();

			if (!hit.transform.gameObject.GetComponent<Outline>().enabled)
				hit.transform.gameObject.GetComponent<Outline>().enabled = true;

			hit.transform.gameObject.GetComponent<Outline>().OutlineColor = dirtyColor;

			hit.transform.gameObject.GetComponent<outlinescript>().AssureOutline();
		}
		else
		{

			if (hitObj != null)
			{

				hitObj.transform.gameObject.GetComponent<Outline>().enabled = false;
				reticle.color = new Color(inactiveColor.r, inactiveColor.g, inactiveColor.b, inactiveColor.a);
				hitObj = null;
			}


			//hit.transform.gameObject.GetComponent<Outline>().enabled = false;
			//reticle.color = new Color(inactiveColor.r, inactiveColor.g, inactiveColor.b, inactiveColor.a);
		}
    }
}
