using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public AudioSource hurtSound;

    public int currentHealth;
    public int maxHealth = 10;
    public bool isDead;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
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

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Enemy>().enabled = false;
        this.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("hurt");

        hurtSound.Play();

        currentHealth -= damage;
    }
}
