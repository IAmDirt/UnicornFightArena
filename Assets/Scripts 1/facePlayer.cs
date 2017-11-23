using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facePlayer : MonoBehaviour {

	public float rotSpeed = 90;

	public float maxSpeed = 8;
	public float Speed = 1;

	public float KnockBackForce = -20;
	Transform player;


	private Rigidbody2D rb2d;

	void Awake()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	//go forward
	void Update () 
	{
		if (Speed <= -10) 
		{
			Speed = 0f;
		}
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (0, Speed * Time.deltaTime, 0);

		pos += transform.rotation * velocity;

		transform.position = pos;

		if (Speed < maxSpeed)

			Speed += 0.04f;
		
		//face player
		if (player == null) 
			
		{

			GameObject go = GameObject.Find ("UnicornPlayer");
		
			if (go != null) 
			{
				player = go.transform;
			}
		
		}
		if (player == null)
		{
			return;
		}

		Vector3 dir = player.position - transform.position;
		dir.Normalize();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRot = Quaternion.Euler( 0, 0, zAngle );

		transform.rotation = Quaternion.RotateTowards( transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
	}
	//knockback
	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector2 knockbackDir){
		Debug.Log (knockbackDir);
		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime;
			Vector3 pos = transform.position;

			Vector3 velocity = new Vector3 (knockbackDir.x * KnockBackForce, knockbackDir.y * knockbackPwr);

			pos += transform.rotation * velocity;

			transform.position = pos;
		//	rb2d.AddForce (new Vector2 (knockbackDir.x * KnockBackForce, knockbackDir.y * knockbackPwr));
		}

		yield return 0;

	}
//	dont colide with tag ("enemy")
	void OnCollisionEnter2D(Collision2D coll )
	{
		if (coll.gameObject.tag == "enemy") 
		{
			
		} 
		else 
		{	
			Vector2 collisionPoint = coll.contacts[0].point;
			Vector2 myPos = transform.position;
			Vector2 direction = myPos - collisionPoint;

			StartCoroutine (Knockback (0.02f, 350, direction.normalized * 10));
			Speed -= 3;
		}
	}
		
}