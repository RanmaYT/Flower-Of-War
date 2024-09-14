using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public HealthBar healthBar;
    public AudioSource hurtSound;
    public bool isInvunerable;
    public float invunerabilityTime = 0.5f;

    private PlayerHealth playerHealth;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy") && !isInvunerable)
        {
            hurtSound.Play();

            anim.SetTrigger("hurt");

            playerHealth.currentHealth -= other.gameObject.GetComponent<Enemy>().attackDamage;

            healthBar.SetCurrentHealth(playerHealth.currentHealth);

            StartCoroutine(InvunerableTimer());
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isInvunerable)
        {
            hurtSound.Play();

            anim.SetTrigger("hurt");

            playerHealth.currentHealth -= other.gameObject.GetComponent<Enemy>().attackDamage;

            healthBar.SetCurrentHealth(playerHealth.currentHealth);

            StartCoroutine(InvunerableTimer());
        }
    }

    IEnumerator InvunerableTimer()
    {
        isInvunerable = true;
        yield return new WaitForSeconds(invunerabilityTime);
        isInvunerable = false;
    }
}
