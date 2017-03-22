using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {

	// Use this for initialization
	 	public bool Drag=false;
		public GameObject Player;
		public float speed;
		public float altura;

		private  RaycastHit hit;

		private Rigidbody rigid;
		

		// Use this for initialization
		void Start () 
		{
			rigid = this.GetComponent<Rigidbody> ();
			
		}

		// Update is called once per frame
		void Update () 
		{
		if (Input.GetKeyDown(KeyCode.E))
		{
			Ray rayo = new Ray(this.transform.position, Vector3.right);


			if (Physics.Raycast (rayo, out hit, 20)) {
				Debug.Log ("el raycastfunciona");

				if (hit.transform.gameObject.tag == "Diana"){
					Debug.Log (hit.transform.gameObject.name);
					Destroy (hit.transform.gameObject);
					Debug.Log ("rompesCubo");
				}
			}
			/*if (hit.collider.tag == "Diana") {
				Debug.Log ("el raycastfunciona");
				Destroy (hit.collider);
			}*/
			/*if (Drag)
			{
			Ray ray = Player.(Input.mousePosition);

			if (Physics.Raycast(ray, out hit)&&hit.collider.tag=="Diana" )
				{
				Debug.Log ("el raycastfunciona");
				if (Input.GetKey(KeyCode.D))
				{
					Vector3 right = transform.TransformDirection(Vector3.right) * 10;
					Debug.DrawRay(this.transform.position, right, Color.red);

					Destroy (hit.collider);
				}

				}
			}*/
		}


	
	}
}




