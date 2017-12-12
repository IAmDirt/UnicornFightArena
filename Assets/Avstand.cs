using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avstand : MonoBehaviour {

    public Transform other;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //kvadratrot trekant
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            print("Distance to other: " + dist);
        }
    /*
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            Mathf.Sqrt(Distance.x * Distance.x);
        }
	*/}
}
