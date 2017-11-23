using UnityEngine;
using System.Collections;

public class PlayerAddOns : MonoBehaviour {

	public float speed = 100;
	public Transform MousePoint;
	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

	public float bulletVelocity = 1f;
	public GameObject bullet;
	int bulletLayer;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;

	void Start() 
	{
		bulletLayer = gameObject.layer;
	}

	private void Update()
	{
		Vector2 direction = MousePoint.position - transform.position;
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, 360 * Time.deltaTime);

			cooldownTimer -= Time.deltaTime;

			if( Input.GetButton("Fire2") && cooldownTimer <= 0 ) 
			{
				cooldownTimer = fireDelay;

				Vector3 offset = transform.rotation * bulletOffset;

				GameObject bulletGO = (GameObject)Instantiate(bullet, transform.position + offset, transform.rotation);
				bulletGO.layer = bulletLayer;
			}
		}


}
