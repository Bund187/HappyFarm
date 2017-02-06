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

	void FixedUpdate () {
		Move ();
	}

	void Move(){
		transform.Translate(Vector2.up * Time.deltaTime * speed);

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyDashBehaviour> ().Life-=1; //Se podria cambiar el Couple por un enemigo generico, ¿herencia?
			//print("vida enemy="+col.gameObject.GetComponent<CoupleBehaviour> ().Life);
			Destroy(this.gameObject);
		}
		if (col.tag == "Limits") {
			Destroy(this.gameObject);
		}
	}
}
