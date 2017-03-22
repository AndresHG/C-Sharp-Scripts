using UnityEngine;
using System.Collections;

public class CuboCaidaScript : MonoBehaviour {
	public GameObject ZonaCaida;
	Vector3 offset;
	GameControler gamecontroler;

	//componente animacion 
	public Animation componenteAnimator;

	// Use this for initialization
	void Start () {
		//componenteAnimator.SetBool ("caida cuadro despacho", false);
	}
	
	// Update is called once per frame
	void Update () {
		//float distanciaV3;
		//distanciaV3 = Vector3.Distance (transform.position, ZonaCaida.transform.position);
	
	}
	public void caidaCuadroAccion(){
		Debug.Log ("PlayAnim cuadro");
		componenteAnimator.Play ("caida cuadro despacho");

		//this.transform.position = ZonaCaida.transform.position;

	}
}
