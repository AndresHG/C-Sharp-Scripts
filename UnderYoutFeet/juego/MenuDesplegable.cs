using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class MenuDesplegable : MonoBehaviour {

	//vr
	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;

    public GameObject menudesPlegablePg;

	public bool menuOn;
	public bool InventarioOn;


    //menu principal
	public GameObject Informe;
    public GameObject Inventario;
	public GameObject Opciones;

  	//inventario
	public GameObject Cassete;
	public GameObject LuzNegra;


    // Use this for initialization
	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();   


        //menu principal
        menudesPlegablePg.SetActive(true);
        Inventario.SetActive(false);
		Informe.SetActive (false);
		Opciones.SetActive (false);

		//inventario
		Cassete.SetActive(false);
//		LuzNegra.SetActive (false);


		menuOn = true;
		InventarioOn = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
	//	device =SteamVR_Controller.Input((int)trackedObj.index); //Gatillo

	
	}


	void OnTriggerStay(Collider col)
	{
		/*if (menuOn == true) {

			if (col.gameObject.CompareTag ("IconoInventario")) {
				Debug.Log ("stas tocando inventario");
				if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
					menudesPlegablePg.SetActive (false);
					Inventario.SetActive (false);
					Opciones.SetActive (false);


					Informe.SetActive (true);
					menuOn = false;
			
				}

			}

			if (col.gameObject.CompareTag ("IconoInventario")) {
				if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
					menudesPlegablePg.SetActive (false);
					Informe.SetActive (false);
					Opciones.SetActive (false);

					InventarioOn = true;
					Inventario.SetActive (true);
					menuOn = false;
				}
			}

			if (col.gameObject.CompareTag ("IconoOpciones")) {
				if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
					menudesPlegablePg.SetActive (false);
					Informe.SetActive (false);
					Inventario.SetActive (false);

					Opciones.SetActive (true);
					menuOn = false;
				}

			}
		}
		if (InventarioOn == true) {
			
			Debug.Log ("stas en el inventario");
			if (col.gameObject.CompareTag ("IconoCassete")) {
				CasseteOn ();
			}



		}

			



	}


	//--------------------------------------------------------
	//inventario
	public void CasseteOn(){
		Cassete.SetActive (true);
	}
	public void LuzNegraOn(){
		LuzNegra.SetActive (true);
	}
	*/
	}
}
