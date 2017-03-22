using UnityEngine;
using System.Collections;

public class caidaCubo : MonoBehaviour {
	public float tiempoAcumulado= 0f;
	public float tiempoSpawn;
	public bool X = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (X) {
			transform.Translate(0, 8*-Time.deltaTime,0);
		}
	
	}
	void OnCollisionEnter(Collision collider){
		if (collider.transform.CompareTag ("Player")){
		tiempoAcumulado += Time.deltaTime;		

			if (tiempoAcumulado > tiempoSpawn) {
			//	GetComponent <Rigidbody> ().useGravity = true;

			//	GetComponent <Rigidbody> ().isKinematic = false;
				X = true;

			}
		}
	}
}
