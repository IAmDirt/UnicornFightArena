using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public float rotSpeed = 90;

    public Transform LookAtThis;
    bool PlayerClose;

    public Transform Spawner;
    public Transform Player;
    public float maxRange = 10;


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

            }
        //not close to spawner
        if (distance >= maxRange)
            {
                LookAtThis = GameObject.Find("spawnTargetPoint").transform;


            }

            Vector2 dir = LookAtThis.position - transform.position;

        dir.Normalize();
		float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed* Time.deltaTime);
	}
}
