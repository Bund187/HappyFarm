using UnityEngine;
using System.Collections;

public class CoupleBehaviour : MonoBehaviour {

	bool die;
	Animator anim;
	int life, directionCollision;

	public float speed, distance;

	void Start () {
		life = 10;
		anim = GetComponent<Animator>();

	}
	void FixedUpdate(){
		CoupleMove ();
		CollisionDetector ();
	}
	void Update () {
		if (life <= 0)
			die = true;
		if (die) {
			anim.SetBool ("die", die);
			speed = 0;
		}
	}

	void CoupleMove(){
		transform.position= Vector2.MoveTowards (transform.position, GameObject.Find ("Player").transform.position, Time.deltaTime * speed);

	}
	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player") {
			col.gameObject.GetComponent<PlayerAtributes> ().Life -= 0.1f;
			//print ("Vida=" + col.gameObject.GetComponent<PlayerAtributes> ().Life);
		}
	}
	void CollisionDetector(){
		
		Vector2 down=transform.TransformDirection(Vector2.down);
		Vector2 up=transform.TransformDirection(Vector2.up);
		Vector2 left=transform.TransformDirection(Vector2.left);
		Vector2 right=transform.TransformDirection(Vector2.right);
		Debug.DrawRay(new Vector2(transform.position.x,transform.position.y-distance),down,Color.red);
		RaycastHit2D hit = Physics2D.Raycast (transform.position, down,0.5f);
		if(hit.collider!=null){
			directionCollision = 1;
			print ("colision abajo");
		}
		hit = Physics2D.Raycast (transform.position, up,0.5f);
		if(hit.collider!=null){
			directionCollision = 2;
			print ("colision arriba");
		}
		hit = Physics2D.Raycast (transform.position, left,0.5f);
		if(hit.collider!=null){
			directionCollision = 3;
		}
		hit = Physics2D.Raycast (transform.position, right,0.5f);
		if(hit.collider!=null){
			directionCollision = 4;
		}
		/*if(hit.collider==null){
			directionCollision = 0;
		}*/

	}

	public int Life {
		get {
			return this.life;
		}
		set {
			life = value;
		}
	}

	public int DirectionCollision{
		get{
			return this.directionCollision;
		}
		set{
			directionCollision = value;
		}
	}
}
