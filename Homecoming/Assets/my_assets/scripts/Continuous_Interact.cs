using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Continuous_Interact : vp_Interactable {
	
	protected vp_FPInteractManager m_InteractManager = null;
	protected AudioSource m_Audio = null;
	protected bool is_pulled = false;
	public int ForceApplied = 1000;
	public Texture GrabStateCrosshair = null; // crosshair to display while holding this object
	
	
	// Use this for initialization
	void Start () {
		
		base.Start();
		// for continuos interaction type
		InteractType = vp_InteractType.CollisionTrigger;
		InteractDistance = 50;

		m_InteractManager = GameObject.FindObjectOfType(typeof(vp_FPInteractManager)) as vp_FPInteractManager;
		
	}
	
	public override bool TryContinuousInteract(vp_FPPlayerEventHandler player)
	{
		
		//Debug.Log("Eimai i try ContinuosInteract");
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
		
		// set this object as the one the player is currently
		// interacting with
		m_Player.Register(this);
		m_Player.Interactable.Set(this);
		
		StartContinuousInteract();
		
		
		return true;
	}
	
	
	protected virtual void StartContinuousInteract(){
		
		this.GetComponent<vp_MovingPlatform>().enabled = true;
	}
	
	public virtual void OnStop_ContinuousInteract(){
		
		this.GetComponent<vp_MovingPlatform>().enabled = false;
	}
	
	
	

	// Update is called once per frame
	void Update () {
	
	}
}
