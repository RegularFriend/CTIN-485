using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal")*speed, 0, Input.GetAxis("Vertical") * speed));
	}
}
