using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Text_Interact : vp_Interactable {
	
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

	
	public text_handler my_text;
	
	void Awake() {
		
		text = GameObject.Find("Label").GetComponent<dfLabel>();
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
		
		if (!is_pulled)
			DisplayText();

		
	
		
		return true;
	}
		
	protected virtual void DisplayText(){
		
		if ( this.gameObject.name.Equals("old-tree"))
			my_text.DisplayText("Jessica always wanted a tree in our yard. She liked the shade.");
		if ( this.gameObject.name.Equals("saint_mary"))
			my_text.DisplayText("This where my daughter is buried...");
		if ( this.gameObject.name.Equals("WoodCart_home"))
			my_text.DisplayText("My old woodcart. Alice like to play with it. Where are they?");
		
	
	}

	

}
