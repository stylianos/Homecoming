using UnityEngine;
using System.Collections;

public class cinema: MonoBehaviour {
	
	public Texture2D []frames;
	public int frames_per_sec = 40;
	int index = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
		index = (int)((Time.time * frames_per_sec ) % frames.Length);
		index = index+1;
		//Debug.Log("index" + index);sad
		GetComponent<Renderer>().material.mainTexture = frames[index];
		
		
	}
}
