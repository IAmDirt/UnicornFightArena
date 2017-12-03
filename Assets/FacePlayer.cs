using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public float rotSpeed = 90f;

    public Transform LookAtThis;
    bool PlayerClose;

    public Transform Spawner;
    public Transform Player;
    public float maxRange = 10f;


    void Update()
    {
        Player = GameObject.Find("UnicornPlayer").transform;
        Spawner = GameObject.Find("RompetrollSpawner").transform;
        //distance
        float distance = Vector2.Distance(Spawner.position, Player.position);

        //if you are close to spawner
        if (distance <= maxRange)
            { 
                LookAtThis = GameObject.Find("UnicornPlayer").transform;
                GetComponent<knockback>().maxSpeed = 8f;
        }
        //not close to spawner
        if (distance >= maxRange)
            {
                LookAtThis = GameObject.Find("spawnTargetPoint").transform;
                GetComponent<knockback>().maxSpeed = 3f;

        }

            Vector2 dir = LookAtThis.position - transform.position;

        dir.Normalize();
		float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed* Time.deltaTime);
	}
}