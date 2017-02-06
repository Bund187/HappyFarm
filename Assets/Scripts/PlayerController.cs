using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public bool canMove;
	public SpriteRenderer meleerend;
	public float impulse;

	GameObject pauseCanvas;
	bool isMovingL=true, isMovingR = true, isMovingU = true, isMovingD = true, blockMove=false;
	Animator anim;
	SpriteRenderer spriteRend;
	bool isPaused,isPressed;
	string idiom="esp";
	Rigidbody2D rigidb;

	void Start() {
		anim = GetComponent<Animator>();
		canMove = true;
		spriteRend = GetComponent<SpriteRenderer> ();
		rigidb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){

		if (!canMove)   
		{
			moveSpeed = 0;
			return;
		}
		Move();
	}

	void Update(){
		/*if ((Input.GetAxisRaw ("Pause") != 0)) {
			Pause ();
			pauseCanvas.SetActive (isPaused);	

		} else
			isPressed = false;*/
		
	}

	public void Pause(){
		if (!isPressed) {
			isPaused = !isPaused;
			if (isPaused)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
			isPressed = true;
		}
	}

	void Move() {
		float xMove = Input.GetAxisRaw("Horizontal");
		float yMove = Input.GetAxisRaw("Vertical");

		if (!blockMove) {
			if ((xMove > 0f || xMove < 0f) || (yMove > 0f || yMove < 0f)) { 
				if (isMovingR) {
					if (xMove > 0f) {
						spriteRend.flipX = false;
						meleerend.flipX = false;
						anim.SetFloat ("Speed", moveSpeed);
						rigidb.AddForce(new Vector2(impulse,0),ForceMode2D.Impulse);
					}
				}

				if (isMovingL) {
					if (xMove < 0f) {
						spriteRend.flipX = true;
						meleerend.flipX = true;
						anim.SetFloat ("Speed", moveSpeed);
						rigidb.AddForce(new Vector2(impulse*-1,0),ForceMode2D.Impulse);
					}
				}
				if (isMovingU) {
					if (yMove > 0f) {
						
						anim.SetFloat ("Speed", moveSpeed);
						rigidb.AddForce(new Vector2(0,impulse),ForceMode2D.Impulse);
					}
				}

				if (isMovingD) {
					if (yMove < 0f) {
						
						anim.SetFloat ("Speed", moveSpeed);
						rigidb.AddForce(new Vector2(0,impulse*-1),ForceMode2D.Impulse);
					}

				}

			} else {
				anim.SetFloat ("Speed", 0);

			}
		}



	}

	public bool BlockMove {
		get {
			return this.blockMove;
		}
		set {
			blockMove = value;
		}
	}
	public bool IsMovingR
	{
		get
		{
			return isMovingR;
		}

		set
		{
			isMovingR = value;
		}
	}

	public bool IsMovingL
	{
		get
		{
			return isMovingL;
		}

		set
		{
			isMovingL = value;
		}
	}

	public bool IsMovingU
	{
		get
		{
			return isMovingU;
		}

		set
		{
			isMovingU = value;
		}
	}

	public bool IsMovingD
	{
		get
		{
			return isMovingD;
		}

		set
		{
			isMovingD = value;
		}
	}
	public string Idiom {
		get {
			return this.idiom;
		}
		set {
			idiom = value;
		}
	}
	public GameObject PauseCanvas {
		get {
			return this.pauseCanvas;
		}
		set {
			pauseCanvas = value;
		}
	}

}
