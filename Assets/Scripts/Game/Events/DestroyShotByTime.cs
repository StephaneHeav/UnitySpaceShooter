using UnityEngine;
using System.Collections;

public class DestroyShotByTime : MonoBehaviour {
	public float lifetime = 0.5f;
	
	void Start () {
		Destroy(gameObject, lifetime);
		Invoke("Explode", lifetime);
	}

	void OnDestroy () {
		Shot shot = GetComponent<Shot>();
		Instantiate(shot.explosion, transform.position, transform.rotation);
	}
}
