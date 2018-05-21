using UnityEngine;
using System.Collections;

public class testing_script : MonoBehaviour {
	
	bool calm = true;
	// Use this for initialization
	void Start () {
		
		test_function();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void test_function(){
		if ( calm ){
			Debug.Log ("eimai calm");	
		}	
		
	}
}
