using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {

    //VR

    public bool manoLibre;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

	//ACCESO SCRIPT Menudesplegable
	MenuDesplegable menudesplegable;


	public bool AgendaAbierta;

	// props para inventario----------

	//agenda-----------------------------
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

		//objetos del inventario
	public GameObject CasseteInventario;
	public GameObject llavelaboratorioInventario;
	public GameObject luzNegraInventario;
	//--------------------------------




    // Use this for initialization
    void Awake () {
        manoLibre = true;
        trackedObj = GetComponent<SteamVR_TrackedObject>();   

		menudesplegable = GetComponent< MenuDesplegable> (); 


		//----------------------------------------
		//objetos inventario
		CasseteInventario.SetActive(false);
		llavelaboratorioInventario.SetActive (false);
		luzNegraInventario.SetActive (false);


		//--------------------------------------------

		AgendaAbierta = false;

		//menu principal
		menudesPlegablePg.SetActive(true);
		Inventario.SetActive(false);
		Informe.SetActive (false);
		Opciones.SetActive (false);

		//inventario
		Cassete.SetActive(false);
		LuzNegra.SetActive (false);


		menuOn = true;
		InventarioOn = false;
	

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    device =SteamVR_Controller.Input((int)trackedObj.index); //Gatillo

     
		//vaciar mano
		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
			llavelaboratorioInventario.SetActive (false);
			CasseteInventario.SetActive (false);
			luzNegraInventario.SetActive (false);
		}
    }

    public void setMano(bool par)
    {
        manoLibre = par;
    }


    void OnTriggerStay(Collider col)
    {
    //    Debug.Log("You have collided with " + col.name + " abd active obTriggerStay");

		if (AgendaAbierta == false) {
			if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
				Debug.Log ("PILLAR");
				col.attachedRigidbody.isKinematic = true;
				col.gameObject.transform.SetParent (this.gameObject.transform);
				//
			}
			if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger) ) {
				col.gameObject.transform.SetParent (null);
				col.attachedRigidbody.isKinematic = false;

				tossObject (col.attachedRigidbody);
			}
		}else{

			if (menuOn == true) {
				if (col.gameObject.CompareTag ("IconoInventario")) {
					

					if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
						menudesPlegablePg.SetActive (false);
						Inventario.SetActive (false);
						Opciones.SetActive (false);


						Informe.SetActive (true);
						menuOn = false;

					}
				}
				}
		}






//Menu desplegable:------------------------------------------------

		
	     

	//LLevar Objetos a inventario-----------------------------------------------------------------------------
		/*if (col.CompareTag("CintaCasete")){
			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Grip)) {
				menudesplegable.CasseteOn ();
				Destroy (col.gameObject);
				Debug.Log ("mandas objeto a inventario");
			}
		}*/
		/*if (col.CompareTag("luzNegra")){
			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Grip)) {
				menudesplegable.LuzNegraOn ();
				Destroy (col.gameObject);
				Debug.Log ("mandas objeto a inventario");
			}
		}*/
	
	//------------------------------------------------------------------------------------------------



	





    }
	//tirar Objetos
	void tossObject(Rigidbody rigidBody)
	{
		Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
		if (origin != null) {
			rigidBody.velocity = origin.TransformVector (device.velocity);
			rigidBody.angularVelocity = origin.TransformVector (device.angularVelocity);
		} else 
		{
			rigidBody.velocity = device.velocity;
			rigidBody.angularVelocity = device.angularVelocity;
		}
	
	}
	public void AbrirAgenda(){
		if (AgendaAbierta == false) {
		
			AgendaAbierta = true;
		} else {
			AgendaAbierta = false;
		}
	}
}
