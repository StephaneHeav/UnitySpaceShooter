using UnityEngine;
using System.Collections;

public class AttractTo : MonoBehaviour {
	public string targetGameTag;

	public float range = 5f;
	public Vector3 limit;

	private GameObject target;

	void Start () {
		GameObject[] targets = GameObject.FindGameObjectsWithTag (targetGameTag);
		if (targets.Length > 0) {
			target = (GameObject.FindGameObjectsWithTag (targetGameTag)) [0];
		}
	}

	void Update () {
		if (target != null && (Vector3.Distance (transform.position, target.transform.position) <= range || target.transform.position.z >= limit.z)) {
			float step = 20 * Time.deltaTime;

			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
		}
	}
}
