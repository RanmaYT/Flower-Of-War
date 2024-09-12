using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement playerMove;
    private PlayerHealth playerHealth;
    private PlayerCollision playerColl;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMove = GetComponent<PlayerMovement>();
        playerColl = GetComponent<PlayerCollision>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetParameters();
    }

    void SetParameters()
    {
        anim.SetBool("isWalking", playerMove.isWalking);
        anim.SetBool("isDead", playerHealth.isDead);

        anim.SetFloat("x", playerMove.lastDirection.x);
        anim.SetFloat("y", playerMove.lastDirection.y);

    }
}
