using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public float width = 1;
    public float height = 1;
 //   public Vector3 position;

    public GameObject LookAt;
    public Transform DamageThis;
    public float rotSpeed = 180f;


    void start()
    {




        // set the scaling

        // set the position
  //      transform.position = position;
    }


    void Update()
    {
    //    width = GetComponent<GetClosesObject>().distance;
  //      Debug.Log(string.Format("width = ", + width));

        // set the scaling
//        Vector3 scale = new Vector3(height, width, 1f);
 //       transform.localScale = scale;
        // set the position
        //      transform.position = position;

        if (DamageThis != null)
        {
           // GameObject LookAt = GetComponent<GetClosesObject>().closest;
            DamageThis = LookAt.transform;

            Vector2 dir = DamageThis.position - transform.position;

            dir.Normalize();
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
    }
}