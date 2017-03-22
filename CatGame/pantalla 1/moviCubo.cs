using UnityEngine;
using System.Collections;

public class moviCubo : MonoBehaviour {
	public bool X = true;
	public bool Y = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(X)
			transform.Translate( 8*-Time.deltaTime,0,0);
		if(Y)
			transform.Translate( 8*Time.deltaTime,0,0);
	}
	void OnTriggerEnter(Collider collider){

		if (collider.CompareTag ("CuboA")) {
			//Debug.Log ("COLISION CUBOA");
			X = false;
			Y = true;
		}
		if (collider.CompareTag ("CuboB")) {
			X = true;
			Y = false;
		}
  }
}
