using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour {

	public GameObject misilPrefab;
	float lastShoolTime = 0 ;
	public float coolDown = 2;
	public int estado = 0;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () { 

	}
	public void Fire(GameObject parametro){
		if (lastShoolTime + coolDown <= Time.time) {
			//crea un obj y lo clona a partir del prefab
			Instantiate (misilPrefab, parametro.transform.position, parametro.transform.rotation);
			lastShoolTime = Time.time;
		} 

	}
/*	void Test(){
		GameObject[] arrayGO;
			arrayGo;
		
	}*/
}

