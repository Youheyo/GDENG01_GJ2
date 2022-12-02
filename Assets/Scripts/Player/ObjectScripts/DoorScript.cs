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
			this.isOpen = false;
			animator.SetBool("isOpen", false);
		}
		else
		{
			this.isOpen = true;
			animator.SetBool("isOpen", true);
		}
	}

}
