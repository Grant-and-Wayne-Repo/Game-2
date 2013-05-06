using UnityEngine;
using System.Collections;

public class TriggerLightning : MonoBehaviour {
	public GameObject LPad;
	private LineRenderer LR;
	private Transform [] lPads;
	public int count;

	void Start () {
		lPads = new Transform[20];
		LR = new LineRenderer();
		
		LR = this.gameObject.AddComponent<LineRenderer>();
		count = 0;
	}
	
	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "LPad")
		{
			count++;
			Debug.Log ("Hit");
			lPads[count] = other.gameObject.transform;
			
			if(count == 2)
			{
				Vector3 mid = (lPads[count -1].position - lPads[count].position)/2 + lPads[count].position;
				var lclone = Instantiate(LPad, mid, Quaternion.identity) as GameObject;
				
				float dy = lclone.transform.position.y - lPads[count].position.y;
				float dx = lclone.transform.position.x - lPads[count].position.x;
        		float angle = Mathf.Atan2(dy,dx); 
				float rotZ = angle * (180/Mathf.PI) - 90;
				lclone.transform.eulerAngles = new Vector3(lclone.transform.rotation.x, lclone.transform.rotation.y, rotZ);
				lclone.transform.localScale += new Vector3(0, Vector3.Distance(lPads[count].position, lPads[count - 1].position), 5);
				
				LR.SetWidth(5, 5);
				LR.SetVertexCount(count);
				LR.SetPosition(0, lPads[count].position);
				LR.SetPosition(1, lPads[count-1].position);
				
				
				count = 0;
			}
			
		}
		else if(other.gameObject.tag == "XPad")
		{
				other.gameObject.GetComponent<Explode>().Xplode = true;
		}
	}
}