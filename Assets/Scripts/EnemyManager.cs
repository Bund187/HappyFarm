using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	float nextAction=0f;
	bool start;

	public float period;
	public GameObject enemy;

	void Update () {
		if (Time.time > nextAction) {
			nextAction += period;
			EnemySpawner ();	
		}
	}

	void EnemySpawner(){
		int posX = Random.Range (1, 3);
		if (posX == 1) {
			Instantiate (enemy, new Vector2 (4, Random.Range (-2.7f, 1.3f)), Quaternion.identity);
		} else {
			Instantiate (enemy, new Vector2 (-4, Random.Range (-2.7f, 1.3f)), Quaternion.identity);
		}
	}
}
