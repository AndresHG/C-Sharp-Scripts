using UnityEngine;
using System.Collections;

public class ObjetosMenu : MonoBehaviour {
    public GameObject reload;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider col) {
        if (col.gameObject.CompareTag("volver")) {
            Debug.Log("objeto vuelve");
            this.transform.position = reload.transform.position;
        }
    }
}
