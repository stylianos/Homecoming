using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {
	
	public GameObject target;
	public dfLabel hint;

	// Use this for initialization
	void Start () {
		this.gameObject.layer = 3;
		target = GameObject.Find("wife_transform");
		hint = GameObject.Find("hint").GetComponent<dfLabel>();
		hint.Text = "Get to your home";
		hint.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		this.GetComponent<MeshRenderer>().enabled = false;
		hint.enabled = false;
		if ( Input.GetKey(KeyCode.Tab)){
			Debug.Log("Patisa");
			hint.enabled = true;		
			Vector3 target_to_look = target.transform.position - transform.position;
			Vector3 newDir = Vector3.RotateTowards(transform.up, target_to_look, 5f , 0.0f);

			
			transform.rotation = Quaternion.LookRotation(newDir);
			transform.Rotate(Vector3.right , 90f ,Space.Self );
			//transform.LookAt(target1.transform);
			this.GetComponent<MeshRenderer>().enabled = true;
			
		}
	}
}
