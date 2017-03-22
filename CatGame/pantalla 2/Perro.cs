using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Perro : MonoBehaviour
{
    GameObject target;
    Vector3 offset;
    public float damping = 4;
	public GameObject renacer;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        float distanciaV3;

        distanciaV3 = Vector3.Distance(transform.position, target.transform.position);

        if (target)
        {
            if (distanciaV3 < 8)
            {


                //	this.transform.position = target.transform.position;
                //	this.transform.rotation = target.transform.rotation;
                Vector3 desiredPosition = target.transform.position - offset;
                //meodo para movim suavizado de camara
                this.transform.position = Vector3.Lerp(this.transform.position, desiredPosition, Time.deltaTime * damping);
                // this.transform.LookAt(target.transform.position);

            }

        }
    }
    void OnTriggerEnter(Collider collider)
    {
		Debug.Log ("AAAAAA: " + collider.transform.gameObject.name);
		if (collider.transform.gameObject.tag == "bolapelo")
        {
			Debug.Log ("PPPPP");
            Destroy(this.gameObject);
        }
		if (collider.transform.gameObject.tag == "Player") {
			this.transform.position = renacer.transform.position;

		}
    }
}