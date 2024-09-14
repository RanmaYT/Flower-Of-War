using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int attackDamage = 1;
    public float moveSpeed;
    public float detectionRange = 3;
    public bool playerOnRange;
    public LayerMask playerLayer;
    public Transform player;
    
    private Rigidbody2D rb;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerOnRange = CheckPlayerClose();

        SetPlayerPos();
    }

    private void FixedUpdate()
    {
        Move();
    }

    bool CheckPlayerClose()
    {
        return Physics2D.OverlapCircle(transform.position, detectionRange, playerLayer); 
    }

    private void SetPlayerPos()
    {
        if (playerOnRange)
        {
            player = Physics2D.OverlapCircle(transform.position, detectionRange, playerLayer).transform; 
        }
        else
        {
            player = null;
        }
    }

    private void Move()
    {
        Vector3 desiredDirection;

        if(playerOnRange)
        {
            desiredDirection = player.transform.position - transform.position;

            rb.velocity = desiredDirection.normalized * moveSpeed;
        }
        else
        {
            desiredDirection = originalPos - transform.position;

            if(desiredDirection != transform.position)
            {
                rb.velocity = desiredDirection.normalized * moveSpeed;
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    // Abstract is used to be something that everyone has, but it can have differences between some kinds of enemys, one may attack with fire, and another with a sword.
    protected abstract void Attack();
}
