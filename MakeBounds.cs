using UnityEngine;
using System.Collections;

public class MakeBounds : MonoBehaviour {
	public Transform thisTransform;

	
	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.A))
		{
			thisTransform.Translate(Vector3.left * 10);
		}
	else if(Input.GetKeyDown(KeyCode.D))
		{
			thisTransform.Translate(Vector3.right * 10);
		}
	else if(Input.GetKeyDown(KeyCode.W))
		{
			thisTransform.Translate(Vector3.up *10);
		}
	else if(Input.GetKeyDown(KeyCode.S))
		{
			thisTransform.Translate(Vector3.down * 10);
		}
		
	}
}
