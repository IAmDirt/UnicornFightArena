
using UnityEngine;
using System.Collections;

public class GetClosesObject : MonoBehaviour
{

    public GameObject closest;
    public float distance = 1;

    private void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemy");
        closest = null;
        distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            //Debug.Log(diff);
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
    }
}