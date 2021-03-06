﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    public bool GetNewHight;
    public float RandomShotHight;
    public float RandomShotUpOrDown;

    public GameObject DamageThis;
    public DamageType type = DamageType.DamagesPlayer;

    public GameObject[] Shot;
    public GameObject CurrentShot;
    public Renderer rend;
    public float rotSpeed = 500f;

    public bool animationHasEnded = true;

    void Start()
    {

        //tag random object fra lista
        //int index = Random.Range(0, Shot.Length);
        //CurrentShot = Shot[index];

        foreach (GameObject go in Shot)
        {
            rend = go.GetComponent<Renderer>();
            rend.enabled = false;
        }
    }

    void Update()
    {
        if (!GetNewHight)
        {
            //få spriten til av og til være opp ned
            RandomShotUpOrDown = Random.Range(1f, 3f);
            if (RandomShotUpOrDown < 2f)
            {
                RandomShotHight = Random.Range(0.8f, 3f);
                GetNewHight = true;
            }
            if (RandomShotUpOrDown > 2f)
            {
                RandomShotHight = Random.Range(-0.8f, -3f);
                GetNewHight = true;
            }
        }

        DamageThis = GetComponent<GetClosesObject>().closest;
        if (DamageThis != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //finn health script på enemy
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
                        int index = Random.Range(0, Shot.Length);
                        CurrentShot = Shot[index];

                        animationHasEnded = false;
                        CurrentShot.GetComponent<Renderer>().enabled = true;
                        StartCoroutine(wait());
                        health.TakeDamage();
                    }
                }
            }
            //sett scale of shot
            float distance = Vector3.Distance(DamageThis.transform.position, transform.position);
            Vector3 dir = DamageThis.transform.position - transform.position;

            foreach (GameObject go in Shot)
                go.transform.localScale = new Vector3(RandomShotHight, distance /2f, 0);
   

            // bare roter når du ikkje viser skuddet
            if (animationHasEnded)
            {
                //shot is allways pointing at enemy
                if (DamageThis != null)
                {
                    float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
                    Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
                }
            }
        }
    }
            IEnumerator wait()
            {
                    yield return new WaitForSeconds(0.1f);
                    CurrentShot.GetComponent<Renderer>().enabled = false;
                    animationHasEnded = true;
                    GetNewHight = false;
            }
        
}

public enum DamageType
{
    DamagesEnemy,
    DamagesPlayer,
}