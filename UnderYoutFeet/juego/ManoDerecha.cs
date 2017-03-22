using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ManoDerecha : MonoBehaviour {
  SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    public GameObject agenda;
    public GameObject linterna;
    public bool AgendaLinterna;

	//linterna
	public bool	luzOnOff;


	public GameObject pickUp;
	PickupParent controlMenu;

    // Use this for initialization
    void Awake()
    {

        AgendaLinterna = true;//linterna es activa
        agenda.SetActive(false);

		//linterna
		luzOnOff= true;

		controlMenu = pickUp.GetComponent<PickupParent>(); 
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
		/*if (Input.GetKeyDown (KeyCode.A)) {
			pickUp.GetComponent<PickupParent>().enabled=false;
			controlMenu.GetComponent<MenuDesplegable> ().enabled = true;
		}*/
        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
            Debug.Log("stas tocando el boton lateral");
            if (AgendaLinterna == true)
            {
                //sacas agenda
                agenda.SetActive(true);
                linterna.SetActive(false);
                AgendaLinterna = false;

				//Activar y desactivar el pickup
				controlMenu.AbrirAgenda();
            }
            else
            {
                //sacas linterna
                agenda.SetActive(false);
                linterna.SetActive(true);
                AgendaLinterna = true;

				//Activar y desactivar el pickup

				controlMenu.AbrirAgenda();
            }

        }
		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)){


			//linterna

			if (AgendaLinterna == true) {
				if (luzOnOff == false) {
					linterna.SetActive (true);
					luzOnOff = true;
				} else {
					linterna.SetActive (false);
					luzOnOff =false;
					}

			}//agenda
			else{
				Debug.Log ("abres agenda");

			}
            
        }
    }
}
