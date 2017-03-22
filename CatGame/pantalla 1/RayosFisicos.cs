using UnityEngine;
using System.Collections;

public class RayosFisicos : MonoBehaviour {

    RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKey(KeyCode.W))
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(this.transform.position, forward,Color.red);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 back = transform.TransformDirection(Vector3.back) * 10;
            Debug.DrawRay(this.transform.position, back, Color.red);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 left = transform.TransformDirection(Vector3.left) * 10;
            Debug.DrawRay(this.transform.position, left, Color.red);

            //Debug.DrawLine(this.transform.position, this.transform.position + Vector3.left * 10, Color.green);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 right = transform.TransformDirection(Vector3.right) * 10;
            Debug.DrawRay(this.transform.position, right, Color.red);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray rayo = new Ray(this.transform.position, Vector3.right);


            if (Physics.Raycast(rayo, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
	
	}
}
