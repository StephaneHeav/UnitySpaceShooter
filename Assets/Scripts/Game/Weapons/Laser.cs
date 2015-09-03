using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	[Header("Laser pieces")]
	public GameObject laserStart;
	public GameObject laserMiddle;
	public float maxLaserDistance = 15f;
	
	private GameObject start;
	private GameObject middle;
	private float startSpriteHeight;

	private BoxCollider boxCollider;

	void Start() {
		startSpriteHeight = laserStart.GetComponent<Renderer> ().bounds.size.z;
		boxCollider = GetComponent<BoxCollider> ();

		InstantiateLaserPart(ref start, laserStart);
		InstantiateLaserPart(ref middle, laserMiddle);
	}

	void Update() {
		float currentLaserDistance = Vector3.Distance(this.transform.position, new Vector3(this.transform.position.x, 0, maxLaserDistance));
		RaycastHit2D hit = RaycastDirection(currentLaserDistance);
		
		if (hit.collider != null) {
			currentLaserDistance = Vector2.Distance(hit.point, this.transform.position);
		}
		
		middle.transform.localScale = new Vector3(middle.transform.localScale.x, currentLaserDistance - startSpriteHeight, middle.transform.localScale.z);
		middle.transform.localPosition = new Vector3 (0f, 0f, (currentLaserDistance / 2f));

		boxCollider.size = new Vector3(boxCollider.size.x, middle.transform.localScale.y, currentLaserDistance);
		boxCollider.center = new Vector3(0f, 0f, (currentLaserDistance/2f));
	}

	void InstantiateLaserPart(ref GameObject part, GameObject laserPart) {
		if (part == null) {
			part = Instantiate<GameObject>(laserPart);
			part.transform.parent = gameObject.transform;
			part.transform.localPosition = Vector2.zero;
			part.transform.localEulerAngles = Vector2.zero;
			part.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
		}
	}

	RaycastHit2D RaycastDirection(float distance) {
		return Physics2D.Raycast(
			this.transform.position,
			this.transform.up,
			distance
			);
	}
}
