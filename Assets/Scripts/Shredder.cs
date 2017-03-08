using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
void OnTriggerEnter2D(Collider2D col){
	Destroy (col.gameObject);
}
	// Update is called once per frame
	void Update () {
	
	}
}
