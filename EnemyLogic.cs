using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {
	private Transform target;
	public float moveSpeed;
	
	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
			var lookDir = Quaternion.LookRotation(transform.position - target.transform.position, -Vector3.forward);
			lookDir.x = 0.0f;
			lookDir.y = 0.0f;
			transform.rotation = lookDir;
 
    		//move towards the player
    		//transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
			float step = moveSpeed*Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
