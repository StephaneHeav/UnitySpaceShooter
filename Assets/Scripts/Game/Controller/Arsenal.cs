using UnityEngine;
using System.Collections;

public class Arsenal : MonoBehaviour {

	public GameObject boltOrange;
	public GameObject boltBlue;
	public GameObject bullet;
	public GameObject bomb;
	public GameObject laser;
	public GameObject shield;

	public float boltOrangeFireRate = 0.05f;
	public float boltBlueFireRate = 0.05f;
	public float bulletFireRate = 2f;
	public float bombFireRate = 5f;

	public GameObject SpecialFire (GameObject owner, int fireType) {
		GameObject gameObjectFire = null;
		
		switch (fireType) {
		case Constants.LASER:
			gameObjectFire = LaserActivate();
			break;
		case Constants.SHIELD:
			gameObjectFire = ShieldActivate();
			break;
		default:
			break;
		}

		return gameObjectFire;
	}

	public GameObject Fire (Transform spawn, int fireType, string ownerTag) {
		GameObject gameObjectFire;
		
		switch (fireType) {
		case Constants.BOLTBLUE:
			gameObjectFire = FireBoltBlue(spawn);
			break;
		case Constants.BOLTORANGE:
			gameObjectFire = FireBoltOrange(spawn);
			break;
		case Constants.BOMB:
			gameObjectFire = FireBomb();
			break;
		case Constants.BULLET:
		default:
			gameObjectFire = FireBullet(spawn);
			break;
		}

		Weapon weaponScript = gameObjectFire.GetComponent<Weapon>();
		weaponScript.SetOwner(ownerTag);

		return gameObjectFire;
	}

	public float GetFireRate (int fireType) {
		float value;
		
		switch (fireType) {
		case Constants.BOLTBLUE:
			value = boltBlueFireRate;
			break;
		case Constants.BULLET:
			value = bulletFireRate;
			break;
		case Constants.BOLTORANGE:
			value = boltOrangeFireRate;
			break;
		case Constants.BOMB:
			value = bombFireRate;
			break;
		default:
			value = boltBlueFireRate;
			break;
		}
		
		return value;
	}

	private GameObject FireBoltOrange (Transform spawn) {
		return (GameObject) Instantiate(boltOrange, spawn.position, spawn.rotation);
	}
	private GameObject FireBoltBlue (Transform spawn) {
		return (GameObject) Instantiate(boltBlue, spawn.position, spawn.rotation);
	}
	private GameObject FireBullet (Transform spawn) {
		return (GameObject) Instantiate(bullet, spawn.position, spawn.rotation);
	}
	private GameObject FireBomb () {
		return (GameObject) Instantiate(bomb, new Vector3(0,0,5), Quaternion.identity);
	}
	private GameObject LaserActivate () {
		return (GameObject) Instantiate(laser, new Vector3(0,0,5), Quaternion.identity);
	}
	private GameObject ShieldActivate () {
		return (GameObject) Instantiate(shield, new Vector3(0,0,5), Quaternion.identity);
	}
}
