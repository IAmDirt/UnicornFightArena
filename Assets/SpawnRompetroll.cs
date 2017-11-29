using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRompetroll : MonoBehaviour {

    public GameObject Rompetroll;
    public Vector2 SpawnDirection;

    public float spawnRate;
    float nextSpawn;

    void Update () {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            GameObject Spawn = Instantiate(Rompetroll);
            Vector2 MyPosition = transform.position;
            Spawn.transform.position = MyPosition + SpawnDirection;
        }
    }
}