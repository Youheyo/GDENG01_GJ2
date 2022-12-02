using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeScript : ObjectInteracted
{
	[SerializeField] private Texture[] texture;
	[SerializeField] private int cleanScore;
	public int level = 0;
	Renderer rend;
	GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        this.rend = GetComponent<Renderer>();
		this.rend.enabled = true;
		this.rend.material.SetTexture("_DetailAlbedoMap", texture[level]);
		gameManager = FindObjectOfType<GameManager>();
		//this.rend.sharedMaterial = material[level];
	}

	// Update is called once per frame
	void Update()
    {
		//this.rend.material.SetTexture("_DetailAlbedoMap", texture[level]);
	}

	public override void onClean()
	{
		levelUp();
		this.rend.material.SetTexture("_DetailAlbedoMap", texture[level]);
	}

	public override void applyDirt()
	{
		levelDown();
		this.rend.material.SetTexture("_DetailAlbedoMap", texture[0]);
	}

	public void levelUp()
	{
		if (level < texture.Length)
		{
			this.level++;
			if(cleanScore > 0) gameManager.cleanAdd(cleanScore);
			else gameManager.cleanAdd(1);
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
