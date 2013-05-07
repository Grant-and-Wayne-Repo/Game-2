using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public float SpawnTimer;
	public float WaveTimer;
	public float WaveTimerChange;
	public float StartingSpawnAmount;
	public float DifficultyLevel;
	public GameObject enemyPrefab;
	
	private GameObject player;
	// Use this for initialization
	void Start () {
	player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(SpawnTimer > 0f)
			SpawnTimer-= Time.deltaTime;
		if(SpawnTimer < 0f)
			SpawnTimer = 0f;
		if(SpawnTimer == 0f)
		{
			/*for(int i = 0; i < StartingSpawnAmount; i++)
			{
				GameObject Boss = (GameObject)Instantiate(BossClone);
				Boss.transform.position = this.transform.position;	
				Boss.transform.rotation = this.transform.rotation;
				Boss.transform.rotation = Quaternion.Euler(Random.value*360, 0, 0);
				
			}*/
			/*int rVal = Random.Range(0,3);
			switch(rVal)
			{
			case 1:
				SpawnCircle (15, 10, 10);
				break;
			case 2:
				SpawnSides ();
				break;
			case 3:
				SpawnX ();
				break;
			default:
				break;
			}*/
			//SpawnCircle(15, 30, 30);
			//SpawnSides (1, 10);
			SpawnReg (15);
			SpawnTimer = WaveTimer;
			WaveTimer += WaveTimerChange;
			StartingSpawnAmount +=1;
			DifficultyLevel +=1;
		}
	}
	void SpawnCircle (int numEnemies, float radiusX, float radiusY)
	{
		Vector3 center = player.transform.position;
		for(int i = 0; i <  numEnemies; i++)
		{
				var g = (i * 1.0)/numEnemies;
				float angle = (float)g * Mathf.PI * 2;
 
    			float x = Mathf.Sin(angle) * radiusX;
   				float y = Mathf.Cos(angle) * radiusY;
 
   				Vector3 pos = new Vector3(x, y, 0) + center;
				
				Instantiate(enemyPrefab, pos, Quaternion.identity);
		}
				
	}
	
	void SpawnSides(int direction, int numEnemies)
	{
		float bottom = Screen.height;
		float right = Screen.width;
		
		if(direction == 1)
		{
			Vector3 tempPos = new Vector3(0,10,0);
			for(int i = 0; i < numEnemies; i++)
			{
				Instantiate(enemyPrefab, tempPos, Quaternion.identity);
				tempPos.x += right/numEnemies;
			}
		}
		else 
		{
			Vector3 tempPos = new Vector3(0,0,0);
			for(int i = 0; i < numEnemies; i++)
			{
				Instantiate(enemyPrefab, tempPos, Quaternion.identity);
				tempPos.y += bottom/numEnemies;
			}
		}
	}
	
	void SpawnX ()
	{
		//X formation?
	}
	void SpawnReg(int numEnemies)
	{
		Vector3 tempPos = new Vector3(0,0,0);
		for(int i = 0; i < numEnemies; i++) 
		{
			float xR = Random.Range (0,50);
			float yR = Random.Range (0,50);
			
			tempPos.x = xR;
			tempPos.y = yR;
			
			Instantiate(enemyPrefab, tempPos, Quaternion.identity);
		}
	}
}
