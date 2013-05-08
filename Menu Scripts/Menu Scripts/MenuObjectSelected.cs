using UnityEngine;
using System.Collections;

public class MenuObjectSelected : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator ChosenPlay()
	{
		Vector3 chosen = new Vector3(0f,0f,3.5f);
		this.collider.isTrigger = false;
   		yield return new WaitForSeconds(2);
		iTween.MoveTo(this.gameObject,chosen,2f);
    	Application.LoadLevel(1);
	}
	IEnumerator ChosenQuit()
	{
		Vector3 chosen = new Vector3(0f,0f,3.5f);
		this.collider.isTrigger = false;
   		yield return new WaitForSeconds(2);
		iTween.MoveTo(this.gameObject,chosen,2f);
		Application.Quit();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Selector")
		{
			Vector3 nScale = new Vector3(1.25f, 1.25f,1f);
			if(this.gameObject.tag == "Play")
			{
				iTween.ScaleTo(this.gameObject, nScale, 1.0f);
				StartCoroutine(ChosenPlay());
			}
			else if(this.gameObject.tag == "Quit")
			{	
				iTween.ScaleTo(this.gameObject, nScale, 1.0f);
				StartCoroutine(ChosenQuit());
			}
			else if(this.gameObject.tag == "Achievments")
			{
				iTween.ScaleTo(this.gameObject, nScale, 1.0f);
				StartCoroutine(ChosenQuit());
			}
		}
	}
}
