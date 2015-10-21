using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public int Damage = 1;
	protected string owner;
	
	
	public void SetOwner (string newOwner) {
		owner = newOwner;
	}
	public string GetOwner () {
		return owner;
	}
}
