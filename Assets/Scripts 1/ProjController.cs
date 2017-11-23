using UnityEngine;
using System.Collections;

public class ProjController : MonoBehaviour {

	public KeyCode shoot;
	public float amount = 500;
	private Rigidbody2D rb2d; 

	void Start () 
	{

		rb2d = GetComponent<Rigidbody2D> ();
	}
		
	void Update () {

		if (Input.GetButton ("Fire1")) {


			Vector2 mp = new Vector2 (Input.mousePosition.x,Input.mousePosition.y);
			Vector3 wp = Camera.main.ScreenToWorldPoint(new Vector3(mp.x, mp.y, 0f));

			rb2d.AddForce (new Vector2(wp.x, wp.y), 0);

		}

	}
}
