using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Wife_Text_Interact : vp_Interactable {
	
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
	
	public text_handler my_text;
	
	void Awake() {
		
		
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
		
		if (time_of_interact < 2)
			DisplayText();
		else
			Transform_Wife();
		
		
		return true;
	}

	

	
	protected virtual void DisplayText(){
		
		
		
		
		if ( time_of_interact == 0 ) {
			
			my_text.DisplayText("What the fuck?!");
			
		}
		
		if ( time_of_interact == 1 ) {
			
			my_text.DisplayText("Seriously???!?!?");
			
		}
		
		time_of_interact++;
		
			
		
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
		
	protected virtual void Transform_Wife(){
		
		
		ParticleEmitter[] blood =  this.gameObject.GetComponentsInChildren<ParticleEmitter>();
		game_logic test = GameObject.Find("Game_logic").GetComponent<game_logic>();
		Debug.Log(test);
		
		for ( int i = 0 ; i < blood.Length ; i++ ) {
			
			
			blood[i].emit = true;
			
		}
		
		splatered = true;
		
	}
	
	IEnumerator Coroutine_Die() {
		
		
		yield return new WaitForSeconds(2);
		Instantiate(monster,this.gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
		

	}

}
