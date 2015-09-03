using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public static class Lib {
	public static float Modulo (float a, float b) {
		return a - b * Mathf.Floor(a / b);
	}
	
	public static List<string> LoadFile(string fileName) {
		List<string> lines = new List<string>();
		// Handle any problems that might arise when reading the text
		try {
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file was saved as
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the beginning of a class!)
			using (theReader) {
				// While there's lines left in the text file, do this:
				do {
					line = theReader.ReadLine();
					
					if (line != null) {
						lines.Add(line);
					}
				} while (line != null);
				// Done reading, close the reader and return true to broadcast success
				theReader.Close();
			}
		} catch (Exception e) {
			// If anything broke in the try block, we throw an exception with information on what didn't work
			Console.WriteLine("{0}\n", e.Message);
			lines = new List<string>();
		}
		
		return lines;
	}
}