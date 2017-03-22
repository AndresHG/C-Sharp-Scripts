using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorInicio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //ir a partida 1
    
    public void irScenaUno()
    {

        Application.LoadLevel(LevelNames.NIVEL_PANTALLAUNO);
        
    }
}
