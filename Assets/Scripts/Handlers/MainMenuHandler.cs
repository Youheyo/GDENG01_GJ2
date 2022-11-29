using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void playBtn() {
	SceneManager.LoadScene("Game");
    }

    public void quitBtn() {
	Application.Quit();
    }
}
