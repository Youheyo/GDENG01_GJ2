using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeScript : ObjectInteracted
{
	[SerializeField] private Texture[] texture;
	public int level = 0;
	Renderer rend;
	GameManager gameManager;
	public bool isDirty = true;
	private float dirtTimer;
	private float Timer;


    // Start is called before the first frame update
    void Start()
    {
		gameManager = FindObjectOfType<GameManager>();

        this.rend = GetComponent<Renderer>();
		this.rend.enabled = true;
		this.rend.material.SetTexture("_DetailAlbedoMap", texture[level]);

		this.gameObject.tag = "Cleanable";
		this.dirtTimer = Random.Range(10.0f, 30.0f);

		//Insurance to get texture and avoid setting it over and over again
		if (this.texture[0] == null) {
			this.texture[0] = this.rend.material.GetTexture("_DetailAlbedoMap");
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
				this.dirtTimer = Random.Range(10.0f, 30.0f);
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
			gameManager.cleanAdd(1);
			this.rend.material.SetTexture("_DetailAlbedoMap", texture[level]);
			this.isDirty = false;
			this.gameObject.tag = "Untagged";

		}
	}
	public void levelDown()
	{
		if (level > 0)
		{
			this.level--;
			this.rend.material.SetTexture("_DetailAlbedoMap", texture[0]);
			this.isDirty = true;
			this.gameObject.tag = "Cleanable";
		}
	}
}
