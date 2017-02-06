using UnityEngine;
using System.Collections;

public class IAController : MonoBehaviour {

	public int dashing;

	void FixedUpdate(){
		//Dash (1);
	}

	void OnTriggerStay2D(Collider2D col){
		
		if (col.tag == "Bullet") {
			Dash (dashing);	
		}

	}

	void Dash(int dash){
		Rigidbody2D rigidb = transform.parent.GetComponent<Rigidbody2D> ();
		float x = transform.position.x - GameObject.Find ("Player").transform.position.x;
		float y = transform.position.y - GameObject.Find ("Player").transform.position.y;

		if (x < 0)
			x *= -1;
		if (y < 0)
			y *= -1;

		if (x > y) {
			switch(transform.parent.GetComponent<EnemyDashBehaviour> ().DirectionCollision){
			case 1:
				rigidb.AddForce(new Vector2(0,dash),ForceMode2D.Impulse);
				//transform.parent.Translate (Vector2.up * Time.deltaTime * (transform.parent.GetComponent<CoupleBehaviour> ().speed * dash));
				break;
			case 2:
				rigidb.AddForce(new Vector2(0,dash*-1),ForceMode2D.Impulse);
				//transform.parent.Translate (Vector2.down * Time.deltaTime * (transform.parent.GetComponent<CoupleBehaviour> ().speed * dash));
				break;
			}


		} 
		if(x < y){

			switch (transform.parent.GetComponent<EnemyDashBehaviour> ().DirectionCollision) {
			case 3:
				rigidb.AddForce(new Vector2(dash,0),ForceMode2D.Impulse);
				//transform.parent.Translate (Vector2.right * Time.deltaTime * (transform.parent.GetComponent<CoupleBehaviour> ().speed * dash));
				break;
			case 4:
				rigidb.AddForce(new Vector2(dash*-1,0),ForceMode2D.Impulse);
				//transform.parent.Translate (Vector2.left * Time.deltaTime * (transform.parent.GetComponent<CoupleBehaviour> ().speed * dash));
				break;
			}

		}
	}
}
