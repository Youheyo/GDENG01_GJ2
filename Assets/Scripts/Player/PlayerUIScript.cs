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

	private int moneyCount = 0;
	private int cleanCount = 0;

	void Awake() {
		
	}

	private void OnDestroy() {

	}

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		//noteCount = GameManager.Instance.NotesFound();
		//noteCountText.text = "Notes found: " + noteCount.ToString();
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

	public void resumeGame()
	{
		Time.timeScale = 1.0f;
		pausePanel.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}