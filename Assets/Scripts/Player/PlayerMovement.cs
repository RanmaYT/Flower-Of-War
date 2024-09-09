using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float hMove;
    public float vMove;
    public float speed;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(rb.velocity.magnitude);

        hMove = Input.GetAxisRaw("Horizontal");
        vMove = Input.GetAxisRaw("Vertical");
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
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
