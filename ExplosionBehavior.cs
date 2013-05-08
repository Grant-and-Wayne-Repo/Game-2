using UnityEngine;
using System.Collections;

public class ExplosionBehavior : MonoBehaviour {
	private bool test;
	private bool test2;
	public float size;
	
	public static int ecombo;
	public static int escore;
	public static bool EComboEnabled;
	private float timer;
	// Use this for initialization
	void Start () {
		test = true;
		test2 = false;
		ecombo = 0; 
		EComboEnabled = false;
		timer = 5.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(EComboEnabled)
		{
			timer -= Time.deltaTime;
		}
		if(test)
		{
		transform.localScale += new Vector3(0.25f,0.25f,0);
		}
		if(size > 0f)
			size -= Time.deltaTime;
		if(size < 0f)
			size = 0f;
		if(size == 0f)
		{
			test=false;
			StartCoroutine(Shrink ());
		}
		if(test2)
		{
			transform.localScale -= new Vector3(0.5f,0.5f,0);
			if(transform.localScale.x <= 0)
			{
				Destroy (gameObject);
			}
		}
	
	}
	IEnumerator Shrink(){
		yield return new WaitForSeconds(1);
		test2 = true;
		//Destroy(gameObject);
	}
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Destroy(other.gameObject);
			escore++;
			if(timer > 0)
			{
				EComboEnabled = true;
				ecombo++;
			}
			else if(timer <= 0)
			{
				EComboEnabled = false;
			}
			
		}
		if(other.gameObject.tag == "XPad")
		{
			other.gameObject.GetComponent<Explode>().Xplode = true;
		}
	}
}
