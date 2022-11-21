using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightScript : MonoBehaviour
{
    private bool flashlightState;
    private bool onCooldown;

    [SerializeField] private Color flashlightColor;
    //[SerializeField] private Sprite flashlightOnSprite;
    //[SerializeField] private Sprite flashlightOffSprite;
    //[SerializeField] private Image flashlightIndicator;
    [SerializeField] private GameObject flashlightObject;
    //[SerializeField] private AudioSource flashlightOn;
    //[SerializeField] private AudioSource flashlightOff;

    // Start is called before the first frame update
    void Start()
    {
        this.flashlightState = false;
        this.onCooldown = false;
        this.flashlightObject.GetComponent<Light>().color = flashlightColor;
        //this.flashlightIndicator.sprite = flashlightOffSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && this.onCooldown == false)
        {
            this.onCooldown = true;
            flashlightState = !flashlightState;
            Debug.Log(flashlightState);
            flashlightObject.SetActive(flashlightState);

            //if (flashlightState == false)
            //{
            //    flashlightOff.Play();
            //    this.flashlightIndicator.sprite = flashlightOffSprite;
            //}

            StartCoroutine(FlashlightCooldown());

            //if (flashlightState == true)
            //{
            //    flashlightOn.Play();
            //    this.flashlightIndicator.sprite = flashlightOnSprite;
            //}

        }
    }

    IEnumerator FlashlightCooldown()
    {
        yield return new WaitForSeconds(1f);
        this.onCooldown = false;
    }
}