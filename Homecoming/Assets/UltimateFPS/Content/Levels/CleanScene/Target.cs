using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
	
	vp_FPPlayerEventHandler m_Player;
	public int hp;

	void Awake()
	{

        m_Player = transform.GetComponent<vp_FPPlayerEventHandler>();
		hp = 4;
	}
	
	protected virtual void OnEnable()

	{

        if (m_Player != null)

                m_Player.Register(this);
			
	}

	protected virtual void OnDisable()

	{

        if (m_Player != null)

             m_Player.Unregister(this);

	}
	
	void OnMessage_PrintSomething(string s)

	{
        Debug.Log(s);

	}
	
	
	void OnMessage_Test_message(bool test) 
	{
		if (test)
			Debug.Log("True");
		else
			Debug.Log("False");
	}
	
	int OnValue_hp
	{
		get
		{
			return hp;	
		}
	}
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	protected virtual bool CanStart_Jump()
	{
		Debug.Log("Target");
		// always allowed to move vertically in free fly mode
		return true;

	}
	
	protected virtual bool CanStart_ContinuousInteract()
	{
		Debug.Log("lalal");
		// always allowed to move vertically in free fly mode
		return true;

	}

}
