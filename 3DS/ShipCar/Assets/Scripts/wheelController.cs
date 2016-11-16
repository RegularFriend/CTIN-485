using UnityEngine;
using System.Collections;

public class wheelController : MonoBehaviour {

	public GameObject player;

	private Vector3 mousePos;

	// Use this for initialization
	void Start () {
		Input.simulateMouseWithTouches = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			mousePos = Input.mousePosition;
		}

		if (Input.GetMouseButton(0))
		{
			Vector2 lastMouseWorldPos = (Vector2)Camera.main.ScreenToWorldPoint(mousePos);
			Vector2 currentMouseWorldPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

			Vector2 dirToLastMousePos = (lastMouseWorldPos - (Vector2)transform.position).normalized;
			Vector2 dirToCurrentMousePos = (currentMouseWorldPos - (Vector2)transform.position).normalized;

			// Get angle of change
			float deltaAngle = Vector2.Angle(dirToCurrentMousePos, dirToLastMousePos);
			// Apply correct direction to the angle of change
			Vector3 cross = Vector3.Cross(dirToCurrentMousePos, dirToLastMousePos);
			if (cross.z > 0) deltaAngle = 360 - deltaAngle;

			// Rotate this game object
			transform.Rotate(0.0f,0.0f,deltaAngle);

			player.transform.rotation = Quaternion.Euler(0.0f,-transform.rotation.eulerAngles.z,0.0f);

			// Update mouse position
			mousePos = Input.mousePosition;
		}
	}
}
