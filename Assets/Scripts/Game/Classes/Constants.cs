using UnityEngine;
using System.Collections;

public static class Constants {
	public const int BOLTORANGE = 1;
	public const int BOLTBLUE = 2;
	public const int BULLET = 3;
	public const int BOMB = 4;
	public const int LASER = 5;
	public const int SHIELD = 6;
	
	public const int minRangeArsenal = 1;
	public const int maxRangeArsenal = 3;
	
	public const int DEAD = 0;
	public const int ALIVE = 1;
	public const int RESPAWN = -1;
	public const int IMMORTAL = 2;
	public const int MAXNUMBEROFBLINK = 19;
	
	public const int START = -1;
	public const int GAMEOVER = 0;
	public const int PLAY = 1;
	public const int PAUSE = 2;

	public const float ENERGYMAX = 100;
	public const float STEPMINENERGYTOFIRE = 20;
	
	public const int DIFFICULTYNAVIO = 0;
	public const int DIFFICULTYNORMAL = 1;
	public const int DIFFICULTYMASTER = 2;
	public const int DIFFICULTYGOD = 3;
	
	public const int SHIP1 = 0;
	public const int SHIP2 = 1;
	public const int MAXSHIP = 2;

	public const int INDEXSCORETLORES = 0;
	public const int INDEXSCORETSHOT = 1;
	public const int INDEXSCORETENEMIES = 2;
	public const int INDEXSCORETSPECIALFORCE = 3;
	public const int INDEXSCORETBOSSES = 4;
	public const int INDEXSCORESSHOT = 0;
	public const int INDEXSCORESBOMB = 1;
	public const int INDEXSCORESSW = 2;
	
	public const string KEYMAINATTACK = "Primary Attack";
	public const string KEYALTATTACK = "Secondary Attack";
	public const string KEYBOMB = "Bomb";
	public const string KEYSWITCH = "Switch";
	public const string KEYUP = "Up";
	public const string KEYDOWN = "Down";
	public const string KEYLEFT = "Left";
	public const string KEYRIGHT = "Right";
	
	public const string KEYDATAPLAYER = "PlayerShip";
	public const string KEYDATADIFFICULTY = "Difficulty";
	public const string KEYDATASCOREV = "ScoreValue";
	public const string KEYDATASCOREN = "ScoreName";
}


[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}
[System.Serializable]
public class InputManager {
	public string keyName;
	public string key;
	
	public InputManager (string newKey, string newKeyName) {
		key = newKey;
		keyName = newKeyName;
	}
}
public class ShipInformation {
	public string shipName;
	public string shipDesc;
	
	public ShipInformation (string name, string desc) {
		shipName = name;
		shipDesc = desc;
	}
}
public class SetupDifficulty {
	public string name;
	public int indexAsteroids;
	public float waitBtwWave;
	public float coefWaitFormation;
	public int coefScore;
	public string desc;
	
	public SetupDifficulty (string newName, int newIndexAsteroids, float newWaitBtwWave, float newCoefWaitFormation, int newCoefScore, string newDesc) {
		name = newName;
		indexAsteroids = newIndexAsteroids;
		waitBtwWave = newWaitBtwWave;
		coefWaitFormation = newCoefWaitFormation;
		coefScore = newCoefScore;
		desc = newDesc;
	}
}
public class ScoreObject {
	public string playerName;
	public int score;
	
	public ScoreObject (string name, int newScore) {
		playerName = name;
		score = newScore;
	}
}