using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDirection : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMove;

    public Vector2 rightPos = new Vector2(0.8f, 0);
    public Vector2 upPos = new Vector2(0, 0.8f);

    // Update is called once per frame
    void Update()
    {
        SetDirection();
    }

    void SetDirection()
    {
        if (playerMove.currentDirection.x != 0 && playerMove.currentDirection.y == 0)
        {
            if(playerMove.currentDirection.x == 1)
            {
                transform.localPosition = rightPos;
            }
            else
            {
                transform.localPosition = -rightPos;
            }
        }

        else if(playerMove.currentDirection.x != 0 && playerMove.currentDirection.y != 0)
        {
            if (playerMove.currentDirection.y > 0)
            {
                transform.localPosition = upPos;
            }
            else
            {
                transform.localPosition = -upPos;
            }
        }

        else if(playerMove.currentDirection.y != 0 && playerMove.currentDirection.x == 0)
        {
            if (playerMove.currentDirection.y > 0)
            {
                transform.localPosition = upPos;
            }
            else
            {
                transform.localPosition = -upPos;
            }
        }
    }
}
