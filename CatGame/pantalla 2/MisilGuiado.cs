using UnityEngine;
using System.Collections;

public class MisilGuiado : MonoBehaviour {
    float createTime ;
    public float lifeTime = 5;
    GameObject target;
    Vector3 offset;
    public float damping = 4;
    public float vida = 15f;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
       

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 15 * -Time.deltaTime, 0);

       


    }
    void LateUpdate()
    {
        if (target)
        {
            //	this.transform.position = target.transform.position;
            //	this.transform.rotation = target.transform.rotation;
            Vector3 desiredPosition = target.transform.position - offset;
            //meodo para movim suavizado de camara
            this.transform.position = Vector3.Lerp(this.transform.position, desiredPosition, Time.deltaTime * damping);
            //this.transform.LookAt(target.transform.position);
        }
       /* if (createTime + lifeTime <= vida)
        {
            //autodestruccion
            Debug.Log("destruir misil por tiempo");
            Destroy(this.gameObject);
        }*/
    }
}
