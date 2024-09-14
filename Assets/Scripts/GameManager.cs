using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverBG;
    public GameObject gamewinBG;
    public EnemyHealth boss;
    public PlayerHealth playerHealth;
    public float loadTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameOverBG.SetActive(false);
        gamewinBG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.isDead)
        {
            StartCoroutine(LoadGameOver());
            
        }

        if(boss.isDead && !playerHealth.isDead)
        {
            StartCoroutine(LoadGameWin());
            
        }
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(loadTime);
        gameOverBG.SetActive(true);
    }

    IEnumerator LoadGameWin()
    {
        yield return new WaitForSeconds(loadTime);
        gamewinBG.SetActive(true);
    }
}
