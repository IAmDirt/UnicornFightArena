
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	//late update betyr at denne vil gå etter Update (er akkurat det samme som update)
	void FixedUpdate ()
	{

		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		// alltid se på "player"
		//		transform.LookAt (target);
	}
}
