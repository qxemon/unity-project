using UnityEngine;
using System.Collections;
public class WaveSpawn : MonoBehaviour {

	public int WaveSize;
	public GameObject EnemyPrefab;
	public Transform spawnPoint;
	public Transform[] WayPoints;
	int enemyCount=0;

	void Update()
	{
		if(enemyCount == WaveSize)
		{
			CancelInvoke("SpawnEnemy");
		}
	}

	void SpawnEnemy()
	{
		enemyCount++;
		GameObject enemy = GameObject.Instantiate(EnemyPrefab,spawnPoint.position,Quaternion.identity) as GameObject;
        
		enemy.GetComponent<Enemy>().waypoints = WayPoints;
    }

	// call by GameManager, for starting wave as now wave number
	void WaveStart(float[] data) {
		InvokeRepeating("SpawnEnemy", data[0], data[1]);
		WaveSize = (int) data[2];
		enemyCount = 0;
	}
}
