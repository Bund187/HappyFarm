using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {

	void Update () {
		Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = target;

	}
}
