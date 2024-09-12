using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float hMove;
    public float vMove;
    public float speed;
    public float lastDirectionUpdateTime = 0.5f;

    public bool isWalking;
    public bool isRunning;

    public Vector2 currentDirection;
    public Vector2 lastDirection;

    private Rigidbody2D rb;
    private bool alreadyDoubled;
    private bool alreadyUpdated;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        vMove = Input.GetAxisRaw("Vertical");

        currentDirection = new Vector2(hMove, vMove);

        Run();

        if(currentDirection != lastDirection && !alreadyUpdated && currentDirection != Vector2.zero)
        {
            lastDirection = currentDirection;
            StartCoroutine(UpdateLastDirection());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
       if(hMove != 0 || vMove != 0)
        {
            rb.velocity = new Vector2(hMove, vMove).normalized * speed;
            isWalking = true;
        }
        else
        {
            rb.velocity = Vector2.zero;
            isWalking = false;
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (!alreadyDoubled)
            {
                speed *= 2;
                alreadyDoubled = true;
            }

            isRunning = true;
        }
        else
        {
            isRunning = false;

            if (alreadyDoubled)
            {
                speed /= 2;
                alreadyDoubled = false;
            }
        }
    }

    IEnumerator UpdateLastDirection()
    {
        alreadyUpdated = true;
        yield return new WaitForSeconds(lastDirectionUpdateTime);
        alreadyUpdated = false;
    }
}
