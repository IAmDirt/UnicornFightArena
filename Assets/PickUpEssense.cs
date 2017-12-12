using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEssense : MonoBehaviour
{
    public GameObject objectWeHit;
    public PickUpTypes type = PickUpTypes.PlayerPickup;

    void OnTriggerEnter2D(Collider2D other)
    {
        objectWeHit = other.gameObject;
        Health health = objectWeHit.GetComponent<Health>();

        if (health != null)
        {
            bool CanPickUp = false;
            if (type == PickUpTypes.PlayerPickup && health.isPlayer)
            {
                CanPickUp = true;
                Debug.Log("player has picked up something");
            }
            if (CanPickUp)
            {
                //health.TakeDamage();
                GameObject Parent = transform.parent.gameObject;
                Destroy(Parent);
                Destroy(gameObject);
                objectWeHit.GetComponent<TrackScore>().Score += 40f;


            }
        }
    }
}


public enum PickUpTypes
{
    EnemyPickUp,
    PlayerPickup,
}