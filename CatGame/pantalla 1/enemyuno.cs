using UnityEngine;
using System.Collections;

public class enemyuno : MonoBehaviour {
	public bool X = true;
	public bool Y = false;
	public GameObject target; 
	public GameObject bomba;
	public float tiempoAcumulado= 0f;
	public float tiempoSpawn;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		if(X)
			transform.Translate( 8*-Time.deltaTime,0,0);
		if(Y)
			transform.Translate( 8*Time.deltaTime,0,0);
		float distanciaV3;

		distanciaV3 = Vector3.Distance (transform.position, target.transform.position);
		//Debug.Log ("distancia es de v3: " + distanciaV3);
		tiempoAcumulado += Time.deltaTime;

		if (distanciaV3 < 20 && tiempoAcumulado > tiempoSpawn) {

			Debug.Log ("STAS EN EL RADIO DE DISPARO ");

			GameObject prefabAux = GameObject.Instantiate (bomba, this.transform.position, Quaternion.identity) as GameObject;

			tiempoAcumulado = 0F;


		} else {
			
			//Debug.Log ("NO STAS EN EL RADIO DE DISPARO ");
		}
		

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
