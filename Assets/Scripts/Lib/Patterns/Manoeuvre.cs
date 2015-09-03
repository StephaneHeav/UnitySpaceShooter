using UnityEngine;
using System;
using System.Collections;

public class Manoeuvre {
    public Formation[] manoeuvre;
	
	private float timeToSpend = 0f;
    private int lastFormation;

    public static Manoeuvre Create (string manoeuvreString) {
        Manoeuvre retValue = new Manoeuvre();
        string[] slots = manoeuvreString.Split(';');
        int i = slots.Length - 1;
		retValue.timeToSpend = 0f;

        retValue.manoeuvre = new Formation[slots.Length];

        for (; i >= 0; --i) {
            retValue.manoeuvre[i] = new Formation().Create(slots[i]);
			retValue.timeToSpend += retValue.manoeuvre[i].timer;
        }

        return retValue;
    }

	public float StartManoeuvre () {
        lastFormation = 0;

		return timeToSpend;
    }

    public Formation GetNextFormation () {
		Formation nextForm = null;

		if (lastFormation < manoeuvre.Length) {
			nextForm = manoeuvre[lastFormation];
			++lastFormation;
		}

		return nextForm;
    }
}
