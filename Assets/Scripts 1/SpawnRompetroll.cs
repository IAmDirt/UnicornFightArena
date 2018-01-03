using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRompetroll : MonoBehaviour {

    public GameObject ThisTargetPoint;
    public GameObject Player;
    public bool PlayerClose;
    public float maxRange = 18f;

    public GameObject Rompetroll;
    public Vector2 SpawnDirection;

    public float spawnRate;

    public float nextSpawn;
    void Update () {

        Player = GameObject.Find("UnicornPlayer");

        //distance
        float distance = Vector2.Distance(gameObject.transform.position, Player.transform.position);

        //if you are close to spawner
        if (distance <= maxRange)
        {
            PlayerClose = true;
        }
        //not close to spawner
        if (distance >= maxRange)
        {
            PlayerClose = false;
        }


        //spawn rompetroll
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            GameObject Spawn = Instantiate(Rompetroll);
            //set "rompetrol" target to this spawner's targetpoint
            Spawn.GetComponent<FacePlayer>().ThisTargetPoint = ThisTargetPoint;
            //set "rompetrol" spawner to this spawner
            Spawn.GetComponent<FacePlayer>().MySpawner = gameObject;
            Vector2 MyPosition = transform.position;
            Spawn.transform.position = MyPosition + SpawnDirection;
        }
    }
}