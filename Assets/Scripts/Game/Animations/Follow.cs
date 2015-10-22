using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	public string targetGameTag;
	public Vector3 addValue = new Vector3(0, 0 ,0);

	private GameObject target;

	void Start () {
		target = (GameObject.FindGameObjectsWithTag(targetGameTag))[0];
	}

	void LateUpdate () {
		if (target != null) {
			transform.position = target.transform.position + addValue;
		}
	}
}
