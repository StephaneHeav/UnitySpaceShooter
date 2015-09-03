using UnityEngine;
using System;
using System.Reflection;
using System.Collections;

public class Formation {
    public Pattern[] formation;
    public float timer;

    public Formation Create (string formationString) {
        Formation retValue = new Formation();

        string[] elements = formationString.Split('=');
        string[] patternsString = elements[0].Split('|');
        string[] patternString = null;
		int i = patternsString.Length - 1;

        retValue.formation = new Pattern[patternsString.Length];
        retValue.timer = System.Convert.ToSingle(elements[1]);

        for (; i >= 0; --i) {
            patternString = patternsString[i].Split('#');
			retValue.formation[i] = (Pattern) Activator.CreateInstance(Type.GetType(patternString[0]));
			retValue.formation[i].Set(patternString[1]);
        }

        return retValue;
    }
}