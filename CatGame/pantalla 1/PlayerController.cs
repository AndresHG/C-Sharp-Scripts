	using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public GameObject Zonarenacer;

	public float speed= 2f;
	public float altura = 1;

	public	float movx = 0f;
	public float movy = 0f;

	public bool tocandoSuelo = true;
	public float valorjump = 2f;
	private bool onJump = false;

    //canvas:
    
    public Text VidasText;
    public int vidas = 7;

    public Text PecesText;
    public int Peces=0;
	// doble salto

	public float timeDobleJump;
	private float tiempoAcumulado = 0f;

	public bool dobleJump=true;
	private bool unavez = true;
    //instanciate
    public GameObject bolapelo;
	public AudioSource player;
    //
    public Canvas menu;

    void Start(){
        VidasText.text = "vidas: " + vidas;
        PecesText.text = "Pescado: " + Peces;
    }

	void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.Space) && (!onJump || (dobleJump && tiempoAcumulado > timeDobleJump))) {	
			if (onJump) {
				dobleJump = false;
			}
				onJump = true;
			tiempoAcumulado = 0f;
		} 

	}
	void Update(){

		movx =	Input.GetAxis ("Horizontal");/** speed* Time.deltaTime*/
		movy = Input.GetAxis ("Vertical");/** speed* Time.deltaTime*/
		altura = (valorjump * 9.8F) * Time.deltaTime;

	
		//salto
	if (Input.GetKey (KeyCode.Space) && !onJump) {
			tocandoSuelo = false;
			tiempoAcumulado += Time.deltaTime;
			onJump = true;
			Debug.Log ("saltas");
			player.Play ();
			

		}
    //

        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("disparar bolas de pelo");
            GameObject BolaPelo = GameObject.Instantiate(bolapelo, this.transform.position, Quaternion.identity) as GameObject;

        }

	/*if (primersalto && Input.GetKey (KeyCode.Space) && doblesalto == false) {

                    onJump = true;
                    Debug.Log ("db");
                    doblesalto = true;


                }*/

        //detecta salto+

        if (onJump) {
			altura = -valorjump;
			valorjump -= speed * Time.deltaTime;

			if (!dobleJump && unavez) 
			{
				valorjump = 2f;
				unavez = false;
			}

			if (valorjump < 0 && tocandoSuelo) {
				altura = 1f;
				valorjump = 2f;
				onJump = false;
			}
			if (tocandoSuelo) 
			{
				
				valorjump = 2f;
				onJump = false;
				dobleJump = true;
				unavez = true;
			}
            //-------------------------------------------------------------
            



            //____-----------------------------

        }


			

		// mov fuerzas (riggitbody)
		Vector3 moveDirection= new Vector3(speed*movx,-9.8f*altura,speed*movy);

		moveDirection = transform.TransformDirection (moveDirection);

		GetComponent<Rigidbody> ().velocity = new Vector3 (moveDirection.x * 3f, moveDirection.y, moveDirection.z * 3f);

		GetComponent<Rigidbody> ().AddForce (Vector3.forward);
//--------------------------------------------------------------------
        if (vidas == 0)
        {
            Application.LoadLevel(LevelNames.NIVEL_INICIO);
        }

        //_----------Menu desplegable-------------------------------------------
        if (Input.GetKeyUp(KeyCode.M))
        {
            if (menu.isActiveAndEnabled)
            {
                Time.timeScale = 1f;
                menu.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                menu.gameObject.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
            }
        }

    }


	void OnCollisionEnter(Collision suelo){
		tocandoSuelo = true;

	
	}
	//Muertes
	void OnTriggerEnter(Collider collider){
		if (collider.CompareTag ("ZonaMuerte")) {
			Debug.Log ("caes zona muerte");
			this.transform.position = Zonarenacer.transform.position;
            vidas--;
            VidasText.text = "vidas: " + vidas;
        }
		if (collider.CompareTag ("bomba")) {
			Debug.Log ("te da la bomba");
			this.transform.position = Zonarenacer.transform.position;
            vidas--;
            VidasText.text = "vidas: " + vidas;
        }
        if (collider.CompareTag("SuperasLevel"))
        {
            Debug.Log("saltas de nivel");
            Application.LoadLevel(LevelNames.NIVEL_Dos);
        }

        if (collider.CompareTag("IrLevel3"))
        {
            Debug.Log("saltas de nivel");
            Application.LoadLevel(LevelNames.NIVEL_Tres);
        }
		if (collider.CompareTag("IrLevel4"))
		{
			Debug.Log("saltas de nivel");
			Application.LoadLevel(LevelNames.NIVEL_Cuatro);
		}
		if (collider.CompareTag("IrLevel5"))
		{
			Debug.Log("saltas de nivel");
			Application.LoadLevel(LevelNames.NIVEL_Cinco);
		}
        if (collider.CompareTag("win"))
        {
            Debug.Log("saltas de nivel");
            Application.LoadLevel(LevelNames.NIVEL_WinGame);
        }
        if (collider.CompareTag("Pez")) {
            Peces++;
            PecesText.text= "Pescado: " + Peces;
            Destroy(collider.gameObject);
        }

    }
}
