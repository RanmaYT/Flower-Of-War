using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackCenter;
    public LayerMask enemyLayer;
    public float attackRadius;
    public int attackDamage;
    public float attackCooldown = 0.75f;
    public float knockBackForce = 10f;

    private Animator anim;
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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

        // Check enemys hitted, do damage and push them away
        Collider2D[] enemys = Physics2D.OverlapCircleAll(attackCenter.position, attackRadius, enemyLayer);
        foreach(Collider2D enemy in enemys)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
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
