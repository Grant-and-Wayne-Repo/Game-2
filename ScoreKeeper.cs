using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	public Rect scoreLabelRect = new Rect(10,10, 200, 50);
	public Rect timeLabelRect = new Rect(350, 10, 200, 100);
	static public int Score;
	
	
	void Start () {
		Score = 0;
	}
	
	void Update () {
		int sum = TriggerLightning.score + Explode.escore + Zap.zscore;
		Score = sum;
	}		
	void OnGUI()
	{
		GUI.Label (scoreLabelRect, "Score "+ Score.ToString());
		string ft = formatedTimeString(Time.time);
		GUI.Label (timeLabelRect,  ft);
	}
	private string formatedTimeString (float input) 
	{
   	 	int seconds;
    	int minutes;
 
    	minutes = Mathf.FloorToInt(input / 60);
    	seconds = Mathf.FloorToInt(input - minutes * 60);
    	string r = (minutes < 10) ? "0" + minutes.ToString() : minutes.ToString();
    	r += ":";
    	r += (seconds < 10) ? "0" + seconds.ToString() : seconds.ToString();
    	return r;
	}
}
