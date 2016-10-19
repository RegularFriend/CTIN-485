using UnityEngine;
using System.Collections;

public class Swordsman : MonoBehaviour {
	public float HP;
	public float attack;
	public float speed;
	bool moused;
	bool selected;
	bool isMoving;
	Vector3 targetPos;

	void Start () {
		HP = 5.0f;
		attack = 1.0f;
		speed = 5.0f;
		selected = false;
		isMoving = false;
		targetPos = transform.position;
		this.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f); //to "turn off" the outline, set val to 0
	}
	
	void Update () {
		if (Input.GetMouseButton (0)) {
			if (!moused) {
				if (selected) {
					SetSwordsmanPosition ();
				}
				selected = false;
				this.GetComponent<Renderer> ().material.SetFloat ("_Outline", 0.0f);
			}
		}

		if (isMoving) {
			MoveSwordsman ();
		}
	}

	void OnMouseOver () {
		moused = true;
		this.GetComponent<Renderer>().material.SetFloat("_Outline", 0.003f);
		if (Input.GetMouseButtonDown (0)) {
			selected = true;
		}
	}

	void OnMouseExit () {
		moused = false;
		if (selected) {
			this.GetComponent<Renderer> ().material.SetFloat ("_Outline", 0.003f);
		} else {
			this.GetComponent<Renderer> ().material.SetFloat ("_Outline", 0.0f);
		}
	}

	void SetSwordsmanPosition(){
		Plane plane = new Plane (Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float point = 0.0f;

		if (plane.Raycast (ray, out point)) {
			targetPos = ray.GetPoint (point);
		}

		isMoving = true;
	}

	void MoveSwordsman(){
		transform.LookAt (targetPos);
		transform.position = Vector3.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);

		if (transform.position == targetPos) {
			isMoving = false;
		}

		Debug.DrawLine (transform.position, targetPos, Color.red);
	}
}