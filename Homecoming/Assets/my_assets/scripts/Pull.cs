using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Pull : vp_Interactable {
	
	protected vp_FPInteractManager m_InteractManager = null;
	protected AudioSource m_Audio = null;
	protected bool is_pulled = false;
	public int ForceApplied = 1000;
	public Texture GrabStateCrosshair = null; // crosshair to display while holding this object
	
	
	// Use this for initialization
	void Start () {
		
		base.Start();
		// for normal interaction type
		//InteractType = vp_InteractType.Normal;
		InteractDistance = 50;

		m_InteractManager = GameObject.FindObjectOfType(typeof(vp_FPInteractManager)) as vp_FPInteractManager;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override bool TryInteract(vp_FPPlayerEventHandler player)
	{
		Debug.Log("eim,aio i pull");
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
		
		// if we have a grab state crosshair, set i
		/*if (GrabStateCrosshair != null)
			m_Player.Crosshair.Set(GrabStateCrosshair);
		else
			m_Player.Crosshair.Set(new Texture2D(0, 0));
		*/
		
		return true;
	}

	

	
	protected virtual void StartPull(){
		
		
		Debug.Log("Me travikse");
		Vector3 temp = m_Camera.Forward;
		temp.x = temp.x *(-ForceApplied);
		temp.y = temp.y *(-ForceApplied);
		temp.z = temp.z *(-ForceApplied);
		this.GetComponent<Rigidbody>().AddForce(temp);
		
		
	}
	
	protected virtual void StopPull() {
		
	}
	
}
