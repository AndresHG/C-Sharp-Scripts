using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	 
	public GameObject target; 

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target.transform);
	}
}
