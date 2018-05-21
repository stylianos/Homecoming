using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class SMPMenuItems : MonoBehaviour {
	[MenuItem ("Window/AntiLunchBox/Check For Updates", false, 100)]
	static void CheckForUpdates()
	{
		if(Application.internetReachability != NetworkReachability.NotReachable)
		{
			if(SMPAutorun.versionChecker && SMPAutorun.versionChecker.GetComponent<EditorUpdateCheck>().querying)
			{
				if(SMPAutorun.versionChecker.GetComponent<EditorUpdateCheck>().respondInAlerts)
					Debug.Log("Stopping previous queries for updates...");
				SMPAutorun.versionChecker.GetComponent<EditorUpdateCheck>().StopChecking();
			}
			
			Debug.Log("Checking servers for updates...keep working in the meantime.");
			
			SMPAutorun.versionChecker = new GameObject("versionChecker", typeof(EditorUpdateCheck));
			SMPAutorun.versionChecker.hideFlags = HideFlags.HideAndDontSave;
			
			SMPAutorun.versionChecker.GetComponent<EditorUpdateCheck>().QueryUpdates(true);
		}
		else
		{
			EditorUtility.DisplayDialog("No Internet Connection...", "You must be connected to the internet to check for updates.", "OK");
		}
	}
	
	[MenuItem ("Window/AntiLunchBox/Create SoundManager", false, 101)]
	static void CreateSoundManager()
	{
		if(SoundManager.Instance)
			return;
		Debug.Log("A SoundManager has been created or one already exists in the scene.");
	}
	[MenuItem ("Window/AntiLunchBox/Setup For JS", false, 102)]
	static void JSSetup()
	{
		string error1, error2;
		error1 = AssetDatabase.MoveAsset("Assets/SoundManagerPro/Scripts", "Assets/Plugins/SoundManagerPro/Scripts");
		error2 = AssetDatabase.MoveAsset("Assets/SoundManagerPro/EditorHelper", "Assets/Plugins/SoundManagerPro/EditorHelper");
		
		if(error1 != "")
			Debug.LogError(error1 + "\nMove the 'SoundManagerPro/Scripts' folder to 'Plugins/SoundManagerPro/Scripts' yourself.");
		if(error2 != "")
			Debug.LogError(error2 + "\nMove the 'SoundManagerPro/EditorHelper' folder to 'Plugins/SoundManagerPro/EditorHelper' yourself.");
	}
	[MenuItem ("Window/AntiLunchBox/NGUI Integration", false, 200)]
	static void IntegrateNGUI()
	{
		string csCheckLocation = Application.dataPath+"/SoundManagerPro/Scripts/Extensions/NGUI_SMPRO_INTEGRATION.unitypackage";
		string jsCheckLocation = Application.dataPath+"/Plugins/SoundManagerPro/Scripts/Extensions/NGUI_SMPRO_INTEGRATION.unitypackage";
		
		if(File.Exists(csCheckLocation))
			AssetDatabase.ImportPackage(csCheckLocation, true);
		else if(File.Exists(jsCheckLocation))
			AssetDatabase.ImportPackage(jsCheckLocation, true);
		else
			Debug.LogError("Cannot find 'NGUI_SMPRO_INTEGRATION.unitypackage' that came with SoundManagerPro. Re-download it or import it yourself.");
	}
	[MenuItem ("Window/AntiLunchBox/PlayMaker Integration", false, 201)]
	static void IntegratePlayMaker()
	{
		string csCheckLocation = Application.dataPath+"/SoundManagerPro/Scripts/Extensions/PLAYMAKER_SMPRO_INTEGRATION.unitypackage";
		string jsCheckLocation = Application.dataPath+"/Plugins/SoundManagerPro/Scripts/Extensions/PLAYMAKER_SMPRO_INTEGRATION.unitypackage";
		
		if(File.Exists(csCheckLocation))
			AssetDatabase.ImportPackage(csCheckLocation, true);
		else if(File.Exists(jsCheckLocation))
			AssetDatabase.ImportPackage(jsCheckLocation, true);
		else
			Debug.LogError("Cannot find 'PLAYMAKER_SMPRO_INTEGRATION.unitypackage' that came with SoundManagerPro. Re-download it or import it yourself.");
	}
	[MenuItem ("Window/AntiLunchBox/2D Toolkit Integration", false, 202)]
	static void IntegrateTDTK()
	{
		string csCheckLocation = Application.dataPath+"/SoundManagerPro/Scripts/Extensions/TDTK_SMPRO_INTEGRATION.unitypackage";
		string jsCheckLocation = Application.dataPath+"/Plugins/SoundManagerPro/Scripts/Extensions/TDTK_SMPRO_INTEGRATION.unitypackage";
		
		if(File.Exists(csCheckLocation))
			AssetDatabase.ImportPackage(csCheckLocation, true);
		else if(File.Exists(jsCheckLocation))
			AssetDatabase.ImportPackage(jsCheckLocation, true);
		else
			Debug.LogError("Cannot find 'TDTK_SMPRO_INTEGRATION.unitypackage' that came with SoundManagerPro. Re-download it or import it yourself.");
	}
	[MenuItem ("Window/AntiLunchBox/Documentation", false, 300)]
	static void Documentation()
	{
		Application.OpenURL("http://antilunchbox.com/soundmanagerpro/soundmanagerpro-documentation/");
	}
	[MenuItem ("Window/AntiLunchBox/Forum", false, 301)]
	static void Forum()
	{
		Application.OpenURL("http://forum.unity3d.com/threads/186067-RELEASED-SoundManagerPro-Easy-Game-Music-Plugin");
	}
	[MenuItem ("Window/AntiLunchBox/About", false, 302)]
	static void About()
	{
		Application.OpenURL("http://antilunchbox.com/soundmanagerpro/");
	}
}