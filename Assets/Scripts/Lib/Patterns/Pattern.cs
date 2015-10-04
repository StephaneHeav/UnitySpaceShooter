using UnityEngine;
using System;
using System.Collections;

public abstract class Pattern {
    public Vector3 posStart;
	
	public abstract void Set (string patternString);
	public abstract Vector3 GetNextPosition (Vector3 currPos, float deltaTime, float speed);
	public abstract Pattern GetClone();
}