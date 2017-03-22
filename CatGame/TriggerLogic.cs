using UnityEngine;
using System.Collections;

public class TriggerLogic : MonoBehaviour 
{
	public AudioSource sonido;
	public GameObject panel;

	private bool activado = false;
	
	void Start () 
	{
		sonido = GetComponent<AudioSource> ();

		sonido.Stop ();
	
		panel.SetActive (false);
	}

	void Update () 
	{
	
	}

	public void OnTriggerStay(Collider player)
	{
		if (player.gameObject.tag == "Player" && !activado) 
		{
			panel.SetActive(true);
			if(Input.GetKey(KeyCode.E))
			{
				sonido.Play();
				panel.SetActive(false);
				activado = true;
			}
		}
	}

	public void OnTriggerExit(Collider player)
	{
		if (player.gameObject.tag == "Player") 
		{
			panel.SetActive(false);
			activado = false;
		}
	}
}
