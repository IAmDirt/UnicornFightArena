using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnSpawn : MonoBehaviour {

    bool SetDirection;
    public float timer;
    bool AddFore;
    public float Speed;
    Rigidbody2D rb2d;
    Vector2 Direction;

    private void Update()
    {

        if (!SetDirection)
        {
            rb2d = GetComponent<Rigidbody2D>();
            float RandomX = Random.Range(-3f, 3f);
            Direction = new Vector2(RandomX, 10);
                SetDirection = true;
        }

            if (!AddFore)
            rb2d.AddForce(Direction * Speed);

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                AddFore = true;
            }


    }
}
