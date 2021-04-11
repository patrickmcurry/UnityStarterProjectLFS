using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class EditorVersion {
	static string thisUserCurrentUnityVersion;
	static string thisProjectOfficialUnityVersion;
	const string versionStringPrefix = "m_EditorVersion: ";

	static EditorVersion()
	{
		thisUserCurrentUnityVersion = Application.unityVersion;
#if UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9
        StreamWriter writer = new StreamWriter("ProjectSettings/ProjectVersion.txt");
		writer.WriteLine(versionStringPrefix + thisUserCurrentUnityVersion + "\n");
		writer.Close();
#endif
		if (File.Exists("ProjectSettings/ProjectVersionOfficial.txt"))
		{
			// Get the official version of Unity this project has decided to use
			string[] lines = File.ReadAllLines("ProjectSettings/ProjectVersionOfficial.txt");
			foreach (string line in lines)
			{
				if (line.StartsWith(versionStringPrefix))
				{
					thisProjectOfficialUnityVersion = line.Replace(versionStringPrefix,"");
					break;
				}
			}
		}

		if (thisProjectOfficialUnityVersion != null)
		{
			if (thisProjectOfficialUnityVersion.Equals(thisUserCurrentUnityVersion))
			{
				// The user is currently running the correct version of the Unity editor.
				Debug.Log("Project's official Unity version is " + thisProjectOfficialUnityVersion + " -- matches your editor.");
			}
			else
			{
				// The user is likely NOT running the correct version of the Unity editor.
				string errorMessage = "Project's official Unity version is \nUnity " + thisProjectOfficialUnityVersion + "\n -- \nBut you are currently running \nUnity " + thisUserCurrentUnityVersion + " \n\n> Ask your tech lead for assistance.";
				Debug.LogError(errorMessage.Replace("\n",""));
				EditorUtility.DisplayDialog("Unity Version Warning", errorMessage, "OK");
			}
		}
		else
		{
			// No official Unity version has been set by the tech lead. Sets this Unity version to be the correct one
			Debug.Log("Project's official Unity version could not be found.");
			StreamWriter writer = new StreamWriter("ProjectSettings/ProjectVersionOfficial.txt");
			writer.WriteLine(versionStringPrefix + thisUserCurrentUnityVersion + "\n");
			writer.Close();
			thisProjectOfficialUnityVersion = thisUserCurrentUnityVersion;
			Debug.Log("Set initial official Unity version to : " + thisProjectOfficialUnityVersion);
		}
	}
}
