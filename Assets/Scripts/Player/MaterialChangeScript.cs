using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MaterialChangeScript : ObjectInteracted
{
	[SerializeField] private Texture[] texture;
	public int level = 0;
	Renderer rend;
	public bool isDirty = true;
	private float dirtTimer;
	private float Timer;


    // Start is called before the first frame update
    void Start()
    {
        this.rend = GetComponent<Renderer>();
		this.rend.enabled = true;
		this.rend.material.SetTexture("_DetailAlbedoMap", texture[level]);

		if(this.gameObject.tag != "Interactable")
		{
			this.gameObject.tag = "Cleanable";
		}
		this.dirtTimer = Random.Range(10.0f, 30.0f);
		//Insurance to get texture and avoid setting it over and over again
		if (this.texture.Length == 0)
		{
			this.texture[0] = this.rend.material.GetTexture("_DetailAlbedoMap");
			this.texture[1] = null;
		}

	}

	// Update is called once per frame
	void Update()
    {
		//this.rend.material.SetTexture("_DetailAlbedoMap", texture[level]);
		if (!isDirty)
		{
			Timer += Time.deltaTime;
			if(Timer > dirtTimer)
			{
				Timer = 0;
				this.dirtTimer = Random.Range(20.0f, 60.0f);
				this.applyDirt();
			}
		}
	}

	public override void onClean()
	{
		levelUp();
	}

	public override void applyDirt()
	{
		levelDown();
	}

	public void levelUp()
	{
		if (level < texture.Length)
		{
			this.level++;
			GameManager.instance.cleanAdd(1);
			this.rend.material.SetTexture("_DetailAlbedoMap", texture[level]);
			this.isDirty = false;
			if (this.gameObject.tag != "Interactable") this.gameObject.tag = "Untagged";

		}
	}
	public void levelDown()
	{
		if (level > 0)
		{
			this.level--;
			this.rend.material.SetTexture("_DetailAlbedoMap", texture[0]);
			this.isDirty = true;
			if (this.gameObject.tag != "Interactable") this.gameObject.tag = "Cleanable";
		}
	}
}
