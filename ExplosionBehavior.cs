using UnityEngine;
using System.Collections;

public class ExplosionBehavior : MonoBehaviour {
	private bool test;
	private bool test2;
	public float size;

	// Use this for initialization
	void Start () {
		test = true;
		test2 = false;
	
	}
	
	// Update is called once per frame
	void Update () {
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
}
