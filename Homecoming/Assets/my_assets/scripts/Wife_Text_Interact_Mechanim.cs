using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Wife_Text_Interact_Mechanim : vp_Interactable {
	
	protected vp_FPInteractManager m_InteractManager = null;
	protected AudioSource m_Audio = null;
	protected bool is_pulled = false;
	protected bool display = false;
	protected bool fade_away = false;
	public int ForceApplied = 1000;
	public Texture GrabStateCrosshair = null; // crosshair to display while holding this object
	protected dfLabel text; 
	private float opacity_passed = 0f;
	private float display_message_time =0f;
	private int time_of_interact = 0;
	public bool splatered = false;
	public GameObject monster;
	public names names_script;
	public vp_FPInput input_script;
	public bool interact = false;
	
	
	public Animator wife_anime;
	
	
	public text_handler my_text;
	
	void Awake() {
		input_script = GameObject.Find("my_player").GetComponent<vp_FPInput>();
		names_script = GameObject.Find("names").GetComponent<names>();
		wife_anime = this.gameObject.GetComponent<Animator>();
		my_text = GameObject.Find("Game_logic").GetComponent<text_handler>();
	}
	// Use this for initialization
	void Start () {
		
		base.Start();
		// for continuos interaction type
		InteractType = vp_InteractType.Normal;
		InteractDistance = 1000;
		
		m_InteractManager = GameObject.FindObjectOfType(typeof(vp_FPInteractManager)) as vp_FPInteractManager;
		
	}

	
	public override bool TryInteract(vp_FPPlayerEventHandler player)
	{
		
		if (m_Player == null)
			m_Player = player;

		if (player == null)
			return false;

		if (m_Controller == null)
			m_Controller = m_Player.GetComponent<vp_FPController>();

		if (m_Controller == null)
			return false;

		if (m_Camera == null)
			m_Camera = m_Player.GetComponentInChildren<vp_FPCamera>();

		if (m_Camera == null)
			return false;

		if (m_WeaponHandler == null)
			m_WeaponHandler = m_Player.GetComponentInChildren<vp_FPWeaponHandler>();

		if (m_Audio == null)
			m_Audio = m_Player.GetComponent<AudioSource>();

		//m_Player.Register(this);
		
		
		//m_Player.Interactable.Set(this);
		
		if (!interact)
			StartCoroutine(Coroutine_DisplayText());
		
		return true;
	}
	 
	

	
	protected IEnumerator Coroutine_DisplayText(){
		
		interact = true;
		input_script.Player.SetWeapon.TryStart(0);
		
		if ( time_of_interact == 0 ) {
			
			yield return null;
			
			my_text.DisplayText( names_script.mother + " what happened? Where is everyone?");
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "[color #ffff00]" + names_script.player +"!You are back!! [/color]");
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "What are these mosnters in the village?");
			yield return new WaitForSeconds(4);
			my_text.DisplayText( "[color #ffff00] It is curse! Suddenly everyone in the village started turning into monsters! [/color]");
			yield return new WaitForSeconds(4);
			my_text.DisplayText( "You mean the monsters are the villagers!?!?");
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "[color #ffff00] Yes a necromancer came to the old tower, outside the village. [/color]");
			yield return new WaitForSeconds(4);
			my_text.DisplayText( "Come on, then we are leaving!");
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "[color #ffff00] You do not understand! I am also infected by the curse! I do not have much time left. I tried holding it, waiting for you. But it is getting me I can feel it. [/color]");
			yield return new WaitForSeconds(6);
			my_text.DisplayText( "[color #ffff00] Soon I will die... Promise me this " + names_script.player +"[/color]");
			yield return new WaitForSeconds(5);
			my_text.DisplayText( "No , no , no...");
			yield return new WaitForSeconds(5);
			my_text.DisplayText( "[color #ffff00] When I turn... You will kill me. [/color]");
			yield return new WaitForSeconds(5);
			my_text.DisplayText( "[color #ffff00] Don't cry my love. I am happy that I saw you one last time. [/color]");
			yield return new WaitForSeconds(5);
			my_text.DisplayText( "No " + names_script.mother + ",please...");
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "[color #ffff00] I love you...[/color]");
			yield return new WaitForSeconds(5);
			StartCoroutine(Coroutine_Transform_Wife());
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "NOOOOOOOOO!!!!!");
			yield return new WaitForSeconds(3);
			Debug.Log("Kano to wield weapon");
			input_script.Player.SetWeapon.TryStart(4);
		}
		
		
	}
	
	void Update () {
				
	
	
		if ( splatered) {
			
			if ( this.gameObject != null ) {
			
			if (splatered) {
				
				StartCoroutine(Coroutine_Die());
				}
			}
			
		}
				
	
	}
		
	IEnumerator Coroutine_Transform_Wife(){
		
		wife_anime.SetBool("Die", true);
		
		yield return new WaitForSeconds(3);
		
		ParticleEmitter[] blood =  this.gameObject.GetComponentsInChildren<ParticleEmitter>();
		
		
		for ( int i = 0 ; i < blood.Length ; i++ ) {
			
			
			blood[i].emit = true;
			
		}
		GameObject.Find("Game_logic").GetComponent<game_logic>().Wife_transformed();
		splatered = true;
		
	}
	
	
	
	IEnumerator Coroutine_Die() {
		
		
		yield return new WaitForSeconds(2);
		Instantiate(monster,this.gameObject.transform.position, Quaternion.identity);
		GameObject.Find("Game_logic").GetComponent<game_logic>().StartCoroutine("Coroutine_Wife_Dead");
		Destroy(gameObject);
		
		

	}

}


/*
 * my_text.DisplayText( names_script.mother + " what happened? Where is everyone?");
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "[color #ffff00]" + names_script.player +"!You are back!! Thank goodness! [/color]");
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "What are these mosnters in the village. Where is " +  names_script.daughter+"?");
			yield return new WaitForSeconds(4);
			my_text.DisplayText( "[color #ffff00] It is curse! Suddenly everyone in the village started turning into monsters! [/color]");
			yield return new WaitForSeconds(4);
			my_text.DisplayText( "You mean the monsters are the villagers!?!? WHERE IS " +  names_script.daughter+"?");
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "[color #ffff00] They took her outside of the village! That's where the curse started!! You must find her!! [/color]");
			yield return new WaitForSeconds(4);
			my_text.DisplayText( "Come on, then we are leaving!");
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "[color #ffff00] You do not understand! I am also infected by the curse! I do not have much time left. I tried holding it, waiting for you. But it is getting me I can feel it. [/color]");
			yield return new WaitForSeconds(6);
			my_text.DisplayText( "[color #ffff00] Promise me you will find our daughter! And promise me something else... [/color]");
			yield return new WaitForSeconds(5);
			my_text.DisplayText( "No , no , no...");
			yield return new WaitForSeconds(5);
			my_text.DisplayText( "[color #ffff00] When I turn... You will kill me. [/color]");
			yield return new WaitForSeconds(5);
			my_text.DisplayText( "No " + names_script.mother + ",no ,no...");
			yield return new WaitForSeconds(4);
			StartCoroutine(Coroutine_Transform_Wife());
			yield return new WaitForSeconds(3);
			my_text.DisplayText( "NOOOOOOOOO!!!!!");
			yield return new WaitForSeconds(3);
 * 
 */