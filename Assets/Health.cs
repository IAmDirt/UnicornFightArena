using UnityEngine;

public class Health : MonoBehaviour {

    public bool isPlayer;
    public int health = 3;

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}