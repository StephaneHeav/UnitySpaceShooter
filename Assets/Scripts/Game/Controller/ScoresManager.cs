using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoresManager : MonoBehaviour {
	private DataController dataController;
	private GUILayoutOption[] options;
	private GUIStyle style = new GUIStyle();

	void Start () {
		GameObject dataControllerObject = GameObject.FindGameObjectWithTag("DataController");
		dataController = dataControllerObject.GetComponent<DataController> ();

		options = new GUILayoutOption[] {
			GUILayout.Width(250),
			GUILayout.Height(50)
		};

		style.fontSize = 20;
		style.alignment = TextAnchor.MiddleLeft;
		style.normal.textColor = Color.white;
	}

	void OnGUI () {
		GUILayout.BeginArea (new Rect (250,100, 400,300));
		ScoreObject[] scores = dataController.GetScores ();
		int i = 0, len = (int) scores.Length/2;
		string text = "";


		for(; i < len; ++i) {
			GUILayout.BeginHorizontal();

			if (scores[i].playerName == "" && scores[i].score == 0) {
				text = (i+1) + " - ";
			} else {
				text = (i+1) + " - " + (scores[i].playerName.PadLeft(5, ' ')) + ' ' + scores[i].score;
			}
			GUILayout.Label(text, style, options);

			if (scores[i+len].playerName == "" && scores[i+len].score == 0) {
				text = (i+len+1) + " - ";
			} else {
				text = (i+len+1) + " - " + (scores[i+len].playerName.PadLeft(5, ' ')) + " : " + scores[i+len].score;
			}
			GUILayout.Label(text, style, options);
			
			GUILayout.EndHorizontal();
		}
		GUILayout.EndArea ();
	}
}
