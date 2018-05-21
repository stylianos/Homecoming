using UnityEngine;
using System.Collections;

public class anger_bar : MonoBehaviour {
	
	public dfProgressBar anger_bar_object;
	private bool fill_bar = false;
	private float target_anger_value;
	// Use this for initialization
	void Start () {
	
	}
	
	
	
	void Update(){
		
		if (fill_bar)
			anger_bar_object.Value = Mathf.Lerp( anger_bar_object.Value , target_anger_value, 0.05f);
		
		if ( Mathf.Abs(anger_bar_object.Value - target_anger_value) < 0.02f){
			
			anger_bar_object.Value = target_anger_value;
			fill_bar = false;
		}
	}

	public void enable_anger_bar(){
		anger_bar_object.enabled = true;
	}
	
	public void disable_anger_bar(){
		anger_bar_object.enabled = false;
	}
	
	
	public void SetBar(string angry){
		
		if ( angry == "light_angry"){
			
			target_anger_value = 0.33f;
			fill_bar = true;
			
		}
			
		if ( angry == "medium_angry"){
			
			target_anger_value = 0.66f;
			fill_bar = true;
			
		}
			
		if ( angry == "really_angry"){
			
			target_anger_value = 1f;
			fill_bar = true;
			
		}
		if ( angry == "calm"){
			
			target_anger_value = 0f;
			fill_bar = true;
			
		}
		
	}
	
}
