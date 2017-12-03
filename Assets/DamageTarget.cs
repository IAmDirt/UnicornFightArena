using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour {

    public GameObject DamageThis;
    public DamageType type = DamageType.DamagesPlayer;

    void Start()
    {
       // DamageThis = GetComponent<GetClosesObject>().closest;
    }

    void Update()
    {
        DamageThis = GetComponent<GetClosesObject>().closest;

        if (DamageThis != null)
        {
            Health health = DamageThis.GetComponent<Health>();

            if (health != null)
            {
                bool shouldDoDamage = false;
                if (type == DamageType.DamagesPlayer && health.isPlayer)
                    shouldDoDamage = true;
                else if (type == DamageType.DamagesEnemy && !health.isPlayer)
                    shouldDoDamage = true;

                if (shouldDoDamage)
                {
                   //health.TakeDamage();
                }
            }
        }
    }
}

public enum DamageType
{
    DamagesEnemy,
    DamagesPlayer,
}