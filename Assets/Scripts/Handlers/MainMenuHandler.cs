using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{

	public GameObject HelpPanel;

    public void playBtn() {
	SceneManager.LoadScene("Game");
    }

	public void helpBtn()
	{
		HelpPanel.SetActive(true);
	}
	public void exitHelpPanel()
	{
		HelpPanel.SetActive(false);
	}

    public void quitBtn() {
	Application.Quit();
    }
}
