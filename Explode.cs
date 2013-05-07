using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	
	public bool Xplode;
	public GameObject exPrefab;
	
	void Start () {
		Xplode = false;
	}
	

	void Update () {
		if(Xplode == true)
		{
			Debug.Log ("BOOM");
			var xclone = Instantiate(exPrefab, this.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
