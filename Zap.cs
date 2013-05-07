using UnityEngine;
using System.Collections;

public class Zap : MonoBehaviour {
	
	public static int zscore;
	// Use this for initialization
	void Start () {
	zscore = 0;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		Vector3 shake = new Vector3(1, 1, 0);
		if(other.gameObject.tag == "Enemy")
		{
			iTween.ShakePosition(other.gameObject, shake, 1.0f);
			Destroy(other.gameObject, .5f);
			zscore ++;
		}
	}
}
