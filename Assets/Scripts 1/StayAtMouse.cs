using UnityEngine;
using System.Collections;


public class StayAtMouse : MonoBehaviour {

	public static int zAxisPos = 0; //Static because other scripts may need to get this.
	private float yAxisPos = -5.23f;
	public float xAxisBoundry = 7.5f;
	public float speed = 10f;

	void Update () {

		Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxisPos - Camera.main.transform.position.z);
		mouse = Camera.main.ScreenToWorldPoint(mouse);

		this.transform.position = new Vector3(mouse.x, mouse.y , zAxisPos);
	}
}