using UnityEngine;
using System.Collections;

public class GameControlEvents : MonoBehaviour {

	// Luz
	// luz ambiente
	public GameObject luzFondo;
	//luz negra
	public bool luzOnOff;
	public GameObject luzNegra;

	//luz proyector
	public GameObject luzproyector;


	// Use this for initialization
	void Start () {
		//luz
		luzOnOff= true;
		luzNegra.SetActive(false);
		luzproyector.SetActive(false);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
