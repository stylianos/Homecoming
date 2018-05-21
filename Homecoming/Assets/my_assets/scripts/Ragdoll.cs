using UnityEngine;
using System.Collections;

public class Ragdoll : MonoBehaviour {
	
	GameObject player;
	states_handler player_state;
	bool blown_away = false;
	
	
	public Vector3 forward_enemy;
	
	void Awake () {
		
		player = GameObject.Find("my_player");
		
	}
	// Use this for initialization
	void Start () {
		player_state = player.GetComponent<states_handler>();
		Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!blown_away){
			
			vp_Timer.In (0.0003f, BlowAway );
			//BlowAway();
			blown_away = true;	
		}
	}
	//final_move = false;
	
	
	void BlowAway(){
		//Debug.Log("To left einai KOUMPJIU " + player_state.left_button);
		//Debug.Log("Eimai o " + this.gameObject.name );
		Transform[] transforms = this.GetComponentsInChildren<Transform>();
			foreach(Transform t in transforms)
				if(t.GetComponent<Rigidbody>()){
			
					if ( this.gameObject.name == "Demon_ragdoll(Clone)"){
						return;
					}
					else if (player_state.left_button ) {
					 	Debug.Log("PAANOOOOOOOOOOOOOOOOO");
						t.GetComponent<Rigidbody>().AddForce( Vector3.up * 400f ,ForceMode.Impulse );
						return;
					}
					
					if (player_state.calm ) {
						
						t.GetComponent<Rigidbody>().AddForce( this.gameObject.transform.forward * (-5f));
					}
					else if ( player_state.light_angry ) {
	
						t.GetComponent<Rigidbody>().AddForce( this.gameObject.transform.forward * (-50f) ,ForceMode.Impulse );
						
					}
					
					else if (player_state.medium_angry) {
						//Debug.Log("Edo");
						t.GetComponent<Rigidbody>().AddForce( Vector3.up * 10f ,ForceMode.Impulse );
						t.GetComponent<Rigidbody>().AddForce( this.gameObject.transform.forward * (-30f) ,ForceMode.Impulse );
					}
					
				}
		
	}
	
	public void set_forward(GameObject test){
		
		forward_enemy = test.transform.forward;
		
	}

	
}
