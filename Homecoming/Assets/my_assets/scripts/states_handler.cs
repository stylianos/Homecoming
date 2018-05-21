using UnityEngine;
using System.Collections;

public class states_handler : MonoBehaviour {
	
	
	private vp_FPWeaponMeleeAttack m_Weapon = null;
	private angry_weapon angry_script = null;
	private vp_FPController m_Controller = null;
	private vp_FPCamera m_Camera = null;
	public GameObject mace;
	public GameObject soundtrack;
	public AtmoXfade sky;
	private bool is_playing = false;
	public bool slow_motion;
	public float slow_timer = 0;
	public bool calm = true;
	public bool light_angry = false;
	public bool medium_angry = false;
	public bool really_angry = false;

	public bool paused = false;

	public dfLabel black_screen;

	public AudioClip slow_time;
	public AudioClip quick_time;
	
	public AudioSource music;
	public AudioSource time_effect;
	public AudioSource rain_sound;
	public bool should_sound_slow = true;
	private bool bring_them_down = false;
	
	public anger_bar my_gui;
	public bool left_button = true;
	
	public GameObject clouds;
	public GameObject rain;
	
	//public ParticleSystem spithes;
	public GameObject spithes;
	public GameObject game_logic;
	
	void Awake () {
		
		clouds = GameObject.Find("CloudsStormy");
		rain = GameObject.Find("rain_heavy");
		spithes = GameObject.Find("Sparks");
		my_gui = GameObject.Find("Game_logic").GetComponent<anger_bar>();
		black_screen = GameObject.Find("Black_screen").GetComponent<dfLabel>();
	}
	
	// Use this for initialization
	void Start () {
		left_button = false;
		m_Weapon = (vp_FPWeaponMeleeAttack)this.GetComponentInChildren(typeof(vp_FPWeaponMeleeAttack));
		SetBehaviour();
		SetWeapon();
		
		vp_Timer.In(5f, SetWeapon, 0);
	}
	
	
	// Update is called once per frame
	void Update () {
		//Slow motion effect
		
		if (  slow_timer > 0  ) {
			
			if (should_sound_slow){
				this.gameObject.GetComponent<AudioSource>().PlayOneShot(slow_time);
				should_sound_slow = false;
			}
			
			vp_TimeUtility.FadeTimeScale(0.2f , 1f);
			slow_timer -= Time.deltaTime;
			
		}
		
		else {
			if (!should_sound_slow){
				this.gameObject.GetComponent<AudioSource>().PlayOneShot(quick_time);	
				should_sound_slow = true;
				Debug.Log("Kai tora pame pros ta piso");
				if ( bring_them_down ) {
					
					Debug.Log("mpika");
					GameObject[] dead_bodies = GameObject.FindGameObjectsWithTag("ragdoll");
					Debug.Log("dead_bodies " + dead_bodies.Length);
					foreach ( GameObject body in dead_bodies ) {
					
						Transform[] transforms = body.GetComponentsInChildren<Transform>();
						foreach(Transform t in transforms) {
								
								if(t.GetComponent<Rigidbody>())
									t.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.up * (-600) ,ForceMode.Impulse );
					
						}
									
					}
				}
				
				//restore the way A.I handles damage and weapon
				bring_them_down = false;
				//m_Weapon.final_move = false;
			}
			
			vp_TimeUtility.FadeTimeScale(1f , 1f);
			left_button = false;
		}
		
		if (Input.GetMouseButton(1)){
			
			if ( really_angry ){
				left_button = true;
				GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
				//m_Weapon.final_move = true;
				foreach (GameObject enemy in enemies ) {
					//enemy.GetComponent<vp_AI>().DamageHandler.final_move = true;
					enemy.GetComponent<vp_AI>().DamageHandler.Die();
				
				}
			
				bring_them_down = true;	
				calm = true;
				light_angry = false;
				medium_angry = false;
				really_angry = false;
			
				SetWeapon();
				SetBehaviour();
				
			}
			
		}
		
		
		if (Input.GetKey(KeyCode.B)){
			
			calm = false;
			light_angry = true;
			medium_angry = false;
			really_angry = false;
			
			SetWeapon();
			SetBehaviour();
		}
		
		if (Input.GetKey(KeyCode.V)){
			
			calm = false;
			light_angry = false;
			medium_angry = true;
			really_angry = false;
			
			SetWeapon();
			SetBehaviour();
		}
		
		if (Input.GetKey(KeyCode.I)){
			calm = false;
			light_angry = false;
			medium_angry = true;
			really_angry = true;
			
			SetWeapon();
			SetBehaviour();
		}
				
		if (Input.GetKey(KeyCode.N)){
			calm = true;
			light_angry = false;
			medium_angry = false;
			really_angry = false;
			
			SetWeapon();
			SetBehaviour();
			
		}

		/*
		if (Input.GetKey(KeyCode.P)){


			if ( !paused ) {

				vp_TimeUtility.FadeTimeScale(1f , 0f);
				black_screen.Opacity = 0.5f;
				paused = true;

			}

			if ( paused ) {
				
				vp_TimeUtility.FadeTimeScale(1f , 1f);
				black_screen.Opacity = 0f;
				paused = false;
			}


		}*/	
	
		

	}
	
	public void SetBehaviour(){
		//Debug.Log(" Mpika sto behaviour");
		if ( calm ) {
			//Bar
			my_gui.SetBar("calm");
			
			//Weather
			clouds.GetComponent<ParticleSystem>().Stop();
			rain.GetComponent<ParticleSystem>().Stop();
			rain_sound.Stop();
			if (Application.loadedLevelName.Equals("my_village_1360")){
				GetComponent<AtmoXfade>().MakeSkyLight();
			}
				
			
			//Spithes
			spithes.GetComponent<ParticleEmitter>().maxEmission = 60;
			spithes.GetComponent<ParticleEmitter>().emit = false;
			
			
		}
		
		 if (light_angry){
			//Bar
			my_gui.SetBar("light_angry");
			
			//Weather
			clouds.GetComponent<ParticleSystem>().Play();
			rain.GetComponent<ParticleSystem>().Stop();
			if (Application.loadedLevelName.Equals("my_village_1360")){
				GetComponent<AtmoXfade>().MakeSkyLight();
			}
			rain_sound.Stop();
			
			//Spithes
			spithes.GetComponent<ParticleEmitter>().maxEmission = 60;
			spithes.GetComponent<ParticleEmitter>().emit = true;
		
			
		}
		
		 if (medium_angry){
			
			//Bar
			my_gui.SetBar("medium_angry");
			
			//Weather
			clouds.GetComponent<ParticleSystem>().Play();
			rain.GetComponent<ParticleSystem>().Play();
			rain.GetComponent<ParticleSystem>().Play();
			rain_sound.Play();

			if (Application.loadedLevelName.Equals("my_village_1360")){
				GetComponent<AtmoXfade>().MakeSkyDark();
			}

			
			//Spithes
			spithes.GetComponent<ParticleEmitter>().maxEmission = 100;
			spithes.GetComponent<ParticleEmitter>().emit = true;
			
		}
		
		if (really_angry){
			//Bar
			my_gui.SetBar("really_angry");
			
			
		}
		
		
	}
	
	public void SetWeapon(){
		//Debug.Log("EIMAI I SET WEAPON");
		if (calm) {
			//Debug.Log("mesa sto calm");
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
			foreach (GameObject enemy in enemies ) {
				
				enemy.GetComponent<vp_AI>().DamageHandler.angry = false;
				enemy.GetComponent<vp_AI>().DamageHandler.splash = false;
				
			}
			
			GameObject[] demons = GameObject.FindGameObjectsWithTag("demon");
			foreach (GameObject enemy in demons ) {
				
				enemy.GetComponent<vp_AI>().DamageHandler.angry = false;
				enemy.GetComponent<vp_AI>().DamageHandler.splash = false;
				
			}
			if (m_Weapon == null)
				m_Weapon = (vp_FPWeaponMeleeAttack)this.GetComponentInChildren(typeof(vp_FPWeaponMeleeAttack));
			
			m_Weapon.GetComponent<vp_FPWeaponMeleeAttack>().Damage = 5;
			m_Weapon.GetComponent<vp_FPWeaponMeleeAttack>().test = false;

			//m_Weapon.RefreshDefaultState();
			mace.GetComponent<ParticleSystem>().enableEmission = false;
			
			if (is_playing){
				is_playing = false;
				soundtrack.GetComponent<AudioSource>().Pause();
			}
			
		}
		//Debug.Log("meta to calm");
		if (light_angry){
			
			
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
			
			foreach (GameObject enemy in enemies ) {
					
				enemy.GetComponent<vp_AI>().DamageHandler.angry = true;
				enemy.GetComponent<vp_AI>().DamageHandler.splash = false;
			}
			
			GameObject[] demons = GameObject.FindGameObjectsWithTag("demon");
			foreach (GameObject enemy in demons ) {
				
				enemy.GetComponent<vp_AI>().DamageHandler.angry = true;
				enemy.GetComponent<vp_AI>().DamageHandler.splash = false;
				
			}
			if (m_Weapon == null)
				m_Weapon = (vp_FPWeaponMeleeAttack)this.GetComponentInChildren(typeof(vp_FPWeaponMeleeAttack));
			
			m_Weapon.GetComponent<vp_FPWeaponMeleeAttack>().Damage = 100;
			m_Weapon.GetComponent<vp_FPWeaponMeleeAttack>().test = false;
			//m_Weapon.RefreshDefaultState();
			
			if ( !is_playing){
				is_playing = true;
				soundtrack.GetComponent<AudioSource>().Play();	
			}
		}
		
		
		if (medium_angry){
			
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
			
			foreach (GameObject enemy in enemies ) {
				enemy.GetComponent<vp_AI>().DamageHandler.angry = true;
				enemy.GetComponent<vp_AI>().DamageHandler.splash = true;
				
			}	
			
			GameObject[] demons = GameObject.FindGameObjectsWithTag("demon");
			foreach (GameObject enemy in demons ) {
				
				enemy.GetComponent<vp_AI>().DamageHandler.angry = true;
				enemy.GetComponent<vp_AI>().DamageHandler.splash = true;
				
			}
			//m_Weapon.RefreshDefaultState();
			if (m_Weapon == null)
				m_Weapon = (vp_FPWeaponMeleeAttack)this.GetComponentInChildren(typeof(vp_FPWeaponMeleeAttack));
			
			m_Weapon.GetComponent<vp_FPWeaponMeleeAttack>().Damage = 100;
			m_Weapon.GetComponent<vp_FPWeaponMeleeAttack>().test  = true;
			
			if ( !is_playing){
				is_playing = true;
				soundtrack.GetComponent<AudioSource>().Play();	
			}
		}
		
		
		//Debug.Log ("eftasa sto telos");
		
		
	}
	
	public void random_functions(){
		Debug.Log("re mpika kai edo");
	}
}
