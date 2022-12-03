using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUIScript : MonoBehaviour
{
	[SerializeField] private TMP_Text moneyText;
	[SerializeField] private TMP_Text cleanText;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject upgradePanel;
	[SerializeField] private GameObject timeObj;

	private int moneyCount = 0;
	private int cleanCount = 0;

	void Awake() {
		resumeGame();

	}

	private void OnDestroy() {

	}

	// Start is called before the first frame update
	void Start()
	{
		// Adds the time to the TimeHandler
		//var time = timeObj.GetComponent<Time_Base>();
		//GameManager.instance.addTime(time);
	}

	// Update is called once per frame
	void Update()
	{
		moneyCount = GameManager.instance.getMoneyAmt();
		moneyText.text = "Money: " + moneyCount.ToString();
		cleanCount = GameManager.instance.getCleanAmt();
		cleanText.text = "Cleanliness: " + cleanCount.ToString();
		if (Input.GetButtonDown("Cancel"))
		{
			pauseScreen();
		}
	}

	public void pauseScreen()
	{
		pausePanel.SetActive(!pausePanel.activeSelf);
		if (pausePanel.activeSelf)
		{
			Time.timeScale = 0.0f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Time.timeScale = 1.0f;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

		}
	}

	public void upgradeScreen() {
		upgradePanel.SetActive(!upgradePanel.activeSelf);
		if (upgradePanel.activeSelf)
		{
			Time.timeScale = 0.0f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Time.timeScale = 1.0f;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

		}
	}

	public void closeUpgrade() {
		Time.timeScale = 1.0f;
		upgradePanel.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void resumeGame()
	{
		Time.timeScale = 1.0f;
		pausePanel.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void GoToMainMenu()
	{
		GameManager.instance.endGame();
		SceneManager.LoadScene("MainMenu");
	}
}
