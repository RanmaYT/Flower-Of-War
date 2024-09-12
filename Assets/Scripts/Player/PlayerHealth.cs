using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool isDead;
    public int currentHealth;
    private int maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
