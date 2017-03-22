
using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Apuntar : MonoBehaviour
{
	public float rotationSpeed = 1;
	GameObject target;
	public float seeDistance = 1;
	public float fireDistance = 1;
	public GameObject[] arrayMisil;
	public int indice;
	float lastShoolTime = 0 ;
	public float coolDown = 2;
	// Use this for initialization
	private List<GameObject> arrayCanyon; 
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player");



		/*for (int i=0; i>transform.childCount; i++) {
			Transform child = transform.GetChild (i);
			if (child.CompareTag ("cabezatorreta")) {*/
			
				arrayMisil = GameObject.FindGameObjectsWithTag ("cabezatorreta");
				indice = 6;
			//}
		//}
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (target) {
			if (CanSeeTarget (seeDistance, target.transform.position)) {
				//if target sirve para saber si el objeto sta o no destruido

				this.transform.rotation = AimRotation (this.transform, target.transform.position, rotationSpeed);
			}



			if (CanSeeTarget (fireDistance, target.transform.position)) { 

				Disparar disparo = GetComponent <Disparar > ();
				if (disparo) {
					if (indice < arrayMisil.Length) {
						if (lastShoolTime + coolDown <= Time.time) {
							lastShoolTime = Time.time;

							Debug.Log ("numero array" + indice);
							disparo.Fire (arrayMisil [indice]);
							indice++;
						}
						
					} else {
						indice = 0;
					}
				}
			}
		} else {
			target = GameObject.FindGameObjectWithTag ("Player");
		}
	}
					
	bool CanSeeTarget (float maxDistance, Vector3 targetPosition)
	{

		float distance = (Vector3.Distance (this.transform.position, targetPosition));
		if (distance <= maxDistance) {
			return true;
		} else {
			return false;
		}

	}
	//this es la cabeza de la torreta
	//ejer:metodo que nos devuelva una rotacion (quaternion) coge 2 verctor 3
	//metodo q calcula la rotacion necesaria para apuntar a "target"  a veloc "speed"
	/*
		 * GameObjet>Trasform> vector 3+ quaternion +....
		 * verctor3 targetPosition
		 * float speed (v rotacion)
		 */
	Quaternion AimRotation (Transform originTranform, Vector3 targetPosition, float Speed)
	{

		// calcular cuanto rotar para mirar al target(avion)
		Quaternion targetRotation = Quaternion.LookRotation (targetPosition - originTranform.position);
		// calculamos cuanto tenemos que rotar debuelve una rotacion 
		// "Slerp" calcula d manera suave la rotacion
		Quaternion rotation = Quaternion.Slerp (this.transform.rotation, targetRotation, Time.deltaTime * Speed); 
		return rotation;

	}
			

		
	
}
