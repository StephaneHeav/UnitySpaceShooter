using UnityEngine;
using System;
using System.Collections;

public class TrajectoryZigZag : Trajectory {
	private float amplitudeX = 1.0f;
	private float amplitudeZ = 1.0f;
	private Vector3 linearPos;
	private float direction;

	public Vector3 posEnd;

	public override void Set (string trajectoryString) {
		saveTrajectoryString = trajectoryString;
		string[] elements = trajectoryString.Split(')');
		
		elements[0] = elements[0].Substring(1);
		string[] posStartString = elements[0].Split(',');
		posStart = new Vector3( System.Convert.ToSingle(posStartString[0]), System.Convert.ToSingle(posStartString[1]), System.Convert.ToSingle(posStartString[2]));
		linearPos = posStart;

		elements[1] = elements[1].Substring(1);
		string[] posEndString = elements[1].Split(',');
		posEnd = new Vector3( System.Convert.ToSingle(posEndString[0]), System.Convert.ToSingle(posEndString[1]), System.Convert.ToSingle(posEndString[2]));

		elements[2] = elements[2].Substring(1);
		string[] paramString = elements[2].Split(',');
		
		amplitudeX = System.Convert.ToSingle (paramString [0]);
		amplitudeZ = System.Convert.ToSingle (paramString [1]);

		if (System.Convert.ToSingle (paramString [2]) < 0) {
			direction = -1;
		} else {
			direction = 1;

		}
	}
	
	public override Vector3 GetNextPosition (Vector3 currPos, float deltaTime, float speed) {
		float distance;
		Vector2 v;
		linearPos = Vector3.MoveTowards (linearPos, posEnd, deltaTime * speed);

		distance = Vector3.Distance (posStart, linearPos);
		distance = amplitudeX * (float)(Math.Sin (amplitudeZ * distance));

		v = new Vector2 (posStart.x, posStart.z) - new Vector2 (linearPos.x, linearPos.z);
		v = new Vector2 (-v.y, v.x) / (float) Math.Sqrt (Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2)) * distance * direction;

		return linearPos + new Vector3(v.x, 0, v.y);
	}
	
	public override Trajectory GetClone() {
		Trajectory result = new TrajectoryZigZag ();
		result.Set (saveTrajectoryString);
		
		return result;
	}
}