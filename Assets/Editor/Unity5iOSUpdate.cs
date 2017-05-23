using UnityEngine;
using UnityEditor;

// Place this file in an Editor directory within Assets
[InitializeOnLoad]
public class Unity5iOSUpdate {
	static Unity5iOSUpdate()
	{
#if UNITY_5
		// Set the project to build with IL2CPP
		PlayerSettings.SetPropertyInt("ScriptingBackend", 1, BuildTargetGroup.iOS);

		// Set the project to build both 32 and 64-bit for iOS
		PlayerSettings.SetPropertyInt("Architecture", 2, BuildTargetGroup.iOS);
#endif
	}
}

