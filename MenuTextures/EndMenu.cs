using UnityEngine;
using System.Collections;

public class EndMenu : MonoBehaviour {

	public Rect endMenuRect = new Rect(400, 50 , 300, 300);
	public Rect endLabelRect = new Rect(450, 100, 100, 50);
	public Rect endTimeRect = new Rect(450, 150, 100, 50);
	public Rect replayButton = new Rect(450, 250, 50, 50);
	public Rect quitButton = new Rect(450, 250, 50, 50);
	public Rect info = new Rect(410, 110, 100, 100);
	public Texture replayIcon;
	public Texture quitIcon;
	public GUISkin def;
	static public bool end;
	
	private bool added;
	
	void Start()
	{
		end = true;
		added = false;
	}
	void OnGUI()
	{
		if(end == true)
		{
			GUI.skin = def;
			GUI.Box(endMenuRect, "END");
			GUI.Label(endLabelRect, "Score: " + ScoreKeeper.Score);
			GUI.Label (endTimeRect, "Time: " + Time.time);
			GUI.Label (info, "Circle Gesture to replay || ScreenTap to quit to main menu");
			GUI.Label (replayButton, replayIcon);
			GUI.Label (quitButton, quitIcon);
			Destroy(this.gameObject.GetComponent<Restart>());
			added = false;
		}
		
	}
	void Update()
	{
		if(end == true && added == false)
		{
			//this.gameObject.GetComponent<FingerJoystick>().enabled = false;
			this.gameObject.GetComponent<MenuLeap>().enabled = false;
			this.gameObject.AddComponent<Restart>();
			added = true;
		}
	}
}
