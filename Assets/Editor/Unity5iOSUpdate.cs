using UnityEngine;
using UnityEditor;

// Place this file in an Editor directory within Assets
[InitializeOnLoad]
public class Unity5iOSUpdate {
	static Unity5iOSUpdate()
	{
#if !(UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9)
		// Set the project to build for iOS with IL2CPP
		PlayerSettings.SetPropertyInt("ScriptingBackend", 1, BuildTargetGroup.iOS);

		// Set the project to build both 32 and 64-bit for iOS
		PlayerSettings.SetPropertyInt("Architecture", 2, BuildTargetGroup.iOS);
#endif
    }
}

