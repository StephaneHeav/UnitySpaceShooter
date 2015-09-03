using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeysManager : MonoBehaviour {
	private List<InputManager> inputManager = new List<InputManager>();

	private bool change;
	private int key;

	private GUILayoutOption[] options;
	private GUIStyle style = new GUIStyle();

	private DataController dataController;

	void Start () {		
		GameObject dataControllerObject = GameObject.FindGameObjectWithTag("DataController");
		dataController = dataControllerObject.GetComponent<DataController> ();
		inputManager = dataController.GetInputManager ();

		options = new GUILayoutOption[] {
			GUILayout.Width(150),
			GUILayout.Height(30)
		};
		
		style.fontSize = 20;
		style.alignment = TextAnchor.MiddleLeft;
		style.normal.textColor = Color.white;
		
	}

	void OnGUI () {
		Event e = Event.current;

		if (inputManager != null) {
			GUILayout.BeginArea (new Rect (325,160,300,400));
			int i = 0;
			for(; i < inputManager.Count; ++i) {
				GUILayout.BeginHorizontal();

				GUILayout.Label(inputManager[i].keyName, style, options);

				if (GUILayout.Button (inputManager[i].key, options)) {
					key = i;
					change = true;
				}

				GUILayout.EndHorizontal();
				GUILayout.Space (10);

				if (change && e.isKey) {
					inputManager[key].key = e.keyCode.ToString();
					dataController.SetInputManager(key, inputManager[key]);
					change = false;
				}
			}
			GUILayout.EndArea ();
		}
	}
}