using UnityEngine;
using System.Collections;

public class Game_logic_gauntlet : MonoBehaviour {

	public bool is_zombie = false;
	public bool has_become_zombie = false;
	public states_handler player_state_script;
	private vp_PlayerDamageHandler player_damage;
	public text_handler my_text;
	// Use this for initialization

	void Awake () {
		player_state_script =  GameObject.Find("my_player").GetComponent<states_handler>();
		my_text = GetComponent<text_handler>();
	}

	void Start () {
		player_damage = (vp_PlayerDamageHandler)GameObject.Find("my_player").GetComponent(typeof(vp_PlayerDamageHandler));
	}
	
	// Update is called once per frame
	void Update () {

		if (is_zombie){
			if (!has_become_zombie){
				my_text.DisplayText("Your health is below zero!! Try NOT to remail calm");
				has_become_zombie = true;
			}
			if ( player_state_script.calm)
				player_damage.Die();
		}
	
	}
}
