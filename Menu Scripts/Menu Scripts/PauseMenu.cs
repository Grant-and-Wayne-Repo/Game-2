using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public GUITexture pauseMenu;

	void Start () {
		
		Vector3 dest1 = new Vector3(pauseMenu.gameObject.transform.position.x, pauseMenu.gameObject.transform.position.y - 10.0f, 0f);
		iTween.MoveFrom(pauseMenu.gameObject, dest1, 1.0f );
		
	}
}
