using UnityEngine;
using System.Collections;
using Leap;

public class FingerJoystick : MonoBehaviour {
	public Vector3 m_LeapScaling = new Vector3(0.02f, 0.02f, 0.02f);
	public GameObject Tractor;
	public int speed;
	private GameObject Tclone;
	private Controller controller;
	private GameObject Mcam;

	void Awake () 
	{
			controller = new Controller();
			Leap.UnityVectorExtension.InputScale = m_LeapScaling;
			Tclone = Instantiate(Tractor, transform.position, Quaternion.identity) as GameObject;
			Mcam = GameObject.Find ("Main Camera");
			Mcam.transform.parent = Tclone.transform;
			//Mcam.GetComponent<Follow>().target = Tclone.transform;
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
					Vector3 directionT = new Vector3 (firstList[0].Direction.x, firstList[0].Direction.y, 0);
					if(Tclone.transform.position.x >= 50)
				    {
						if(directionT.x >=0)
						directionT.x = 0;
					}
					if(Tclone.transform.position.x <= -50)
					{
						if(directionT.x <=0)
						directionT.x = 0;
					}
					if(Tclone.transform.position.y >= 50)
					{
						if(directionT.y >=0)
						directionT.y = 0;
					}
					if(Tclone.transform.position.y <= -50)
					{
						if(directionT.y <= 0)
						directionT.y = 0;
					}
					Tclone.transform.Translate(directionT * speed);
				}
		}
	
	}	
}
