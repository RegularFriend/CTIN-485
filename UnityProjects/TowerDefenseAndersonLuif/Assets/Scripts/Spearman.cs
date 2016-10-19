using UnityEngine;
using System.Collections;

public class Spearman : MonoBehaviour {
	public float HP;
	public float attack;

	void Start () {
		HP = 5.0f;
		attack = 1.0f;
		this.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f); //to "turn off" the outline, set val to 0
	}

	void Update () {

	}

	void OnMouseOver () {
		this.GetComponent<Renderer>().material.SetFloat("_Outline", 0.003f);
	}

	void OnMouseExit () {
		this.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);
	}
}