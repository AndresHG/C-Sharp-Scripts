using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickUpMenuInicio : MonoBehaviour {

	public GameObject playGameText;
    public GameObject hojaCreditos;

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	// Use this for initialization
	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
        hojaCreditos.SetActive(false);
        playGameText.SetActive(false);

    }
  

    // Update is called once per frame
    void FixedUpdate () {
		device =SteamVR_Controller.Input((int)trackedObj.index); //Gatillo

        /*if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
			Debug.Log ("stas tocando grip");

		}*/
       


    }
    void OnTriggerStay(Collider col)
    {

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("PILLAR");
            col.attachedRigidbody.isKinematic = true;
            col.gameObject.transform.SetParent(this.gameObject.transform);
            //
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;

            tossObject(col.attachedRigidbody);
        }
        if (col.CompareTag("Telefono"))
        {
            playGameText.SetActive(true);
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                //go play game
                this.ScenaJuego();
            }
        }
        if (col.CompareTag("maquinaDeEscribir")) {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                hojaCreditos.SetActive(true);
            }
        }
    }
	void OnTriggerExit(Collider col){
		if (col.CompareTag ("Telefono")) {
			playGameText.SetActive (false);

		}
	}

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
    public void ScenaJuego() {

        Application.LoadLevel (LevelNames.NIVEL_JUEGO);
    }

}
