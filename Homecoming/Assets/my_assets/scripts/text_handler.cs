using UnityEngine;
using System.Collections;

public class text_handler : MonoBehaviour {

	protected dfLabel text; 
	private float opacity_passed = 0f;
	private float display_message_time =0f;
	private int time_of_interact = 0;
	protected bool display = false;
	protected bool fade_away = false;

	void Awake() {
		
		text = GameObject.Find("Label").GetComponent<dfLabel>();
		
		
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if ( display ) {
						
			//text.SetProperty("opacity", Mathf.Lerp(0 , 1 , 0.01f));
			opacity_passed += Time.deltaTime;
			text.Opacity = Mathf.Lerp(0f,1f,opacity_passed);
			display_message_time = 3f;
			//Debug.Log ( "kanoume display " + text.Text + " einai " + display_message_time);		
		}
				
		if (text.Opacity > 0.98f && display ) {
					
			text.Opacity = 1f;
			display = false;
			fade_away = true;
		}
				
		if (fade_away){
			
			//Debug.Log ("To text einai " + text.Text + " kai kanoume fade away");
			if ( display_message_time > 0 ){
				
				//Debug.Log ( "Display_message Time einai gia to " + text.Text + " einai " + display_message_time);
				display_message_time -= Time.deltaTime;
				opacity_passed = 0f;
			}
					
			else {
						
				opacity_passed += Time.deltaTime;
				text.Opacity = Mathf.Lerp(1f,0f,opacity_passed);
						
			}
					
			if ( text.Opacity < 0.02 ){
						
				display_message_time = 3f;
				text.Opacity = 0f;
				opacity_passed = 0f;
				fade_away = false;
						
			}			
						
		}
		
	}
	
	public virtual void DisplayText( string text_to_display ){
		
		text.Text = text_to_display;
		text.Opacity = 0f;
		opacity_passed = 0f;
		display_message_time = 3f;
		fade_away = false;
		display = true;
		
	}
	
	

}
