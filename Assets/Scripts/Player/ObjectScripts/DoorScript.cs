using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : ObjectInteracted
{
	private bool isOpen = false;
	[SerializeField] Animator animator;
	Material material;

	public override void onInteract()
	{
		if (isOpen)
		{
			isOpen = !isOpen;
			animator.SetBool("isOpen", false);
		}
		else
		{
			isOpen = !isOpen;
			animator.SetBool("isOpen", true);
		}
	}

}
