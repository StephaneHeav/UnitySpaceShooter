using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public static SetupDifficulty[] difficultyList = new SetupDifficulty[] {
		new SetupDifficulty("Navio Mode", 2, 10f, 2f, 1, "Asteroids speed : \t\t\t\t\t Slow\nAsteroids size : \t\t\t\t\t Big\nTime between waves : \t\t 10 sec\nTime between asteroids : \t Slow\n"),
		new SetupDifficulty("Normal Mode", 1, 5f, 1f, 1, "Asteroids speed : \t\t\t\t\t Normal\nAsteroids size : \t\t\t\t\t Medium\nTime between waves : \t\t 5 sec\nTime between asteroids : \t Normal\n"),
		new SetupDifficulty("Master Mode", 1, 2f, 0.5f, 1, "Asteroids speed : \t\t\t\t\t Normal\nAsteroids size : \t\t\t\t\t Medium\nTime between waves : \t\t 2 sec\nTime between asteroids : \t Fast\n"),
		new SetupDifficulty("God Mode", 0, 0f, 0.25f, 1, "Asteroids speed : \t\t\t\t\t Fast\nAsteroids size : \t\t\t\t\t Small\nTime between waves : \t\t 0 sec\nTime between asteroids : \t Fastest\n"),
		new SetupDifficulty("God X Mode", 0, 0f, 0.25f, 2, "Asteroids speed : \t\t\t\t\t Fast\nAsteroids size : \t\t\t\t\t Small\nTime between waves : \t\t 0 sec\nTime between asteroids : \t Fastest\n"),
		new SetupDifficulty("God XX Mode", 0, 0f, 0.25f, 3, "Asteroids speed : \t\t\t\t\t Fast\nAsteroids size : \t\t\t\t\t Small\nTime between waves : \t\t 0 sec\nTime between asteroids : \t Fastest\n")
	};
	
	public Image gameOverPanel;
	public Image menuPanel;
	public int gameState;
	public bool isMenuManager;
	public InputField  playerName;

	public GameObject[] ships;
	
	private HazardsController hazardsController;
	private MenuController menuController;
	private DataController dataController;
	private UIController uiController;


	void Start () {
		GameObject dataControllerObject = GameObject.FindGameObjectWithTag("DataController");
		dataController = dataControllerObject.GetComponent<DataController> ();

		hazardsController = GetComponent<HazardsController>();
		menuController = GetComponent<MenuController>();
		uiController = GetComponent<UIController>();

		isMenuManager = true;
		gameState = Constants.START;
		Time.timeScale = 0;

		UpdateDifficulty(dataController.GetDifficulty ());
	}
	
	void Update () {
		if (isMenuManager && Input.GetKeyDown(KeyCode.Escape)) {
			switch(gameState) {
			case Constants.PLAY:
				PauseGame();
				break;
			case Constants.PAUSE:
				PlayGame();
				break;
			default:
				break;
			}
		}
		if (isMenuManager && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))) {
			switch(gameState) {
			case Constants.GAMEOVER:
				OverNSubmit ();
				break;
			default:
				break;
			}
		}
	}

	public void StartGame () {
		Instantiate (ships[dataController.GetPlayerShip ()], new Vector3(0,0,0), Quaternion.identity);
		hazardsController.StartHazards();
		PlayGame();
	}

	public void PlayGame () {
		Time.timeScale = 1;
		gameState = Constants.PLAY;
		CloseMenu();
	}
	public void PauseGame () {
		Time.timeScale = 0;
		gameState = Constants.PAUSE;
		OpenMenu();
	}

	public void OpenMenu () {
		menuPanel.gameObject.SetActive(true);
	}
	public void CloseMenu () {
		menuPanel.gameObject.SetActive(false);
	}

	public void UpdateDifficulty (int newDifficulty) {
		dataController.SetDifficulty (newDifficulty);
		hazardsController.SetHazards(difficultyList[newDifficulty]);
		menuController.SetDifficultySlider (newDifficulty);
	}

	public void GameOver () {
		GetComponent<AudioSource>().Play ();
		gameOverPanel.gameObject.SetActive(true);
		gameState = Constants.GAMEOVER;
	}

	public void OverNSubmit () {
		dataController.SetScores (playerName.text, uiController.GetScore ());
		menuController.RetryGame();
	}
}