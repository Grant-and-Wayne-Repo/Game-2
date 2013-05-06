using UnityEngine;
using System.Collections;

public class Zap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "Enemy")
		{
			Destroy(other.gameObject);
		}
	}
}
