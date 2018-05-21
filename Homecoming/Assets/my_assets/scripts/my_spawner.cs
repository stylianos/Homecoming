using UnityEngine;
using System.Collections;

public class my_spawner : MonoBehaviour {
	
	
	public GameObject creature;
	bool spawned = false;
	
	BoxCollider m_Collider;
	
	// Use this for initialization
	void Start () {
		m_Collider = this.GetComponent<Collider>() as BoxCollider;
		m_Collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public virtual void OnTriggerEnter( Collider other )
	{
		if( other.gameObject.CompareTag("Player")){
			if (!spawned){
				
			
				Spawn();
				
				spawned = true;
					
				
			}
			
		}
			
	
	}
	
	public void Spawn(){
		
			for (int i = 0 ; i < 4 ; i++ ) {
					
					Reroll:
			
					// get a random position within the spawners bounds
					Vector3 min = m_Collider.bounds.min;
					Vector3 max = m_Collider.bounds.max;
					Vector3 randPos = new Vector3(Random.Range(min.x, max.x), max.y, Random.Range(min.z, max.z));
					
					// check to see if this is a good position to spawn, if not, reroll
					if (Physics.CheckSphere(randPos, 1f , vp_Layer.Mask.PhysicsBlockers))
						goto Reroll;
						
					// random rotation
					Quaternion randRot = Random.rotation;
					randRot.z = 0;
					randRot.x = 0;
			
					GameObject.Instantiate(creature, randPos , randRot);
					
					
				}
	}
}
