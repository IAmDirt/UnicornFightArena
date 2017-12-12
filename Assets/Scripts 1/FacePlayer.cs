using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public float rotSpeed = 90f;

    public bool PlayerClose;

    public Transform LookAtThis;
    public GameObject MySpawner;
    public GameObject ThisTargetPoint;

    private void Start()
    {
        LookAtThis = ThisTargetPoint.transform;
    }

    void Update()
    {
        PlayerClose = MySpawner.GetComponent<SpawnRompetroll>().PlayerClose;
        //what to look at
        if (!PlayerClose)

        {
            GetComponent<knockback>().maxSpeed = 3f;
            LookAtThis = ThisTargetPoint.transform;
        }
        if (PlayerClose)
        {
            GetComponent<knockback>().maxSpeed = 8f;
            LookAtThis = GameObject.Find("UnicornPlayer").transform;
        }

        //rotate
        if (LookAtThis != null)
        {
            Vector2 dir = LookAtThis.position - transform.position;

            dir.Normalize();
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
	}
}