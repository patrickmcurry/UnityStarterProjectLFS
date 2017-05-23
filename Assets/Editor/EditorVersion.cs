using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class EditorVersion {
	static EditorVersion()
	{
		StreamWriter writer = new StreamWriter("Assets/Editor/EditorVersion.txt");
		writer.WriteLine(Application.unityVersion + "");
		writer.Close();
		
		// Official Unity 5 style editor version tracking too
		writer = new StreamWriter("ProjectSettings/ProjectVersion.txt");
		writer.WriteLine("m_EditorVersion: " + Application.unityVersion);
		writer.Close();
	}
}
