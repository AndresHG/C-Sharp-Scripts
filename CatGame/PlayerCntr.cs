using UnityEngine;
using System.Collections;

public class PlayerCntr : MonoBehaviour {

	public float speed;

	public float valorJump;

	public float velRot;

	public float timeDobleJump;
	private float tiempoAcumulado = 0f;

	public Transform posicionSpawn;

	public bool onJump=false;
	public bool dobleJump=true;
	private bool unavez = true;
	private float altura = 0f; 
	private CharacterController controller;

	private float movX;


	// Use this for initialization
	void Start () 
	{
		controller = gameObject.GetComponent<CharacterController> ();
	}

	void FixedUpdate()
	{
		if (Input.GetButton("Jump") && (!onJump || (dobleJump && tiempoAcumulado > timeDobleJump))) 
		{	
			if(onJump)
				dobleJump = false;
			
			onJump=true;
			tiempoAcumulado=0f;
		}  

		movX = Input.GetAxis ("Horizontal") * speed * Time.deltaTime ;

		if (movX > 0) 
		{
			transform.localRotation = Quaternion.RotateTowards(transform.localRotation,  Quaternion.Euler(new Vector3(0,0,0)), velRot * Time.deltaTime);
		} 
		else if (movX < 0)
		{
			transform.localRotation = Quaternion.RotateTowards(transform.localRotation,  Quaternion.Euler(new Vector3(0,-180f,0)), velRot * Time.deltaTime);
		}

	}

	// Update is called once per frame
	void Update () 
	{	
		
		if (onJump) 
		{
			tiempoAcumulado += Time.deltaTime;


			altura = (valorJump * 9.8f) * Time.deltaTime;
			valorJump -= speed * Time.deltaTime;

			if (!dobleJump && unavez) 
			{
				valorJump = 6f;
				unavez = false;
			}

			if (controller.isGrounded) 
			{
				altura = 0;
				valorJump = 4f;
				onJump = false;
				dobleJump = true;
				unavez = true;
			}

		} 
		else 
		{
			if (controller.isGrounded) 
			{
				altura = 0f;
			}
			else
			{
				altura -= speed * Time.deltaTime;
			}
		}

		controller.Move (new Vector3 (-movX, altura, 0));

		if (transform.position.y < -10f) 
		{
			transform.position = posicionSpawn.position;
		}

	}
	
}
