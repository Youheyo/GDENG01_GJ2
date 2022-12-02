using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneHandler : MonoBehaviour
{
	[SerializeField] private GameObject timeObj;
	[SerializeField] private GameObject lightTimeObj;
	[SerializeField] private Time_Base skyboxObj;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.startGame();
	// Adding time
	// Player Time/Clock
	var time = timeObj.GetComponent<Time_Base>();
	GameManager.instance.addTime(time);
	// Directional Light Time
	time = lightTimeObj.GetComponent<Time_Base>();
	GameManager.instance.addTime(time);
	// Skybox Light Time
	time = skyboxObj;
	GameManager.instance.addTime(time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
