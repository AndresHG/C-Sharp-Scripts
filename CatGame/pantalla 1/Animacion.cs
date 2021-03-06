using UnityEngine;
using System.Collections;

public class Animacion : MonoBehaviour {

	private float x;
	private float y;

	private Animator anim;

	private bool mD = false;
	private bool mU = false;
	private bool mR = false;
	private bool mL = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		//transform.Translate(x * Time.deltaTime, y * Time.deltaTime ,0);

		if (x > 0 && y == 0 && !mR)
		{
			anim.SetTrigger("MoveRight");

			mR = true;
			mD = mU = mL = false;
		}

		if (x < 0 && y == 0 && !mL)
		{
			anim.SetTrigger("MoveLeft");

			mL = true;
			mD = mU = mR = false;
		}

	}
}
