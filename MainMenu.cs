using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GameObject play;
	public GameObject quit;
	public GameObject achievements;
	
	// Use this for initialization
	void Start () {
		Vector3 dest1 = new Vector3(0f,0f, 3.5f);
		iTween.MoveFrom(play.gameObject, dest1, 1.0f );
		
		Vector3 dest2 = new Vector3(0f, 0f, 3.5f);
		iTween.MoveFrom(quit.gameObject, dest2, 1.0f );	
		
		Vector3 dest3 = new Vector3(0f, 0f, 3.5f);
		iTween.MoveFrom(achievements.gameObject, dest2, 1.0f );	
		
		StartCoroutine(Activate());
	}
	
	// Update is called once per frame
	void Update () {

	}
	IEnumerator Activate()
	{
		yield return new WaitForSeconds(2);
		play.collider.isTrigger = true;
		quit.collider.isTrigger = true;
		achievements.collider.isTrigger = true;
	}
}

