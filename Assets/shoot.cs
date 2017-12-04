using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
/*
    public float width = 1;
    public float height = 1;
 //   public Vector3 position;

    public GameObject LookAt;
    public GameObject DamageThis;
    public float rotSpeed = 180f;
    */

    void start()
    {

    }


  /*  void Update()
    {
  //      DamageThis = GetComponent<GetClosesObject>().closest;

        if (DamageThis != null)
        {
            Vector3 position = transform.position;
            Vector3 diff = DamageThis.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            Debug.Log(curDistance);







            // GameObject LookAt = GetComponent<GetClosesObject>().closest
            Vector2 dir = DamageThis.transform.position - transform.position;

            dir.Normalize();
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
    }*/
}