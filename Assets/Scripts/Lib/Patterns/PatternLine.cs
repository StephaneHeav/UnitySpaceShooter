using UnityEngine;
using System;
using System.Collections;

public class PatternLine : Pattern {
    public Vector3 posEnd;

	public override void Set (string patternString) {
		string[] elements = patternString.Split(')');
		
		elements[0] = elements[0].Substring(1);
		string[] posStartString = elements[0].Split(',');
		posStart = new Vector3( System.Convert.ToSingle(posStartString[0]), System.Convert.ToSingle(posStartString[1]), System.Convert.ToSingle(posStartString[2]));

		elements[1] = elements[1].Substring(1);
		string[] posEndString = elements[1].Split(',');
		posEnd = new Vector3( System.Convert.ToSingle(posEndString[0]), System.Convert.ToSingle(posEndString[1]), System.Convert.ToSingle(posEndString[2]));
	}
	
	public override Vector3 GetNextPosition (Vector3 currPos, float step) {
		return Vector3.MoveTowards (currPos, posEnd, step);
	}
}