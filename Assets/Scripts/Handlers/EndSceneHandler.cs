using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndSceneHandler : MonoBehaviour
{

	[SerializeField] TMP_Text EndTextResult;
	[SerializeField] TMP_Text EndText;

	private void Awake()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		if (GameManager.instance.checkBadEnd())
		{
			EndTextResult.color = Color.red;
			EndTextResult.fontStyle = FontStyles.Bold;
			EndTextResult.text = " been evicted...";
			EndText.text = "Better luck next time..";
			
		}
		else if (!GameManager.instance.checkBadEnd())
		{
			EndTextResult.color = Color.green;
			EndTextResult.fontStyle = FontStyles.Bold;
			EndTextResult.text = "NOT been evicted";
			EndText.text = "You've managed to keep your home\nCongratulations!";
		}
	}

	public void retryButtonPressed()
	{
		SceneManager.LoadScene("Game");
	}
	public void quitButtonPressed()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
