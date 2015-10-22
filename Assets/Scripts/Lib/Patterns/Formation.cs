using UnityEngine;
using System;
using System.Reflection;
using System.Collections;

public class Formation {
    public Trajectory[] formation;
    public float timer;

    public Formation Create (string formationString) {
        Formation retValue = new Formation();

        string[] elements = formationString.Split('=');
        string[] trajectoriesString = elements[0].Split('|');
        string[] trajectoryString = null;
		int i = trajectoriesString.Length - 1;

		retValue.formation = new Trajectory[trajectoriesString.Length];
        retValue.timer = System.Convert.ToSingle(elements[1]);

        for (; i >= 0; --i) {
			trajectoryString = trajectoriesString[i].Split('#');
			retValue.formation[i] = (Trajectory) Activator.CreateInstance(Type.GetType(trajectoryString[0]));
			retValue.formation[i].Set(trajectoryString[1]);
        }

        return retValue;
    }
}