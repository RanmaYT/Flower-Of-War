using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColliderDisable : MonoBehaviour
{
    public int pointsNeeded;
    public PlayerPoints playerPoints;
    public TextMeshProUGUI text;

    private void Start()
    {
        text.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPoints.points >= pointsNeeded)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        text.SetText("I still need to kill more enemies to move forward");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        text.SetText("");
    }
}
