using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#pragma strict

public class game_logic : MonoBehaviour {
	
	private vp_PlayerDamageHandler player_damage;
	public GameObject player;
	public dfLabel black_screen;
	public float time_delay = 3f;
	public text_handler my_text;
	
	
	private int order_of_text = 0;
	
	public bool start_game = true;
	public bool fade_out;
	
	
	public vp_FPInput player_input;
	public vp_SimpleHUD player_gui;
	public vp_SimpleCrosshair player_crosshair;
	public Light sun;
	public Camera player_camera;
	public dfProgressBar anger_bar;
	public dfLabel mini_control;
	public names names_script;
	public GameObject spawner_at_tower;
	public GameObject mage;
	
	//public GameObject[] get_home;
	public GameObject[] spawners;
	public GameObject[] text_before_wife;
	public GameObject[] torches;
	public GameObject[] demons;
	public GameObject[] enemies;
	public List<GameObject> skeletons = new List<GameObject>();
	
	
	public bool end_game = false;
	public bool credits = false;
	public bool first_killed = true;
	public bool is_zombie = false;
	public bool has_become_zombie = false;
	public bool mage_dead = false;
	public anger_bar anger_bar_script;
	public states_handler player_state_script;
	
	

	public vp_FPInput input_script;
	
	void Awake(){
		anger_bar_script = GameObject.Find("Game_logic").GetComponent<anger_bar>();
		input_script = GameObject.Find("my_player").GetComponent<vp_FPInput>();
		
		names_script = GameObject.Find("names").GetComponent<names>();
		
		//get_home = GameObject.FindGameObjectsWithTag("get_home");
		spawners = GameObject.FindGameObjectsWithTag("spawners_village");
		text_before_wife = GameObject.FindGameObjectsWithTag("text_before_wife");
		mini_control = GameObject.Find("mini_control").GetComponent<dfLabel>();
		spawner_at_tower = GameObject.Find("spawner_tower");
		torches = GameObject.FindGameObjectsWithTag("torch");
		demons = GameObject.FindGameObjectsWithTag("demon");
		mage = GameObject.Find("skeleton_mage");
		
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		
		foreach ( GameObject enemy in enemies){
			if (enemy.name.Equals("skeleton")){
					skeletons.Add(enemy);
			}
			
		}
		
		player_state_script =  GameObject.Find("my_player").GetComponent<states_handler>();
	}
	
	// Use this for initialization
	
	void Start()
	{
		fade_out = false;
		my_text = GetComponent<text_handler>();
		player_damage = (vp_PlayerDamageHandler)GameObject.Find("my_player").GetComponent(typeof(vp_PlayerDamageHandler));
		black_screen = GameObject.Find("Black_screen").GetComponent<dfLabel>();
		player_input = GameObject.FindGameObjectWithTag("Player").GetComponent<vp_FPInput>();
		player_gui = GameObject.FindGameObjectWithTag("Player").GetComponent<vp_SimpleHUD>();
		player_crosshair = GameObject.FindGameObjectWithTag("Player").GetComponent<vp_SimpleCrosshair>();
		player_camera = GameObject.Find("FPSCamera").GetComponent<Camera>();
		anger_bar = GameObject.Find("Progress Bar").GetComponent<dfProgressBar>();
		
		
		foreach ( GameObject t in torches){
		
			t.SetActive(false);
			
		}
		
		
		foreach ( GameObject t in demons){
		
			t.SetActive(false);
			
		}
		
		foreach ( GameObject t in skeletons){
			
			t.SetActive(false);
			
		}
		
		mage.SetActive(false);
		
		player_state_script.enabled = false;
		anger_bar_script.disable_anger_bar();
		
	}

	
	
	void Update () {
		
		
		if (start_game){
			
			StartCoroutine(Coroutine_ShowLetters());
			start_game = false;
		}
		
		if (fade_out){
			
			black_screen_fadeout();
			if ( black_screen.Opacity == 0 )
				fade_out = false;
		}
		
		if (is_zombie){
			if (!has_become_zombie){
				my_text.DisplayText("I am dead man, it's over for me. But I refuse to die, until I have taken all the monsters with me");
				has_become_zombie = true;
			}
			if ( player_state_script.calm && !mage_dead)
				player_damage.Die();
		}
		
	
		if ( player_damage.is_dead){
			
				time_delay -= Time.deltaTime;
				if (time_delay < 0 )
				Application.LoadLevel("main_menu1360x768");
				
		}
		
	
		if ( mage_dead && first_killed){
			first_killed = false;
			StartCoroutine(Coroutine_Mage_Killed());
			
		}
		
		if (end_game){
			black_screen_fadein();	
		}
		if (credits){
			credits = false;
			StartCoroutine(Corouting_Credits());
		}
		
		
		
		
		
	}
		
		
	public IEnumerator Coroutine_ShowLetters() {
		
		
		yield return new WaitForSeconds(4);
		my_text.DisplayText("I was just returning from war");
		yield return new WaitForSeconds(7);
		my_text.DisplayText("My footsteps had brought me back to my hometown. I could already see the village in the distance...");
		yield return new WaitForSeconds(7);
		my_text.DisplayText("I wanted to see my wife "+ names_script.mother + ".I missed her so much!");
		yield return new WaitForSeconds(7);
		
		
		fade_out = true;
		yield return null;
		
	}

	
	
	
	public void black_screen_fadeout (){
		
		black_screen.Opacity = Mathf.Lerp(black_screen.Opacity , 0f, 0.0001f);
		
		if ( black_screen.Opacity < 0.95) {
		
			player_camera.enabled = true;
		}
		
			
		if ( black_screen.Opacity < 0.05 ) {
			
			black_screen.Opacity = 0;
			player_gui.enabled = true;
			player_input.enabled = true;
			player_crosshair.enabled = true;
			//anger_bar.enabled = true;
			mini_control.enabled = true;
			
		
		}
				
	}
	

			
	
	public void SetTarget(string name){
		
		//Debug.Log("allaksa");
		GameObject.Find("arrow").GetComponent<arrow>().target = GameObject.Find(name);
		
	}
	
	public void SetHint (string hint){
		GameObject.Find("arrow").GetComponent<arrow>().hint.Text = hint;
	}
	
	public void Wife_transformed(){
		anger_bar_script.enable_anger_bar();
		player_state_script.enabled = true;
		foreach ( GameObject t in spawners ) {
			
			t.GetComponent<my_spawner>().GetComponent<my_spawner>().enabled = true;
			t.GetComponent<BoxCollider>().enabled = true;
			
		}
		foreach ( GameObject t in text_before_wife ) {
			
			Destroy(t);
			
		}
		
		
		
		
		foreach ( GameObject t in torches){
		
			t.SetActive(true);
			
		}
		
		foreach ( GameObject t in demons){
		
			t.SetActive(true);
			
		}
		
		foreach ( GameObject t in skeletons){
			
			t.SetActive(true);
			
		}
		
		
		
		mage.SetActive(true);
		
		SetTarget("skeleton_mage");
		SetHint("Get Revenge. Kill the necromancer");

	}
	
	IEnumerator  Coroutine_Wife_Dead(){
		
		
		yield return new WaitForSeconds(6);
		
		my_text.DisplayText("My wife... They made me kill MY OWN WIFE! ");
		yield return new WaitForSeconds(3);
		my_text.DisplayText(" The necromancer will pay for that");
		yield return new WaitForSeconds(3);
		my_text.DisplayText("I will teach him there are things far more scary than the dead... ");
		yield return new WaitForSeconds(3);
		
	}
	
	public IEnumerator Coroutine_Mage_Killed(){
		player_state_script.calm = true;
		player_state_script.light_angry = false;
		player_state_script.medium_angry = false;
		player_state_script.really_angry = false;
		
		foreach ( GameObject t in torches){
		
			t.SetActive(false);
			
		}
		
		foreach ( GameObject t in demons){
			if (t != null ){
				
				t.GetComponent<vp_AI>().DamageHandler.Die();
			}
			
			
		}
		
		foreach (GameObject t in skeletons){
			if (t != null ){
				
				t.GetComponent<vp_AI>().DamageHandler.Die();
			}
		}
		
		Debug.Log("Eimai mesa sto pethane o magos...");
		input_script.Player.SetWeapon.TryStart(0);
		my_text.DisplayText("I killed him " + names_script.mother + " I did it...");
		yield return new WaitForSeconds(6);
		my_text.DisplayText("May you rest in peace...");
		yield return new WaitForSeconds(4);
		
		input_script.Player.SetWeapon.TryStart(0);
		
		player_state_script.SetWeapon();
		player_state_script.SetBehaviour();
		player_state_script.enabled = false;
	
		yield return new WaitForSeconds(7);
		input_script.Player.SetWeapon.TryStart(0);
		my_text.DisplayText("At least if I could see you...");
		
	
		end_game = true;
	}
	
	
	public void black_screen_fadein (){
	
		black_screen.Opacity += 0.01f;
		
		if (black_screen.Opacity > 0.3){
			AudioSource[] player_sounds = GameObject.Find("my_player").GetComponents<AudioSource>();
			foreach ( AudioSource t in player_sounds){
		
				t.enabled = false;
			
			}
		}
		if ( black_screen.Opacity > 0.95f) {
			
			player_camera.enabled = false;
			black_screen.Opacity = 1;
			player_gui.enabled = false;
			player_input.enabled = false;
			player_crosshair.enabled = false;
			anger_bar.enabled = false;
			mini_control.enabled = false;
			credits = true;
			end_game = false;
		}
	
	}
	
	
	public IEnumerator Corouting_Credits(){
		yield return new WaitForSeconds(5);
		my_text.DisplayText("One more time...");
		
		yield return new WaitForSeconds(6);
		my_text.DisplayText("Created by Stelios Avramidis");
		yield return new WaitForSeconds(5);
		my_text.DisplayText("Thank you for playing");
		yield return new WaitForSeconds(7);
		Application.LoadLevel("main_menu1360x768");
	}
		
}
	
	
	
	
	

