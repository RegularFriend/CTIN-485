using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float speed = 50f;
	
	void Update () {
	if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) *speed *Time.deltaTime,Space.World);
        }
	}
}
