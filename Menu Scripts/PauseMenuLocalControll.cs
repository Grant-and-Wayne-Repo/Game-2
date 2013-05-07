using UnityEngine;
using System.Collections;

public class PauseMenuLocalControll : MonoBehaviour {
	static public int finalScore;
	public GUITexture play;
	public GUITexture quit;
	public GUIText score;
	
	void Start () {
		
		finalScore = ScoreKeeper.Score;
		score.text = finalScore.ToString();
		
	}

	void Update () {
		Vector3 nScale = new Vector3(0.05f, 0.075f,0f);
		Vector3 rScale = new Vector3(.01f, .01f,0f);
		//Vector3 chosen = new Vector3(play.gameObject.transform.position.x + 1.0f, play.gameObject.transform.position.y, 0f);
		if(Input.GetKey(KeyCode.A))
		{
			iTween.ScaleTo(play.gameObject, nScale, 1.0f);
			StartCoroutine(ChosenPlay());
		}
		else if(Input.GetKey(KeyCode.S))
		{
			
			iTween.ScaleTo(quit.gameObject, nScale, 1.0f);
			StartCoroutine(ChosenQuit());
		}
	}
	IEnumerator ChosenPlay()
	{
		Vector3 chosen = new Vector3(play.gameObject.transform.position.x + .05f, play.gameObject.transform.position.y, 0f);
   		yield return new WaitForSeconds(1);
		iTween.MoveTo(play.gameObject,chosen,1.5f);
		iTween.FadeTo(quit.gameObject, 0, 1f);
    	//Application.LoadLevel("gamescene");
	}
	IEnumerator ChosenQuit()
	{
		Vector3 chosen = new Vector3(quit.gameObject.transform.position.x -.05f, quit.gameObject.transform.position.y, 0f);
   		yield return new WaitForSeconds(1);
		iTween.MoveTo(quit.gameObject,chosen,1.5f);
		iTween.FadeTo(play.gameObject, 0, 1f);
		//Application.quit;
	}
}
