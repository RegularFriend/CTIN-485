using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5.0f;
	public Transform respawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + transform.forward * speed * Time.deltaTime;

		if (Input.GetButton("Fire1"))
		{
			transform.position = respawnPoint.position;
		}
	}
}
