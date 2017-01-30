using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	bool die,isRight=true;
	Animator anim;
	float speed;

	void Start () {
		anim = GetComponent<Animator>();
		speed = Random.Range (0.1f, 1f);
		if (transform.position.x <= -3.9) {
			transform.GetComponent<SpriteRenderer> ().flipX = true;
			isRight = false;
		}
	}
	void FixedUpdate(){
		if (isRight) {
			transform.Translate (Vector2.left * Time.deltaTime * speed);
		} else {
			transform.Translate (Vector2.right * Time.deltaTime * speed);
		}
	}
	void Update () {
		if (die) {
			anim.SetBool ("die", die);
			speed = 0;
		}
	}

	public bool Die {
		get {
			return this.die;
		}
		set {
			die = value;
		}
	}
}
