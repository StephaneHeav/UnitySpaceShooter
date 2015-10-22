using UnityEngine;
using System;
using System.Collections;

public abstract class Trajectory {
	public Vector3 posStart;
	protected string saveTrajectoryString;
	
	public abstract void Set (string trajectoryString);
	public abstract Vector3 GetNextPosition (Vector3 currPos, float deltaTime, float speed);
	public abstract Trajectory GetClone();
}