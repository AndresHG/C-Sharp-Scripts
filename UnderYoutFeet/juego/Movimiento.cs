using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Movimiento : MonoBehaviour {
	public GameObject pickUpScr;
	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;

    
    public int speed = 5;
    Vector3 ejetraslacion;

	public GameObject camara;

   public GameObject personaje;

	// Use this for initialization
	void Awake () {
		trackedObj = pickUpScr.GetComponent<SteamVR_TrackedObject>();   

	}

	
	// Update is called once per frame
	void FixedUpdate () {
		device = SteamVR_Controller.Input((int)trackedObj.index); //Gatillo
		Vector2 dire = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

      
        
        //get axis


		if(dire.y > 0.5)
		{
			personaje.transform.Translate (camara.transform.forward * speed * Time.deltaTime);
			Debug.Log ("Axis1 move");    //ARRIBA
         //   ejetraslacion = new Vector3(0, 0, speed * Time.deltaTime);
           // personaje.transform.Translate(ejetraslacion);


            //	movX =Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        }

		if(dire.x > 0.5 )
		{
			personaje.transform.Translate (camara.transform.right* speed * Time.deltaTime);
		/*	Debug.Log ("Axis2 move");	  //DERECHA
			//	movZ=Input.GetAxis("Vertical") * speed * Time.deltaTime;
			ejetraslacion = new Vector3( speed * Time.deltaTime,0, 0);
			personaje.transform.Translate(ejetraslacion);*/

	
		}

		if(dire.y < -0.5)
		{
			personaje.transform.Translate (-camara.transform.forward * speed * Time.deltaTime);
			/*Debug.Log ("Axis3 move");	  //ABAJO
			//movX =Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			ejetraslacion = new Vector3(0, 0, -speed * Time.deltaTime);
			personaje.transform.Translate(ejetraslacion);*/

		}

		if(dire.x  < -0.5)
		{
			personaje.transform.Translate (-camara.transform.right* speed * Time.deltaTime);
		/*	Debug.Log ("Axis4 move");	  //IZQUIERDA
			//movZ =Input.GetAxis("Vertical") * speed * Time.deltaTime;
			ejetraslacion = new Vector3( -speed * Time.deltaTime,0, 0);
			personaje.transform.Translate(ejetraslacion);*/

		}
	}
}

/*
Vector3 moveDirection= new Vector3(speed*input.GetAxis("Horizontal")),-9,8f*altura,speed....




*/