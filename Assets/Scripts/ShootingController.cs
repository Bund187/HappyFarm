using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour {

	public GameObject bulletPrefab;
	public float rotAngle;

	bool isPress,isShooting, isRight;
	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}
	

	void Update () {
		
		if ((Input.GetAxisRaw ("Fire1") != 0)) {
			if (!isPress) {
				Shoot ();
				isPress = true;
			}

		} else {
			isPress = false;
			isShooting = false;
			anim.SetBool ("Shooting", isShooting);
		}

		MoveAim ();

	}

	void Shoot(){
		isShooting = true;
		anim.SetBool ("Shooting", isShooting);
		isRight = transform.GetComponent<SpriteRenderer> ().flipX;
		if (isShooting) {
			if (isRight) {
				Instantiate (bulletPrefab, new Vector2(transform.position.x - 0.15f/*1.25f*/, transform.position.y + 0.03f), Quaternion.identity);

			} else {
				Instantiate (bulletPrefab, new Vector2 (transform.position.x + 0.15f/*-1.25f*/, transform.position.y + 0.03f/*-0.58f*/), Quaternion.identity);
			}
		}

	}

	void MoveAim(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (mousePos.x < transform.position.x) {
			transform.GetComponent<SpriteRenderer> ().flipY=false;

		}
		if (mousePos.x > transform.position.x) {
			transform.GetComponent<SpriteRenderer> ().flipY=true;
		}

		Vector3 diff = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		diff.Normalize ();
		float rotationZ = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0, 0, rotationZ - 180);

	}
}
