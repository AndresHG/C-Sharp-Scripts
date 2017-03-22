using UnityEngine;
using System.Collections;

public class caidaBomba : MonoBehaviour {
	float createTime;
	public float lifeTime = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( 0,15*-Time.deltaTime,0);

       	/*if (createTime + Time.time <= lifeTime)
            {
                //autodestruccion
                Debug.Log("destruir misil por tiempo");
                Destroy ( this.gameObject);
            }*/


    }
    void OnTriggerEnter(Collider collider){
		if (collider.CompareTag ("suelo")) {
			Debug.Log("destruir misil impacto");
			Destroy ( this.gameObject);
		}
	}
}
