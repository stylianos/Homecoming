using UnityEngine;
using System.Collections;

public class Source : MonoBehaviour {
	
	vp_FPPlayerEventHandler m_Player;
	bool test;

	void Awake()
	{
		test = false;
		
        m_Player = transform.GetComponent<vp_FPPlayerEventHandler>();

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Return))

		{
        	m_Player.PrintSomething.Send("Hello World!");
			
			m_Player.Test_message.Send(test);
			
			int hp_temp = m_Player.hp.Get();
			Debug.Log("to hp einai " + hp_temp);
			
	
		}
	}
	
	
}
