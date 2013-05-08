using UnityEngine;
using System.Collections;
using Leap;
public class Restart : MonoBehaviour {
	
	private Controller controller;

	// Use this for initialization
	void Start () 
	{
		controller = new Controller();
	
		OnConnect(controller);
	}
	void OnConnect (Controller controller)
	{
        controller.EnableGesture (Gesture.GestureType.TYPECIRCLE);
        //controller.EnableGesture (Gesture.GestureType.TYPEKEYTAP);
        controller.EnableGesture (Gesture.GestureType.TYPESCREENTAP);
        //controller.EnableGesture (Gesture.GestureType.TYPESWIPE);
	}

	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		
		GestureList gestures = frame.Gestures ();
		for (int i = 0; i < gestures.Count; i++) 
		{
        	Gesture gesture = gestures [i];

        	switch (gesture.Type) 
			{
       		 	case Gesture.GestureType.TYPECIRCLE:
                	CircleGesture circle = new CircleGesture (gesture);
					//Application.LoadLevel(1);
					break;
				case Gesture.GestureType.TYPESCREENTAP:
					Debug.Log ("yo");
					ScreenTapGesture screentap = new ScreenTapGesture (gesture);
					//Application.LoadLevel(0);
					break;
				default:
					break;
			}
		}

	}
}
