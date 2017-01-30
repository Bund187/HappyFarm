using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	public float speed=2f;

	bool goRight;
	Vector3 target;
	Rigidbody2D rigidb;
	Quaternion rotation;

	void Start () {
		goRight = GameObject.Find("Gun").GetComponent<SpriteRenderer> ().flipX;	
		rigidb = GetComponent<Rigidbody2D> ();
		target = Input.mousePosition;
		target.z = transform.position.z - Camera.main.transform.position.z;
		target = Camera.main.ScreenToWorldPoint (target);
		rotation = Quaternion.FromToRotation (Vector2.up, target - transform.position);
		transform.rotation = rotation;
	}
	void Update(){
		
		if (transform.position.x < -4 || transform.position.x > 4) {
			Destroy (this.gameObject);
		}
	}
	void FixedUpdate () {
		Move ();
	}

	void Move(){
		transform.Translate(Vector2.up * Time.deltaTime * speed);

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyBehaviour> ().Die = true;
		}
	}
}
