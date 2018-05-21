using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Alternative_Interact : vp_Interactable {
	
	protected vp_FPInteractManager m_InteractManager = null;
	protected AudioSource m_Audio = null;
	protected bool is_pulled = false;
	public int ForceApplied = 1000;
	public Texture GrabStateCrosshair = null; // crosshair to display while holding this object
	
	
	// Use this for initialization
	void Start () {
		
		base.Start();
		// for continuos interaction type
		InteractType = vp_InteractType.Normal;
		InteractDistance = 1000;

		m_InteractManager = GameObject.FindObjectOfType(typeof(vp_FPInteractManager)) as vp_FPInteractManager;
		
	}
	
	public override bool TryAlternativeInteract(vp_FPPlayerEventHandler player)
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
		
		m_Player.Register(this);
		m_Player.Interactable.Set(this);
		StartAlternativeInteract();
		
		return true;
	}
	
	
	protected virtual void StartAlternativeInteract(){
		
		
		Vector3 temp = m_Camera.Forward;
		temp.x = temp.x *(ForceApplied);
		temp.y = temp.y *(ForceApplied);
		temp.z = temp.z *(ForceApplied);
		this.GetComponent<Rigidbody>().AddForce(temp);
		
		
		
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
			StartPull();
		else
			StopPull();
		
		// if we have a grab state crosshair, set it
		/*if (GrabStateCrosshair != null)
			m_Player.Crosshair.Set(GrabStateCrosshair);
		else
			m_Player.Crosshair.Set(new Texture2D(0, 0));
		*/
		
		return true;
	}

	

	
	protected virtual void StartPull(){
		
		//is_pulled = true;
		Debug.Log("Me travikse");
		Vector3 temp = m_Camera.Forward;
		temp.x = temp.x *(-ForceApplied);
		temp.y = temp.y *(-ForceApplied);
		temp.z = temp.z *(-ForceApplied);
		this.GetComponent<Rigidbody>().AddForce(temp);
		
		
	}
	
	protected virtual void StopPull() {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
