using UnityEngine;
using System.Collections;

public class IAController : MonoBehaviour {

	public int dashing;

	void FixedUpdate(){
		Dash (1);
	}

	void OnTriggerStay2D(Collider2D col){
		
		if (col.tag == "Bullet") {
			Dash (dashing);	
		}

	}

	void Dash(int dash){
		
		float x = transform.position.x - GameObject.Find ("Player").transform.position.x;
		float y = transform.position.y - GameObject.Find ("Player").transform.position.y;

		if (x < 0)
			x *= -1;
		if (y < 0)
			y *= -1;

		if (x > y) {
			switch(transform.parent.GetComponent<CoupleBehaviour> ().DirectionCollision){
			case 1:
				transform.parent.Translate (Vector2.up * Time.deltaTime * (transform.parent.GetComponent<CoupleBehaviour> ().speed * dash));
				break;
			case 2:
				transform.parent.Translate (Vector2.down * Time.deltaTime * (transform.parent.GetComponent<CoupleBehaviour> ().speed * dash));
				break;
			}


		} 
		if(x < y){

			switch (transform.parent.GetComponent<CoupleBehaviour> ().DirectionCollision) {
			case 3:
				transform.parent.Translate (Vector2.right * Time.deltaTime * (transform.parent.GetComponent<CoupleBehaviour> ().speed * dash));
				break;
			case 4:
				transform.parent.Translate (Vector2.left * Time.deltaTime * (transform.parent.GetComponent<CoupleBehaviour> ().speed * dash));
				break;
			}

		}
	}
}
