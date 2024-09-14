using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioSource attackSound;
    public Transform attackCenter;
    public LayerMask enemyLayer;
    public float attackRadius;
    public int attackDamage;
    public float attackCooldown = 0.75f;
    public float knockBackForce = 10f;

    private Animator anim;
    private PlayerPoints playerPoints;
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerPoints = GetComponent<PlayerPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        // Trigger attack anim
        anim.SetTrigger("attacked");

        // Attack Sound
        attackSound.Play();

        // Check enemys hitted, do damage and push them away
        Collider2D[] enemys = Physics2D.OverlapCircleAll(attackCenter.position, attackRadius, enemyLayer);
        foreach(Collider2D enemy in enemys)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            playerPoints.points++;
        }

        // Trigger the attack cooldown
        StartCoroutine(AttackOnCooldown());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackCenter.position, attackRadius);
    }

    IEnumerator AttackOnCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
