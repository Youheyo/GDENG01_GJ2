using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeScript : ObjectInteracted
{
	[SerializeField] private Texture[] texture;
	public int level = 0;
	Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        this.rend = GetComponent<Renderer>();
		this.rend.enabled = true;
		//this.rend.sharedMaterial = material[level];
    }

    // Update is called once per frame
    void Update()
    {
		//this.rend.sharedMaterial = material[level];
    }

	public override void onClean()
	{
		levelUp();
	}

	public void levelUp()
	{
		if (level < texture.Length)
		{
			this.level++;
			this.rend.material.SetTexture("_DetailAlbedoMap", texture[level]);
		}
	}
	public void levelDown()
	{
		if (level > 0)
		{
			this.level--;
		}
	}
}
