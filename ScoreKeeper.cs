using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	public Rect scoreLabelRect = new Rect(10,10, 200, 50);
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
	}
}
