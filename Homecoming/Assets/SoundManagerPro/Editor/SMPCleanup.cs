using UnityEngine;
using UnityEditor;
using System.Collections;

public class SMPCleanup : AssetModificationProcessor {
	static string[] OnWillSaveAssets (string[] paths) {
        SoundManager SMP = GameObject.FindObjectOfType(typeof(SoundManager)) as SoundManager;
		if(SMP != null && SMP.storage != null)
			SMP.storage.ClearStorage();
        return paths;
    }
}
