using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppLoot : MonoBehaviour
{
    public GameObject WhatToDropp;
    bool HaveDroppedLoot;

    void Update()
    {
        Health health = GetComponent<Health>();

        if (!HaveDroppedLoot)
        {
            if (health.health <= 0)
            {
                GameObject dropp = Instantiate(WhatToDropp);
                Vector2 MyPosition = transform.position;
                dropp.transform.position = MyPosition;
                HaveDroppedLoot = true;
            }
        }
    }
}