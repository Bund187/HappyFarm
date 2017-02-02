using UnityEngine;
using System.Collections;

public class PlayerAtributes : MonoBehaviour {


	float life;

	void Start () {
		life = 10;
	}
	

	void Update () {
		if (life == 0) {
			transform.GetComponent<PlayerController> ().moveSpeed = 0;
			Time.timeScale = 0;
		}
	}
	public float Life {
		get {
			return this.life;
		}
		set {
			life = value;
		}
	}
}
