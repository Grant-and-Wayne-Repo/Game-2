using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	public Rect scoreLabelRect = new Rect(10,10, 200, 50);
	public Rect timeLabelRect = new Rect(350, 10, 200, 100);
	static public int Score;
	static public int ComboScore;
	
	private float multiplier;
	private bool addCombo;
	
	
	void Start () {
		Score = 0;
		ComboScore = 0;
		multiplier = 0f;
		addCombo = false;
	}
	
	void Update () {
		if(Zap.ComboEnabled || ExplosionBehavior.EComboEnabled || TriggerLightning.TComboEnabled)
		{
				ComboScore = Zap.zcombo + ExplosionBehavior.ecombo + TriggerLightning.tcombo;
				multiplier += Time.deltaTime;
		}
		else{
			ComboScore*=(int)multiplier;
			Zap.zcombo = 0;
			TriggerLightning.tcombo = 0;
			ExplosionBehavior.ecombo = 0;
			multiplier = 0;
			addCombo = true;
		}
				
		int sum = TriggerLightning.score + ExplosionBehavior.escore + Zap.zscore;
		Score = sum;
		if(addCombo)
		{
			Score += ComboScore;
			ComboScore = 0;
		}
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
