using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour {

    public GameObject DamageThis;
    public DamageType type = DamageType.DamagesPlayer;

    public GameObject Shot;
    public float rotSpeed = 360f;

    void Start()
    {

    }

    void Update()
    {
        DamageThis = GetComponent<GetClosesObject>().closest;
        if (DamageThis != null)
        {
            Health health = DamageThis.GetComponent<Health>();

            //damage enemy health--
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
            //Vector3 diff = go.transform.position - position;
            Vector3 dir = DamageThis.transform.position - transform.position;
            //dir = dir.normalized;
            float distance = dir.sqrMagnitude;
            //Shot.transform.localScale = new Vector3(1f, dir.x /-3f, 0);
            Debug.Log(distance);


            if (dir.x <= 0)
            {
                Shot.transform.localScale = new Vector3(1f, dir.x  /-3f, 0);
            }
            
            if (dir.x > 0)
            {
                Shot.transform.localScale = new Vector3(1, dir.x /3f, 0);
            }


            //shot is allways pointing at enemy
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
    }
}

public enum DamageType
{
    DamagesEnemy,
    DamagesPlayer,
}