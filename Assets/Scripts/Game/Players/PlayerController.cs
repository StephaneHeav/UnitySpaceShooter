using UnityEngine;
using System.Collections;

public class PlayerController : Ship {
	
	private PlayerAction playerAction;
	private GameController gameController;
	private UIController uiController;
	private int numberOfBlink = Constants.MAXNUMBEROFBLINK;
	private MeshRenderer meshRenderer;
	private GameObject playerEngine;
	
	public void Start () {
		playerAction = GetComponent<PlayerAction>();
		playerEngine = GameObject.FindGameObjectWithTag("PlayerEngine");
		
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
		uiController = gameControllerObject.GetComponent<UIController>();
		
		init (3, 1);
		UpdatePlayerInfoUI ();
		
		meshRenderer = GetComponent<MeshRenderer>();
	}
	
	
	/**
	 * Information & UI
	 */
	public void SetBomb (int newBomb) {
		playerAction.SetBomb (newBomb);
		UpdatePlayerInfoUI ();
	}
	public int GetBomb () {
		return playerAction.GetBomb ();
	}
	public void SetEnergy (float newEnergy) {
		playerAction.SetEnergy (newEnergy);
		
		UpdatePlayerInfoUI ();
	}
	public float GetEnergy () {
		return playerAction.GetEnergy ();
	}
	public new void SetLife (int newLife) {
		base.SetLife(newLife);
		UpdatePlayerInfoUI ();
	}
	public void UpdatePlayerInfoUI () {
		uiController.UpdatePlayerInfo (life, playerAction.GetBomb ());
	}
	
	
	/**
	 * Damage
	 */
	public new int IsHitted (int damage) {
		if (state == Constants.ALIVE) {
			Died();
		}
		
		return state;
	}
	private new void Died () {
		base.Died();
		
		if (state == Constants.DEAD) {
			UpdatePlayerInfoUI ();
			gameController.GameOver();
		} else {
			playerAction.fireLevel = 0;
			playerAction.SetEnergy(Constants.ENERGYMAX);
			UpdatePlayerInfoUI ();
			uiController.AddScore(0, 0, true, -5000);
			Respawn();
		}
	}
	
	/**
	 * Respawn
	 */
	private new void Respawn () {
		state = Constants.RESPAWN;
		StartBlinking();
	}
	private void StartBlinking () {
		StartCoroutine(Blinking());
	}
	private void StopBlinking () {
		state = Constants.ALIVE;
		numberOfBlink = Constants.MAXNUMBEROFBLINK;
	}
	IEnumerator Blinking () {
		for (; numberOfBlink >= 0; --numberOfBlink) {
			bool stateOfBlink = ((numberOfBlink%2) == 0);
			meshRenderer.enabled = stateOfBlink;
			playerEngine.SetActive(stateOfBlink);
			yield return new WaitForSeconds(0.1f);
		}
		StopBlinking();
		yield break;
	}

	void OnTriggerEnter (Collider other) {
		switch (other.tag) {
		case "Lore":
			IsHitted(health);
			break;
		default:
			break;
		}
	}
}
