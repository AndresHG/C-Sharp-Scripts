using UnityEngine;
using System.Collections;

public class AbrirNeveraScript : MonoBehaviour {
	public Animation componentAnimator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void abrirNevera(){
		Debug.Log ("PlayAnim nevera");
		componentAnimator.Play();
	}
}
