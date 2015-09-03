using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
	
	public Transform mainShotSpawn;
	public Transform[] shotSpawnLeft;
	public Transform[] shotSpawnRight;

	public int fireLevel = 0;
	
	public int fireType;
	public int fireSpecialType;

	private float fireRate;
	private float nextFire;

	private float fireBombRate;
	private float nextBombFire;

	private int bomb = 3;
	private float energy = Constants.ENERGYMAX;
	private float amountEnergy = 0;
	private bool isFocus = false;
	private float regenRate = 1f;
	private float nextRegen = 1f;
	private int numberOfSpawn = 0;
	private int zPosition = 15;
	
	private Arsenal arsenal;
	private UIController uiController;
	private DataController dataController;
	private PlayerController playerController;

	private GameObject specialShot = null;
	private SpecialWeapon swScript;

	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		arsenal = gameControllerObject.GetComponent<Arsenal>();
		uiController = gameControllerObject.GetComponent<UIController>();
		GameObject dataControllerObject = GameObject.FindGameObjectWithTag("DataController");
		dataController = dataControllerObject.GetComponent<DataController> ();

		playerController = GetComponent<PlayerController>();
		
		fireRate = arsenal.GetFireRate (fireType);
		fireBombRate = arsenal.GetFireRate (Constants.BOMB);

		numberOfSpawn = shotSpawnLeft.Length - 1;
	}

	void Update () {
		if (Time.timeScale == 1) {
			int i = fireLevel - 1;
			i = (i > numberOfSpawn) ? numberOfSpawn : i;

			if (Input.GetKey(dataController.GetKeyInput(Constants.KEYMAINATTACK))) {
				if (!isFocus && Time.time > nextFire) {
					nextFire = Time.time + fireRate;
					
					arsenal.Fire (mainShotSpawn, fireType, gameObject.tag);
					
					for (; i>= 0; --i) {
						shotSpawnLeft[i].rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
						shotSpawnRight[i].rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
						
						arsenal.Fire (shotSpawnLeft[i], fireType, gameObject.tag);
						arsenal.Fire (shotSpawnRight[i], fireType, gameObject.tag);
					}
				} else if (isFocus && energy - 4 > 0 && Time.time > nextRegen) {
					amountEnergy = -10f;
					energy = energy - 10;

					nextRegen = Time.time + regenRate;
					if (specialShot == null) {
						specialShot = arsenal.SpecialFire (gameObject, fireSpecialType);
						swScript = specialShot.GetComponent<SpecialWeapon> ();
					}
					swScript.FillUp ();
				}
			} else if (Input.GetKey(dataController.GetKeyInput(Constants.KEYALTATTACK)) && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				
				int magnitudeX = (isFocus) ? 0 : 5;

				arsenal.Fire (mainShotSpawn, fireType, gameObject.tag);
				
				for (; i>= 0; --i) {
					shotSpawnLeft[i].LookAt(new Vector3(transform.position.x + (-1 * magnitudeX * (i+1)),0,zPosition));
					shotSpawnRight[i].LookAt(new Vector3(transform.position.x + (magnitudeX * (i+1)),0,zPosition));

					arsenal.Fire (shotSpawnLeft[i], fireType, gameObject.tag);
					arsenal.Fire (shotSpawnRight[i], fireType, gameObject.tag);
				}
			}

			if (energy < Constants.ENERGYMAX && Time.time > nextRegen) {
				nextRegen = Time.time + regenRate;
				amountEnergy = 2.5f;
				energy = energy + 2.5f;
			}

			if (energy > Constants.ENERGYMAX) {
				energy = Constants.ENERGYMAX;
			} else if (energy < 0) {
				energy = 0;
			}

			uiController.UpdateEnergy(energy-((nextRegen - Time.time)/regenRate*amountEnergy));
			if (bomb > 0 && Input.GetKey(dataController.GetKeyInput(Constants.KEYBOMB)) && Time.time > nextBombFire) {
				--bomb;
				nextBombFire = Time.time + fireBombRate;
				arsenal.Fire (transform, Constants.BOMB, gameObject.tag);
				playerController.UpdatePlayerInfoUI();
			}

			if (Input.GetKeyDown(dataController.GetKeyInput(Constants.KEYSWITCH))) {
				isFocus = !isFocus;
			}
		}
	}

	public void SetBomb (int newBomb) {
		bomb = newBomb;
	}
	public int GetBomb () {
		return bomb;
	}
	public void SetEnergy (float newEnergy) {
		energy = newEnergy;
		
		if (energy > Constants.ENERGYMAX) {
			energy = Constants.ENERGYMAX;
		}
	}
	public float GetEnergy () {
		return energy;
	}
}
