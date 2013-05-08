using UnityEngine;
using System.Collections;

public class Zap : MonoBehaviour {
	
	public static int zscore;
	public static int zcombo;
	public static bool ComboEnabled;
	
	private float timer;
	
	// Use this for initialization
	void Start () {
		zscore = 0;
		zcombo = 0; 
		timer = 5.0f;
	}
	void Update ()
	{
		if(ComboEnabled)
		{
			timer -= Time.deltaTime;
		}
	}
	void OnTriggerEnter (Collider other) {
		Vector3 shake = new Vector3(1, 1, 0);
		if(other.gameObject.tag == "Enemy")
		{
			iTween.ShakePosition(other.gameObject, shake, 1.0f);
			Destroy(other.gameObject, .5f);
			zscore ++;
			if(timer > 0)
			{
				ComboEnabled = true;
				zcombo++;
			}
			else if(timer <= 0)
			{
				ComboEnabled = false;
			}
		}
	}
}
