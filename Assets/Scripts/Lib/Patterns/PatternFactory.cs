﻿using UnityEngine;
using System.Collections;

public static class PatternFactory {

	public static Manoeuvre SpiralPattern (int nbPoint, int nbTurn, float baseDelay, Vector3 initialPosition) {
		int i = 0;
		float x, z, angle, realAngle;
		string spiralManoeuvreString = "";

		angle = ( 360 / nbPoint ) * ( Mathf.PI / 180 );

		for (; nbTurn > 0; --nbTurn) {
			for (i = 0; i < nbPoint; ++i) {

				realAngle = i * angle;
				x = initialPosition.x + 100 * Mathf.Cos(realAngle);
				z = initialPosition.z + 100 * Mathf.Sin(realAngle);

				spiralManoeuvreString += "TrajectoryLine#("+initialPosition.x+",0,"+initialPosition.z+")("+x+",0,"+z+")="+baseDelay+";";
			}
		}
		spiralManoeuvreString = spiralManoeuvreString.Remove( spiralManoeuvreString.Length - 1);

		return Manoeuvre.Create(spiralManoeuvreString);
	}

	public static Manoeuvre CirclePattern (int nbPoint, int nbTurn, float baseDelay, Vector3 initialPosition) {
		int i = 0;
		float x, z, angle, realAngle;
		string spiralManoeuvreString = "";
		
		angle = ( 360 / nbPoint ) * ( Mathf.PI / 180 );
		
		for (; nbTurn > 0; --nbTurn) {
			for (i = 0; i < nbPoint; ++i) {
				
				realAngle = i * angle;
				x = initialPosition.x + 100 * Mathf.Sin(realAngle);
				z = initialPosition.z + 100 * Mathf.Cos(realAngle);
				
				spiralManoeuvreString += "TrajectoryLine#("+initialPosition.x+",0,"+initialPosition.z+")("+x+",0,"+z+")|";
			}
			spiralManoeuvreString += spiralManoeuvreString.Remove( spiralManoeuvreString.Length - 1) + "=" + baseDelay + ";";
		}
		spiralManoeuvreString = spiralManoeuvreString.Remove( spiralManoeuvreString.Length - 1);
		
		return Manoeuvre.Create(spiralManoeuvreString);
	}
	
	public static Manoeuvre HalfCirclePattern (int nbPoint, int nbTurn, float baseDelay, Vector3 initialPosition, Vector3 direction) {
		return ArcPattern (nbPoint, nbTurn, baseDelay, initialPosition, direction, 180);
	}
	
	public static Manoeuvre QuarterCirclePattern (int nbPoint, int nbTurn, float baseDelay, Vector3 initialPosition, Vector3 direction) {
		return ArcPattern (nbPoint, nbTurn, baseDelay, initialPosition, direction, 90);
	}
	
	public static Manoeuvre ArcPattern (int nbPoint, int nbTurn, float baseDelay, Vector3 initialPosition, Vector3 direction, int wide) {
		int i = 0;
		float x, z, angle, realAngle,
		ratio = 360 / wide,
		xOrigin = initialPosition.x + 100 * Mathf.Sin(0),
		zOrigin = initialPosition.z + 100 * Mathf.Cos(0),
		angleOrigine = Mathf.Atan2(direction.x - xOrigin, direction.z - zOrigin) - ((wide/2)*(Mathf.PI / 180));
		string spiralManoeuvreString = "";
		
		angle = ( 360 / (nbPoint * ratio) ) * ( Mathf.PI / 180 );

		for (; nbTurn > 0; --nbTurn) {
			for (i = 0; i <= nbPoint; ++i) {
				
				realAngle = angleOrigine + i * angle;
				x = initialPosition.x + 100 * Mathf.Sin(realAngle);
				z = initialPosition.z + 100 * Mathf.Cos(realAngle);
				
				spiralManoeuvreString += "TrajectoryLine#("+initialPosition.x+",0,"+initialPosition.z+")("+x+",0,"+z+")|";
			}
			spiralManoeuvreString += spiralManoeuvreString.Remove( spiralManoeuvreString.Length - 1) + "=" + baseDelay + ";";
		}
		spiralManoeuvreString = spiralManoeuvreString.Remove( spiralManoeuvreString.Length - 1);
		
		return Manoeuvre.Create(spiralManoeuvreString);
	}
}
