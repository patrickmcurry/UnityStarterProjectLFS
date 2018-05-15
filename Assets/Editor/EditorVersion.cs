using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class EditorVersion {
	static EditorVersion()
	{
#if UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9
        StreamWriter writer = new StreamWriter("ProjectSettings/ProjectVersion.txt");
		writer.WriteLine("m_EditorVersion: " + Application.unityVersion + "\n");
		writer.Close();
#endif
	}
}
