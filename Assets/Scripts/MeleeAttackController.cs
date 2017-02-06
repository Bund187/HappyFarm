using UnityEngine;
using System.Collections;

public class MeleeAttackController : MonoBehaviour {

	public GameObject gun;

	//Animator anima;
	//Animation anim;
	public float seconds;
	public float impulse;
	void Start(){
		//anim = GetComponent<Animation> ();
		//anima = GetComponent<Animator> ();
		//seconds = Time.time+seconds;
		//print ("segundos=" + seconds);
	}

	void Update(){
		//StartCoroutine (WaitForAnimation ());

		//if (/*anima.GetCurrentAnimatorStateInfo (0).IsName ("MeleeAttack")*/anima.GetCurrentAnimatorStateInfo (0).length>=0.6f) {

		if(Time.time>seconds){
			print ("funciona="+Time.time);
			this.gameObject.SetActive (false);
			gun.SetActive (true);
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Enemy") {
			Rigidbody2D rigidb = col.GetComponent<Rigidbody2D> ();
			col.gameObject.GetComponent<EnemyDashBehaviour> ().Life -= 1;
			float x = col.gameObject.transform.position.x - GameObject.Find ("Player").transform.position.x;
			float y = col.gameObject.transform.position.y - GameObject.Find ("Player").transform.position.y;
			float x2 = x;
			float y2 = y;
			if (x < 0) x *= -1;
			
			if (y < 0) y *= -1;

			//Esta en horizontal
			if (x > y) {
				if (x2 < 0) { 		//Izquierda
					rigidb.AddForce(new Vector2(impulse*-1,0),ForceMode2D.Impulse);
					//col.transform.Translate (Vector2.left * Time.deltaTime * (col.transform.GetComponent<CoupleBehaviour> ().speed * 8));	
				} else {			//Derecha
					rigidb.AddForce(new Vector2(impulse,0),ForceMode2D.Impulse);
					//col.transform.Translate (Vector2.right * Time.deltaTime * (col.transform.GetComponent<CoupleBehaviour> ().speed * 8));	
				}	
			}
			//Esta en vertical
			if (x < y) {
				if (y2 < 0) {		//Arriba
					rigidb.AddForce(new Vector2(0,impulse*-1),ForceMode2D.Impulse);
					//col.transform.Translate (Vector2.up * Time.deltaTime * (col.transform.GetComponent<CoupleBehaviour> ().speed * 8));	
				} else {			//Abajo
					rigidb.AddForce(new Vector2(0,impulse),ForceMode2D.Impulse);
					//col.transform.Translate (Vector2.down * Time.deltaTime * (col.transform.GetComponent<CoupleBehaviour> ().speed * 8));	
				}
			}
		}
	}

	IEnumerator WaitForAnimation(){
		//anim.Play ("MeleeAttack");
		yield return new WaitForSeconds(0.5f);
		print ("funciona");
		this.gameObject.SetActive (false);
		gun.SetActive (true);
	
	}
}
