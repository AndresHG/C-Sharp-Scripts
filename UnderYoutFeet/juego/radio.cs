using UnityEngine;
using System.Collections;

public class radio : MonoBehaviour {
	public bool casete;

	//acceso a otros scrips
	public GameObject GamecontrolesEvents;
	GameControlEvents gamecontoler;

	// Use this for initialization
	void Start () {
		casete = false;
		gamecontoler = gamecontoler.GetComponent<GameControlEvents> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider collider){
		if (collider.CompareTag ("CintaCasete")) {
			casete = true;
			Destroy (collider.gameObject);
		}
	}
}
