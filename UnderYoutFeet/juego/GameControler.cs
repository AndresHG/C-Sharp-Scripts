using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour {

	/*
	//CANVAS
	public Text PulsaFText;

	//Linterna
	public GameObject linterna;
	public bool luzLinternaOnOff;


	//objetos interactuables
	public bool PulsadoF;
	public bool casete;
	public bool caseteInRadio;
	public bool diapositivas;
	public bool keylaboratorio;
	public bool LinternaLuzNegra;


	//eventos
	public bool proyectorActive;
	public bool radioActive;

	//Acceso a otros scripts
	public GameObject cuadrocaida;
	CuboCaidaScript CuboCaida;

	public GameObject puertanevera;
	AbrirNeveraScript AbrirNevera;
	public bool neveraAbierta;

	//enigma cuadros
	public bool accesoEnigmaCuadros;
	public int numCuadro;
	public GameObject llaveLaboratorio;

	// Luz
	  // luz ambiente
	public GameObject luzFondo;
	  //luz negra
	public bool luzOnOff;
    public GameObject luzNegra;
	 
	   //luz proyector
	public GameObject luzproyector;
		


	// CONTRASEÑA LABORATORIO
	public GameObject contraseñaLaboratorio;
	public Text contraseñaText;
	public GameObject provetas;
	GameObject colliderprovetas;


	//	Caja Fuerte(el texto es el mismo que el texto del laboratorio)
	public bool CajaFuerteAbierta;
	public GameObject diapositivasOnOff;

	//diapositivas
	public GameObject colocadorDiapositivas;

	*/


    // Use this for initialization
    void Start () {
		
		/*

		PulsaFText.text= " ";
		PulsadoF = false;
		luzLinternaOnOff = false;

		//objetos interactuables
		casete = false;
		caseteInRadio = false;
		diapositivas = false;
		keylaboratorio = false;
		LinternaLuzNegra = false;
		//EVentos
		radioActive = false;
		proyectorActive = false;

		//acceso otros scripts
		CuboCaida = cuadrocaida.GetComponent<CuboCaidaScript>();
		AbrirNevera = puertanevera.GetComponent<AbrirNeveraScript> ();

		//ENIGMA CUADROS 
		accesoEnigmaCuadros= false;
		numCuadro=0;
		llaveLaboratorio.SetActive (false);

		//luz
		luzOnOff= true;
        luzNegra.SetActive(false);
		luzproyector.SetActive(false);

		// CONTRASEÑA LABORATORIO
		contraseñaLaboratorio.SetActive(false);
		neveraAbierta = false;
//		colliderprovetas = provetas.GetComponent<BoxCollider> ();
//		colliderprovetas.SetActive (false);

		//cajafuerte

		CajaFuerteAbierta = false;
		diapositivasOnOff.SetActive (false);

		//Diapositivas

		colocadorDiapositivas.SetActive (false);



		*/

	}
	
	// Update is called once per frame
	void Update () {
/*		if (luzOnOff == true) {
			luzFondo.SetActive (true);
		}
		if (luzOnOff == false) {
			luzFondo.SetActive (false);
		}
		//limnterna
		if(Input.GetKeyUp (KeyCode.L)){
			
			if (luzLinternaOnOff==true){
				luzLinternaOnOff = false;
				linterna.SetActive(false);
			}
			else{
				luzLinternaOnOff = true;
				linterna.SetActive(true);
			}
		}
	*/
	}

	void OnTriggerStay(Collider collider){
	/*	
		//Despacho----------------------------------------------

		if (collider.CompareTag ("CintaCasete")) {
			PulsaFText.text = "Pulsa F para coger Cinta de casete";
			if (Input.GetKeyUp (KeyCode.F)) {
				
				casete = true;

				Destroy (collider.gameObject);
			
				PulsaFText.text = " ";
			}
		}

		if (collider.CompareTag ("radio")) {
			if (PulsadoF == false) {
				PulsaFText.text = "Pulsa F para poner casete";
			}
			if (Input.GetKeyUp (KeyCode.F)) {
				PulsadoF = true;
				PulsaFText.text = " ";
				if (casete == false) {
					PulsaFText.text = "no tienes casete";
				}
				if (casete == true) {
					PulsaFText.text = "pones casete";
					radioActive = true;
					caseteInRadio = true;
					// EVENTO_ANIMACÓN
					CuboCaida.caidaCuadroAccion();
					accesoEnigmaCuadros = true;

					//luz
					luzOnOff= false;

					Debug.Log ("apagas luz");
					//PROYECTOR
					proyectorActive = false;
					luzproyector.SetActive (false);



				}
				if (caseteInRadio == true && luzOnOff == true) {
				//Suenan numeros en la radio
					Debug.Log("suenan numeros en la radio");
				}
			}
		}

		if (collider.CompareTag ("proyector") && luzOnOff== true) {
			if (PulsadoF == false) {
				PulsaFText.text = "Pulsa F para poner diapositivas";
			
				if (Input.GetKeyUp (KeyCode.F) && proyectorActive == false) {
					PulsadoF = true;
					PulsaFText.text = " ";
					proyectorActive = true;
					luzproyector.SetActive (true);


					if (diapositivas == false) {
						PulsaFText.text = "no tienes diapositivas";
					}
					if (diapositivas == true) {
						PulsaFText.text = "PON LAS DIAPOSITIVAS POR DELANTE";
						colocadorDiapositivas.SetActive (true);
						//EVEnto,animacion
						//Diapositivas

					}
				}

			}		
				
		}
		if (collider.CompareTag ("contadorDiapositivas")) {
			PulsadoF = true;
			PulsaFText.text = "pulsa F para pasar diapositiva";
		}


		if (collider.CompareTag ("llavelaboratorio")) {
			PulsaFText.text = "Pulsa F para coger llave";
			if (Input.GetKeyUp (KeyCode.F)) {
				
				keylaboratorio = true;

				Destroy (collider.gameObject);

				PulsaFText.text = " ";
			}
			
		}

		//-----------------------------------------------------
		// ENIGMA CUADROS:-------------------------------------
		if (accesoEnigmaCuadros == true) {
			
			if (collider.CompareTag ("cuadro1")) {
				if (PulsadoF == false) {
					PulsaFText.text = "Pulsa F para tocar cuadro";
					if (Input.GetKeyUp (KeyCode.F)) {
						PulsadoF = true;
						PulsaFText.text = " ";
						if (numCuadro == 0) {
							numCuadro++;
							Debug.Log ("vas bn");
						} else {
							numCuadro = 0;
							Debug.Log ("vas mal");
						}
					}
				}
			
			}
			if (collider.CompareTag ("cuadro2")) {
				if (PulsadoF == false) {
					PulsaFText.text = "Pulsa F para tocar cuadro";
					if (Input.GetKeyUp (KeyCode.F)) {
						PulsadoF = true;
						PulsaFText.text = " ";
						if (numCuadro == 1) {
							numCuadro++;
							Debug.Log ("vas  bn");
						} else {
							numCuadro = 0;
							Debug.Log ("vas mal");
						}
					}
				}

			}
			if (collider.CompareTag ("cuadro3")) {
				if (PulsadoF == false) {
					PulsaFText.text = "Pulsa F para tocar cuadro";
					if (Input.GetKeyUp (KeyCode.F)) {
						PulsadoF = true;
						PulsaFText.text = " ";
						if (numCuadro == 2) {
							numCuadro++;
							Debug.Log ("vas  bn");

						} else {
							numCuadro = 0;
							Debug.Log ("vas mal");
						}
					}
				}

			}
			if (collider.CompareTag ("cuadro4")) {
				if (PulsadoF == false) {
					PulsaFText.text = "Pulsa F para tocar cuadro";
					if (Input.GetKeyUp (KeyCode.F)) {
						PulsadoF = true;
						PulsaFText.text = " ";
						if (numCuadro == 3) {
							numCuadro++;
							Debug.Log ("vas  bn");
						} else {
							numCuadro = 0;
							Debug.Log ("vas mal");
						}
					}
				}

			}
			if (collider.CompareTag ("cuadro5")) {
				if (PulsadoF == false) {
					PulsaFText.text = "Pulsa F para tocar cuadro";
					if (Input.GetKeyUp (KeyCode.F)) {
						PulsadoF = true;
						PulsaFText.text = " ";
						if (numCuadro == 4) {
							numCuadro++;
							Debug.Log ("vas  bn");
						} else {
							numCuadro = 0;
							Debug.Log ("vas mal");
						}
					}
				}

			}
			if (collider.CompareTag ("cuadro6")) {
				if (PulsadoF == false) {
					PulsaFText.text = "Pulsa F para tocar cuadro";
					if (Input.GetKeyUp (KeyCode.F)) {
						PulsadoF = true;
						PulsaFText.text = " ";
						if (numCuadro == 5) {
							numCuadro++;
							Debug.Log ("consigues llave");
							llaveLaboratorio.SetActive (true);
						} else {
							numCuadro = 0;
							Debug.Log ("vas mal");
						}
					}
				}

			}
		}
		//--------------------------------------------------------------
		//LABORATORIO---------------------------------------------------	
		if (collider.CompareTag ("cuadroLuz")) {
			PulsaFText.text = "Pulsa F para encender/apagar luz";
			if (Input.GetKeyUp (KeyCode.F)) {

				PulsaFText.text = " ";
				if (Input.GetKeyUp (KeyCode.F)) {
					PulsadoF = true;
					PulsaFText.text = " ";
					if (luzOnOff == true) {
						luzOnOff = false;

						luzOnOff= false;

						Debug.Log ("apagas luz");
						//PROYECTOR
						proyectorActive = false;

						luzproyector.SetActive (false);

						Debug.Log ("apagas luz");
					} else {
						luzOnOff = true;
						Debug.Log ("enciendes luz");
					}
				}

			}
		}
		if (collider.CompareTag ("luzNegra")) {
			PulsaFText.text = "Pulsa F para cogerluz negra";
			if (Input.GetKeyUp (KeyCode.F)) {

				LinternaLuzNegra = true;

				Destroy (collider.gameObject);

				PulsaFText.text = " ";
			}
		}
        if (collider.CompareTag("EnchufeLuzNegra"))
        {
            PulsaFText.text = "Pulsa F para colocar luz negra";
            if (Input.GetKeyUp(KeyCode.F))
            {
                PulsaFText.text = " ";

                if (LinternaLuzNegra == true)
                {
                    luzNegra.SetActive(true);
                    PulsaFText.text = " ";
                }
                else {
                    PulsaFText.text = "falta la luz negra";
                }
                
            }
        }
		if (collider.CompareTag ("ordenador") && luzOnOff== true ) {
			PulsaFText.text = "pulsa la contraseña (HHH)";
			contraseñaLaboratorio.SetActive(true);


			if (contraseñaText.text== "HHH"){
				contraseñaLaboratorio.SetActive (false);
				PulsaFText.text = " ";
				Debug.Log ("abres nevera");
				//puertanevera.abrirNevera ();
				if (neveraAbierta == false) {
					
					neveraAbierta = true;
				
					AbrirNevera.abrirNevera ();

					colliderprovetas.SetActive (true);


				}
				
			}
		}
		if (collider.CompareTag ("CajaFuerte")){
			PulsaFText.text = "pulsa la contraseña 123";
			contraseñaLaboratorio.SetActive(true);
			if (contraseñaText.text == "123") {
				contraseñaLaboratorio.SetActive (false);
				PulsaFText.text = " ";
				Debug.Log ("abres CAJA FUERTE");
				diapositivasOnOff.SetActive (true);

				//puertanevera.abrirNevera ();
				if (CajaFuerteAbierta == false) {

					CajaFuerteAbierta = true;


				
					//animacion Abrir Caja Fuerte
				}
			}
		}
		if (collider.CompareTag ("Diapositivas")) {
			PulsaFText.text = "Pulsa F para coger Diapositivas";
			if (Input.GetKeyUp (KeyCode.F)) {

				diapositivas = true;

				Destroy (collider.gameObject);

				PulsaFText.text = " ";
			}
		}


		*/
        //--------------------------------------------------------------	
    }


	/*


		void OnTriggerExit(Collider collider) {

		//Despacho----------------------------------------------

					
		if (collider.CompareTag ("CintaCasete")) {
						PulsaFText.text= " ";
						PulsadoF = false;
					}

		if (collider.CompareTag ("radio")) {
				PulsaFText.text= " ";
				PulsadoF = false;
			}

		if (collider.CompareTag ("proyector")) {
				PulsaFText.text= " ";
				PulsadoF = false;
		}
		if (collider.CompareTag ("contadorDiapositivas")) {
			PulsadoF = false;
			PulsaFText.text = " ";
		}

		if (collider.CompareTag ("llavelaboratorio")) {
			PulsaFText.text= " ";
			PulsadoF = false;
		}
	
	//ENIGMA CUADROS-------------------------------
		if(collider.CompareTag("cuadro1")){
			PulsaFText.text= " ";
			PulsadoF = false;
		}
		if(collider.CompareTag("cuadro2")){
			PulsaFText.text= " ";
			PulsadoF = false;
		}
		if(collider.CompareTag("cuadro3")){
			PulsaFText.text= " ";
			PulsadoF = false;
		}
		if(collider.CompareTag("cuadro4")){
			PulsaFText.text= " ";
			PulsadoF = false;
		}
		if(collider.CompareTag("cuadro5")){
			PulsaFText.text= " ";
			PulsadoF = false;
		}
		if(collider.CompareTag("cuadro6")){
			PulsaFText.text= " ";
			PulsadoF = false;
		}
		//------------------------------------------
		//LABORATORIO-------------------------------

		if (collider.CompareTag ("cuadroLuz")) {
				PulsaFText.text= " ";
				PulsadoF = false;
			}

        if (collider.CompareTag("EnchufeLuzNegra")){ 

                PulsaFText.text = " ";
        PulsadoF = false;
    }
		if (collider.CompareTag ("ordenador")) {
			PulsaFText.text = " ";
			PulsadoF = false;
			contraseñaLaboratorio.SetActive(false);
		}
			if (collider.CompareTag ("CajaFuerte")){
					PulsaFText.text = " ";
					PulsadoF = false;
					contraseñaLaboratorio.SetActive(false);
					
				}

		if (collider.CompareTag ("Diapositivas")) {
			
			PulsaFText.text = " ";
			PulsadoF = false;
		}
    //--------------------------------------------------------------	
    }
	*/
}
