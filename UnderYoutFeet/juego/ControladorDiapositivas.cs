using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDiapositivas : MonoBehaviour {
	//Diapositivas

	public int contadordiapositivas;
	public GameObject diapositiva1;
	public GameObject diapositiva2;
	public GameObject diapositiva3;
	public GameObject diapositiva4;
	public GameObject diapositiva5;



	// Use this for initialization
	void Start () {
		

		contadordiapositivas=0;

		diapositiva1.SetActive (false);
		diapositiva2.SetActive (false);
		diapositiva3.SetActive (false);
		diapositiva4.SetActive (false);
		diapositiva5.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("contadordips: " + contadordiapositivas);

	
	}
	void OnTriggerStay (Collider collider)
	{
		if (collider.CompareTag ("contadorDiapositivas")) {
			Debug.Log ("stas en poniendo diapositivas");
				
			if (Input.GetKeyUp (KeyCode.F))
			{
				if ( contadordiapositivas == 4) {
					diapositiva4.SetActive (false);
					diapositiva5.SetActive (true);
					contadordiapositivas = 0;

				}

				if ( contadordiapositivas == 3) {
					diapositiva3.SetActive (false);
					diapositiva4.SetActive (true);
					contadordiapositivas++;

				}

				if ( contadordiapositivas == 2) {
					diapositiva2.SetActive (false);
					diapositiva3.SetActive (true);
					contadordiapositivas++;
					Debug.Log ("HAS PULSADO LA f D3");

				}

				if (contadordiapositivas == 1) {
					diapositiva1.SetActive (false);
					diapositiva2.SetActive (true);
					contadordiapositivas++;
					Debug.Log ("HAS PULSADO LA f D2");
				}

				if(contadordiapositivas == 0) {
					Debug.Log ("HAS PULSADO LA f D1");
					diapositiva1.SetActive (true);
					diapositiva5.SetActive (false);

					contadordiapositivas++;
				}
			}
		}
	}

}
