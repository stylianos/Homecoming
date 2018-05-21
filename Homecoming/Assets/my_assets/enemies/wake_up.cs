using UnityEngine;
using System.Collections;

public class wake_up : MonoBehaviour {
	
	Animation anime;
	public GameObject total_horror;
		
	void Awake () {
		

	}
	
	// Use this for initialization
	void Start () {
		
		vp_AI script = total_horror.GetComponent<vp_AI>();
		
		
		
		anime = this.GetComponent<Animation>();
		anime["Getup"].wrapMode = WrapMode.Once;
		anime.Play("Getup");
		
		vp_Timer.In(2f , delegate() { script.enabled = true; } );
		
		//base.Start();
		
		//SetState("woke_up",true);
		//total_horror.animation.wrapMode = WrapMode.Once;
		//total_horror.animation.Play();
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
