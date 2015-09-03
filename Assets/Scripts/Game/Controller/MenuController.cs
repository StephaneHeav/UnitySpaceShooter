using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {
	
	public Image optionsPanel;
	public Image scoresPanel;
	public Image difficultyOptionPanel;
	public Image playerShipOptionPanel;
	public Image commandsOptionPanel;
	public Text playerShipOptionPanelTitle;
	public Text playerShipOptionPanelDesc;
	public Slider difficultySlider;
	public Text difficultyTitle;
	public Text difficultyDesc;

	public Button startButton;
	public Button continueButton;
	public Button retryButton;

	private bool isMenuManager;
	private int menuOptionsLevel = 0;

	private List<Image> currentPanel = new List<Image> ();

	private GameController gameController;
	private DataController dataController;

	private ShipInformation[] shipList = new ShipInformation[] {
		new ShipInformation("Attacker", "Faster projectiles. Higher fire rate. Lower Damage. Attack oriented ship with laser as special attack."),
		new ShipInformation("Defender", "Slower projectiles. Lower fire rate. Higher Damage. Defence oriented ship with shield as special attack.")
	};

	void Start () {
		gameController = GetComponent<GameController>();

		GameObject dataControllerObject = GameObject.FindGameObjectWithTag("DataController");
		dataController = dataControllerObject.GetComponent<DataController> ();

		difficultySlider.onValueChanged.AddListener(DifficultyChanged);
		UpdatePlayerShipOption (dataController.GetPlayerShip ());

		isMenuManager = false;
		initGame();
	}

	void Update () {
		if (isMenuManager && Input.GetButtonDown("Cancel")) {
			CloseSubMenu ();
		}
	}

	/**
	 * MAIN MENU
	 */
	public void initGame () {
		startButton.interactable = true;
		continueButton.interactable = false;
		retryButton.interactable = false;
	}
	public void StartGame () {
		startButton.interactable = false;
		continueButton.interactable = true;
		retryButton.interactable = true;

		gameController.StartGame();	
	}
	public void ContinueGame () {
		gameController.PlayGame();
	}
	public void RetryGame () {
		Application.LoadLevel(Application.loadedLevel);
	}
	public void ExitGame () {
		Application.Quit();
	}
	
	public void OpenSubMenu (Image currPan) {

		if (menuOptionsLevel == 0) {
			gameController.CloseMenu ();
			isMenuManager = true;
			gameController.isMenuManager = !isMenuManager;
		} else {
			currentPanel [menuOptionsLevel-1].gameObject.SetActive (false);
		}

		currentPanel.Insert (menuOptionsLevel, currPan);
		currentPanel [menuOptionsLevel].gameObject.SetActive (true);
	}
	public void CloseSubMenu () {
		currentPanel [menuOptionsLevel].gameObject.SetActive (false);
		currentPanel.RemoveAt (menuOptionsLevel);

		
		if (menuOptionsLevel == 0) {
			gameController.OpenMenu();
			isMenuManager = false;
			gameController.isMenuManager = !isMenuManager;
		} else {
			--menuOptionsLevel;
			currentPanel [menuOptionsLevel].gameObject.SetActive (true);
		}
	}

	/**
	 * OPTIONS MENU
	 */
	public void OpenOptionsMenu () {
		OpenSubMenu (optionsPanel);
	}
	// DIFFICULTY
	public void OpenDifficultyOption () {
		++menuOptionsLevel;
		OpenSubMenu (difficultyOptionPanel);
	}
	public void DifficultyChanged (float value) {
		difficultyTitle.text = GameController.difficultyList [(int)value].name;
		difficultyDesc.text = GameController.difficultyList [(int)value].desc;
		gameController.UpdateDifficulty ((int) value);
	}
	public void SetDifficultySlider (int newDifficulty) {
		difficultySlider.value = newDifficulty;
		difficultyTitle.text = GameController.difficultyList [newDifficulty].name;
		difficultyDesc.text = GameController.difficultyList [newDifficulty].desc;
	}
	// PLAYER SHIP
	public void OpenPlayerShipOption () {
		++menuOptionsLevel;
		OpenSubMenu (playerShipOptionPanel);
	}
	public void NextShipOption () {
		UpdatePlayerShipOption ((int) Lib.Modulo((dataController.GetPlayerShip () + 1), Constants.MAXSHIP) );
	}
	public void PreviousShipOption () {
		UpdatePlayerShipOption ((int) Lib.Modulo((dataController.GetPlayerShip () - 1), Constants.MAXSHIP) );
	}
	public void UpdatePlayerShipOption (int newPlayerShip) {
		dataController.SetPlayerShip (newPlayerShip);
		playerShipOptionPanelTitle.text = shipList[newPlayerShip].shipName;
		playerShipOptionPanelDesc.text = shipList[newPlayerShip].shipDesc;
	}
	// COMMANDS - KEY BINDING
	public void OpenCommandsOption () {
		++menuOptionsLevel;
		OpenSubMenu (commandsOptionPanel);
	}

	/**
	 * SCORES MENU
	 */
	public void OpenScoresMenu () {
		OpenSubMenu (scoresPanel);
	}
}
