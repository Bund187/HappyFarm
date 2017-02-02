using UnityEngine;
using System.Collections;

public class MeleeAttackController : MonoBehaviour {

	Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void Update(){
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<CoupleBehaviour> ().Life -= 1;
			print ("Vida enemigo=" + col.gameObject.GetComponent<CoupleBehaviour> ().Life);
			float x = col.gameObject.transform.position.x - GameObject.Find ("Player").transform.position.x;
			float y = col.gameObject.transform.position.y - GameObject.Find ("Player").transform.position.y;
			float x2 = x;
			float y2 = y;
			if (x < 0) x *= -1;
			
			if (y < 0) y *= -1;

			//Esta en horizontal
			if (x > y) {
				if (x2 < 0) { 		//Izquierda
					col.transform.Translate (Vector2.left * Time.deltaTime * (col.transform.GetComponent<CoupleBehaviour> ().speed * 8));	
				} else {			//Derecha
					col.transform.Translate (Vector2.right * Time.deltaTime * (col.transform.GetComponent<CoupleBehaviour> ().speed * 8));	
				}	
			}
			//Esta en vertical
			if (x < y) {
				if (y2 < 0) {		//Arriba
					col.transform.Translate (Vector2.up * Time.deltaTime * (col.transform.GetComponent<CoupleBehaviour> ().speed * 8));	
				} else {			//Abajo
					col.transform.Translate (Vector2.down * Time.deltaTime * (col.transform.GetComponent<CoupleBehaviour> ().speed * 8));	
				}
			}
		}

	}
}
