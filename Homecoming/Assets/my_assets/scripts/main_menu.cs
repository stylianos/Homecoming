using UnityEngine;
using System.Collections;

public class main_menu : MonoBehaviour {
	
	public dfButton NewGame;
	public dfButton NewGauntlet;
	public dfButton family;
	public dfButton Quit;
	public dfButton save;
	public dfButton controls;
	public dfButton credits;
	public dfButton prepare_emotiv;
	public dfLabel controls_info;
	public dfLabel emotiv_label;
	public dfLabel music_track;



	
	public bool reveal_family;
	
	// Use this for initialization
	void Start () {
	
		this.gameObject.GetComponent<AudioSource>().Play();
		prepare_emotiv = GameObject.Find("emotiv_button").GetComponent<dfButton>();
		save = GameObject.Find("Save").GetComponent<dfButton>();
		controls_info = GameObject.Find ("control_label").GetComponent<dfLabel>();
		emotiv_label = GameObject.Find("prepare_emotiv").GetComponent<dfLabel>();
		credits = GameObject.Find("Credits").GetComponent<dfButton>();
		music_track = GameObject.Find("music_track").GetComponent<dfLabel>();
		NewGauntlet = GameObject.Find("NewGauntlet").GetComponent<dfButton>();

		
	}
	
	// Update is called once per frame
	void Update () {
		


		if ( NewGame.State == dfButton.ButtonState.Pressed ) {
			
			Application.LoadLevel("my_village_1360");
				
		}

		if ( NewGauntlet.State == dfButton.ButtonState.Pressed ) {
			
			Application.LoadLevel("gauntlet");
			
		}


		
		if ( Quit.State == dfButton.ButtonState.Pressed ) {
			
			Application.Quit();
				
		}
		
		if ( family.State == dfButton.ButtonState.Pressed ) {
			music_track.enabled = false;
			emotiv_label.enabled = false;
			controls_info.enabled = false;
			
			family.TextColor = Color.red;
			family.FocusTextColor = Color.red;
			family.PressedTextColor = Color.red;
			
			reveal_family = true;
			dfLabel[] family_labels = family.gameObject.GetComponentsInChildren<dfLabel>();
			
			foreach ( dfLabel t in family_labels)
				t.enabled = true;
			
			dfTextbox[] family_textbox = family.gameObject.GetComponentsInChildren<dfTextbox>();
			
			foreach ( dfTextbox t in family_textbox)
				t.enabled = true;
			
			
			save.enabled = true;		
		}
		
		
		if (save.State == dfButton.ButtonState.Pressed){
			music_track.enabled = false;
			names names_scirpt = GameObject.Find("names").GetComponent<names>();
			dfTextbox wife_name = GameObject.Find("name_wife").GetComponent<dfTextbox>();
			dfTextbox player_name = GameObject.Find("name_player").GetComponent<dfTextbox>();
			
			if ( wife_name.Text != null)
				names_scirpt.mother = wife_name.Text;
			if ( player_name.Text != null)
			names_scirpt.player = player_name.Text;
			
			
			
			dfLabel[] family_labels = family.gameObject.GetComponentsInChildren<dfLabel>();
			
			foreach ( dfLabel t in family_labels)
				t.enabled = false;
			
			dfTextbox[] family_textbox = family.gameObject.GetComponentsInChildren<dfTextbox>();
			
			foreach ( dfTextbox t in family_textbox)
				t.enabled = false;
			
			
			family.TextColor = Color.white;
			family.FocusTextColor = Color.white;
			family.PressedTextColor = Color.white;
			
			save.enabled = false;		
		}
		
		if (controls.State == dfButton.ButtonState.Pressed){
			music_track.enabled = false;
			emotiv_label.enabled = false;
			controls_info.enabled = true;
			
			dfLabel[] family_labels = family.gameObject.GetComponentsInChildren<dfLabel>();
			
			foreach ( dfLabel t in family_labels)
				t.enabled = false;
			
			dfTextbox[] family_textbox = family.gameObject.GetComponentsInChildren<dfTextbox>();
			
			foreach ( dfTextbox t in family_textbox)
				t.enabled = false;
			
			save.enabled = false;
			
			family.TextColor = Color.white;
			family.FocusTextColor = Color.white;
			family.PressedTextColor = Color.white;
			
			
		}
		
		if ( prepare_emotiv.State == dfButton.ButtonState.Pressed ) {
			music_track.enabled = false;
			emotiv_label.enabled = true;
			controls_info.enabled = false;
			
			dfLabel[] family_labels = family.gameObject.GetComponentsInChildren<dfLabel>();
			
			foreach ( dfLabel t in family_labels)
				t.enabled = false;
			
			dfTextbox[] family_textbox = family.gameObject.GetComponentsInChildren<dfTextbox>();
			
			foreach ( dfTextbox t in family_textbox)
				t.enabled = false;
			
			save.enabled = false;
			
			family.TextColor = Color.white;
			family.FocusTextColor = Color.white;
			family.PressedTextColor = Color.white;
		}

		if ( credits.State == dfButton.ButtonState.Pressed ) {
			music_track.enabled = true;
			emotiv_label.enabled = false;
			controls_info.enabled = false;
			
			dfLabel[] family_labels = family.gameObject.GetComponentsInChildren<dfLabel>();
			
			foreach ( dfLabel t in family_labels)
				t.enabled = false;
			
			dfTextbox[] family_textbox = family.gameObject.GetComponentsInChildren<dfTextbox>();
			
			foreach ( dfTextbox t in family_textbox)
				t.enabled = false;
			
			save.enabled = false;
			
			family.TextColor = Color.white;
			family.FocusTextColor = Color.white;
			family.PressedTextColor = Color.white;


		}
	}
	
	
}
