using UnityEngine;
using System.Collections;

public class names : MonoBehaviour {
	
	public string mother = "Jessica";
	public string player = "Alexander";
	
	// Use this for initialization
	void Awake () {
		
		DontDestroyOnLoad(gameObject);	
	}
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
