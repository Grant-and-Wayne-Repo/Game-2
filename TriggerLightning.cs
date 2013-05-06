using UnityEngine;
using System.Collections;

public class TriggerLightning : MonoBehaviour {
	public GameObject LPad;
	private LineRenderer LR;
	private Transform [] lPads;
	public int count;
	// Use this for initialization
	void Start () {
		lPads = new Transform[20];
		LR = new LineRenderer();
		
		LR = this.gameObject.AddComponent<LineRenderer>();
		count = 0;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "LPad")
		{
			count++;
			Debug.Log ("Hit");
			lPads[count] = other.gameObject.transform;
			if(lPads.Length > 1)
			{
				Vector3 mid = (lPads[count].position - lPads[count - 1].position)/2;
				var lclone = Instantiate(LPad, mid/*((lPads[1].position.y - lPads[0].position.y)/2)other.gameObject.transform.position*/, Quaternion.identity) as GameObject;
				
				lclone.transform.localScale += new Vector3(0, Vector3.Distance(lPads[count].position, lPads[count - 1].position), 5);
				
				LR.SetWidth(5, 5);
				LR.SetVertexCount(count);
				LR.SetPosition(0, lPads[count-1].position);
				LR.SetPosition(1, lPads[count].position);
			}
		}
		else if(other.gameObject.tag == "XPad")
		{
				other.gameObject.GetComponent<Explode>().Xplode = true;
		}
	}
}