using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LoadResources : MonoBehaviour {
	public static List<string> LoadTxtAsListString(string filename) {
		List<string> lines = new List<string>();
		
		try {
			TextAsset txt = (TextAsset)Resources.Load(filename, typeof(TextAsset));
			String[] lineArray = txt.text.Split('\n');
			
			int i = 0, len = lineArray.Length;
			for (i = 0; i < len; ++i) {
				lines.Add(lineArray[i]);
			}
		} catch (Exception e) {
			Debug.Log (e.ToString());
			lines = new List<string>();
		}
		
		return lines;
	}
}
