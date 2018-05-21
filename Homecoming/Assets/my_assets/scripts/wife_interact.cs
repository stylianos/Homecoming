using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class wife_interact : vp_Interactable {
	
	protected vp_FPInteractManager m_InteractManager = null;
	protected AudioSource m_Audio = null;
	protected bool is_pulled = false;
	public int ForceApplied = 1000;
	public Texture GrabStateCrosshair = null; // crosshair to display while holding this object
	public GameObject monster;
	bool splatered = false;
	
	
	
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

		Transform_Wife();
		
		return true;
	}

	

	
	protected virtual void Transform_Wife(){
		
		Debug.Log("Ekana interact");
		ParticleEmitter[] blood =  this.gameObject.GetComponentsInChildren<ParticleEmitter>();
			
		for ( int i = 0 ; i < blood.Length ; i++ ) {
			
			blood[i].emit = true;
			
		}
		
		splatered = true;
		
	}
	
	protected virtual void StopPull() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if ( this.gameObject != null ) {
			
			if (splatered) {
				
				StartCoroutine(Coroutine_Test());
			}
		}
	}
	
	IEnumerator Coroutine_Test() {
	
		yield return new WaitForSeconds(1);
		Instantiate(monster,this.gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);	

	}
	
}
