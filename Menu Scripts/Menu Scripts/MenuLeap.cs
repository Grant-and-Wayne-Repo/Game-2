using UnityEngine;
using System.Collections;
using Leap;

public class MenuLeap : MonoBehaviour {
	public Vector3 m_LeapScaling = new Vector3(0.02f, 0.02f, 0.02f);
	public GameObject Tractor;
	public int speed;
	private GameObject Tclone;
	private Controller controller;
	//private GameObject Mcam;

	void Awake () 
	{
			controller = new Controller();
			Leap.UnityVectorExtension.InputScale = m_LeapScaling;
			Tclone = Instantiate(Tractor, transform.position, Quaternion.identity) as GameObject;
	}
	
	void Update () 
	{
		Frame frame = controller.Frame(); 
		if(!frame.Hands.Empty)
		{
				Hand firstHand = frame.Hands[0];
				FingerList firstList = firstHand.Fingers;
				if(!firstList.Empty)
				{
					Vector3 selector = new Vector3 (firstList[0].Direction.x, firstList[0].Direction.y, 3.5f);
					Tclone.transform.position = selector;
				}
		}
	
	}	
}
